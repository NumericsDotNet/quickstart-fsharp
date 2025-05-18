//=====================================================================
//
//  File: discrete-distributions.fs
//
//---------------------------------------------------------------------
//
//  This file is part of the Numerics.NET Code Samples.
//
//  Copyright (c) 2004-2025 ExoAnalytics Inc. All rights reserved.
//
//=====================================================================

module DiscreteDistributions

// Demonstrates how to use classes that implement
// discrete probability distributions.

#light

open System

open Numerics.NET
open Numerics.NET.Statistics
open Numerics.NET.Statistics.Distributions

// The license is verified at runtime. We're using a 30 day trial key here.
// For more information, see:
//     https://numerics.net/trial-key
let licensed = Numerics.NET.License.Verify("your-trial-key-here")

// This QuickStart Sample demonstrates the capabilities of
// the classes that implement discrete probability distributions.
// These classes inherit from the DiscreteDistribution class.
//
// For an illustration of classes that implement discrete probability
// distributions, see the ContinuousDistributions QuickStart Sample.
//
// We illustrate the properties and methods of discrete distribution
// using a binomial distribution. The same properties and methods
// apply to all other discrete distributions.

//
// Constructing distributions
//

// Many discrete probability distributions are related to Bernoulli trials,
// events with a certain probability, p, of success. The number of trials
// is often one of the distribution's parameters.

// The binomial distribution has two constructors. Here, we create a
// binomial distribution for 6 trials with a probability of success of 0.6:
let binomial = BinomialDistribution(6, 0.6)

// The distribution's parameters are available through the
// NumberOfTrials and ProbabilityOfSuccess properties:
printfn "# of trials:          %d" binomial.NumberOfTrials
printfn "Prob. of success:     %.5f" binomial.ProbabilityOfSuccess

//
// Basic statistics
//

// The Mean property returns the mean of the distribution:
printfn "Mean:     %.5f" binomial.Mean

// The Variance and StandardDeviation are also available:
printfn "Variance: %.5f" binomial.Variance
printfn "Standard deviation:   %.5f" binomial.StandardDeviation

// As are the skewness:
printfn "Skewness: %.5f" binomial.Skewness

// The Kurtosis property returns the kurtosis supplement.
// The Kurtosis property for the normal distribution returns zero.
printfn "Kurtosis: %.5f" binomial.Kurtosis
printfn ""

//
// Distribution functions
//

// The (cumulative) distribution function (CDF) is implemented by the
// DistributionFunction method:
printfn "CDF(4) =%.5f" (binomial.DistributionFunction(4))

// The probability density function (PDF) is available as the
// Probability method:
printfn "PDF(4) =%.5f" (binomial.Probability(4))

// The Probability method has an overload that returns the probability
// that a variate lies between two values:
printfn "Probability(3, 5) = %.5f" (binomial.Probability(3, 5))
printfn ""

//
// Random variates
//

// The Sample method returns a single random variate
// using the specified random number generator:
let rng = Random.MersenneTwister()
let x = binomial.Sample(rng)
// The Sample method fills an array or vector with
// random variates. It has several overloads:
let xArray = Array.zeroCreate(100)
// 1. Fill all values:
binomial.Sample(rng, xArray)
// 2. Fill only a range (start index and length are supplied)
binomial.Sample(rng, xArray, 20, 50)

// The GetExpectedHistogram method returns a Histogram that contains the
// expected number of samples in each bin:
let h = binomial.GetExpectedHistogram(100.0)
printfn "Expected distribution of 100 samples:"
for bin in h.BinsAndValues do
    printfn "%A success(es) -> %A" bin.Key bin.Value
printfn ""
