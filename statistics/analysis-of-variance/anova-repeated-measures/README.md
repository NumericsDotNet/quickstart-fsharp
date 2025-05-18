# Repeated Measures Anova

This sample illustrates how to use the OneWayRAnovaModel class to perform a one-way analysis of variance with repeated measures using Numerics.NET.

## Overview

This QuickStart sample demonstrates how to perform a one-way analysis of variance (ANOVA) with repeated measures using 
the OneWayRAnovaModel class from Numerics.NET.

The sample analyzes a study investigating the effects of four different drugs on test scores across five 
subjects. Each subject is tested with all four drugs, making this a repeated measures design. The code 
shows how to:

- Create a DataFrame from sample data containing subject IDs, drug treatments, and test scores
- Set up and fit a one-way repeated measures ANOVA model using both direct specification and formula syntax
- Check if the experimental design is balanced
- Display the ANOVA results table showing sources of variation, degrees of freedom, and significance
- Access and analyze group means and variance for different treatment levels
- Extract overall summary statistics like the grand mean and total number of observations

The example illustrates key concepts in repeated measures ANOVA including:
- Working with within-subjects factors
- Handling repeated observations on the same subjects
- Analyzing treatment effects while accounting for individual differences
- Interpreting ANOVA results for repeated measures designs


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
[C#](https://github.com/NumericsDotNet/quickstart-csharp/tree/net6.0/statistics/analysis-of-variance/anova-repeated-measures), [Visual Basic](https://github.com/NumericsDotNet/quickstart-visualbasic/tree/net6.0/statistics/analysis-of-variance/anova-repeated-measures), [IronPython](https://github.com/NumericsDotNet/quickstart-ironpython/tree/net6.0/statistics/analysis-of-variance/anova-repeated-measures).

You can find out more about the methods used in this sample from the Numerics.NET documentation.

### Numerics.NET User's Guide

- [One-Way ANOVA with Repeated Measures](https://numerics.net/documentation/latest/statistics/analysis-of-variance/one-way-anova-with-repeated-measures)
- [ANOVA Models](https://numerics.net/documentation/latest/statistics/analysis-of-variance/anova-models)
- [Defining models using formulas](https://numerics.net/documentation/latest/statistics/statistical-models/defining-models-using-formulas)

### Numerics.NET API Reference

- [OneWayRAnovaModel class](https://numerics.net/documentation/latest/reference/numerics.net.statistics.onewayranovamodel)
- [DataFrame&lt;R, C&gt; class](https://numerics.net/documentation/latest/reference/numerics.net.dataanalysis.dataframe-2)
- [Cell structure](https://numerics.net/documentation/latest/reference/numerics.net.statistics.cell)
- [AnovaTable class](https://numerics.net/documentation/latest/reference/numerics.net.statistics.anovatable)
- [Numerics.NET.Statistics namespace](https://numerics.net/documentation/latest/reference/numerics.net.statistics)


## Troubleshooting

### Common Issues

- **Missing dependencies**: Make sure to run `dotnet restore` before building
- **License verification failed**: Ensure you have a valid trial key from [https://numerics.net/trial-key](https://numerics.net/trial-key)
- **Runtime errors**: Check that you're targeting the correct .NET version (.NET 6 or .NET 8)

### Need Help?

- Check the [Numerics.NET documentation](https://numerics.net/documentation/)
- Contact support at [support@numerics.net](mailto:support@numerics.net?subject=AnovaRepeatedMeasures%20QuickStart%20Sample%20%28F%23%29)

## About Numerics.NET

Numerics.NET is a powerful numerical library for .NET that provides advanced mathematical 
functions and algorithms for scientific computing, data analysis, and machine learning.
See [numerics.net](https://numerics.net) for details.

---

_Last updated on 2025-05-06 3:03:10 PM (version 9.1.3)._
