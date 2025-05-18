//=====================================================================
//
//  File: sorting-and-filtering.fs
//
//---------------------------------------------------------------------
//
//  This file is part of the Numerics.NET Code Samples.
//
//  Copyright (c) 2004-2025 ExoAnalytics Inc. All rights reserved.
//
//=====================================================================

module SortingAndFiltering

#light

open System

open Numerics.NET.Data.Text
open Numerics.NET.DataAnalysis
open Numerics.NET
open Numerics.NET.Statistics

// The license is verified at runtime. We're using a 30 day trial key here.
// For more information, see:
//     https://numerics.net/trial-key
let licensed = Numerics.NET.License.Verify("your-trial-key-here")

// Illustrates sorting and filtering of data sets and variables.

// Time series data frames can be created in a variety of ways.
// Here we read from a CSV file and specify the column to use as the index:
let timeSeries = DelimitedTextFile.ReadDataFrame<DateTime>(
                    "..\..\..\..\Data\MicrosoftStock.csv", "Date")
let date = timeSeries.RowIndex

// The following are all equivalent ways of getting
// a strongly typed vector from a data frame:
let ``open`` = timeSeries["Open"].As<double>()
let close = timeSeries.GetColumn("Close")
let high = timeSeries.GetColumn<double>("High")
let low = timeSeries["Low"] :?> Vector<double>

let volume = timeSeries["Volume"].As<double>()

// Let's print some basic statistics for the full data set:
printfn "Total # observations: %d" timeSeries.RowCount
printfn "Average volume: %.0f" (volume.Mean())
printfn "Total volume: %.0f" (volume.Sum())

//
// Filtering
//

// Use the GetRows method to select subsets of rows.

// You can use a sequence of keys:
let subset = timeSeries.GetRows(
                [| new DateTime(2000,3,1); new DateTime(2000,3,2) |])

// When the index is sorted, you can use a range:
let subset2 = timeSeries.GetRows(DateTime(2000, 1, 1), DateTime(2010, 1, 1))

// Another option is to use a boolean mask. Here we select
// observations where the close price was greater
// than the open price:
let filter = Vector.GreaterThan(close, ``open``)
// Then we can use the GetRows method:
let subset3 = timeSeries.GetRows(filter)
// Data is now filtered:
printfn "Filtered # observations: %d" subset3.RowCount

// Masks can be combined using logical operations:
let volumeFilter = volume.Map(fun x -> 200e+6 <= x && x < 300e+6)
printfn "Volume filtered #: %d" (volumeFilter.CountTrue())
let intersection = Vector.And(volumeFilter, filter)
let union = Vector.Or(volumeFilter, filter)
let negation = Vector.Not(filter)

printfn "Combined filtered #: %d" (intersection.CountTrue())
let subset4 = timeSeries.GetRows(intersection)

// When the row index is ordered, it is possible
// to get the rows with the key nearest to the
// supplied keys:
let startDate = new DateTime(2001, 1, 1, 3, 0, 0)
let offsetDates = Index.CreateDateRange(startDate,
                    100, Recurrence.Daily)
let subset5 = timeSeries.GetNearestRows(offsetDates, Direction.Forward)

//
// Sorting
//

// The simplest way to sort data is calling the Sort method
// with the name of the variable to sort on:
let sortedSeries = timeSeries.SortBy("High", SortOrder.Descending)
let highSorted = sortedSeries.GetColumn("High")[new Range(0, 4)]
printfn "Largest 'High' values:"
printfn "%s" (highSorted.ToString("F2"))

// If you just want the largest few items in a series,
// you can use the Top or Bottom method:
printfn "%s" (high.Top(5).ToString("F2"))
