# Sorting and Filtering

This sample illustrates how to sort and filter data used for data analysis using Numerics.NET.

## Overview

This QuickStart sample demonstrates how to perform basic sorting and filtering operations on data frames in Numerics.NET.

The sample loads time series data from a CSV file containing Microsoft stock price information and shows how 
to:
- Extract strongly-typed vectors from data frame columns
- Filter data using different approaches:
  - Selecting rows by specific keys
  - Selecting rows within a date range
  - Using boolean masks to filter based on conditions
  - Combining filters with logical operations
  - Finding nearest matches when working with time-based indices
- Sort data:
  - Sorting entire data frames by column values
  - Getting top/bottom values from vectors

The sample illustrates both simple and advanced filtering techniques, showing how to combine multiple
conditions and work with time series data efficiently. It also demonstrates different ways to access and
manipulate data frame contents using strongly-typed vectors.


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
[C#](https://github.com/NumericsDotNet/quickstart-csharp/tree/net8.0/data-analysis/sorting-and-filtering), [Visual Basic](https://github.com/NumericsDotNet/quickstart-visualbasic/tree/net8.0/data-analysis/sorting-and-filtering), [IronPython](https://github.com/NumericsDotNet/quickstart-ironpython/tree/net8.0/data-analysis/sorting-and-filtering).

You can find out more about the methods used in this sample from the Numerics.NET documentation.

### Numerics.NET User's Guide

- [Sorting And Filtering](https://numerics.net/documentation/latest/data-analysis/data-wrangling/sorting-and-filtering)
- [Basic Operations on Data Frames](https://numerics.net/documentation/latest/data-analysis/data-frames/basic-operations-on-data-frames)
- [Resampling](https://numerics.net/documentation/latest/data-analysis/working-with-time-series-data/resampling)

### Numerics.NET API Reference

- [DataFrame&lt;R, C&gt; class](https://numerics.net/documentation/latest/reference/numerics.net.dataanalysis.dataframe-2)
- [Text.DelimitedTextFile class](https://numerics.net/documentation/latest/reference/numerics.net.data.text.delimitedtextfile)
- [Index&lt;T&gt; class](https://numerics.net/documentation/latest/reference/numerics.net.dataanalysis.index-1)
- [Numerics.NET.DataAnalysis namespace](https://numerics.net/documentation/latest/reference/numerics.net.dataanalysis)


## Troubleshooting

### Common Issues

- **Missing dependencies**: Make sure to run `dotnet restore` before building
- **License verification failed**: Ensure you have a valid trial key from [https://numerics.net/trial-key](https://numerics.net/trial-key)
- **Runtime errors**: Check that you're targeting the correct .NET version (.NET 6 or .NET 8)

### Need Help?

- Check the [Numerics.NET documentation](https://numerics.net/documentation/)
- Contact support at [support@numerics.net](mailto:support@numerics.net?subject=SortingAndFiltering%20QuickStart%20Sample%20%28F%23%29)

## About Numerics.NET

Numerics.NET is a powerful numerical library for .NET that provides advanced mathematical 
functions and algorithms for scientific computing, data analysis, and machine learning.
See [numerics.net](https://numerics.net) for details.

---

_Last updated on 2025-05-06 3:03:10 PM (version 9.1.3)._
