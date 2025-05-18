# Goodness-Of-Fit Tests

This sample illustrates how to test for goodness-of-fit using classes in the Numerics.NET.Statistics.Tests namespace using Numerics.NET.

## Overview

This QuickStart sample demonstrates how to use different goodness-of-fit tests to evaluate whether data follows
expected statistical distributions.

The sample covers three major goodness-of-fit tests:

1. **Chi-square Test** - Shows how to test if observed frequencies match expected frequencies from a
binomial distribution, using data from dice rolls as an example.

2. **Kolmogorov-Smirnov Test** - Demonstrates both one-sample and two-sample K-S tests:
   - One-sample test compares random samples from a lognormal distribution against a Weibull
     distribution
   - Two-sample test compares samples from lognormal and Weibull distributions directly

3. **Anderson-Darling Test** - Illustrates testing for normality using real-world data about the
strength of polished airplane windows. Shows how to analyze the data statistically and interpret
the test results.

For each test, the sample shows how to:
- Set up the test parameters
- Calculate test statistics
- Obtain P-values
- Make statistical decisions based on the results

The code includes examples of working with various probability distributions and demonstrates proper
statistical hypothesis testing practices.


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
[C#](https://github.com/NumericsDotNet/quickstart-csharp/tree/net6.0/statistics/hypothesis-tests/goodness-of-fit-tests), [Visual Basic](https://github.com/NumericsDotNet/quickstart-visualbasic/tree/net6.0/statistics/hypothesis-tests/goodness-of-fit-tests), [IronPython](https://github.com/NumericsDotNet/quickstart-ironpython/tree/net6.0/statistics/hypothesis-tests/goodness-of-fit-tests).

You can find out more about the methods used in this sample from the Numerics.NET documentation.

### Numerics.NET User's Guide

- [Hypothesis Test Basics](https://numerics.netstatistics/hypothesis-tests/hypothesis-test-basics)
- [Testing Goodness-Of-Fit](https://numerics.netstatistics/hypothesis-tests/testing-goodness-of-fit)
- [Continuous Distributions](https://numerics.netstatistics/continuous-distributions/continuous-distributions)
- [Discrete Probability Distributions](https://numerics.netstatistics/discrete-distributions/discrete-probability-distributions)

### Numerics.NET API Reference

- [ChiSquareGoodnessOfFitTest class](https://numerics.net/documentation/latest/reference/numerics.net.statistics.tests.chisquaregoodnessoffittest)
- [OneSampleKolmogorovSmirnovTest class](https://numerics.net/documentation/latest/reference/numerics.net.statistics.tests.onesamplekolmogorovsmirnovtest)
- [AndersonDarlingTest class](https://numerics.net/documentation/latest/reference/numerics.net.statistics.tests.andersondarlingtest)
- [HypothesisTest class](https://numerics.net/documentation/latest/reference/numerics.net.statistics.tests.hypothesistest)
- [Numerics.NET.Statistics.Tests namespace](https://numerics.net/documentation/latest/reference/numerics.net.statistics.tests)


## Troubleshooting

### Common Issues

- **Missing dependencies**: Make sure to run `dotnet restore` before building
- **License verification failed**: Ensure you have a valid trial key from [https://numerics.net/trial-key](https://numerics.net/trial-key)
- **Runtime errors**: Check that you're targeting the correct .NET version (.NET 6 or .NET 8)

### Need Help?

- Check the [Numerics.NET documentation](https://numerics.net/documentation/)
- Contact support at [support@numerics.net](mailto:support@numerics.net?subject=GoodnessOfFitTests%20QuickStart%20Sample%20%28F%23%29)

## About Numerics.NET

Numerics.NET is a powerful numerical library for .NET that provides advanced mathematical 
functions and algorithms for scientific computing, data analysis, and machine learning.
See [numerics.net](https://numerics.net) for details.

---

_Last updated on 2025-05-06 3:03:10 PM (version 9.1.3)._
