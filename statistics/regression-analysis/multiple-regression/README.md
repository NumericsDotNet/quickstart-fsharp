# Multiple Linear Regression

This sample illustrates how to use the LinearRegressionModel class to perform a multiple linear regression using Numerics.NET.

## Overview

This QuickStart sample demonstrates how to perform multiple linear regression analysis using the 
LinearRegressionModel class in Numerics.NET.

The sample uses a dataset containing test scores of 200 high school students to build a regression model 
predicting science scores based on math, reading, and social studies scores along with gender. It shows:

- How to load data from a CSV file into a DataFrame
- Creating regression models using both explicit variable lists and formula notation
- Fitting the model and accessing regression parameters
- Getting parameter estimates, standard errors, t-statistics and p-values
- Calculating confidence intervals for parameters
- Accessing model statistics like R-squared and F-statistics
- Generating ANOVA tables and model summaries
- Working with model parameters both by index and by name

The sample demonstrates both basic model building and more advanced statistical analysis techniques,
making it useful for both beginners and those needing more sophisticated regression analysis.


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
[C#](https://github.com/NumericsDotNet/quickstart-csharp/tree/net8.0/statistics/regression-analysis/multiple-regression), [Visual Basic](https://github.com/NumericsDotNet/quickstart-visualbasic/tree/net8.0/statistics/regression-analysis/multiple-regression), [IronPython](https://github.com/NumericsDotNet/quickstart-ironpython/tree/net8.0/statistics/regression-analysis/multiple-regression).

You can find out more about the methods used in this sample from the Numerics.NET documentation.

### Numerics.NET User's Guide

- [Multiple Linear Regression](https://numerics.net/documentation/latest/statistics/regression-analysis/multiple-linear-regression)
- [Linear Curve Fitting](https://numerics.net/documentation/latest/statistics/regression-analysis/linear-curve-fitting)
- [Defining models using formulas](https://numerics.net/documentation/latest/statistics/statistical-models/defining-models-using-formulas)

### Numerics.NET API Reference

- [LinearRegressionModel class](https://numerics.net/documentation/latest/reference/numerics.net.statistics.linearregressionmodel)
- [DataFrame&lt;R, C&gt; class](https://numerics.net/documentation/latest/reference/numerics.net.dataanalysis.dataframe-2)
- [Text.DelimitedTextFile class](https://numerics.net/documentation/latest/reference/numerics.net.data.text.delimitedtextfile)
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
- Contact support at [support@numerics.net](mailto:support@numerics.net?subject=MultipleRegression%20QuickStart%20Sample%20%28F%23%29)

## About Numerics.NET

Numerics.NET is a powerful numerical library for .NET that provides advanced mathematical 
functions and algorithms for scientific computing, data analysis, and machine learning.
See [numerics.net](https://numerics.net) for details.

---

_Last updated on 2025-05-06 3:03:10 PM (version 9.1.3)._
