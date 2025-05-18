# Generalized Linear Models

This sample illustrates how to use the GeneralizedLinearModel class to compute probit, Poisson and similar regression models using Numerics.NET.

## Overview

This QuickStart sample demonstrates how to use generalized linear models (GLM) in Numerics.NET to analyze 
relationships between variables with non-normal distributions.

The sample walks through two complete examples:

1. A Poisson regression analyzing student attendance data to examine relationships between absences and 
factors like math scores, language arts scores, and gender. This demonstrates handling count data using 
the canonical link function.

2. A probit regression analyzing graduate school admissions data to model the probability of admission 
based on GRE scores, GPA, and school ranking. This shows how to work with binary outcome data using 
the probit link function.

For each example, the code shows how to:
- Load and prepare the data
- Specify the model family and link function 
- Fit the model
- Extract and interpret parameter estimates, standard errors, and p-values
- Calculate confidence intervals
- Obtain model fit statistics like log likelihood and information criteria

The sample includes detailed comments explaining each step and interpreting the results, making it an
excellent introduction to generalized linear modeling in Numerics.NET.


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
[C#](https://github.com/NumericsDotNet/quickstart-csharp/tree/net6.0/statistics/regression-analysis/generalized-linear-models), [Visual Basic](https://github.com/NumericsDotNet/quickstart-visualbasic/tree/net6.0/statistics/regression-analysis/generalized-linear-models).

You can find out more about the methods used in this sample from the Numerics.NET documentation.

### Numerics.NET User's Guide

- [Generalized Linear Models](https://numerics.net/documentation/latest/statistics/regression-analysis/generalized-linear-models)
- [Hypothesis Test Basics](https://numerics.net/documentation/latest/statistics/hypothesis-tests/hypothesis-test-basics)
- [Poisson Distribution](https://numerics.net/documentation/latest/statistics/discrete-distributions/poisson-distribution)

### Numerics.NET API Reference

- [GeneralizedLinearModel class](https://numerics.net/documentation/latest/reference/numerics.net.statistics.generalizedlinearmodel)
- [DataFrame&lt;R, C&gt; class](https://numerics.net/documentation/latest/reference/numerics.net.dataanalysis.dataframe-2)
- [DelimitedTextFile class](https://numerics.net/documentation/latest/reference/numerics.net.data.text.delimitedtextfile)
- [LinkFunction class](https://numerics.net/documentation/latest/reference/numerics.net.statistics.linkfunction)
- [Numerics.NET.Statistics namespace](https://numerics.net/documentation/latest/reference/numerics.net.statistics)


## Troubleshooting

### Common Issues

- **Missing dependencies**: Make sure to run `dotnet restore` before building
- **License verification failed**: Ensure you have a valid trial key from [https://numerics.net/trial-key](https://numerics.net/trial-key)
- **Runtime errors**: Check that you're targeting the correct .NET version (.NET 6 or .NET 8)

### Need Help?

- Check the [Numerics.NET documentation](https://numerics.net/documentation/)
- Contact support at [support@numerics.net](mailto:support@numerics.net?subject=GeneralizedLinearModels%20QuickStart%20Sample%20%28F%23%29)

## About Numerics.NET

Numerics.NET is a powerful numerical library for .NET that provides advanced mathematical 
functions and algorithms for scientific computing, data analysis, and machine learning.
See [numerics.net](https://numerics.net) for details.

---

_Last updated on 2025-05-06 3:03:10 PM (version 9.1.3)._
