//=====================================================================
//
//  File: grouping-and-aggregation.fs
//
//---------------------------------------------------------------------
//
//  This file is part of the Numerics.NET Code Samples.
//
//  Copyright (c) 2004-2025 ExoAnalytics Inc. All rights reserved.
//
//=====================================================================

module GroupingAndAggregation

// Illustrates how to group data and how to compute aggregates
// over groups and entire datasets.

#light

open System

open Numerics.NET.DataAnalysis
open Numerics.NET
open Numerics.NET.Data.Text

// The license is verified at runtime. We're using a 30 day trial key here.
// For more information, see:
//     https://numerics.net/trial-key
let licensed = Numerics.NET.License.Verify("your-trial-key-here")

// We work with the Titanic dataset
let titanic = DelimitedTextFile.ReadDataFrame(@"..\..\..\..\data\titanic.csv")
// We'll use these columns often:
let age = titanic.GetColumn("Age")
let survived = titanic.["Survived"].As<bool>()
// We want to group by the passenger class,
// so we make this a categorical vector.
let pclass = titanic.["Pclass"].AsCategorical()

//
// Aggregators and Aggregation
//

// The Aggregators class defines all common aggregator functions.
// Here we compute the mean and do the computations using the float
// (System.Double) type. The Aggregate method applies the aggregator
// to every column in the data frame:
let means = titanic.Aggregate(Aggregators.Mean.As<float>())
printfn "%O" (means.Summarize())

// We can create custom aggregators. Here we compute
// the fraction of true values of a boolean vector:
let trueFraction = Aggregators.Create(
                    fun (b:Vector<bool>) -> float (b.CountTrue()) / float b.Count)
let pctSurvived = survived.Aggregate(trueFraction)

// We can also compute more than one aggregate:
let descriptives = titanic.Aggregate(
                    Aggregators.Count,
                    Aggregators.Mean.As<float>(),
                    Aggregators.StandardDeviation.As<float>())
printfn "%O" (descriptives.Summarize())

// Aggregations can be applied to individual vectors:
let meanAge = age.Aggregate(Aggregators.Mean)

// Or to rows or columns of a matrix:
let m = Matrix.CreateRandom(5, 8)
let meanByRow = m.AggregateRows(Aggregators.Mean)
let meanByColumn = m.AggregateColumns(Aggregators.Mean)

//
// Groupings
//

// By defining a grouping, we can compute the aggregate
// for each group.

// The simplest grouping is by value, similar to
// GROUP BY clauses in database queries.

// Let's get the average age by class:
let ageByClass = age.AggregateBy(pclass, Aggregators.Mean)

// Grouping by quantile means we sort the values
// and divide the result into groups of the same size.
let byQuantile = Grouping.ByQuantile(age, 5)
let survivedByAgeGroup = survived.AggregateBy(byQuantile, trueFraction)
printfn "Survival rate by age group:"
printfn "%O" (survivedByAgeGroup.Summarize())

// For the remainder we will use a vector with a DateTime index:
let x = Vector.CreateRandom(200)
let dates = Index.CreateDateRange(new DateTime(2016, 1, 1), x.Length)
x.Index <- dates

// A partition is a straight division of the data into equal groups:
let partition = Grouping.Partition(dates, 10,
                    alignToEnd=true, skipIncomplete=true)
let partitionAvg = x.AggregateBy(partition, Aggregators.Mean)
printfn "Avg. by partition:"
printfn "%O" partitionAvg

//
// Moving and expanding windows
//

// Moving or rolling averages and related statistics
// can be computed efficiently by using moving windows:
let window = Grouping.Window(dates, 20)
let ma20 = x.AggregateBy(window, Aggregators.Mean)
printfn "ma20:"
printfn "%O" (ma20.GetSlice(0, 20))
// Moving standard deviation is just as simple:
let mstd20 = x.AggregateBy(window, Aggregators.StandardDeviation)
printfn "mstd20:"
printfn "%O" (mstd20.GetSlice(0, 20))

// Moving windows can have a fixed number of elements, as above,
// or a fixed maximum width:
let window2 = Grouping.RangeWindow(dates, TimeSpan.FromDays(20.0))
let ma20_2= x.AggregateBy(window2, Aggregators.Mean)

// Expanding windows keep the starting point and move the end point
// forward in time:
let expanding = Grouping.ExpandingWindow(dates)
let expAvg = x.AggregateBy(expanding, Aggregators.Mean)
printfn "expAvg:"
printfn "%O" (expAvg.GetSlice(0, 10))

//
// Resampling
//

// Resampling means computing values for a series
// with longer periods by aggregating over the values
// for shorter periods.

// We start by creating an index with the boundaries,
// in this case the 10th of each month.
let months = Index.CreateDateRange(new DateTime(2016, 1, 10),
                12, Recurrence.Monthly)
// We then create the resampling grouping from this:
// Giving the Direction argument as Backward means that
// the last value in the time period is used as the key
// for the group.
let resampling1 = Grouping.Resample(dates, months, Direction.Backward)
// We can also obtain this grouping in one step:
let resampling2 = Grouping.Resample(dates,
                    Recurrence.Monthly.Day(10), Direction.Backward)
let resampled = x.AggregateBy(resampling2, Aggregators.Mean)

//
// Pivot tables
//

// A pivot table is a 2-dimensional grouping on two key columns.
// For this, we go back to the Titanic dataset, and we compute
// the survival rate per class in a different way. We group
// by class and by whether the passenger survived:
let pivot = Grouping.Pivot(
                titanic.["Pclass"].As<int>(),
                titanic.["Survived"].As<bool>())
// We can then get the # of elements in each group
// as a matrix, with rows indexed by class and columns
// indexed by survived:
let counts = pivot.CountsMatrix()
// Scaling by the row sums gives us the fraction
// of survived/did not survive for each class:
let fractions = counts.UnscaleRowsInPlace(counts.GetRowSums())
printfn "%O" (fractions.Summarize())
