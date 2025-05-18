# ARIMA Models

This sample illustrates how to work with ARIMA time series models using classes in the Numerics.NET.Statistics.TimeSeriesAnalysis namespace using Numerics.NET.

## Overview

This QuickStart sample demonstrates how to use the ArimaModel class to perform time series analysis and 
forecasting using ARIMA (AutoRegressive Integrated Moving Average) models in Numerics.NET.

The sample illustrates two common ARIMA model specifications:
- An ARMA(2,1) model without differencing
- An ARIMA(0,1,1) model with first-order differencing

For each model, the sample shows how to:
- Create and configure the model
- Fit the model to sunspot time series data
- Access model parameters and their statistical properties
- Examine model fit statistics including log-likelihood, AIC, and BIC
- Generate forecasts for future time periods

The sample also demonstrates how to:
- Work with model parameters including standard errors and significance tests
- Control model estimation options like mean estimation
- Access diagnostic information about the fitted model
- Generate both single-step and multi-step forecasts

This provides a practical introduction to time series modeling and forecasting using ARIMA models in 
Numerics.NET.


## Getting Started

### Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download) (.NET 6.0 or .NET 8.0)
- A code editor like [Visual Studio](https://visualstudio.microsoft.com/), [VS Code](https://code.visualstudio.com/), or [JetBrains Rider](https://www.jetbrains.com/rider/)
- Required NuGet packages: Numerics.NET.Core, Version 9.1.0

### Running the Sample

#### In Visual Studio
1. Open the solution file (.sln) in Visual Studio
2. Restore NuGet packages: Right-click on the solution → Restore NuGet Packages
3. Update the trial key in the code:
4. Press F5 to build and run the sample

#### In VS Code

1. Open the project folder in VS Code
2. Make sure you have the [C# Dev Kit extension](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csdevkit) installed
3. Open a terminal and run: `dotnet restore`
4. Update the trial key in the code 
5. Run the sample with: `dotnet run`

#### From the Command Line

1. Open a terminal and navigate to the project directory
2. Run `dotnet restore` to restore the required NuGet packages
3. Update the trial key in the code
4. Run the sample with `dotnet run`

### Getting a Trial Key

To run this sample, you'll need a trial key for Numerics.NET:

1. Visit [https://numerics.net/trial-key](https://numerics.net/trial-key)
2. Sign in using the provider of your choice to receive your 30-day trial key
3. Replace the placeholder in `License.Verify("your-trial-key-here")` with your actual trial key

## Related Content

This sample is also available in the following languages: 
[C#](https://github.com/NumericsDotNet/quickstart-csharp/tree/net8.0/statistics/time-series-analysis/arima-models), [Visual Basic](https://github.com/NumericsDotNet/quickstart-visualbasic/tree/net8.0/statistics/time-series-analysis/arima-models), [IronPython](https://github.com/NumericsDotNet/quickstart-ironpython/tree/net8.0/statistics/time-series-analysis/arima-models).

You can find out more about the methods used in this sample from the Numerics.NET documentation.

### Numerics.NET User's Guide

- [ARIMA Models](https://numerics.net/documentation/latest/statistics/time-series-analysis/arima-models)
- [Other Time Series Functions](https://numerics.net/documentation/latest/statistics/time-series-analysis/other-time-series-functions)
- [Hypothesis Test Basics](https://numerics.net/documentation/latest/statistics/hypothesis-tests/hypothesis-test-basics)

### Numerics.NET API Reference

- [TimeSeriesAnalysis.ArimaModel class](https://numerics.net/documentation/latest/reference/numerics.net.statistics.timeseriesanalysis.arimamodel)
- [TimeSeriesAnalysis.TimeSeriesModel&lt;T&gt; class](https://numerics.net/documentation/latest/reference/numerics.net.statistics.timeseriesanalysis.timeseriesmodel-1)
- [Vector&lt;T&gt; class](https://numerics.net/documentation/latest/reference/numerics.net.vector-1)
- [Numerics.NET.Statistics.TimeSeriesAnalysis namespace](https://numerics.net/documentation/latest/reference/numerics.net.statistics.timeseriesanalysis)


## Troubleshooting

### Common Issues

- **Missing dependencies**: Make sure to run `dotnet restore` before building
- **License verification failed**: Ensure you have a valid trial key from [https://numerics.net/trial-key](https://numerics.net/trial-key)
- **Runtime errors**: Check that you're targeting the correct .NET version (.NET 6 or .NET 8)

### Need Help?

- Check the [Numerics.NET documentation](https://numerics.net/documentation/)
- Contact support at [support@numerics.net](mailto:support@numerics.net?subject=ArimaModels%20QuickStart%20Sample%20%28F%23%29)

## About Numerics.NET

Numerics.NET is a powerful numerical library for .NET that provides advanced mathematical 
functions and algorithms for scientific computing, data analysis, and machine learning.
See [numerics.net](https://numerics.net) for details.

---

_Last updated on 2025-05-06 3:03:10 PM (version 9.1.3)._
