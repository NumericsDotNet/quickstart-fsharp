# Grouping and Aggregation

This sample illustrates how to group data and how to compute aggregates over groups and entire datasets. using Numerics.NET.

## Overview

This QuickStart sample demonstrates how to perform grouping operations and compute aggregate statistics on 
datasets using Numerics.NET.

The sample uses the classic Titanic dataset to illustrate various grouping and aggregation 
techniques. It covers:

- Computing basic statistics like mean, count and standard deviation across entire datasets
- Creating custom aggregation functions for specialized calculations
- Grouping data by categorical variables and computing group-wise statistics
- Working with different types of windows including:
  - Moving (rolling) windows for time series analysis
  - Expanding windows that grow over time
  - Fixed-width time windows
- Resampling time series data to different frequencies
- Creating pivot tables for cross-tabulation analysis

The sample shows both simple aggregations on vectors and matrices as well as more complex 
operations on data frames. It demonstrates how to work with datetime indexes and time-based 
groupings, which are essential for time series analysis. The code includes examples of computing 
survival rates by passenger class in the Titanic dataset using different approaches, showing the 
flexibility of the grouping and aggregation capabilities in Numerics.NET.


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
[C#](https://github.com/NumericsDotNet/quickstart-csharp/tree/net8.0/data-analysis/grouping-and-aggregation), [Visual Basic](https://github.com/NumericsDotNet/quickstart-visualbasic/tree/net8.0/data-analysis/grouping-and-aggregation).

You can find out more about the methods used in this sample from the Numerics.NET documentation.

### Numerics.NET User's Guide

- [Constructing data frames](https://numerics.net/documentation/latest/data-analysis/data-frames/constructing-data-frames)
- [Groupings](https://numerics.net/documentation/latest/data-analysis/grouping-and-aggregation/groupings)
- [Aggregators](https://numerics.net/documentation/latest/data-analysis/grouping-and-aggregation/aggregators)
- [Resampling](https://numerics.net/documentation/latest/data-analysis/working-with-time-series-data/resampling)

### Numerics.NET API Reference

- [DataFrame&lt;R, C&gt; class](https://numerics.net/documentation/latest/reference/numerics.net.dataanalysis.dataframe-2)
- [Aggregators class](https://numerics.net/documentation/latest/reference/numerics.net.dataanalysis.aggregators)
- [Grouping&lt;T&gt; class](https://numerics.net/documentation/latest/reference/numerics.net.dataanalysis.grouping-1)
- [Pivot&lt;R, C&gt; class](https://numerics.net/documentation/latest/reference/numerics.net.dataanalysis.pivot-2)
- [Numerics.NET.DataAnalysis namespace](https://numerics.net/documentation/latest/reference/numerics.net.dataanalysis)


## Troubleshooting

### Common Issues

- **Missing dependencies**: Make sure to run `dotnet restore` before building
- **License verification failed**: Ensure you have a valid trial key from [https://numerics.net/trial-key](https://numerics.net/trial-key)
- **Runtime errors**: Check that you're targeting the correct .NET version (.NET 6 or .NET 8)

### Need Help?

- Check the [Numerics.NET documentation](https://numerics.net/documentation/)
- Contact support at [support@numerics.net](mailto:support@numerics.net?subject=GroupingAndAggregation%20QuickStart%20Sample%20%28F%23%29)

## About Numerics.NET

Numerics.NET is a powerful numerical library for .NET that provides advanced mathematical 
functions and algorithms for scientific computing, data analysis, and machine learning.
See [numerics.net](https://numerics.net) for details.

---

_Last updated on 2025-05-06 3:03:10 PM (version 9.1.3)._
