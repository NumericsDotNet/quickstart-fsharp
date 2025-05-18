//=====================================================================
//
//  File: variance-tests.fs
//
//---------------------------------------------------------------------
//
//  This file is part of the Numerics.NET Code Samples.
//
//  Copyright (c) 2004-2025 ExoAnalytics Inc. All rights reserved.
//
//=====================================================================

module VarianceTests

#light

open System

open Numerics.NET
open Numerics.NET.Statistics
open Numerics.NET.Statistics.Tests

// The license is verified at runtime. We're using a 30 day trial key here.
// For more information, see:
//     https://numerics.net/trial-key
let licensed = Numerics.NET.License.Verify("your-trial-key-here")

// Demonstrates how to use hypothesis tests for the variance
// of one or two distributions.
// </summary>

// This QuickStart Sample uses the scores obtained by the students
// in two groups of students on a national test.
//
// We want to know if the variance of the scores is greater than
// a specific value. We use the one sample Chi-square test for this
// purpose.

printfn "Tests for class 1"

// First we create a NumericalVariable that holds the test results.
let group1Results =
  Vector.Create(
    [|
        62.0; 77.0; 61.0; 94.0; 75.0; 82.0; 86.0; 83.0; 64.0; 84.0;
        68.0; 82.0; 72.0; 71.0; 85.0; 66.0; 61.0; 79.0; 81.0; 73.0
    |])

// We can get the mean and standard deviation of the class right away:
printfn "Mean for the class: %.1f" (group1Results.Mean())
printfn "Standard deviation: %.1f" (group1Results.StandardDeviation())

//
// One Sample Chi-square Test
//

printfn "\nUsing chi-square test:"

// We want to know if the standard deviation is larger than 15.
// Therefore, we use a one-tailed chi-square test:
let chiSquareTest = OneSampleChiSquareTest(group1Results, 225.0, HypothesisType.OneTailedUpper)

// We can obtan the value of the test statistic through the Statistic property,
// and the corresponding P-value through the Probability property:
printfn "Test statistic: %.4f" chiSquareTest.Statistic
printfn "P-value:        %.4f" chiSquareTest.PValue

// The significance level is the default value of 0.05:
printfn "Significance level:     %.2f" chiSquareTest.SignificanceLevel
// We can now print the test results:
printfn "Reject null hypothesis? %s" (if chiSquareTest.Reject() then "yes" else "no")
// We can get a confidence interval for the current significance level:
let varianceInterval = chiSquareTest.GetConfidenceInterval()
printfn "95%% Confidence interval for the variance: %.1f - %1f"
    varianceInterval.LowerBound varianceInterval.UpperBound

// We can get the same results for the 0.01 significance level by explicitly
// passing the significance level as a parameter to these methods:
printfn "Significance level:     %.2f" 0.01
printfn "Reject null hypothesis? %s" (if chiSquareTest.Reject(0.01) then "yes" else "no")

// The GetConfidenceInterval method needs the confidence level, which equals
// 1 - the significance level:
let varianceInterval2 = chiSquareTest.GetConfidenceInterval(0.99)
printfn "99%% Confidence interval for the variance: %.1f - %.1f"
    varianceInterval2.LowerBound varianceInterval2.UpperBound

//
// Two sample F-test
//

printfn "\nUsing F-test:"
// We want to compare the scores of the first group to the scores
// of a second group from another school. We want to verify that the
// variances of the scores from the two schools are equal. Once again,
// we start by creating a NumericalVariable, this time containing
// the scores for the second group:
let group2Results =
  Vector.Create(
    [|
        61.0; 80.0; 98.0; 90.0; 94.0; 65.0; 79.0; 75.0; 74.0; 86.0;
        76.0; 85.0; 78.0; 72.0; 76.0; 79.0; 65.0; 92.0; 76.0; 80.0
    |])

// To compare the variances of the two groups, we need the two sample
// F test, implemented by the FTest class:
let fTest = FTest(group1Results, group2Results)
// We can obtan the value of the test statistic through the Statistic property,
// and the corresponding P-value through the Probability property:
printfn "Test statistic: %.4f" fTest.Statistic
printfn "P-value:        %.4f" fTest.PValue

// The significance level is the default value of 0.05:
printfn "Significance level:     %.2f" fTest.SignificanceLevel
// We can now print the test results:
printfn "Reject null hypothesis? %s" (if fTest.Reject() then "yes" else "no")
