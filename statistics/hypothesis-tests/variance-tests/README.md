# Variance Tests

This sample illustrates how to perform hypothesis tests involving the standard deviation or variance using classes in our .NET statistical library using Numerics.NET.

## Overview

This QuickStart sample demonstrates how to perform statistical hypothesis tests involving variances and 
standard deviations using Numerics.NET.

The sample works with test scores from two groups of students to illustrate two key variance-related 
tests:

1. A one-sample chi-square test to determine if a group's variance is greater than a specific value
2. A two-sample F-test to compare the variances between two groups

The code shows how to:
- Create numerical variables from test score data
- Calculate basic statistics like mean and standard deviation
- Perform a one-sample chi-square test with configurable significance levels
- Generate confidence intervals for variance estimates
- Compare variances between two groups using the F-test
- Interpret test results including test statistics, p-values, and hypothesis rejection decisions

The sample includes examples of setting different significance levels and obtaining corresponding 
confidence intervals, demonstrating the flexibility of the testing framework. All results are clearly
formatted and displayed with appropriate precision.


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
[C#](https://github.com/NumericsDotNet/quickstart-csharp/tree/net8.0/statistics/hypothesis-tests/variance-tests), [Visual Basic](https://github.com/NumericsDotNet/quickstart-visualbasic/tree/net8.0/statistics/hypothesis-tests/variance-tests), [IronPython](https://github.com/NumericsDotNet/quickstart-ironpython/tree/net8.0/statistics/hypothesis-tests/variance-tests).

You can find out more about the methods used in this sample from the Numerics.NET documentation.

### Numerics.NET User's Guide

- [Testing Variances](https://numerics.netstatistics/hypothesis-tests/testing-variances)
- [Hypothesis Test Basics](https://numerics.netstatistics/hypothesis-tests/hypothesis-test-basics)
- [Continuous Distributions](https://numerics.netstatistics/continuous-distributions/continuous-distributions)

### Numerics.NET API Reference

- [FTest class](https://numerics.net/documentation/latest/reference/numerics.net.statistics.tests.ftest)
- [OneSampleChiSquareTest class](https://numerics.net/documentation/latest/reference/numerics.net.statistics.tests.onesamplechisquaretest)
- [HypothesisTest class](https://numerics.net/documentation/latest/reference/numerics.net.statistics.tests.hypothesistest)
- [Numerics.NET.Statistics.Tests namespace](https://numerics.net/documentation/latest/reference/numerics.net.statistics.tests)


## Troubleshooting

### Common Issues

- **Missing dependencies**: Make sure to run `dotnet restore` before building
- **License verification failed**: Ensure you have a valid trial key from [https://numerics.net/trial-key](https://numerics.net/trial-key)
- **Runtime errors**: Check that you're targeting the correct .NET version (.NET 6 or .NET 8)

### Need Help?

- Check the [Numerics.NET documentation](https://numerics.net/documentation/)
- Contact support at [support@numerics.net](mailto:support@numerics.net?subject=VarianceTests%20QuickStart%20Sample%20%28F%23%29)

## About Numerics.NET

Numerics.NET is a powerful numerical library for .NET that provides advanced mathematical 
functions and algorithms for scientific computing, data analysis, and machine learning.
See [numerics.net](https://numerics.net) for details.

---

_Last updated on 2025-05-06 3:03:10 PM (version 9.1.3)._
