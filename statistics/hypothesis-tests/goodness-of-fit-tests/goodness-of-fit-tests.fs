//=====================================================================
//
//  File: goodness-of-fit-tests.fs
//
//---------------------------------------------------------------------
//
//  This file is part of the Numerics.NET Code Samples.
//
//  Copyright (c) 2004-2025 ExoAnalytics Inc. All rights reserved.
//
//=====================================================================

module GoodnessOfFitTests

#light

open System

open Numerics.NET.DataAnalysis
open Numerics.NET.Statistics
open Numerics.NET.Statistics.Distributions
open Numerics.NET.Statistics.Tests
open Numerics.NET

// The license is verified at runtime. We're using a 30 day trial key here.
// For more information, see:
//     https://numerics.net/trial-key
let licensed = Numerics.NET.License.Verify("your-trial-key-here")

// Illustrates the Chi Square, Kolmogorov-Smirnov and Anderson-Darling
// tests for goodness-of-fit.

// This QuickStart Sample illustrates the wide variety of goodness-of-fit
// tests available.

//
// Chi-square Test
//

printfn "Chi-square test."

// The Chi-square test is the simplest of the goodness-of-fit tests.
// The results follow a binomial distribution with 3 trials (rolls of the dice):
let sixesDistribution = BinomialDistribution(3, 1.0/6.0)

// First, create a histogram with the expected results.
let expected = sixesDistribution.GetExpectedHistogram(100.0)

// And a histogram with the actual results
let actual = Histogram.CreateEmpty(0, 4)
Vector.Create([|51.0; 35.0; 12.0; 2.0|]).CopyTo(actual) |> ignore
let chiSquare = ChiSquareGoodnessOfFitTest(actual, expected)
chiSquare.SignificanceLevel <- 0.01

// We can obtan the value of the test statistic through the Statistic property,
// and the corresponding P-value through the Probability property:
printfn "Test statistic: %.4f" chiSquare.Statistic
printfn "P-value:        %.4f" chiSquare.PValue

// We can now print the test results:
printfn "Reject null hypothesis? %s" (if chiSquare.Reject() then "yes" else "no")

//
// One-sample Kolmogorov-Smirnov Test
//

printfn "One-sample Kolmogorov-Smirnov Test"

// We will investigate a sample of 25 random numbers from a lognormal distribution
// and investigate how well it matches a similar looking Weibull distribution.

// We first create the two distributions:
let logNormal = LognormalDistribution(0.0, 1.0)
let weibull = WeibullDistribution(2.0, 1.0)

// Then we generate the samples from the lognormal distribution:
let logNormalSample = logNormal.Sample(25)

// Finally, we construct the Kolmogorov-Smirnov test:
let ksTest = OneSampleKolmogorovSmirnovTest(logNormalSample, weibull)

// We can obtan the value of the test statistic through the Statistic property,
// and the corresponding P-value through the Probability property:
printfn "Test statistic: %.4f" ksTest.Statistic
printfn "P-value:        %.4f" ksTest.PValue

// We can now print the test results:
printfn "Reject null hypothesis? %s" (if ksTest.Reject() then "yes" else "no")

//
// Two-sample Kolmogorov-Smirnov Test
//

printfn "\nTwo-sample Kolmogorov-Smirnov Test"

// We once again investigate the similarity between a lognormal and
// a Weibull distribution. However, this time, we use 25 random
// samples from each distribution.

// We already have the lognormal samples.
// Generate the samples from the Weibull distribution:
let weibullSample = weibull.Sample(25)

// Finally, we construct the Kolmogorov-Smirnov test:
let ksTest2 = TwoSampleKolmogorovSmirnovTest(logNormalSample, weibullSample)

// We can obtan the value of the test statistic through the Statistic property,
// and the corresponding P-value through the Probability property:
printfn "Test statistic: %.4f" ksTest2.Statistic
printfn "P-value:        %.4f" ksTest2.PValue

// We can now print the test results:
printfn "Reject null hypothesis? %s" (if ksTest2.Reject() then "yes" else "no")

//
// Anderson-Darling Test
//

printfn "\nAnderson-Darling Test"

// The Anderson-Darling is defined for a small number of
// distributions. Currently, only the normal distribution
// is supported.

// We will investigate the distribution of the strength
// of polished airplane windows. The data comes from
// Fuller, e.al. (NIST, 1993) and represents the pressure
// (in psi).

// First, create a numerical variable:
let strength = Vector.Create(
                [|
                    18.830; 20.800; 21.657; 23.030; 23.230; 24.050;
                    24.321; 25.500; 25.520; 25.800; 26.690; 26.770;
                    26.780; 27.050; 27.670; 29.900; 31.110; 33.200;
                    33.730; 33.760; 33.890; 34.760; 35.750; 35.910;
                    36.980; 37.080; 37.090; 39.580; 44.045; 45.290;
                    45.381
                |])

// Let's print some summary statistics:
printfn "Number of observations: %d" strength.Length
printfn "Mean:       %.3f" (strength.Mean())
printfn "Standard deviation:     %.3f" (strength.StandardDeviation())

// The most refined test of normality is the Anderson-Darling test.
let adTest = AndersonDarlingTest(strength)

// We can obtan the value of the test statistic through the Statistic property,
// and the corresponding P-value through the Probability property:
printfn "Test statistic: %.4f" adTest.Statistic
printfn "P-value:        %.4f" adTest.PValue

// We can now print the test results:
printfn "Reject null hypothesis? %s" (if adTest.Reject() then "yes" else "no")
