# Mean Tests

This sample illustrates how to use various tests for the mean of one or more sanples using classes in the Numerics.NET.Statistics.Tests namespace using Numerics.NET.

## Overview

This QuickStart sample demonstrates how to perform statistical hypothesis testing on sample means using the 
Numerics.NET.Statistics.Tests namespace.

The sample works with a scenario involving test scores from two groups of students compared against a
national average. It shows three different approaches to testing means:

1. One-sample z-test: Used when comparing a sample mean to a known population mean and standard
   deviation. The sample demonstrates how to:
   - Create a test using sample data and population parameters
   - Calculate and interpret test statistics and p-values
   - Work with different significance levels
   - Generate confidence intervals

2. One-sample t-test: Used when comparing a sample mean to a population mean when the population
   standard deviation is unknown. The example shows:
   - How to construct and execute the test
   - Interpreting test results
   - Generating confidence intervals

3. Two-sample t-test: Used for comparing means between two independent samples. The sample shows:
   - How to set up the test with two sample groups
   - Interpreting the results to determine if the groups differ significantly

Throughout the sample, you'll learn how to:
- Work with numerical data using Vector objects
- Calculate basic statistics like means and standard deviations
- Set up and run different types of hypothesis tests
- Interpret test results using p-values and confidence intervals
- Make statistical decisions using different significance levels


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
[C#](https://github.com/NumericsDotNet/quickstart-csharp/tree/net8.0/statistics/hypothesis-tests/mean-tests), [Visual Basic](https://github.com/NumericsDotNet/quickstart-visualbasic/tree/net8.0/statistics/hypothesis-tests/mean-tests), [IronPython](https://github.com/NumericsDotNet/quickstart-ironpython/tree/net8.0/statistics/hypothesis-tests/mean-tests).

You can find out more about the methods used in this sample from the Numerics.NET documentation.

### Numerics.NET User's Guide

- [Hypothesis Test Basics](https://numerics.netstatistics/hypothesis-tests/hypothesis-test-basics)
- [Testing Means](https://numerics.netstatistics/hypothesis-tests/testing-means)
- [Statistical Variables](https://numerics.netstatistics/statistical-variables)

### Numerics.NET API Reference

- [OneSampleZTest class](https://numerics.net/documentation/latest/reference/numerics.net.statistics.tests.onesampleztest)
- [OneSampleTTest class](https://numerics.net/documentation/latest/reference/numerics.net.statistics.tests.onesamplettest)
- [TwoSampleTTest class](https://numerics.net/documentation/latest/reference/numerics.net.statistics.tests.twosamplettest)
- [HypothesisTest class](https://numerics.net/documentation/latest/reference/numerics.net.statistics.tests.hypothesistest)
- [Numerics.NET.Statistics.Tests namespace](https://numerics.net/documentation/latest/reference/numerics.net.statistics.tests)


## Troubleshooting

### Common Issues

- **Missing dependencies**: Make sure to run `dotnet restore` before building
- **License verification failed**: Ensure you have a valid trial key from [https://numerics.net/trial-key](https://numerics.net/trial-key)
- **Runtime errors**: Check that you're targeting the correct .NET version (.NET 6 or .NET 8)

### Need Help?

- Check the [Numerics.NET documentation](https://numerics.net/documentation/)
- Contact support at [support@numerics.net](mailto:support@numerics.net?subject=MeanTests%20QuickStart%20Sample%20%28F%23%29)

## About Numerics.NET

Numerics.NET is a powerful numerical library for .NET that provides advanced mathematical 
functions and algorithms for scientific computing, data analysis, and machine learning.
See [numerics.net](https://numerics.net) for details.

---

_Last updated on 2025-05-06 3:03:10 PM (version 9.1.3)._
