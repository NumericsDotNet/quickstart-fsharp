# Manipulating Columns

This sample illustrates how to transform and manipulate the columns of a data frame using Numerics.NET.

## Overview

This QuickStart sample demonstrates how to perform various transformations and manipulations on data frame columns 
using Numerics.NET.

The sample shows common data wrangling operations including:
- Adding and removing columns in a data frame
- Renaming columns individually and using patterns
- Transforming column data using mathematical functions
- Working with multiple columns simultaneously
- Handling missing values by replacing them with group means
- Comparing row-based vs column-based operations for performance

The code uses a sample data frame with a DateTime index and random values to illustrate these
operations. It demonstrates both simple transformations like adding/removing columns as well as more
complex operations like grouping and aggregation. The sample includes examples of both efficient
column-based operations and less efficient but sometimes necessary row-based operations.

Throughout the sample, various DataFrame methods are demonstrated including AddColumn, RemoveColumn,
MapAndAppend, MapAndInsertAfter, and others. The sample also shows how to work with missing values
and perform group-based calculations.


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
[C#](https://github.com/NumericsDotNet/quickstart-csharp/tree/net8.0/data-analysis/manipulating-columns), [Visual Basic](https://github.com/NumericsDotNet/quickstart-visualbasic/tree/net8.0/data-analysis/manipulating-columns).

You can find out more about the methods used in this sample from the Numerics.NET documentation.

### Numerics.NET User's Guide

- [Constructing data frames](https://numerics.net/documentation/latest/data-analysis/data-frames/constructing-data-frames)
- [Basic Operations on Data Frames](https://numerics.net/documentation/latest/data-analysis/data-frames/basic-operations-on-data-frames)
- [Transforming columns](https://numerics.net/documentation/latest/data-analysis/data-wrangling/transforming-columns)
- [Groupings](https://numerics.net/documentation/latest/data-analysis/grouping-and-aggregation/groupings)

### Numerics.NET API Reference

- [DataFrame&lt;R, C&gt; class](https://numerics.net/documentation/latest/reference/numerics.net.dataanalysis.dataframe-2)
- [Vector&lt;T&gt; class](https://numerics.net/documentation/latest/reference/numerics.net.vector-1)
- [Index&lt;T&gt; class](https://numerics.net/documentation/latest/reference/numerics.net.dataanalysis.index-1)
- [DataFrameRow&lt;R, C&gt; class](https://numerics.net/documentation/latest/reference/numerics.net.dataanalysis.dataframerow-2)
- [Numerics.NET.DataAnalysis namespace](https://numerics.net/documentation/latest/reference/numerics.net.dataanalysis)


## Troubleshooting

### Common Issues

- **Missing dependencies**: Make sure to run `dotnet restore` before building
- **License verification failed**: Ensure you have a valid trial key from [https://numerics.net/trial-key](https://numerics.net/trial-key)
- **Runtime errors**: Check that you're targeting the correct .NET version (.NET 6 or .NET 8)

### Need Help?

- Check the [Numerics.NET documentation](https://numerics.net/documentation/)
- Contact support at [support@numerics.net](mailto:support@numerics.net?subject=ManipulatingColumns%20QuickStart%20Sample%20%28F%23%29)

## About Numerics.NET

Numerics.NET is a powerful numerical library for .NET that provides advanced mathematical 
functions and algorithms for scientific computing, data analysis, and machine learning.
See [numerics.net](https://numerics.net) for details.

---

_Last updated on 2025-05-06 3:03:10 PM (version 9.1.3)._
