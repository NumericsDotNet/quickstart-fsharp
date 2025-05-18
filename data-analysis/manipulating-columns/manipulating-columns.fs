//=====================================================================
//
//  File: manipulating-columns.fs
//
//---------------------------------------------------------------------
//
//  This file is part of the Numerics.NET Code Samples.
//
//  Copyright (c) 2004-2025 ExoAnalytics Inc. All rights reserved.
//
//=====================================================================

module ManipulatingColumns

#light

open System
open System.Collections.Generic

open Numerics.NET.DataAnalysis
open Numerics.NET

// The license is verified at runtime. We're using a 30 day trial key here.
// For more information, see:
//     https://numerics.net/trial-key
let licensed = Numerics.NET.License.Verify("your-trial-key-here")

// Illustrates how to transform and manipulate the columns
// of a data frame.

// We start by defining a couple of helper functions:
let (=>) a b = (a, box b)
let makeDict x =
    let d = Dictionary<_, obj>()
    Seq.iter (fun kvp -> d.Add(fst kvp, snd kvp)) x
    d

// Now let's define a data frame with a DateTime index:
let rowCount = 1000
let dates = Index.CreateDateRange(DateTime(2016, 01, 17), rowCount, Recurrence.Daily)
let frame = DataFrame.FromColumns(makeDict
              [
                "values1" => Vector.CreateRandom(rowCount)
                "values2" => Vector.CreateRandom(rowCount)
              ], dates)
printfn "%O" (frame.Head())

// The columns of a data frame are immutable,
// but the collection of columns is not.

// We can add columns:
frame.AddColumn("vzlues3", Vector.CreateRandom(rowCount)) |> ignore
frame.AddColumn("values4", Vector.CreateRandom(rowCount)) |> ignore
frame.AddColumn("values6", Vector.CreateRandom(rowCount)) |> ignore
printfn "%O" (frame.Head())
// Rename columns:
frame.RenameColumn("values4", "vzlues5") |> ignore
frame.RenameColumns((fun s -> s.StartsWith("vzlues")), fun s -> "values" + s.Substring(6)) |> ignore
printfn "%O" (frame.Head())
// And remove columns:
frame.RemoveColumn("values5") |> ignore
frame.RemoveColumnAt(2) |> ignore
printfn "%O" (frame.Head())

// You can transform a column and add the result
// in various places:
// As the last column:
frame.MapAndAppend<float>("values1", (fun x -> Vector.Cos(x) :> IVector), "cosValues1") |> ignore
// After a specific column:
frame.MapAndInsertAfter<float>("values1", (fun x -> Vector.Sin(x) :> IVector), "sinValues1") |> ignore
// Replacing the column
frame.MapAndReplace<float>("values6", (fun x -> Vector.Exp(x) :> IVector), "expValues6") |> ignore
printfn "%O" (frame.Head())

// The same operations can be performed on multiple columns
// at once:
let columns = [| "values1"; "values2" |]
// We can supply the keys for the new columns explicitly:
let negColumns = [| "-values1"; "-values2" |]
frame.MapAndAppend<float>(columns, (fun x -> (-x) :> IVector), negColumns) |> ignore
// or as a function of the original key:
frame.MapAndInsertAfter(columns,
    (fun (x:Vector<float>) -> (2.0 * x) :> IVector),
    (fun s -> "2*" + s)) |> ignore
printfn "%O" (frame.Head())

// A more complex example: replace missing values
// with the mean of a group.

// We create a categorical variable with 5 categories
// so we will have 5 group means.
let group = frame.GetColumn("values1").Bin(5)
// and a variable that has some missing values:
let withNAs = frame.GetColumn("values2").Clone().SetValues(nan, fun x -> x < 0.1)
printfn "%O" (withNAs.GetSlice(0, 12))

// Now for the actual calculation, which has 3 steps:
// First, we compute the means for each group:
let meansPerGroup = withNAs.AggregateBy(group, Aggregators.Mean)
printfn "%O" meansPerGroup

// Next, create a vector with the means of the group
// that each element belongs to:
let means = group.WithCategories(meansPerGroup)
printfn "%O" (means.GetSlice(0, 12))

// Next, we replace the missing values with the corresponding
// elements from that vector.
let withNAsReplaced = withNAs.ReplaceMissingValues(means)
printfn "%O" (withNAsReplaced.GetSlice(0, 12))

//
// Row-based operations
//

// Data frames are column-based data structures.
// Even though it is not recommended, it is possible
// to perform operations on rows:

frame.AddColumn("values3", Vector.CreateRandom(rowCount)) |> ignore
let avg1 = Vector.Create<float>(frame.RowCount)
let mutable i = 0
for row in frame.Rows do
    avg1[i] <- (row.Get<float>("values1")
            + row.Get<float>("values2")
            + row.Get<float>("values3")) / 3.0
    i <- i + 1
frame.AddColumn("Average", avg1) |> ignore

// Performing the operation directly on the columns
// is much more efficient:
let avg2 = (frame.GetColumn("values1")
            + frame.GetColumn("values2")
            + frame.GetColumn("values3")) / 3.0
frame.AddColumn("Average2", avg2) |> ignore
