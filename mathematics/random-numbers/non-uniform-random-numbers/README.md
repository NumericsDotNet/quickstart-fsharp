# Non-Uniform Random Numbers

This sample illustrates how to generate random numbers from a non-uniform distribution using Numerics.NET.

## Overview

This QuickStart sample demonstrates how to generate random numbers from non-uniform probability 
distributions using Numerics.NET.

The sample specifically illustrates the relationship between exponential and Poisson distributions in
modeling events over time. It uses an exponential distribution to generate times between events, and
then compares the resulting frequency of events per time unit with the theoretical Poisson 
distribution.

The code shows how to:
- Create and configure specific probability distributions (Exponential and Poisson)
- Use the MersenneTwister random number generator
- Generate random samples from a probability distribution
- Collect and analyze statistical data from the generated samples
- Compare empirical results with theoretical expectations

This practical example helps understand both the mechanics of generating non-uniform random numbers
and how different probability distributions relate to each other in modeling real-world phenomena.


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
[C#](https://github.com/NumericsDotNet/quickstart-csharp/tree/net6.0/mathematics/random-numbers/non-uniform-random-numbers), [Visual Basic](https://github.com/NumericsDotNet/quickstart-visualbasic/tree/net6.0/mathematics/random-numbers/non-uniform-random-numbers), [IronPython](https://github.com/NumericsDotNet/quickstart-ironpython/tree/net6.0/mathematics/random-numbers/non-uniform-random-numbers).

You can find out more about the methods used in this sample from the Numerics.NET documentation.

### Numerics.NET User's Guide

- [Random Number Generators](https://numerics.net/statistics/random-numbers/random-number-generators)
- [Exponential Distribution](https://numerics.net/statistics/continuous-distributions/exponential-distribution)
- [Poisson Distribution](https://numerics.net/statistics/discrete-distributions/poisson-distribution)

### Numerics.NET API Reference

- [MersenneTwister class](https://numerics.net/documentation/latest/reference/numerics.net.random.mersennetwister)
- [Pcg32 class](https://numerics.net/documentation/latest/reference/numerics.net.random.pcg32)
- [Distributions.ExponentialDistribution class](https://numerics.net/documentation/latest/reference/numerics.net.statistics.distributions.exponentialdistribution)
- [Distributions.PoissonDistribution class](https://numerics.net/documentation/latest/reference/numerics.net.statistics.distributions.poissondistribution)
- [Histogram class](https://numerics.net/documentation/latest/reference/numerics.net.dataanalysis.histogram)
- [Numerics.NET.Statistics.Distributions namespace](https://numerics.net/documentation/latest/reference/numerics.net.statistics.distributions)


## Troubleshooting

### Common Issues

- **Missing dependencies**: Make sure to run `dotnet restore` before building
- **License verification failed**: Ensure you have a valid trial key from [https://numerics.net/trial-key](https://numerics.net/trial-key)
- **Runtime errors**: Check that you're targeting the correct .NET version (.NET 6 or .NET 8)

### Need Help?

- Check the [Numerics.NET documentation](https://numerics.net/documentation/)
- Contact support at [support@numerics.net](mailto:support@numerics.net?subject=NonUniformRandomNumbers%20QuickStart%20Sample%20%28F%23%29)

## About Numerics.NET

Numerics.NET is a powerful numerical library for .NET that provides advanced mathematical 
functions and algorithms for scientific computing, data analysis, and machine learning.
See [numerics.net](https://numerics.net) for details.

---

_Last updated on 2025-05-06 3:03:10 PM (version 9.1.3)._
