# Non-Parametric Tests

This sample illustrates how to perform non-parametric tests like the Wilcoxon-Mann-Whitney test and the Kruskal-Wallis test using Numerics.NET.

## Overview

This QuickStart sample demonstrates how to perform non-parametric statistical hypothesis tests using 
Numerics.NET. Non-parametric tests make fewer assumptions about the underlying data distributions 
compared to their parametric counterparts.

The sample shows three common non-parametric tests:

- The Mann-Whitney (Wilcoxon) rank sum test compares two independent samples to determine if they 
  come from the same distribution. The example uses real data from a study of oyster DNA and protein 
  variation.

- The Kruskal-Wallis test extends the Mann-Whitney test to three or more groups. The sample 
  demonstrates this using investment fund growth data from the NIST Engineering Statistics Handbook.

- The runs test checks for randomness in a sequence by analyzing the pattern of runs (consecutive 
  values) in the data. The example uses a sequence of binary outcomes to illustrate this test.

For each test, the sample shows how to:
- Create the test object with different data input formats
- Access the test statistic and p-value
- Make decisions using different significance levels
- Interpret the results

The code includes detailed comments explaining each step and the statistical concepts involved.


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
[C#](https://github.com/NumericsDotNet/quickstart-csharp/tree/net6.0/statistics/hypothesis-tests/non-parametric-tests), [Visual Basic](https://github.com/NumericsDotNet/quickstart-visualbasic/tree/net6.0/statistics/hypothesis-tests/non-parametric-tests), [IronPython](https://github.com/NumericsDotNet/quickstart-ironpython/tree/net6.0/statistics/hypothesis-tests/non-parametric-tests).

You can find out more about the methods used in this sample from the Numerics.NET documentation.

### Numerics.NET User's Guide

- [Hypothesis Test Basics](https://numerics.net/documentation/latest/statistics/hypothesis-tests/hypothesis-test-basics)
- [Non-Parametric Tests](https://numerics.net/documentation/latest/statistics/hypothesis-tests/non-parametric-tests)

### Numerics.NET API Reference

- [MannWhitneyTest&lt;T&gt; class](https://numerics.net/documentation/latest/reference/numerics.net.statistics.tests.mannwhitneytest-1)
- [KruskalWallisTest class](https://numerics.net/documentation/latest/reference/numerics.net.statistics.tests.kruskalwallistest)
- [RunsTest&lt;T&gt; class](https://numerics.net/documentation/latest/reference/numerics.net.statistics.tests.runstest-1)
- [HypothesisTest class](https://numerics.net/documentation/latest/reference/numerics.net.statistics.tests.hypothesistest)
- [Numerics.NET.Statistics.Tests namespace](https://numerics.net/documentation/latest/reference/numerics.net.statistics.tests)


## Troubleshooting

### Common Issues

- **Missing dependencies**: Make sure to run `dotnet restore` before building
- **License verification failed**: Ensure you have a valid trial key from [https://numerics.net/trial-key](https://numerics.net/trial-key)
- **Runtime errors**: Check that you're targeting the correct .NET version (.NET 6 or .NET 8)

### Need Help?

- Check the [Numerics.NET documentation](https://numerics.net/documentation/)
- Contact support at [support@numerics.net](mailto:support@numerics.net?subject=NonParametricTests%20QuickStart%20Sample%20%28F%23%29)

## About Numerics.NET

Numerics.NET is a powerful numerical library for .NET that provides advanced mathematical 
functions and algorithms for scientific computing, data analysis, and machine learning.
See [numerics.net](https://numerics.net) for details.

---

_Last updated on 2025-05-06 3:03:10 PM (version 9.1.3)._
