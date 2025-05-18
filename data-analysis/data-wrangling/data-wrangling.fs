//=====================================================================
//
//  File: data-wrangling.fs
//
//---------------------------------------------------------------------
//
//  This file is part of the Numerics.NET Code Samples.
//
//  Copyright (c) 2004-2025 ExoAnalytics Inc. All rights reserved.
//
//=====================================================================

module DataWrangling

// Illustrates how to perform basic data wrangling operations
// on data frames.

#light

open System
open System.Collections.Generic

open Numerics.NET.DataAnalysis
open Numerics.NET

// The license is verified at runtime. We're using a 30 day trial key here.
// For more information, see:
//     https://numerics.net/trial-key
let licensed = Numerics.NET.License.Verify("your-trial-key-here")

// We start by defining a couple of helper functions:
let (=>) a b = (a, box b)
let makeDict x =
    let d = Dictionary<_, obj>()
    Seq.iter (fun kvp -> d.Add(fst kvp, snd kvp)) x
    d

//
// Joining and reshaping
//

// When data comes from different sources,
// the Append method lets you join the two
// data frames:
let frame = DataFrame.FromColumns(makeDict
              [
                "A" => [| "A0"; "A1"; "A2"; "A3"|]
                "B" => [| "B0"; "B1"; "B2"; "B3"|]
                "C" => [| "C0"; "C1"; "C2"; "C3"|]
                "D" => [| "D0"; "D1"; "D2"; "D3"|]
              ],
              Index.Default(0, 3))
let df2 = DataFrame.FromColumns(makeDict
            [
              "A" => [| "A4"; "A5"; "A6"; "A7"|]
              "B" => [| "B4"; "B5"; "B6"; "B7"|]
              "C" => [| "C4"; "C5"; "C6"; "C7"|]
              "D" => [| "D4"; "D5"; "D6"; "D7"|]
            ],
            Index.Default(4, 7))
let df12 = frame.Append(df2)
// It is possible to join more than 2 data frames:
let df3 = DataFrame.FromColumns(makeDict
            [
              "A" => [| "A8"; "A9"; "A10"; "A11"|]
              "B" => [| "B8"; "B9"; "B10"; "B11"|]
              "C" => [| "C8"; "C9"; "C10"; "C11"|]
              "D" => [| "D8"; "D9"; "D10"; "D11"|]
            ], Index.Default(8, 11))
let df123 = DataFrame.Append(frame, df2, df3)

// When the columns don't match, you can specify
// a join operation which determines which columns
// to keep in the result. If a column is missing
// in a data frame and present in the result,
// missing values are inserted.
let df4 = DataFrame.FromColumns(makeDict
              [
                "A" => [| "A0"; "A1"; "A2"; "A3" |]
                "B" => [| "B0"; "B1"; "B2"; "B3" |]
                "C" => [| "C0"; "C1"; "C2"; "C3" |]
              ], Index.Default(0, 3))
let df5 = DataFrame.FromColumns(makeDict
            [
              "A" => [| "A4"; "A5"; "A6"; "A7" |]
              "B" => [| "B4"; "B5"; "B6"; "B7" |]
              "D" => [| "D4"; "D5"; "D6"; "D7" |]
            ], Index.Default(4, 7))
let df12outer = df4.Append(df5, JoinType.Outer)
let df12Inner = df4.Append(df5, JoinType.Inner)
// Left column join is equivalent to using the left column index:
let df12Left = df4.Append(df5, JoinType.Left)
let df12Left2 = df4.Append(df5, frame.ColumnIndex)
// Again, these are equivalent:
let df12Right = df4.Append(df5, JoinType.Right)
let df12Right2 = df4.Append(df5, df2.ColumnIndex)

// One to one joins match rows on their keys:

let df6 =
    let start = new DateTime(2015, 11, 11)
    let dates = Index.CreateDateRange(start, 5, Recurrence.Daily)
    Vector.CreateRandom(5).ToDataFrame(dates, "values1")
let df7 =
    let start = df6.RowIndex[2];
    let dates = Index.CreateDateRange(start, 5, Recurrence.Daily)
    Vector.CreateRandom(5).ToDataFrame(dates, "values2")
let df8 = DataFrame.Join(df6, JoinType.Outer, df7)
printfn "%O" df8

// One to many joins match one data frame's index to another's
// column.
// Create a list of presidents:
let numbers = Index.Create([| 44; 43; 42; 41; 40 |])
let names = Vector.Create("Barack Obama", "George W. Bush", "Bill Clinton",
                "George H.W. Bush", "Ronald Reagan")
let homeStates = Vector.Create("IL", "TX", "AR", "TX", "CA")
let presidents = DataFrame.FromColumns(
                    makeDict [ "Name"=> names ; "Home state" => homeStates ],
                    numbers)
// And a list of states indexed by their abbreviations:
let abbreviations = Index.Create([| "AR"; "CA"; "GA"; "MI"; "IL"; "TX" |])
let stateNames = Vector.Create("Arkansas", "California", "Georgia",
                    "Michigan", "Illinois", "Texas")
let states = DataFrame.FromColumns(
                makeDict ["Full name" => stateNames ], abbreviations)
// Now get the full names of states in the list:
let presidentsWithState = DataFrame.Join<int,string>(presidents,
                            JoinType.Left, states, key="Home state")
printfn "%O" presidentsWithState

// When the indexes are sorted, it is possible
// to do an inexact join to the nearest value.
// This is useful for time series where one series
// if offset by a few hours relative to the other:
let dates9 = Index.CreateDateRange(new DateTime(2015, 11, 11), 5, Recurrence.Daily)
let df9 = Vector.CreateRandom(5).ToDataFrame(dates9, "values1")
let dates10 = Index.CreateDateRange(dates9[0].AddHours(3.0), 5, Recurrence.Daily)
let df10 = Vector.CreateRandom(5).ToDataFrame(dates10, "values2")
let df11 = df9.JoinOnNearest(df10, Direction.Backward)
printfn "%O" df11

//
// Sorting and filtering
//

// Data frames can be sorted by their index or by
// a column. The sort methods always return a new data frame.
let frame2 =
    let dates = Index.CreateDateRange(new DateTime(2015, 11, 11), 15, Recurrence.Daily);
    let length = dates.Length
    let dict = makeDict
                [
                  "values1" => Vector.CreateRandom(length)
                  "values2" => Vector.CreateRandom(length)
                  "values3" => Vector.CreateRandom(length)
                ]
    DataFrame.FromColumns(dict, dates)

let frame3 = frame2.SortByIndex(SortOrder.Descending);
let frame4 = frame2.SortBy("values1", SortOrder.Ascending);
