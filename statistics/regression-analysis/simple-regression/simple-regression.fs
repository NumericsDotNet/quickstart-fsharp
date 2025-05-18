//=====================================================================
//
//  File: simple-regression.fs
//
//---------------------------------------------------------------------
//
//  This file is part of the Numerics.NET Code Samples.
//
//  Copyright (c) 2004-2025 ExoAnalytics Inc. All rights reserved.
//
//=====================================================================

module SimpleRegression

#light

open System

open Numerics.NET
open Numerics.NET.Statistics

// The license is verified at runtime. We're using a 30 day trial key here.
// For more information, see:
//     https://numerics.net/trial-key
let licensed = Numerics.NET.License.Verify("your-trial-key-here")

// Illustrates the use of the SimpleRegressionModel class
// to perform multiple linear regression.

// Simple linear regression can be performed using
// the SimpleRegressionModel class. There are some special constructors
// for simple linear regression, with only one independent variable.
//
// This QuickStart sample uses data from the National Institute
// for Standards and Technology's Statistical Reference Datasets
// library at http://www.itl.nist.gov/div898/strd/.

// Note that, due to round-off error, the results here will not be exactly
// the same as the NIST results, which were calculated using 500 digits
// of precision!

// Model 1 uses the 'NoInt1' dataset. The model has no intercept.

// First, we construct Double arrays containing the data for
// the dependent and independent variables.
let yData1 = Vector.Create(
                [|130.0; 131.0; 132.0; 133.0; 134.0; 135.0;
                136.0; 137.0; 138.0; 139.0; 140.0|])
let xData1 = Vector.Create(
                [|60.0; 61.0; 62.0; 63.0; 64.0; 65.0;
                 66.0; 67.0; 68.0; 69.0; 70.0|])

// Next, we create the regression model. We can pass the data arrays directly.
let model1 = SimpleRegressionModel(yData1, xData1)
model1.NoIntercept <- true
model1.Fit()

for parameter in model1.Parameters do
    printfn "%O" parameter
printfn "Residual standard error: %.2f" model1.StandardError
printfn "R-Squared: %.3f" model1.RSquared
printfn "Adjusted R-Squared: %.3f" model1.AdjustedRSquared
printfn "F-statistic: %.3f" model1.FStatistic

printfn "%O" model1.AnovaTable

// Model 2 uses the 'Norris' dataset.

printfn "\n\nModel 2"
let dependent2 =
  Vector.Create(
    [|0.1; 338.8; 118.1; 888.0; 9.2; 228.1; 668.5; 998.5;
        449.1; 778.9; 559.2; 0.3; 0.1; 778.1; 668.8; 339.3;
        448.9; 10.8; 557.7; 228.3; 998.0; 888.8; 119.6; 0.3;
        0.6; 557.6; 339.3; 888.0; 998.5; 778.9;  10.2 ; 117.6;
        228.9; 668.4; 449.2; 0.2|])
let independent2 =
  Vector.Create(
    [|0.2; 337.4; 118.2; 884.6; 10.1; 226.5; 666.3; 996.3;
        448.6; 777.0; 558.2; 0.4; 0.6; 775.5; 666.9; 338.0;
        447.5; 11.6; 556.0; 228.1; 995.8; 887.6; 120.2; 0.3;
        0.3; 556.8; 339.1; 887.2; 999.0; 779.0; 11.1; 118.3;
        229.2; 669.1; 448.9; 0.5|])

// Next, we create the regression model, using the NumericalVariable objects
// we just created:
let model2 = SimpleRegressionModel(dependent2, independent2)
model2.Fit()

for parameter in model2.Parameters do
    printfn "%O" parameter
printfn "Residual standard error: %.8f" model2.StandardError
printfn "R-Squared: %.8f" model2.RSquared
printfn "Adjusted R-Squared: %.8f" model2.AdjustedRSquared
printfn "F-statistic: %.3f" model2.FStatistic

printfn "%O" model2.AnovaTable

// The data can also be supplied as two Vector objects.
// This is not illustrated here.
