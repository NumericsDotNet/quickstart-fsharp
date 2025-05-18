# Logistic Regression

This sample illustrates how to use the LogisticRegressionModel class to create logistic regression models using Numerics.NET.

## Overview

This QuickStart sample demonstrates how to perform binary and multinomial logistic regression analysis using the
LogisticRegressionModel class in Numerics.NET.

The sample shows two key examples:

1. A binary logistic regression model analyzing factors that determine low birth weight, using data
from Baystate Medical Center. The example demonstrates:
   - Loading data from fixed-width text files
   - Creating and fitting logistic regression models using both explicit variable lists and formulas
   - Handling categorical predictors
   - Interpreting model parameters and statistics
   - Performing likelihood ratio tests to compare nested models

2. A multinomial logistic regression example analyzing duration data with three response levels. This
example shows:
   - Working with categorical response variables
   - Specifying multinomial models
   - Interpreting results with multiple response levels
   - Testing global model significance

The sample includes detailed output of parameter estimates, standard errors, test statistics, and
p-values, demonstrating how to access and interpret the full range of model diagnostics available in
Numerics.NET's logistic regression implementation.


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
[C#](https://github.com/NumericsDotNet/quickstart-csharp/tree/net6.0/statistics/regression-analysis/logistic-regression), [Visual Basic](https://github.com/NumericsDotNet/quickstart-visualbasic/tree/net6.0/statistics/regression-analysis/logistic-regression), [IronPython](https://github.com/NumericsDotNet/quickstart-ironpython/tree/net6.0/statistics/regression-analysis/logistic-regression).

You can find out more about the methods used in this sample from the Numerics.NET documentation.

### Numerics.NET User's Guide

- [Logistic Regression](https://numerics.net/documentation/latest/statistics/regression-analysis/logistic-regression)
- [Hypothesis Test Basics](https://numerics.net/documentation/latest/statistics/hypothesis-tests/hypothesis-test-basics)
- [Fixed-width Text Files](https://numerics.net/documentation/latest/data-access/fixed-width-text-files)
- [Defining models using formulas](https://numerics.net/documentation/latest/statistics/statistical-models/defining-models-using-formulas)

### Numerics.NET API Reference

- [LogisticRegressionModel class](https://numerics.net/documentation/latest/reference/numerics.net.statistics.logisticregressionmodel)
- [DataFrame&lt;R, C&gt; class](https://numerics.net/documentation/latest/reference/numerics.net.dataanalysis.dataframe-2)
- [DelimitedTextFile class](https://numerics.net/documentation/latest/reference/numerics.net.data.text.delimitedtextfile)
- [Parameter&lt;T&gt; class](https://numerics.net/documentation/latest/reference/numerics.net.dataanalysis.parameter-1)
- [Numerics.NET.Statistics namespace](https://numerics.net/documentation/latest/reference/numerics.net.statistics)


## Troubleshooting

### Common Issues

- **Missing dependencies**: Make sure to run `dotnet restore` before building
- **License verification failed**: Ensure you have a valid trial key from [https://numerics.net/trial-key](https://numerics.net/trial-key)
- **Runtime errors**: Check that you're targeting the correct .NET version (.NET 6 or .NET 8)

### Need Help?

- Check the [Numerics.NET documentation](https://numerics.net/documentation/)
- Contact support at [support@numerics.net](mailto:support@numerics.net?subject=LogisticRegression%20QuickStart%20Sample%20%28F%23%29)

## About Numerics.NET

Numerics.NET is a powerful numerical library for .NET that provides advanced mathematical 
functions and algorithms for scientific computing, data analysis, and machine learning.
See [numerics.net](https://numerics.net) for details.

---

_Last updated on 2025-05-06 3:03:10 PM (version 9.1.3)._
