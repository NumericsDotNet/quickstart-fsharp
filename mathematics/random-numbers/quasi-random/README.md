# Quasi-Random Sequences

This sample illustrates how to generate quasi-random sequences like Fauré and Sobol sequences using classes in the Numerics.NET.Statistics.Random namespace using Numerics.NET.

## Overview

This sample demonstrates how to use quasi-random sequences to compute multi-dimensional integrals 
efficiently and accurately.

The sample shows how to use both Halton and Sobol sequences to evaluate a specific 5-dimensional
integral. It demonstrates the key differences between these sequence types and provides practical
examples of their usage. The program:

- Creates a Halton sequence and uses it to estimate a 5-dimensional integral
- Shows how to iterate through the sequence points and evaluate the integrand
- Demonstrates progress monitoring by displaying intermediate results
- Illustrates the use of the more sophisticated Sobol sequences
- Shows how to skip points in a Sobol sequence efficiently
- Compares the results to the known exact value of the integral

The sample serves as a practical introduction to quasi-random number generation and shows how these
sequences can be more effective than pseudo-random numbers for certain numerical integration tasks.
It includes examples of proper sequence initialization and demonstrates recommended usage patterns
for both sequence types.


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
[C#](https://github.com/NumericsDotNet/quickstart-csharp/tree/net6.0/mathematics/random-numbers/quasi-random), [Visual Basic](https://github.com/NumericsDotNet/quickstart-visualbasic/tree/net6.0/mathematics/random-numbers/quasi-random), [IronPython](https://github.com/NumericsDotNet/quickstart-ironpython/tree/net6.0/mathematics/random-numbers/quasi-random).

You can find out more about the methods used in this sample from the Numerics.NET documentation.

### Numerics.NET User's Guide

- [Quasi-Random Sequences](https://numerics.net/documentation/latest/mathematics/random-numbers/quasi-random-sequences)
- [Numerical Integration in more than Two Dimensions](https://numerics.net/documentation/latest/mathematics/calculus/numerical-integration-in-more-than-two-dimensions)
- [Random Number Generators](https://numerics.net/documentation/latest/mathematics/random-numbers/random-number-generators)

### Numerics.NET API Reference

- [QuasiRandom class](https://numerics.net/documentation/latest/reference/numerics.net.random.quasirandom)
- [SobolSequenceGenerator class](https://numerics.net/documentation/latest/reference/numerics.net.random.sobolsequencegenerator)
- [Numerics.NET.Random namespace](https://numerics.net/documentation/latest/reference/numerics.net.random)


## Troubleshooting

### Common Issues

- **Missing dependencies**: Make sure to run `dotnet restore` before building
- **License verification failed**: Ensure you have a valid trial key from [https://numerics.net/trial-key](https://numerics.net/trial-key)
- **Runtime errors**: Check that you're targeting the correct .NET version (.NET 6 or .NET 8)

### Need Help?

- Check the [Numerics.NET documentation](https://numerics.net/documentation/)
- Contact support at [support@numerics.net](mailto:support@numerics.net?subject=QuasiRandom%20QuickStart%20Sample%20%28F%23%29)

## About Numerics.NET

Numerics.NET is a powerful numerical library for .NET that provides advanced mathematical 
functions and algorithms for scientific computing, data analysis, and machine learning.
See [numerics.net](https://numerics.net) for details.

---

_Last updated on 2025-05-06 3:03:10 PM (version 9.1.3)._
