//=====================================================================
//
//  File: multiple-regression.fs
//
//---------------------------------------------------------------------
//
//  This file is part of the Numerics.NET Code Samples.
//
//  Copyright (c) 2004-2025 ExoAnalytics Inc. All rights reserved.
//
//=====================================================================

module MultipleRegression

// Illustrates building multiple linear regression models using
// the LinearRegressionModel class in the
// Numerics.NET.Statistics namespace of Numerics.NET.

#light

open System

open System.Data
open System.IO

open Numerics.NET.Data.Text
open Numerics.NET.DataAnalysis
open Numerics.NET
open Numerics.NET.Statistics

// The license is verified at runtime. We're using a 30 day trial key here.
// For more information, see:
//     https://numerics.net/trial-key
let licensed = Numerics.NET.License.Verify("your-trial-key-here")

// Multiple linear regression can be performed using
// the LinearRegressionModel class.
//
// This QuickStart sample uses data test scores of 200 high school
// students, including science, math, and reading.

// First, read the data from a file into a data frame.
let data = DelimitedTextFile.ReadDataFrame(@"..\..\..\..\..\Data\hsb2.csv");

// Now create the regression model. Parameters are the data frame,
// the name of the dependent variable, and a string array containing
// the names of the independent variables.
let model = LinearRegressionModel(data, "science", [| "math"; "female"; "socst"; "read" |])

// Alternatively, we can use a formula to describe the variables
// in the model. The dependent variable goes on the left, the
// independent variables on the right of the ~:
let model2 = LinearRegressionModel(data, "science ~ math + female + socst + read")

// We can set model options now, such as whether to exclude
// the constant term:
// model.NoIntercept <- false

// The Fit method performs the actual regression analysis.
model.Fit()

// The Parameters collection contains information about the regression
// parameters.
printfn "Variable   Value     Std.Error   t-stat  p-Value"
for parameter in model.Parameters do
    // Parameter objects have the following properties:
    printfn "%-20s %10.6f %10.6f %8.2f %7.5f"
        // Name, usually the name of the variable:
        parameter.Name
        // Estimated value of the parameter:
        parameter.Value
        // Standard error:
        parameter.StandardError
        // The value of the t statistic for the hypothesis that the parameter
        // is zero.
        parameter.Statistic
        // Probability corresponding to the t statistic.
        parameter.PValue
printfn ""

// In addition to these properties, Parameter objects have a GetConfidenceInterval
// method that returns a confidence interval at a specified confidence level.
// Notice that individual parameters can be accessed using their numeric index.
// Parameter 0 is the intercept, if it was included.
let confidenceInterval = model.Parameters.[0].GetConfidenceInterval(0.95)
printfn "95%% confidence interval for intercept: %.4f - %.4f"
    confidenceInterval.LowerBound confidenceInterval.UpperBound

// Parameters can also be accessed by name:
let confidenceInterval2 = model.Parameters.Get("math").GetConfidenceInterval(0.95)
printfn "95%% confidence interval for 'math': %.4f - %.4f"
    confidenceInterval2.LowerBound confidenceInterval2.UpperBound
printfn ""

// There is also a wealth of information about the analysis available
// through various properties of the LinearRegressionModel object:
printfn "Residual standard error: %.3f" model.StandardError
printfn "R-Squared:   %.4f" model.RSquared
printfn "Adjusted R-Squared:      %.4f" model.AdjustedRSquared
printfn "F-statistic: %.4f" model.FStatistic
printfn "Corresponding p-value:   %.5f" model.PValue
printfn ""

// Much of this data can be summarized in the form of an ANOVA table:
printfn "%O" model.AnovaTable

// All this information can be printed using the Summarize method.
// You will also see summaries using the library in C# interactive.
printfn "%s" (model.Summarize())
