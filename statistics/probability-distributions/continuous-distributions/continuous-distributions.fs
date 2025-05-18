//=====================================================================
//
//  File: continuous-distributions.fs
//
//---------------------------------------------------------------------
//
//  This file is part of the Numerics.NET Code Samples.
//
//  Copyright (c) 2004-2025 ExoAnalytics Inc. All rights reserved.
//
//=====================================================================

module ContinuousDistributions

// Demonstrates how to use classes that implement
// continuous probability distributions.

#light

open System

open Numerics.NET.Random
open Numerics.NET.Statistics
open Numerics.NET.Statistics.Distributions

// The license is verified at runtime. We're using a 30 day trial key here.
// For more information, see:
//     https://numerics.net/trial-key
let licensed = Numerics.NET.License.Verify("your-trial-key-here")

// This QuickStart Sample demonstrates the capabilities of
// the classes that implement continuous probability distributions.
// These classes inherit from the ContinuousDistribution class.
//
// For an illustration of classes that implement discrete probability
// distributions, see the DiscreteDistributions QuickStart Sample.
//
// We illustrate the properties and methods of continuous distribution
// using a Weibull distribution. The same properties and methods
// apply to all other continuous distributions.

//
// Constructing distributions
//

// Most distributions have one or more parameters with different definitions.
//
// The location parameter is always related to the mean of the distribution.
// When omitted, its default value is zero.
//
// The scale parameter is always directly related to the standard deviation.
// A larger scale parameter means that the distribution is wider.
// When omitted, its default value is one.

// The Weibull distribution has three constructors. The most complete
// constructor takes a location, scale, and shape parameter.
let weibull = WeibullDistribution(3.0, 2.0, 3.0)

//
// Basic statistics
//

// The Mean property returns the mean of the distribution:
printfn "Mean:     %.5f" weibull.Mean

// The Variance and StandardDeviation are also available:
printfn "Variance: %.5f" weibull.Variance
printfn "Standard deviation:   %.5f" weibull.StandardDeviation
// The inter-quartile range is another measure of scale:
printfn "Inter-quartile range: %.5f" weibull.InterQuartileRange

// As are the skewness:
printfn "Skewness: %.5f" weibull.Skewness

// The Kurtosis property returns the kurtosis supplement.
// The Kurtosis property for the normal distribution returns zero.
printfn "Kurtosis: %.5f" weibull.Kurtosis
printfn ""

//
// Distribution functions
//

// The (cumulative) distribution function (CDF) is implemented by the
// DistributionFunction method:
printfn "CDF(4.5) =%.5f" (weibull.DistributionFunction(4.5))

// Its complement is the survivor function:
printfn "SDF(4.5) =%.5f" (weibull.SurvivorDistributionFunction(4.5))

// While its inverse is given by the InverseDistributionFunction method:
printfn "Inverse CDF(0.4) =    %.5f" (weibull.InverseDistributionFunction(0.4))

// The probability density function (PDF) is also available:
printfn "PDF(4.5) =%.5f" (weibull.ProbabilityDensityFunction(4.5))

// The Probability method returns the probability that a variate lies between two values:
printfn "Probability(4.5, 5.5) = %.5f" (weibull.Probability(4.5, 5.5))
printfn ""

//
// Random variates
//

// The Sample method returns a single random variate
// using the specified random number generator:
let rng = MersenneTwister()
let x = weibull.Sample(rng)
// The Sample method fills an array or vector with
// random variates. It has several overloads:
let xArray = Array.zeroCreate(100)
// 1. Fill all values:
weibull.SampleInto(rng, xArray)
// 2. Fill only a range (start index and length are supplied)
weibull.SampleInto(rng, xArray, 20, 50)
// The same two options are available with a DenseVector
// instead of a double array.

// The GetExpectedHistogram method returns a Histogram that contains the
// expected number of samples in each bin, given the total number of samples.
// The bins are specified by lower and upper bounds and number of bins:
let h = weibull.GetExpectedHistogram(3.0, 10.0, 5, 100.0)
printfn "Expected distribution of 100 samples:"
for kvp in h.BinsAndValues do
    let bin = kvp.Key
    printfn "Between %A and %A -> %A" bin.LowerBound bin.UpperBound kvp.Value
printfn ""

// or by supplying an array of boundaries:
let h2 = weibull.GetExpectedHistogram([|3.0; 5.2; 7.4; 9.6; 11.8|], 100.0)
printfn "Expected distribution of 100 samples:"
for kvp in h2.BinsAndValues do
    let bin = kvp.Key
    printfn "Between %A and %A -> %A" bin.LowerBound bin.UpperBound kvp.Value
