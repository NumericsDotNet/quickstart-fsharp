//=====================================================================
//
//  File: arima-models.fs
//
//---------------------------------------------------------------------
//
//  This file is part of the Numerics.NET Code Samples.
//
//  Copyright (c) 2004-2025 ExoAnalytics Inc. All rights reserved.
//
//=====================================================================

module ArimaModels

// Illustrates the use of the ArimaModel class to perform
// estimation and forecasting of ARIMA time series models..

#light

open System

open Numerics.NET
open Numerics.NET.Statistics
open Numerics.NET.Statistics.TimeSeriesAnalysis

// The license is verified at runtime. We're using a 30 day trial key here.
// For more information, see:
//     https://numerics.net/trial-key
let licensed = Numerics.NET.License.Verify("your-trial-key-here")

// This QuickStart Sample fits an ARMA(2,1) model and
// an ARIMA(0,1,1) model to sunspot data.

// The time series data is stored in a numerical variable:
let sunspots =
    Vector.Create(
        [|
            100.8; 81.6; 66.5; 34.8; 30.6;  7.0; 19.8; 92.5;154.4;125.9;
             84.8; 68.1; 38.5; 22.8; 10.2; 24.1; 82.9;132.0;130.9;118.1;
             89.9; 66.6; 60.0; 46.9; 41.0; 21.3; 16.0;  6.4;  4.1;  6.8;
             14.5; 34.0; 45.0; 43.1; 47.5; 42.2; 28.1; 10.1;  8.1;  2.5;
              0.0;  1.4;  5.0; 12.2; 13.9; 35.4; 45.8; 41.1; 30.4; 23.9;
             15.7;  6.6;  4.0;  1.8;  8.5; 16.6; 36.3; 49.7; 62.5; 67.0;
             71.0; 47.8; 27.5;  8.5; 13.2; 56.9;121.5;138.3;103.2; 85.8;
             63.2; 36.8; 24.2; 10.7; 15.0; 40.1; 61.5; 98.5;124.3; 95.9;
             66.5; 64.5; 54.2; 39.0; 20.6;  6.7;  4.3; 22.8; 54.8; 93.8;
             95.7; 77.2; 59.1; 44.0; 47.0; 30.5; 16.3;  7.3; 37.3; 73.9
        |])

// ARMA models (no differencing) are constructed from
// the variable containing the time series data, and the
// AR and MA orders. The following constructs an ARMA(2,1)
// model:
let model = ArimaModel(sunspots, 2, 1)

// The Fit methods fits the model.
model.Fit()

// The model's Parameters collection contains the fitted values.
// For an ARIMA(p,d,q) model, the first p parameters are the
// auto-regressive parameters. The last q parametere are the
// moving average parameters.
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
// as is the Akaike Information Criterion (AIC):
printfn "AIC: %.4f" (model.GetAkaikeInformationCriterion())
// and the Baysian Information Criterion (BIC):
printfn "AIC: %.4f" (model.GetBayesianInformationCriterion())

// The Forecast method can be used to predict the next value in the series...
let nextValue = model.Forecast()
printfn "One step ahead forecast: %.3f" nextValue

// or to predict a specified number of values:
let nextValues = model.Forecast(5)
printfn "First five forecasts: %s" (nextValues.ToString("F3"))

// An integrated model (with differencing) is constructed
// by supplying the degree of differencing. Note the order
// of the orders is the traditional one for an ARIMA(p,d,q)
// model (p, d, q).
// The following constructs an ARIMA(0,1,1) model:
let model2 = ArimaModel(sunspots, 0, 1, 1)

// By default, the mean is assumed to be zero for an integrated model.
// We can override this by setting the EstimateMean property to true:
model2.EstimateMean <- true

// The Fit methods fits the model.
model2.Fit()

// The mean shows up as one of the parameters.
printfn "Variable  Value    Std.Error  t-stat  p-Value"
for parameter in model2.Parameters do
    printfn "%-20s%10.5f%10.5f%8.2f %7.4f" parameter.Name parameter.Value
        parameter.StandardError parameter.Statistic parameter.PValue

// We can also get the error variance:
printfn "Error variance: %.4f" model2.ErrorVariance

printfn "Log-likelihood: %.4f" (model2.LogLikelihood)
printfn "AIC: %.4f" (model2.GetAkaikeInformationCriterion())
printfn "BIC: %.4f" (model2.GetBayesianInformationCriterion())
