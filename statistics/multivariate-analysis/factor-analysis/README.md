# Factor Analysis (FA)

This sample illustrates how to perform a Factor Analysis using classes in the Numerics.NET.Statistics.Multivariate namespace using Numerics.NET.

## Overview

This QuickStart sample demonstrates how to perform Factor Analysis (FA) on multivariate data using Numerics.NET.

The sample shows two common scenarios for factor analysis:

1. Analysis of raw data from a Stata dataset, demonstrating:
   - Loading and preprocessing data
   - Extracting factors and analyzing their contributions
   - Performing Varimax (orthogonal) rotation
   - Performing Promax (oblique) rotation with customizable power parameter
   - Examining factor loadings, uniqueness, and communalities
   - Analyzing factor correlations for oblique rotations

2. Analysis using a correlation matrix as input, showing:
   - Maximum likelihood extraction method
   - Initial and extracted communalities
   - Comparison of unrotated and rotated factor loadings
   
The sample includes detailed output formatting to match common statistical software output,
making it easy to verify results. It demonstrates proper handling of missing values and
provides examples of both formula-based and direct matrix-based model specification.


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
[C#](https://github.com/NumericsDotNet/quickstart-csharp/tree/net8.0/statistics/multivariate-analysis/factor-analysis), [Visual Basic](https://github.com/NumericsDotNet/quickstart-visualbasic/tree/net8.0/statistics/multivariate-analysis/factor-analysis).

You can find out more about the methods used in this sample from the Numerics.NET documentation.

### Numerics.NET User's Guide

- [Factor Analysis](https://numerics.net/documentation/latest/statistics/multivariate-analysis/factor-analysis)
- [Principal Component Analysis](https://numerics.net/documentation/latest/statistics/multivariate-analysis/principal-component-analysis)
- [Matrix Basics](https://numerics.net/documentation/latest/vector-and-matrix/matrices/matrix-basics)

### Numerics.NET API Reference

- [Multivariate.FactorAnalysis class](https://numerics.net/documentation/latest/reference/numerics.net.statistics.multivariate.factoranalysis)
- [Multivariate.PrincipalComponentAnalysis class](https://numerics.net/documentation/latest/reference/numerics.net.statistics.multivariate.principalcomponentanalysis)
- [Stata.StataFile class](https://numerics.net/documentation/latest/reference/numerics.net.data.stata.statafile)
- [Numerics.NET.Statistics.Multivariate namespace](https://numerics.net/documentation/latest/reference/numerics.net.statistics.multivariate)


## Troubleshooting

### Common Issues

- **Missing dependencies**: Make sure to run `dotnet restore` before building
- **License verification failed**: Ensure you have a valid trial key from [https://numerics.net/trial-key](https://numerics.net/trial-key)
- **Runtime errors**: Check that you're targeting the correct .NET version (.NET 6 or .NET 8)

### Need Help?

- Check the [Numerics.NET documentation](https://numerics.net/documentation/)
- Contact support at [support@numerics.net](mailto:support@numerics.net?subject=FactorAnalysis%20QuickStart%20Sample%20%28F%23%29)

## About Numerics.NET

Numerics.NET is a powerful numerical library for .NET that provides advanced mathematical 
functions and algorithms for scientific computing, data analysis, and machine learning.
See [numerics.net](https://numerics.net) for details.

---

_Last updated on 2025-05-06 3:03:10 PM (version 9.1.3)._
