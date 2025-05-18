//=====================================================================
//
//  File: simple-time-series.fs
//
//---------------------------------------------------------------------
//
//  This file is part of the Numerics.NET Code Samples.
//
//  Copyright (c) 2004-2025 ExoAnalytics Inc. All rights reserved.
//
//=====================================================================

module SimpleTimeSeries

// Illustrates the use of the TimeSeriesCollection class to represent
// and manipulate time series data.

#light

open System

open System
open System.Collections.Generic

open Numerics.NET.Data.Text
open Numerics.NET.DataAnalysis
open Numerics.NET
open Numerics.NET.Statistics

// The license is verified at runtime. We're using a 30 day trial key here.
// For more information, see:
//     https://numerics.net/trial-key
let licensed = Numerics.NET.License.Verify("your-trial-key-here")

// Time series data frames can be created in a variety of ways.
// Here we read from a CSV file and specify the column to use as the index:
let timeSeries = DelimitedTextFile.ReadDataFrame<DateTime>(
                    "..\..\..\..\..\Data\MicrosoftStock.csv", "Date")

// The RowCount property returns the number of
// observations:
printfn "# observations: %d" timeSeries.RowCount

//
// Accessing variables
//

// Variables are accessed by name or numeric index.
// They need to be cast to the appropriate specialized
// type using the As() method:
let close = timeSeries.["Close"].As<double>()
Console.WriteLine($"Average close price: ${close.Mean():F2}")

// Variables can also be accessed by numeric index:
printfn "3rd variable: %A" timeSeries.[2].Name

// The GetRows method returns the data from the specified range.
let y2004 = DateTime(2004, 1, 1)
let y2005 = DateTime(2005, 1, 1)
let series2004 = timeSeries.GetRows(y2004, y2005)
Console.WriteLine("Opening price on the first trading day of 2004: {0}",
    series2004.["Open"].GetValue(0))

//
// Transforming the Frequency
//

// The first step is to define the aggregator function
// for each variable. This function specifies how each
// observation in the new time series is calculated
// from the observations in the original series.

// The Aggregators class has a number of
// pre-defined aggregator functions.

// We create a dictionary that maps column names
// to aggregators:
let aggregators =
    let d = Dictionary<string, AggregatorGroup>()
    d.Add("Open", Aggregators.First)
    d.Add("Close", Aggregators.Last)
    d.Add("High", Aggregators.Max)
    d.Add("Low", Aggregators.Min)
    d.Add("Volume", Aggregators.Sum)
    d

// We can then resample the data frame in accordance with
// a recurrence pattern we specify, in this case monthly:
let monthlySeries = timeSeries.Resample(Recurrence.Monthly, aggregators)

// We can specify a subset of the series by selecting it
// from the data frame first:
let monthlySeries2 = timeSeries.GetRows(y2004, y2005).Resample(Recurrence.Monthly, aggregators)

// We can now print the results:
Console.WriteLine("Monthly statistics for Microsoft Corp. (MSFT)")
Console.WriteLine(monthlySeries.ToString())
