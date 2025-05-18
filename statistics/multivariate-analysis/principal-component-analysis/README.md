# Principal Component Analysis (PCA)

This sample illustrates how to perform a Principal Component Analysis using classes in the Numerics.NET.Statistics.Multivariate namespace using Numerics.NET.

## Overview

This QuickStart sample demonstrates how to perform Principal Component Analysis (PCA) on a dataset using the 
Numerics.NET Statistics library.

The sample loads data from a text file containing depression study measurements and performs the 
following operations:

* Loads and prepares the data from a delimited text file
* Creates and fits a PCA model to the data
* Examines the eigenvalues and variance contributions of each principal component
* Shows how to determine the number of components needed to explain a given proportion of variance
* Displays the component vectors themselves
* Calculates and displays component scores
* Demonstrates how to use the components to predict/reconstruct the original data

The sample shows key PCA concepts including variance proportions, cumulative variance explained, 
component vectors, and scores. It illustrates how to interpret PCA results and use them for 
dimensionality reduction by selecting components that explain a target proportion of variance.

The code uses real-world depression study data to make the example concrete and practical. It 
shows common PCA workflow steps from data loading through analysis and prediction.


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
[C#](https://github.com/NumericsDotNet/quickstart-csharp/tree/net462/statistics/multivariate-analysis/principal-component-analysis), [Visual Basic](https://github.com/NumericsDotNet/quickstart-visualbasic/tree/net462/statistics/multivariate-analysis/principal-component-analysis), [IronPython](https://github.com/NumericsDotNet/quickstart-ironpython/tree/net462/statistics/multivariate-analysis/principal-component-analysis).

You can find out more about the methods used in this sample from the Numerics.NET documentation.

### Numerics.NET User's Guide

- [Principal Component Analysis](https://numerics.net/documentation/latest/statistics/multivariate-analysis/principal-component-analysis)
- [Delimited Text Files](https://numerics.net/documentation/latest/data-access/delimited-text-files)
- [Vectors and Matrices as Data Frames](https://numerics.net/documentation/latest/data-analysis/data-frames/vectors-and-matrices-as-data-frames)

### Numerics.NET API Reference

- [Multivariate.PrincipalComponentAnalysis class](https://numerics.net/documentation/latest/reference/numerics.net.statistics.multivariate.principalcomponentanalysis)
- [Multivariate.PrincipalComponent class](https://numerics.net/documentation/latest/reference/numerics.net.statistics.multivariate.principalcomponent)
- [DelimitedTextFile class](https://numerics.net/documentation/latest/reference/numerics.net.data.text.delimitedtextfile)
- [Numerics.NET.Statistics.Multivariate namespace](https://numerics.net/documentation/latest/reference/numerics.net.statistics.multivariate)


## Troubleshooting

### Common Issues

- **Missing dependencies**: Make sure to run `dotnet restore` before building
- **License verification failed**: Ensure you have a valid trial key from [https://numerics.net/trial-key](https://numerics.net/trial-key)
- **Runtime errors**: Check that you're targeting the correct .NET version (.NET 6 or .NET 8)

### Need Help?

- Check the [Numerics.NET documentation](https://numerics.net/documentation/)
- Contact support at [support@numerics.net](mailto:support@numerics.net?subject=PrincipalComponentAnalysis%20QuickStart%20Sample%20%28F%23%29)

## About Numerics.NET

Numerics.NET is a powerful numerical library for .NET that provides advanced mathematical 
functions and algorithms for scientific computing, data analysis, and machine learning.
See [numerics.net](https://numerics.net) for details.

---

_Last updated on 2025-05-06 3:03:10 PM (version 9.1.3)._
