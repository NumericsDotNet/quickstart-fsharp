//=====================================================================
//
//  File: logistic-regression.fs
//
//---------------------------------------------------------------------
//
//  This file is part of the Numerics.NET Code Samples.
//
//  Copyright (c) 2004-2025 ExoAnalytics Inc. All rights reserved.
//
//=====================================================================

module LogisticRegression

// Illustrates building logistic regression models using
// the LogisticRegressionModel class in the
// Numerics.NET.Statistics namespace of Numerics.NET.

#light

open System

open System.Data
open System.IO

open Numerics.NET.Data.Text
open Numerics.NET.DataAnalysis
open Numerics.NET.Statistics

open Numerics.NET

// The license is verified at runtime. We're using a 30 day trial key here.
// For more information, see:
//     https://numerics.net/trial-key
let licensed = Numerics.NET.License.Verify("your-trial-key-here")

// Logistic regression can be performed using
// the LogisticRegressionModel class.
//
// This QuickStart sample uses data from a study of factors
// that determine low birth weight at Baystate Medical Center.
// from Belsley, Kuh and Welsch. The fields are as follows:
//   AGE:  Mother's age.
//   LWT:  Mother's weight.
//   RACE: 1=white, 2=black, 3=other.
//   FVT:  Number of physician visits during the 1st trimester.
//   LOW:  Low birth weight indicator.

// First, read the data from a file into an ADO.NET DataTable.
let data = FixedWidthTextFile.ReadDataFrame(
            "..\..\..\..\..\Data\lowbwt.txt",
            [| 4; 11; 18; 25; 33; 42; 49; 55; 61; 68 |])

// Race is a categorical variable:
data.MakeCategorical("RACE", Index.Create([|1;2;3|])) |> ignore

// Now create the regression model. Parameters are the name
// of the dependent variable, a let array containing
// the names of the independent variables, and the VariableCollection
// containing all variables.
let model = LogisticRegressionModel(data, "LOW", [| "AGE"; "LWT"; "RACE"; "FTV" |])

// The Fit method performs the actual regression analysis.
model.Fit()

// The Parameters collection contains information about the regression
// parameters.
printfn "Variable  Value    Std.Error  t-stat  p-Value"
for parameter in model.Parameters do
    // Parameter objects have the following properties:
    printfn "%-20s%10.5f%10.5f%8.2f %7.4f"
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

// The log-likelihood of the computed solution is also available:
printfn "Log-likelihood: %.4f" (model.LogLikelihood)

// We can test the significance by looking at the results
// of a log-likelihood test, which compares the model to
// a constant-only model:
let lrt = model.GetLikelihoodRatioTest()
printfn "Likelihood-ratio test: chi-squared=%.4f, p=%.4f" lrt.Statistic lrt.PValue
printfn ""

// We can compute a model with fewer parameters:
let model2 = LogisticRegressionModel(data, "LOW ~ LWT + RACE")
model2.Fit()

// Print the results...
printfn "Variable  Value    Std.Error  t-stat  p-Value"
for parameter in model2.Parameters do
    printfn "%-20s%10.5f%10.5f%8.2f %7.4f" parameter.Name parameter.Value
        parameter.StandardError parameter.Statistic parameter.PValue
// ...including the log-likelihood:
printfn "Log-likelihood: %.4f" (model.LogLikelihood)

// We can now compare the original model to this one, once again
// using the likelihood ratio test:
let lrt2 = model.GetLikelihoodRatioTest(model2)
printfn "Likelihood-ratio test: chi-squared=%.4f, p=%.4f" lrt2.Statistic lrt2.PValue
printfn ""

//
// Multinomial (polytopous) logistic regression
//

// The LogisticRegressionModel class can also be used
// for logistic regression with more than 2 responses.
// The following example is from "Applied Linear Statistical
// Models."

// Load the data into a matrix
let dataFrame =
    let options = new FixedWidthTextOptions(
                    [| 5; 10; 15; 20; 25; 32; 37; 42; 47 |],
                    columnHeaders=false)
    let df = FixedWidthTextFile.ReadDataFrame(
                "..\..\..\..\..\Data\mlogit.txt", options)
    let columnNames = [| "id"; "duration"; "x2"; "x3"; "x4";
        "nutritio"; "agecat1"; "agecat3"; "alcohol"; "smoking" |]
    df.WithColumnIndex(columnNames)

// For multinomial regression, the response variable must be
// a categorical variable:
dataFrame.MakeCategorical("duration") |> ignore

// When using a formula, we can use '.' as a shortcut
// for all unused variables in the data frame.
// Because duration has 3 levels, nominal logistic regression
// is automatically inferred.
let model3 =
    let formula = "duration ~ nutritio + agecat1 + agecat3 + alcohol + smoking"
    new LogisticRegressionModel(dataFrame, formula)

// Everything else is the same:
model3.Fit()

// There is a set of parameters for each level of the
// response variable. The highest level is the reference
// level and has no associated parameters.
for p in model3.Parameters do
    printfn "%O" p

printfn "Log likelihood: %.4f" (model3.LogLikelihood)

// To test the hypothesis that all the slopes are zero,
// use the GetLikelihoodRatioTest method.
let lrt3 = model3.GetLikelihoodRatioTest()
printfn "Test that all slopes are zero: chi-squared=%.4f, p=%0.4f" lrt3.Statistic lrt3.PValue
