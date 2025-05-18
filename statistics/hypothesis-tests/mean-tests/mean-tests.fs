//=====================================================================
//
//  File: mean-tests.fs
//
//---------------------------------------------------------------------
//
//  This file is part of the Numerics.NET Code Samples.
//
//  Copyright (c) 2004-2025 ExoAnalytics Inc. All rights reserved.
//
//=====================================================================

module MeanTests

// Demonstrates how to use hypothesis tests for the mean
// of one or two distributions.

#light

open System

open Numerics.NET
open Numerics.NET.Statistics
open Numerics.NET.Statistics.Tests

// The license is verified at runtime. We're using a 30 day trial key here.
// For more information, see:
//     https://numerics.net/trial-key
let licensed = Numerics.NET.License.Verify("your-trial-key-here")

// This QuickStart Sample uses the scores obtained by the students
// in two groups of students on a national test.
//
// We want to know if the scores for these two groups of students
// are significantly different from the national average.0; and
// from each other.

// The mean and standard deviation of the complete population:
let nationalMean = 79.3
let nationalStandardDeviation = 7.3

printfn "Tests for group 1"

    // First we create a NumericalVariable that holds the test scores.
let group1Results = Vector.Create(
                        [|
                            62.0; 77.0; 61.0; 94.0; 75.0;
                            82.0; 86.0; 83.0; 64.0; 84.0;
                            68.0; 82.0; 72.0; 71.0; 85.0;
                            66.0; 61.0; 79.0; 81.0; 73.0
                        |])

// We can get the mean and standard deviation of the group right away:
printfn "Mean for the group: %.1f" (group1Results.Mean())
printfn "Standard deviation: %.1f" (group1Results.StandardDeviation())

//
// One Sample z-test
//

printfn "\nUsing z-test:"
// We know the population standard deviation.0; so we can use the z-test.0;
// implemented by the OneSampleZTest group. We pass the sample variable
// and the population parameters to the constructor.
let zTest = OneSampleZTest(group1Results, nationalMean, nationalStandardDeviation)
// We can obtan the value of the test statistic through the Statistic property.0;
// and the corresponding P-value through the Probability property:
printfn "Test statistic: %.4f" zTest.Statistic
printfn "P-value:        %.4f" zTest.PValue

// The significance level is the default value of 0.05:
printfn "Significance level:     %.2f" zTest.SignificanceLevel
// We can now print the test scores:
printfn "Reject null hypothesis? %s" (if zTest.Reject() then "yes" else "no")
// We can get a confidence interval for the current significance level:
let meanInterval = zTest.GetConfidenceInterval()
printfn "95%% Confidence interval for the mean: %.1f - %.1f"
    meanInterval.LowerBound meanInterval.UpperBound

// We can get the same scores for the 0.01 significance level by explicitly
// passing the significance level as a parameter to these methods:
printfn "Significance level:     %.2f" 0.01
printfn "Reject null hypothesis? %s" (if zTest.Reject(0.01) then "yes" else "no")
// The GetConfidenceInterval method needs the confidence level.0; which equals
// 1 - the significance level:
let meanInterval2 = zTest.GetConfidenceInterval(0.99)
printfn "99%% Confidence interval for the mean: %.1f - %.1f"
    meanInterval2.LowerBound meanInterval2.UpperBound

//
// One sample t-test
//

printfn "\nUsing t-test:"
// Suppose we only know the mean of the national scores.0;
// not the standard deviation. In this case.0; a t-test is
// the appropriate test to use.
let tTest = OneSampleTTest(group1Results, nationalMean)
// We can obtan the value of the test statistic through the Statistic property.0;
// and the corresponding P-value through the Probability property:
printfn "Test statistic: %.4f" tTest.Statistic
printfn "P-value:        %.4f" tTest.PValue

// The significance level is the default value of 0.05:
printfn "Significance level:     %.2f" tTest.SignificanceLevel
// We can now print the test scores:
printfn "Reject null hypothesis? %s" (if tTest.Reject() then "yes" else "no")
// We can get a confidence interval for the current significance level:
let meanInterval3 = tTest.GetConfidenceInterval()
printfn "95%% Confidence interval for the mean: %.1f - %.1f"
    meanInterval3.LowerBound meanInterval3.UpperBound

//
// Two sample t-test
//

printfn "\nUsing two-sample t-test:"
// We want to compare the scores of the first group to the scores
// of a second group from the same school. Once again.0; we start
// by creating a NumericalVariable containing the scores:
let group2Results = Vector.Create(
                        [|
                            61.0; 80.0; 98.0; 90.0; 94.0;
                            65.0; 79.0; 75.0; 74.0; 86.0;
                            76.0; 85.0; 78.0; 72.0; 76.0;
                            79.0; 65.0; 92.0; 76.0; 80.0
                        |])

// To compare the means of the two groups.0; we need the two sample
// t test.0; implemented by the TwoSampleTTest group:
let tTest2 = TwoSampleTTest(group1Results, group2Results, SamplePairing.Paired,
                assumeEqualVariances=false)
// We can obtan the value of the test statistic through the Statistic property.0;
// and the corresponding P-value through the Probability property:
printfn "Test statistic: %.4f" tTest2.Statistic
printfn "P-value:        %.4f" tTest2.PValue

// The significance level is the default value of 0.05:
printfn "Significance level:     %.2f" tTest2.SignificanceLevel
// We can now print the test scores:
printfn "Reject null hypothesis? %s" (if tTest2.Reject() then "yes" else "no")
