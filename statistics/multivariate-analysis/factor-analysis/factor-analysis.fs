//=====================================================================
//
//  File: factor-analysis.fs
//
//---------------------------------------------------------------------
//
//  This file is part of the Numerics.NET Code Samples.
//
//  Copyright (c) 2004-2025 ExoAnalytics Inc. All rights reserved.
//
//=====================================================================

module FactorAnalysis

#light

open System

open Numerics.NET
open Numerics.NET.Statistics
open Numerics.NET.Statistics.Multivariate
open Numerics.NET.Data.Stata

// The license is verified at runtime. We're using a 30 day trial key here.
// For more information, see:
//     https://numerics.net/trial-key
let licensed = Numerics.NET.License.Verify("your-trial-key-here")

// Demonstrates how to use classes that implement
// Factor Analysis.

// This QuickStart Sample demonstrates how to perform
// a factor analysis on a set of data.
//
// The classes used in this sample reside in the
// Numerics.NET.Statistics.Multivariate namespace.

// First, our dataset, 'm255.dta', from Professor James Sidanius.
//     See http://www.ats.ucla.edu/stat/sas/output/factor.htm

// Note: tolerances used to test for convergence in factor analysis
// algorithms are usually set very low (around 0.001). As a result,
// when comparing results from different programs, usually only
// about the first 3 digits will be equal.

// The data is in Stata format.
let rawFrame = StataFile.ReadDataFrame("..\..\..\..\..\Data\m255.dta")

// We'll use only these columns:
let names =
    [|
        "item13"; "item14"; "item15"; "item16"; "item17"; "item18";
        "item19"; "item20"; "item21"; "item22"; "item23"; "item24"
    |]
// First, filter out any rows with missing values:
let col = rawFrame.RemoveRowsWithMissingValues(names)

//
// Factor analysis
//

// We can construct FA objects in many ways. Since we have the data in a matrix,
// we use the constructor that takes a data matrix as input.
let fa = FactorAnalysis(col, names)
// We set the number of factors:
fa.NumberOfFactors <- 3
// and immediately perform the analysis:
fa.Fit()

// We can get the unrotated factors:
let unrotatedFactors = fa.GetUnrotatedFactors()
// We can get the contributions of each factor:
printfn " #    Eigenvalue Difference Contribution Contrib. %%"
for factor in unrotatedFactors do
    // and write out its properties
    printfn "%2d%12.4f%11.4f%14.3f%10.3f"
        factor.Index factor.Eigenvalue factor.EigenvalueDifference
        factor.ProportionOfVariance
        factor.CumulativeProportionOfVariance

printfn "\nVarimax rotation"

// Here are the loadings for each of the variables:
printfn "\nUnrotated loadings:"
printfn "Variable        1          2          3      Uniqueness"
for i in 0..names.Length-1 do
    printfn "  %8s%10.5f %10.5f %10.5f%10.5f"
        names[i]
        unrotatedFactors[0].Loadings[i]
        unrotatedFactors[1].Loadings[i]
        unrotatedFactors[2].Loadings[i]
        fa.Uniqueness[i]

// Now we'll look at the rotated factors:
let rotatedFactors = fa.GetRotatedFactors()
printfn " #    Variance   Difference Proportion   Cumulative"
for factor in rotatedFactors do
    printfn "%2d%12.4f%11s%13.4f%11.4f"
        factor.Index factor.VarianceExplained "-"
        factor.ProportionOfVariance
        factor.CumulativeProportionOfVariance

// Here are the rotated loadings for each of the variables:
printfn "\nRotated loadings (Varimax):"
printfn "Variable        1          2          3      Uniqueness"
for i in 0..names.Length-1 do
    printfn "  %8s%10.5f %10.5f %10.5f%10.5f"
        names[i]
        rotatedFactors[0].Loadings[i]
        rotatedFactors[1].Loadings[i]
        rotatedFactors[2].Loadings[i]
        fa.Uniqueness[i]

// And the matrix that rotates the factors
printfn "Factor transformation matrix:\n%s" (fa.FactorTransformationMatrix.ToString("F4"))

printfn "\nPromax rotation (power = 3)"

// Now let's use an (oblique) Promax rotation:
fa.RotationMethod <- FactorRotationMethod.Promax
fa.PromaxPower <- 3.0
fa.Fit()

