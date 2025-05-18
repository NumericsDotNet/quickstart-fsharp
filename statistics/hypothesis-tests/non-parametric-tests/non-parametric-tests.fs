//=====================================================================
//
//  File: non-parametric-tests.fs
//
//---------------------------------------------------------------------
//
//  This file is part of the Numerics.NET Code Samples.
//
//  Copyright (c) 2004-2025 ExoAnalytics Inc. All rights reserved.
//
//=====================================================================

module NonParametricTests

// Demonstrates how to use non-parametric hypothesis tests
// like the Mann-Whitney (Wilcoxon) rank sum test and the
// Kruskal-Wallis test.

#light

open System

open Numerics.NET
open Numerics.NET.Statistics
open Numerics.NET.Statistics.Tests

// The license is verified at runtime. We're using a 30 day trial key here.
// For more information, see:
//     https://numerics.net/trial-key
let licensed = Numerics.NET.License.Verify("your-trial-key-here")

//
// Mann-Whitney test
//

printfn "Mann-Whitney Test"

// The Mann-Whitney test compares to samples to see if they were
// drawn from the same distribution.

// We use an example from McDonald, et.al. (1996), who compared
// the geographic variation in oyster DNA to the variation in
// proteins. A significant difference in the samples would suggest
// that natural selection played a role in the oyster diversification.

// There are two ways to create a test with multiple samples.

// The first is to put all the data in one variable,
// and use a second variable to group the data in the first.
printfn "\nUsing grouping variable:"

type Group =
    | DNA
    | Protein

let values = Vector.Create(
                [|
                    -0.005; 0.116;-0.006; 0.095; 0.053; 0.003;
                    -0.005; 0.016; 0.041; 0.016; 0.066;
                     0.163; 0.004; 0.049; 0.006; 0.058;
                    -0.002; 0.015; 0.044; 0.024
                |])

let groups = Vector.CreateCategorical(
                [|
                    Group.DNA; Group.DNA; Group.DNA; Group.DNA;
                    Group.DNA; Group.DNA; Group.Protein; Group.Protein;
                    Group.Protein; Group.Protein; Group.Protein;
                    Group.Protein; Group.Protein; Group.Protein;
                    Group.Protein; Group.Protein; Group.Protein;
                    Group.Protein; Group.Protein; Group.Protein
                |])

// With this data, we can create the test:
let mw = MannWhitneyTest(values, groups)

// We can obtan the value of the test statistic through the Statistic property,
// and the corresponding P-value through the PValue property:
printfn "Test statistic: %.4f" mw.Statistic
printfn "P-value:        %.4f" mw.PValue

// The significance level is the default value of 0.05:
printfn "Significance level:     %.2f" mw.SignificanceLevel
// We can now print the test scores:
printfn "Reject null hypothesis? %s" (if mw.Reject() then "yes" else "no")

// We can get the same scores for the 0.01 significance level by explicitly
// passing the significance level as a parameter to these methods:
printfn "Significance level:    %.2f" 0.01
printfn "Reject null hypothesis? %s" (if mw.Reject(0.01) then "yes" else "no")

// The second method is to put the data in different variables
printfn "\nUsing multiple variables:"

let dnaValues = Vector.Create([| -0.005; 0.116;-0.006; 0.095; 0.053; 0.003 |])
let proteinValues = Vector.Create(
                        [|
                            -0.005; 0.016; 0.041; 0.016; 0.066;
                             0.163; 0.004; 0.049; 0.006; 0.058;
                            -0.002; 0.015; 0.044; 0.024
                        |])

// With this data, we can create the test:
let mw2 = MannWhitneyTest(dnaValues, proteinValues);

// We can obtan the value of the test statistic through the Statistic property,
// and the corresponding P-value through the PValue property:
printfn "Test statistic: %.4f" mw2.Statistic
printfn "P-value:        %.4f" mw2.PValue

// The significance level is the default value of 0.05:
printfn "Significance level:     %.2f" mw2.SignificanceLevel
// We can now print the test scores:
printfn "Reject null hypothesis? %s" (if mw2.Reject() then "yes" else "no")

//
// Kruskal-Wallis test
//

printfn "\nKruskal-Wallis Test\n"

// The Kruskal-Wallis test is a generalization of the Mann-Whitney test
// to more than 2 groups.

// The following example was taken from the NIST Engineering Statistics Handbook
// at http://www.itl.nist.gov/div898/handbook/prc/section4/prc41.htm

// The data represents percentage quarterly growth
// in 4 investment funds:
let aValues = Vector.Create([| 4.2; 4.6; 3.9; 4.0      |])
let bValues = Vector.Create([| 3.3; 2.4; 2.6; 3.8; 2.8 |])
let cValues = Vector.Create([| 1.9; 2.4; 2.1; 2.7; 1.8 |])
let dValues = Vector.Create([| 3.5; 3.1; 3.7; 4.1; 4.4 |])

// We simply pass these variables to the constructor:
let kw = KruskalWallisTest(aValues, bValues, cValues, dValues)

// We can obtan the value of the test statistic through the Statistic property,
// and the corresponding P-value through the PValue property:
printfn "Test statistic: %.4f" kw.Statistic
printfn "P-value:        %.4f" kw.PValue

// The significance level is the default value of 0.05:
printfn "Significance level:     %.2f" kw.SignificanceLevel
// We can now print the test scores:
printfn "Reject null hypothesis? %s" (if kw.Reject() then "yes" else "no")

//
// Runs test
//

printfn "\nRuns Test\n"

// The runs test is a test of randomness.

// It compares the lengths of runs of the same value
// in a sample to what would be expected.

// In numerical data, it uses the runs of successively
// increasing or decreasing values

type Gender =
    | Male
    | Female

let genders = Vector.CreateCategorical(
               [|
                Gender.Male; Gender.Male; Gender.Male; Gender.Female;
                Gender.Female; Gender.Female; Gender.Male; Gender.Male;
                Gender.Male; Gender.Male; Gender.Female; Gender.Female;
                Gender.Male; Gender.Male; Gender.Male; Gender.Female;
                Gender.Female; Gender.Female; Gender.Female; Gender.Female;
                Gender.Female; Gender.Female; Gender.Male; Gender.Male;
                Gender.Female; Gender.Male; Gender.Male; Gender.Female;
                Gender.Female; Gender.Female; Gender.Female |])
let rt = RunsTest(genders)

// We can obtan the value of the test statistic through the Statistic property,
// and the corresponding P-value through the PValue property:
printfn "Test statistic: %.4f" rt.Statistic
printfn "P-value:        %.4f" rt.PValue

// The significance level is the default value of 0.05:
printfn "Significance level:     %.2f" rt.SignificanceLevel
// We can now print the test scores:
printfn "Reject null hypothesis? %s" (if rt.Reject() then "yes" else "no")
