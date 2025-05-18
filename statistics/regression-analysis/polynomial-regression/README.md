# Polynomial Regression

This sample illustrates how to fit data to polynomials using the PolynomialRegressionModel class using Numerics.NET.

## Overview

This QuickStart sample demonstrates how to perform polynomial regression analysis using the 
PolynomialRegressionModel class in Numerics.NET.

The sample uses real-world calibration data from the National Institute of Standards and 
Technology's Statistical Reference Datasets library. Specifically, it works with the 'Pontius' 
dataset containing load cell calibration measurements, where deflection is modeled as a function 
of applied load.

The sample shows how to:
- Create and fit a polynomial regression model
- Access and interpret the regression parameters and their statistical properties
- Calculate confidence intervals for the parameters
- Obtain model quality metrics like R-squared and F-statistics
- Generate an ANOVA table for the regression analysis

The code includes detailed comments explaining each step and demonstrates proper error handling 
and statistical interpretation of the results. While the calculations may differ slightly from 
NIST's published results due to numerical precision differences, the sample illustrates the 
practical application of polynomial regression for scientific data analysis.


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
[C#](https://github.com/NumericsDotNet/quickstart-csharp/tree/net6.0/statistics/regression-analysis/polynomial-regression), [Visual Basic](https://github.com/NumericsDotNet/quickstart-visualbasic/tree/net6.0/statistics/regression-analysis/polynomial-regression), [IronPython](https://github.com/NumericsDotNet/quickstart-ironpython/tree/net6.0/statistics/regression-analysis/polynomial-regression).

You can find out more about the methods used in this sample from the Numerics.NET documentation.

### Numerics.NET User's Guide

- [Polynomial Regression](https://numerics.net/documentation/latest/statistics/regression-analysis/polynomial-regression)
- [Simple Linear Regression](https://numerics.net/documentation/latest/statistics/regression-analysis/simple-linear-regression)
- [Multiple Linear Regression](https://numerics.net/documentation/latest/statistics/regression-analysis/multiple-linear-regression)
- [Linear Curve Fitting](https://numerics.net/documentation/latest/mathematics/curve-fitting/linear-curve-fitting)

### Numerics.NET API Reference

- [PolynomialRegressionModel class](https://numerics.net/documentation/latest/reference/numerics.net.statistics.polynomialregressionmodel)
- [DataFrame&lt;R, C&gt; class](https://numerics.net/documentation/latest/reference/numerics.net.dataanalysis.dataframe-2)
- [Parameter&lt;T&gt; class](https://numerics.net/documentation/latest/reference/numerics.net.dataanalysis.parameter-1)
- [AnovaTable class](https://numerics.net/documentation/latest/reference/numerics.net.statistics.anovatable)
- [Numerics.NET.Statistics namespace](https://numerics.net/documentation/latest/reference/numerics.net.statistics)


## Troubleshooting

### Common Issues

- **Missing dependencies**: Make sure to run `dotnet restore` before building
- **License verification failed**: Ensure you have a valid trial key from [https://numerics.net/trial-key](https://numerics.net/trial-key)
- **Runtime errors**: Check that you're targeting the correct .NET version (.NET 6 or .NET 8)

### Need Help?

- Check the [Numerics.NET documentation](https://numerics.net/documentation/)
- Contact support at [support@numerics.net](mailto:support@numerics.net?subject=PolynomialRegression%20QuickStart%20Sample%20%28F%23%29)

## About Numerics.NET

Numerics.NET is a powerful numerical library for .NET that provides advanced mathematical 
functions and algorithms for scientific computing, data analysis, and machine learning.
See [numerics.net](https://numerics.net) for details.

---

_Last updated on 2025-05-06 3:03:10 PM (version 9.1.3)._
