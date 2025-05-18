# Histograms

This sample illustrates how to create histograms using the Histogram class in the Numerics.NET.DataAnalysis namespace using Numerics.NET.

## Overview

This QuickStart sample demonstrates how to create and work with histograms using the Histogram class in 
Numerics.NET.

The sample shows several different ways to create histograms:
- Creating histograms with evenly spaced bins by specifying bounds and bin count
- Creating histograms with explicitly specified bin boundaries
- Creating histograms using Index objects to define bins
- Creating histograms for categorical data

It demonstrates key histogram operations including:
- Adding data to histograms using the Tabulate method
- Incrementing individual bins
- Accessing bin information like bounds and counts
- Finding which bin contains a specific value
- Iterating through bins and their values
- Working with both numerical and categorical data

The sample uses a practical example of analyzing test scores to illustrate these concepts. It shows how
to create different binning strategies and how to work with the resulting histogram data structures.


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
[C#](https://github.com/NumericsDotNet/quickstart-csharp/tree/net462/data-analysis/histograms), [Visual Basic](https://github.com/NumericsDotNet/quickstart-visualbasic/tree/net462/data-analysis/histograms), [IronPython](https://github.com/NumericsDotNet/quickstart-ironpython/tree/net462/data-analysis/histograms).

You can find out more about the methods used in this sample from the Numerics.NET documentation.

### Numerics.NET User's Guide

- [Histograms](https://numerics.net/documentation/latest/data-analysis/working-with-categorical-data/histograms)
- [Constructing data frames](https://numerics.net/documentation/latest/data-analysis/data-frames/constructing-data-frames)
- [Numerical Variables](https://numerics.net/documentation/latest/statistics/numerical-variables)

### Numerics.NET API Reference

- [Histogram class](https://numerics.net/documentation/latest/reference/numerics.net.dataanalysis.histogram)
- [Index class](https://numerics.net/documentation/latest/reference/numerics.net.dataanalysis.index)
- [Numerics.NET.DataAnalysis namespace](https://numerics.net/documentation/latest/reference/numerics.net.dataanalysis)


## Troubleshooting

### Common Issues

- **Missing dependencies**: Make sure to run `dotnet restore` before building
- **License verification failed**: Ensure you have a valid trial key from [https://numerics.net/trial-key](https://numerics.net/trial-key)
- **Runtime errors**: Check that you're targeting the correct .NET version (.NET 6 or .NET 8)

### Need Help?

- Check the [Numerics.NET documentation](https://numerics.net/documentation/)
- Contact support at [support@numerics.net](mailto:support@numerics.net?subject=Histograms%20QuickStart%20Sample%20%28F%23%29)

## About Numerics.NET

Numerics.NET is a powerful numerical library for .NET that provides advanced mathematical 
functions and algorithms for scientific computing, data analysis, and machine learning.
See [numerics.net](https://numerics.net) for details.

---

_Last updated on 2025-05-06 3:03:10 PM (version 9.1.3)._