// Now we'll look at the rotated factors:
printfn "\nRotated factor variance explained:"
let rotatedFactors2 = fa.GetRotatedFactors()
printfn " #    Variance"
for factor in rotatedFactors2 do
    printfn "%2d%12.4f" factor.Index factor.VarianceExplained

// Here are the rotated loadings for each of the variables:
printfn "\nRotated loadings/pattern (Promax):"
printfn "Variable        1          2          3   Communality Uniqueness"
for i in 0..names.Length-1 do
    // and write out its properties
    printfn "  %8s%10.5f%10.5f%10.5f%10.5f %10.5f"
        names[i]
        rotatedFactors2[0].Loadings[i]
        rotatedFactors2[1].Loadings[i]
        rotatedFactors2[2].Loadings[i]
        fa.Communalities[i]
        fa.Uniqueness[i]

// Here are the rotated loadings for each of the variables:
printfn "\nRotated factor structure:"
printfn "Variable        1          2          3"
for i in 0..names.Length-1 do
    // and write out its properties
    printfn "  %8s%10.5f %10.5f %10.5f"
        names[i]
        rotatedFactors2[0].Structure[i]
        rotatedFactors2[1].Structure[i]
        rotatedFactors2[2].Structure[i]

// For oblique rotations, the factors are usually correlated:
printfn "Factor correlation matrix:\n%s" (fa.FactorCorrelationMatrix.ToString("F4"))

//
// Factor analysis on a correlation matrix
//

printfn "\nUsing a correlation matrix"

// This example is from Exploratory Factor Analysis
// http://www.oup.com/us/companion.websites/9780199734177/supplementary/example/
let values =
    [|
        1.000; 0.666; 0.150; 0.617; 0.541; 0.653; 0.473; 0.549; 0.566;
        0.666; 1.000; 0.247; 0.576; 0.510; 0.642; 0.425; 0.544; 0.488;
        0.150; 0.247; 1.000; 0.222; 0.081; 0.164; 0.091; 0.181; 0.120;
        0.617; 0.576; 0.222; 1.000; 0.409; 0.560; 0.338; 0.448; 0.349;
        0.541; 0.510; 0.081; 0.409; 1.000; 0.667; 0.734; 0.465; 0.754;
        0.653; 0.642; 0.164; 0.560; 0.667; 1.000; 0.596; 0.540; 0.672;
        0.473; 0.425; 0.091; 0.338; 0.734; 0.596; 1.000; 0.432; 0.718;
        0.549; 0.544; 0.181; 0.448; 0.465; 0.540; 0.432; 1.000; 0.412;
        0.566; 0.488; 0.120; 0.349; 0.754; 0.672; 0.718; 0.412; 1.000
    |]

let R = Matrix.CreateSymmetric(9, values, MatrixTriangle.Upper,
            MatrixElementOrder.ColumnMajor, true)
let fa2 = new FactorAnalysis(R, FactorMethod.Correlation)
fa2.NumberOfFactors <- 2
fa2.ExtractionMethod <- FactorExtractionMethod.MaximumLikelihood
fa2.RotationMethod <- FactorRotationMethod.Varimax
fa2.Fit()

let names2 =
    [|
        "Hugs"; "Comps"; "PerAd"; "SocAd"; "ProAd";
        "ComSt"; "PhyHlp"; "Encour"; "Tutor"
    |]

// Here are the initial:
printfn "\nRotated factor loadings:"
printfn "Variable     Initial    Extracted"
for i in 0..names2.Length-1 do
    // and write out its properties
    printfn "  %8s%10.5f %10.5f"
        names2[i]
        fa2.InitialCommunalities[i]
        fa2.Communalities[i]

// Here are the rotated loadings for each of the variables:
// Note that in the SPSS output, the ordering of the variables
// is different.
let unrotatedFactors2 = fa2.GetUnrotatedFactors()
printfn "\nUnrotated factor loadings:"
printfn "Variable        1          2"
for i in 0..names2.Length-1 do
    // and write out its properties
    printfn "  %8s%10.5f %10.5f"
        names2[i]
        unrotatedFactors2[0].Loadings[i]
        unrotatedFactors2[1].Loadings[i]

// Here are the rotated loadings for each of the variables:
let rotatedFactors3 = fa2.GetRotatedFactors()
printfn "\nRotated factor loadings:"
printfn "Variable        1          2"
for i in 0..names2.Length-1 do
    // and write out its properties
    printfn "  %8s%10.5f %10.5f"
        names2[i]
        rotatedFactors3[0].Loadings[i]
        rotatedFactors3[1].Loadings[i]
