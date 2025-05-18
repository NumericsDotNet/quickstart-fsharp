//=====================================================================
//
//  File: histograms.fs
//
//---------------------------------------------------------------------
//
//  This file is part of the Numerics.NET Code Samples.
//
//  Copyright (c) 2004-2025 ExoAnalytics Inc. All rights reserved.
//
//=====================================================================

module Histograms

// Illustrates the use of the Histogram class.

#light

open System

open Numerics.NET
open Numerics.NET.DataAnalysis

// The license is verified at runtime. We're using a 30 day trial key here.
// For more information, see:
//     https://numerics.net/trial-key
let licensed = Numerics.NET.License.Verify("your-trial-key-here")

// Histograms are used to summarize the distribution of data.
// This QuickStart sample creates a histogram from data
// in a variety of ways.

// We use the test scores of students on a hypothetical national test.
// First we create a NumericalVariable that holds the test scores.
let group1Results = Vector.Create(62, 77, 61, 94,
                        75, 82, 86, 83, 64, 84, 68, 82,
                        72, 71, 85, 66, 61, 79, 81, 73)

// We can create a histogram with evenly spaced bins
// by specifying the lower bound, the upper bound,
// and the number of bins:
let histogram1 = Histogram.CreateEmpty(50, 100, 5)

// We can also provide the bounds explicitly:
let bounds = [| 50; 62; 74; 88; 100 |]
let histogram2 = Histogram.CreateEmpty(bounds)

// Or we can first create an Index object
let index = Index.CreateBins(bounds)
let histogram3 = Histogram.CreateEmpty(index)

// To tally the results, we simply call the Tabulate method.
// The data can be supplied as a vector:
histogram1.Tabulate(group1Results)
// or simply as any enumerable, including an array:
histogram2.Tabulate(group1Results.ToArray())

// You can add multiple data sets to the same histogram:
histogram2.Tabulate([| 74; 68; 89 |])
// Or you can add individual data points using the Increment method.
// This will increment the count of the bin that contains
// the specified value:
histogram2.Increment(83)
histogram2.Increment(78)

// Histograms are just vectors, so the SetToZero method
// clears all the data:
histogram2.SetToZero() |> ignore

// The Bins property returns an index of bins:
let bins = histogram1.Bins
// The Length property returns the total number of bins:
printfn "# bins: %d" bins.Length

// For binned histograms, the bins are of type Interval<T>:
let bin = bins[2]
// Interval structures have a lower bound, an upper bound:
printfn "Bin 2 has lower bound %d." bin.LowerBound
printfn "Bin 2 has upper bound %d." bin.UpperBound
// You can get the value at a specific bin using the Get method:
printfn "Bin 2 has value %f." (histogram1.Get(bin))

// The histogram's FindBin method returns the Histogram bin
// that contains a specified value:
let bin2 = histogram1.FindBin(83)
printfn "83 is in bin %A" bin2

// You can use the BinsAndValues property to iterate through all the bins
// in a for-each loop:
for pair in histogram1.BinsAndValues do
    printfn "Bin %A: %f" pair.Key pair.Value

// You can also create histograms for categorical data:
let success = Vector.CreateCategorical([| true; false; true; true; false |])
let histogram4 = success.CreateHistogram()
// Bins for categorical histograms are just the categories:
let successes = histogram4.Get(true)
Console.WriteLine(successes)
