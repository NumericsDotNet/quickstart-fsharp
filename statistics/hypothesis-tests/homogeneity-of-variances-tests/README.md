# Homogeneity Of Variances Tests

This sample illustrates how to test a collection of variables for equal variances using classes in the Numerics.NET.Statistics.Tests namespace using Numerics.NET.

## Overview

This QuickStart sample demonstrates how to test whether multiple groups of data have equal variances using
both Bartlett's test and Levene's test implemented in Numerics.NET.

The sample uses a practical example of quality control in manufacturing, analyzing measurements 
of gear diameters from 10 different production batches. It shows how to:

- Set up data for homogeneity of variance tests
- Perform Bartlett's test for equal variances
- Perform Levene's test using different measures of location (mean, median, trimmed mean)
- Interpret test results including test statistics, p-values and critical values
- Compare the characteristics of both tests

The example illustrates an important application in quality control and ANOVA, where equal 
variances across groups is a key assumption. It demonstrates both the faster but more 
restrictive Bartlett's test and the more robust but computationally intensive Levene's test.
The sample includes detailed comments explaining the advantages and limitations of each approach.


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
[C#](https://github.com/NumericsDotNet/quickstart-csharp/tree/net8.0/statistics/hypothesis-tests/homogeneity-of-variances-tests), [Visual Basic](https://github.com/NumericsDotNet/quickstart-visualbasic/tree/net8.0/statistics/hypothesis-tests/homogeneity-of-variances-tests), [IronPython](https://github.com/NumericsDotNet/quickstart-ironpython/tree/net8.0/statistics/hypothesis-tests/homogeneity-of-variances-tests).

You can find out more about the methods used in this sample from the Numerics.NET documentation.

### Numerics.NET User's Guide

- [Testing Homogeneity of Variances](https://numerics.net/documentation/latest/statistics/hypothesis-tests/testing-homogeneity-of-variances)
- [Testing Variances](https://numerics.net/documentation/latest/statistics/hypothesis-tests/testing-variances)
- [Hypothesis Test Basics](https://numerics.net/documentation/latest/statistics/hypothesis-tests/hypothesis-test-basics)

### Numerics.NET API Reference

- [LeveneTest class](https://numerics.net/documentation/latest/reference/numerics.net.statistics.tests.levenetest)
- [BartlettTest class](https://numerics.net/documentation/latest/reference/numerics.net.statistics.tests.bartletttest)
- [HypothesisTest class](https://numerics.net/documentation/latest/reference/numerics.net.statistics.tests.hypothesistest)
- [Numerics.NET.Statistics.Tests namespace](https://numerics.net/documentation/latest/reference/numerics.net.statistics.tests)


## Troubleshooting

### Common Issues

- **Missing dependencies**: Make sure to run `dotnet restore` before building
- **License verification failed**: Ensure you have a valid trial key from [https://numerics.net/trial-key](https://numerics.net/trial-key)
- **Runtime errors**: Check that you're targeting the correct .NET version (.NET 6 or .NET 8)

### Need Help?

- Check the [Numerics.NET documentation](https://numerics.net/documentation/)
- Contact support at [support@numerics.net](mailto:support@numerics.net?subject=HomogeneityOfVariancesTests%20QuickStart%20Sample%20%28F%23%29)

## About Numerics.NET

Numerics.NET is a powerful numerical library for .NET that provides advanced mathematical 
functions and algorithms for scientific computing, data analysis, and machine learning.
See [numerics.net](https://numerics.net) for details.

---

_Last updated on 2025-05-06 3:03:10 PM (version 9.1.3)._
