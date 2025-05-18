//=====================================================================
//
//  File: data-frames.fs
//
//---------------------------------------------------------------------
//
//  This file is part of the Numerics.NET Code Samples.
//
//  Copyright (c) 2004-2025 ExoAnalytics Inc. All rights reserved.
//
//=====================================================================

module DataFrames

// Illustrates how to create and manipulate data frames.

#light

open System
open System.Collections.Generic

open Numerics.NET.DataAnalysis
open Numerics.NET
open Numerics.NET.Data.Text

// The license is verified at runtime. We're using a 30 day trial key here.
// For more information, see:
//     https://numerics.net/trial-key
let licensed = Numerics.NET.License.Verify("your-trial-key-here")

// Data frames are similar to the objects of the same name
// in R and the popular Pandas library for Python.

// Data frames can be constructed in a variety of ways.
// This example will use mostly static methods of the
// static DataFrame class.

// We start by defining a couple of helper functions:
let (=>) a b = (a, box b)
let makeDict x =
    let d = Dictionary<_, obj>()
    Seq.iter (fun kvp -> d.Add(fst kvp, snd kvp)) x
    d

// One way to create a data frame is from a dictionary of column keys
// that map to collections. Using the functions we just defined:
let data = makeDict [
            "state" => [| "Ohio"; "Ohio"; "Ohio"; "Nevada"; "Nevada" |]
            "year" => [| 2000; 2001; 2002; 2001; 2002 |]
            "pop" => [| 1.5; 1.7; 3.6; 2.4; 2.9 |] ]

let df1 = DataFrame.FromColumns<string>(data)
printfn "%O" df1

// The data frame has a default index of row numbers.
// A row index can be specified as well:
let df2 = DataFrame.FromColumns(makeDict
            [
                "first" => [| 11.0; 14.0; 17.0; 93.0; 55.0 |];
                "second" => [| 22.0; 33.0; 43.0; 51.0; 69.0 |]
            ],
            Index.CreateDateRange(new DateTime(2015, 4, 1), 5))
printfn "%O" df2

// Alternatively, the columns can be a list of collections.
let rowIndex = Index.Create([| "one"; "two"; "three"; "four"; "five" |])
let df3 = DataFrame.FromColumns(data, rowIndex)
printfn "%O" df3
// If you supply a column index, only the columns with
// keys in the index will be retained:
let columnIndex = Index.Create([| "pop"; "year" |])
let df4 = DataFrame.FromColumns(data, rowIndex, columnIndex)
printfn "%O" df4

// Yet another way is to use tuples:
let df5 = DataFrame.FromColumns(
            struct ("state", box [| "Ohio"; "Ohio"; "Ohio"; "Nevada"; "Nevada" |]),
            struct ("year", box [| 2000; 2001; 2002; 2001; 2002 |]),
            struct ("pop", box [| 1.5; 1.7; 3.6; 2.4; 2.9 |]))
printfn "%O" df5

// Data frames can be created from a sequence of objects.
// By default, all public properties are included as columns
// in the resulting data frame:
type Point = { X : float; Y : float; Z : float }
let points = [|
        { X = 1.0; Y = 5.0; Z = 9.0 };
        { X = 2.0; Y = 6.0; Z = 10.0 };
        { X = 3.0; Y = 7.0; Z = 11.0 };
        { X = 4.0; Y = 8.0; Z = 12.0 }
    |]
let df6 = DataFrame.FromObjects(points)
printfn "%O" df6
// It is possible to select the properties:
let df7 = DataFrame.FromObjects<Point>(points, [| "Z"; "X" |])
printfn "%O" df7

// Vectors and matrices can be converted to data frames
// using their ToDataFrame method:
let m = Matrix.CreateRandom(10, 2)
let df8 = m.ToDataFrame(Index.Default(10), Index.Create([| "A"; "B" |]))
printfn "%O" df8

let v = Vector.CreateRandom(3)
let df9 = v.ToDataFrame(Index.Create([| "a"; "b"; "c" |]), "values")
printfn "%O" df9

//
// Import / export
//

// Several methods exist for importing data frames directly
// from data sources like text files, R data files, and databases.
let dt = new System.Data.DataTable()
dt.Columns.Add("x1", typeof<float>) |> ignore
dt.Columns.Add("x2", typeof<float>) |> ignore
dt.Rows.Add(1.0, 2.0) |> ignore
dt.Rows.Add(3.0, 4.0) |> ignore
dt.Rows.Add(5.0, 6.0) |> ignore
let df11 = DataFrame.FromDataTable(dt)
printfn "%O" df11

let df12 = DelimitedTextFile.ReadDataFrame(@"..\..\..\..\data\iris.csv",
    DelimitedTextOptions.CsvWithoutHeader);
printfn "%O" (df12.Head())

// By default, these methods return a data frame with a default
// index (row numbers). You can specify the column(s) to use
// for the index, and the data frame will use that column.
let df13 = DelimitedTextFile.ReadDataFrame<int>(@"..\..\..\..\data\titanic.csv",
    "PassengerId", options=DelimitedTextOptions.Csv);
printfn "%O" (df13.Tail())

DelimitedTextFile.Write("irisCopy.csv", df12, DelimitedTextOptions.Csv);

//
// Setting row and column indexes
//

// You can use specific columns as the row index.
// Here we have a 2 level hierarchical index:
let df1a = df1.WithRowIndex<string, int>("state", "year")

/// Column indexes can be changed as well:
let df2b = df2.WithColumnIndex([| "A"; "B"|])
