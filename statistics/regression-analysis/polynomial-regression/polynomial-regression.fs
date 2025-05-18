//=====================================================================
//
//  File: polynomial-regression.fs
//
//---------------------------------------------------------------------
//
//  This file is part of the Numerics.NET Code Samples.
//
//  Copyright (c) 2004-2025 ExoAnalytics Inc. All rights reserved.
//
//=====================================================================

module PolynomialRegression

#light

open System

open Numerics.NET
open Numerics.NET.Statistics

// The license is verified at runtime. We're using a 30 day trial key here.
// For more information, see:
//     https://numerics.net/trial-key
let licensed = Numerics.NET.License.Verify("your-trial-key-here")

// Illustrates the use of the PolynomialRegressionModel class
// to perform polynomial regression.

// Polynomial regression can be performed using
// the PolynomialRegressionModel class.
//
// This QuickStart sample uses data from the National Institute
// for Standards and Technology's Statistical Reference Datasets
// library at http://www.itl.nist.gov/div898/strd/.

// Note that, due to round-off error, the results here will not be exactly
// the same as the NIST results, which were calculated using 500 digits
// of precision!

// We use the 'Pontius' dataset, which contains measurement data
// from the calibration of load cells. The independent variable is the load.
// The dependent variable is the deflection.
let deflection =
  Vector.Create(
    [|
        0.11019; 0.21956; 0.32949; 0.43899; 0.54803; 0.65694; 0.76562;
        0.87487; 0.98292; 1.09146; 1.20001; 1.30822; 1.41599; 1.52399;
        1.63194; 1.73947; 1.84646; 1.95392; 2.06128; 2.16844; 0.11052;
        0.22018; 0.32939; 0.43886; 0.54798; 0.65739; 0.76596; 0.87474;
        0.98300; 1.09150; 1.20004; 1.30818; 1.41613; 1.52408; 1.63159;
        1.73965; 1.84696; 1.95445; 2.06177; 2.16829
    |])
let load =
  Vector.Create(
    [|
         150000.0;  300000.0;  450000.0;  600000.0;  750000.0;  900000.0;
        1050000.0; 1200000.0; 1350000.0; 1500000.0; 1650000.0; 1800000.0;
        1950000.0; 2100000.0; 2250000.0; 2400000.0; 2550000.0; 2700000.0;
        2850000.0; 3000000.0;  150000.0;  300000.0;  450000.0;  600000.0;
         750000.0;  900000.0; 1050000.0; 1200000.0; 1350000.0; 1500000.0;
        1650000.0; 1800000.0; 1950000.0; 2100000.0; 2250000.0; 2400000.0;
        2550000.0; 2700000.0; 2850000.0; 3000000.0
    |])

// Now create the regression model. We supply the dependent and independent
// variable, and the degree of the polynomial:
let model = PolynomialRegressionModel(deflection, load, 2)

// The Fit method performs the actual regression analysis.
model.Fit()

// The Parameters collection contains information about the regression
// parameters.
printfn "Variable      Value    Std.Error  t-stat  p-Value"
for parameter in model.Parameters do
    // Parameter objects have the following properties:
    printfn "%-19s%12.4e%12.2e%8.2f %7.4f"
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
printfn "95%% confidence interval for constant term: %.4e - %.4e"
    confidenceInterval.LowerBound confidenceInterval.UpperBound
printfn ""

// There is also a wealth of information about the analysis available
// through various properties of the LinearRegressionModel object:
printfn "Residual standard error: %.3e" model.StandardError
printfn "R-Squared:   %.4f" model.RSquared
printfn "Adjusted R-Squared:      %.4f" model.AdjustedRSquared
printfn "F-statistic: %.4f" model.FStatistic
printfn "Corresponding p-value:   %.5e" model.PValue
printfn ""

// Much of this data can be summarized in the form of an ANOVA table:
printfn "%O" model.AnovaTable
