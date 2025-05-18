# Simple Time Series

This sample illustrates how to perform simple operations on time series data using classes in the Numerics.NET.Statistics.TimeSeriesAnalysis namespace using Numerics.NET.

## Overview

This QuickStart sample demonstrates how to work with time series data using Numerics.NET. It shows basic operations
for loading, analyzing and transforming financial market data.

The sample loads historical stock price data from a CSV file into a time series data frame. It
demonstrates several key operations:

- Loading time series data from CSV files
- Accessing individual variables (columns) like Open, High, Low, Close prices and Volume
- Calculating basic statistics like mean prices
- Selecting data for specific time ranges
- Resampling time series to different frequencies (daily to monthly)
- Using different aggregation functions for each variable when resampling
  - First price of period for Open
  - Last price of period for Close  
  - Maximum price for High
  - Minimum price for Low
  - Sum for Volume

The code provides a practical example of handling financial market data, but the techniques shown can
be applied to any time-stamped data series.


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
[C#](https://github.com/NumericsDotNet/quickstart-csharp/tree/net6.0/statistics/time-series-analysis/simple-time-series), [Visual Basic](https://github.com/NumericsDotNet/quickstart-visualbasic/tree/net6.0/statistics/time-series-analysis/simple-time-series), [IronPython](https://github.com/NumericsDotNet/quickstart-ironpython/tree/net6.0/statistics/time-series-analysis/simple-time-series).

You can find out more about the methods used in this sample from the Numerics.NET documentation.

### Numerics.NET User's Guide

- [Constructing data frames](https://numerics.net/documentation/latest/data-analysis/data-frames/constructing-data-frames)
- [Other Time Series Functions](https://numerics.net/documentation/latest/statistics/time-series-analysis/other-time-series-functions)
- [Resampling](https://numerics.net/documentation/latest/data-analysis/working-with-time-series-data/resampling)
- [Delimited text files](https://numerics.net/documentation/latest/data-access/delimited-text-files)

### Numerics.NET API Reference

- [DataFrame&lt;R, C&gt; class](https://numerics.net/documentation/latest/reference/numerics.net.dataanalysis.dataframe-2)
- [Recurrence class](https://numerics.net/documentation/latest/reference/numerics.net.dataanalysis.recurrence)
- [AggregatorGroup class](https://numerics.net/documentation/latest/reference/numerics.net.dataanalysis.aggregatorgroup)
- [TimeSeriesFunctions class](https://numerics.net/documentation/latest/reference/numerics.net.statistics.timeseriesanalysis.timeseriesfunctions)
- [Text.DelimitedTextFile class](https://numerics.net/documentation/latest/reference/numerics.net.data.text.delimitedtextfile)
- [Numerics.NET.DataAnalysis namespace](https://numerics.net/documentation/latest/reference/numerics.net.dataanalysis)


## Troubleshooting

### Common Issues

- **Missing dependencies**: Make sure to run `dotnet restore` before building
- **License verification failed**: Ensure you have a valid trial key from [https://numerics.net/trial-key](https://numerics.net/trial-key)
- **Runtime errors**: Check that you're targeting the correct .NET version (.NET 6 or .NET 8)

### Need Help?

- Check the [Numerics.NET documentation](https://numerics.net/documentation/)
- Contact support at [support@numerics.net](mailto:support@numerics.net?subject=SimpleTimeSeries%20QuickStart%20Sample%20%28F%23%29)

## About Numerics.NET

Numerics.NET is a powerful numerical library for .NET that provides advanced mathematical 
functions and algorithms for scientific computing, data analysis, and machine learning.
See [numerics.net](https://numerics.net) for details.

---

_Last updated on 2025-05-06 3:03:10 PM (version 9.1.3)._
