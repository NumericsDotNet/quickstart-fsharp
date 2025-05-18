# Indexes and Labels

This sample illustrates how to use indexes to label the rows and columns of a data frame or matrix, or the elements of a vector using Numerics.NET.

## Overview

This QuickStart sample demonstrates how to use indexes to label and organize data in vectors and matrices in Numerics.NET.

The sample shows several key aspects of working with indexes:
- Creating indexes from arrays, numeric ranges, and date ranges
- Using indexes to label vector elements and matrix rows/columns
- Looking up positions of elements in an index both exactly and approximately
- Working with automatic alignment of vectors based on their indexes
- Handling calculations that preserve indexes through operations
- Creating interval-based indexes for categorization

The code illustrates how indexes enable intuitive data manipulation by allowing operations to be performed
based on labels rather than numeric positions. This is particularly useful when working with time series
data, categorical data, or any scenario where meaningful labels improve code readability and reduce errors.

The sample also demonstrates how indexes propagate through calculations and how they can be used with
matrices to provide meaningful row and column labels for better data organization and analysis.


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
[C#](https://github.com/NumericsDotNet/quickstart-csharp/tree/net462/data-analysis/indexes-and-labels), [Visual Basic](https://github.com/NumericsDotNet/quickstart-visualbasic/tree/net462/data-analysis/indexes-and-labels).

You can find out more about the methods used in this sample from the Numerics.NET documentation.

### Numerics.NET User's Guide

- [Data Frames](https://numerics.netdata-analysis/data-frames)
- [Vector Basics](https://numerics.netvector-and-matrix/vectors/vector-basics)
- [Indexes](https://numerics.netdata-analysis/indexes)
- [Working with Time Series Data](https://numerics.netdata-analysis/working-with-time-series-data)

### Numerics.NET API Reference

- [Index class](https://numerics.net/documentation/latest/reference/numerics.net.dataanalysis.index)
- [Index&lt;T&gt; class](https://numerics.net/documentation/latest/reference/numerics.net.dataanalysis.index-1)
- [DataFrame&lt;R, C&gt; class](https://numerics.net/documentation/latest/reference/numerics.net.dataanalysis.dataframe-2)
- [IDataFrame class](https://numerics.net/documentation/latest/reference/numerics.net.dataanalysis.idataframe)
- [Numerics.NET.DataAnalysis namespace](https://numerics.net/documentation/latest/reference/numerics.net.dataanalysis)


## Troubleshooting

### Common Issues

- **Missing dependencies**: Make sure to run `dotnet restore` before building
- **License verification failed**: Ensure you have a valid trial key from [https://numerics.net/trial-key](https://numerics.net/trial-key)
- **Runtime errors**: Check that you're targeting the correct .NET version (.NET 6 or .NET 8)

### Need Help?

- Check the [Numerics.NET documentation](https://numerics.net/documentation/)
- Contact support at [support@numerics.net](mailto:support@numerics.net?subject=IndexesAndLabels%20QuickStart%20Sample%20%28F%23%29)

## About Numerics.NET

Numerics.NET is a powerful numerical library for .NET that provides advanced mathematical 
functions and algorithms for scientific computing, data analysis, and machine learning.
See [numerics.net](https://numerics.net) for details.

---

_Last updated on 2025-05-06 3:03:10 PM (version 9.1.3)._
