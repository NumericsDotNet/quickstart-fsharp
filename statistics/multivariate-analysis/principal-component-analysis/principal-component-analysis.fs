//=====================================================================
//
//  File: principal-component-analysis.fs
//
//---------------------------------------------------------------------
//
//  This file is part of the Numerics.NET Code Samples.
//
//  Copyright (c) 2004-2025 ExoAnalytics Inc. All rights reserved.
//
//=====================================================================

module PrincipalComponentAnalysis

#light

open System

open Numerics.NET
open Numerics.NET.Statistics
open Numerics.NET.Statistics.Multivariate
open Numerics.NET.Data.Text

// The license is verified at runtime. We're using a 30 day trial key here.
// For more information, see:
//     https://numerics.net/trial-key
let licensed = Numerics.NET.License.Verify("your-trial-key-here")

// Demonstrates how to use classes that implement
// Principal Component Analysis (PCA).

// This QuickStart Sample demonstrates how to perform
// a principal component analysis on a set of data.
//
// The classes used in this sample reside in the
// Numerics.NET.Statistics.Multivariate namespace..

// First, our dataset, 'depress.txt', which is from
//     Computer-Aided Multivariate Analysis, 4th Edition
//     by A. A. Afifi, V. Clark and S. May, chapter 16
//     See http://www.ats.ucla.edu/stat/Stata/examples/cama4/default.htm

// The data is in delimited text format. Use a matrix reader to load it into a matrix.
let m =
    let options = new DelimitedTextOptions(
                    columnHeaders=false,
                    columnDelimiter=' ',
                    mergeConsecutiveDelimiters=true)
    let m = DelimitedTextFile.ReadMatrix<double>(
                "..\..\..\..\..\Data\Depress.txt", options)
    // The data we want is in columns 8 through 27:
    m.GetSubmatrix(0, m.RowCount - 1, 8, 27)

//
// Principal component analysis
//

// We can construct PCA objects in many ways. Since we have the data in a matrix,
// we use the constructor that takes a matrix as input.
let pca = PrincipalComponentAnalysis(m)
// and immediately perform the analysis:
pca.Fit()

// We can get the contributions of each component:
printfn " #    Eigenvalue Difference Contribution Contrib. %%"
for i in 0..4 do
    // We get the ith component from the model...
    let componenti = pca.Components[i]
    // and write out its properties
    printfn "%2d%12.4f%11.4f%14.3f%%%10.3f%%"
        i componenti.Eigenvalue componenti.EigenvalueDifference
        (100.0 * componenti.ProportionOfVariance)
        (100.0 * componenti.CumulativeProportionOfVariance)

// To get the proportions for all components, use the
// properties of the PCA object:
let proportions = pca.VarianceProportions

// To get the number of components that explain a given proportion
// of the variation, use the GetVarianceThreshold method:
let count = pca.GetVarianceThreshold(0.9)
printfn "Components needed to explain 90%% of variation: %d" count
printfn ""

// The value property gives the components themselves:
printfn "Components:"
printfn "Var.      1       2       3       4       5"
let pcs = pca.Components
for i in 0..pcs.Count-1 do
    printfn "%4d%8.4f%8.4f%8.4f%8.4f%8.4f" i
        pcs[0].Value[i] pcs[1].Value[i] pcs[2].Value[i]
        pcs[3].Value[i] pcs[4].Value[i]
printfn ""

// The scores are the coefficients of the observations expressed as a combination
// of principal components.
let scores = pca.ScoreMatrix

// To get the predicted observations based on a specified number of components,
// use the GetPredictions method.
let prediction = pca.GetPredictions(count)
printfn "Predictions using %d components:" count
printfn "   Pr. 1  Act. 1   Pr. 2  Act. 2   Pr. 3  Act. 3   Pr. 4  Act. 4"
for i in 0..9 do
    printfn "%8.4f%8.4f%8.4f%8.4f%8.4f%8.4f%8.4f%8.4f"
        (prediction[i, 0]) m[i, 0]
        (prediction[i, 1]) m[i, 1]
        (prediction[i, 2]) m[i, 2]
        (prediction[i, 3]) m[i, 3]
