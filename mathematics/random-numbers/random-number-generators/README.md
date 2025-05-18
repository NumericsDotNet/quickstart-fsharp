# Random Number Generators

This sample illustrates how to use specialized random number generator classes in the Numerics.NET.Statistics.Random namespace using Numerics.NET.

## Overview

This QuickStart sample demonstrates how to use the various random number generator classes available in 
Numerics.NET. These classes provide alternatives to the standard System.Random class with additional 
features and different algorithms.

The sample covers three main random number generator types:

- The ExtendedRandom class which enhances System.Random with additional functionality like filling arrays
- The RANLUX generators which offer different "luxury levels" of random number quality
- The Generalized Feedback Shift Register (GFSR) generator
- The Mersenne Twister, a variant of GFSR that is widely used in scientific computing

For each generator type, the sample shows how to:
- Create instances with different constructors and parameters
- Generate random integers and floating point numbers
- Fill arrays with random values
- Select appropriate luxury levels for RANLUX generators

The sample also mentions that all generators can produce random variates from arbitrary probability
distributions, with a reference to the NonUniformRandomNumbers sample for details.


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
[C#](https://github.com/NumericsDotNet/quickstart-csharp/tree/net8.0/mathematics/random-numbers/random-number-generators), [Visual Basic](https://github.com/NumericsDotNet/quickstart-visualbasic/tree/net8.0/mathematics/random-numbers/random-number-generators), [IronPython](https://github.com/NumericsDotNet/quickstart-ironpython/tree/net8.0/mathematics/random-numbers/random-number-generators).

You can find out more about the methods used in this sample from the Numerics.NET documentation.

### Numerics.NET User's Guide

- [Random Number Generators](https://numerics.netrandom-numbers/random-number-generators)
- [Quasi-Random Sequences](https://numerics.netrandom-numbers/quasi-random-sequences)
- [Random Enumerators and Shufflers](https://numerics.netrandom-numbers/random-enumerators-and-shufflers)

### Numerics.NET API Reference

- [ExtendedRandom class](https://numerics.net/documentation/latest/reference/numerics.net.random.extendedrandom)
- [RanLux class](https://numerics.net/documentation/latest/reference/numerics.net.random.ranlux)
- [GfsrGenerator class](https://numerics.net/documentation/latest/reference/numerics.net.random.gfsrgenerator)
- [MersenneTwister class](https://numerics.net/documentation/latest/reference/numerics.net.random.mersennetwister)
- [Pcg32 class](https://numerics.net/documentation/latest/reference/numerics.net.random.pcg32)
- [Numerics.NET.Random namespace](https://numerics.net/documentation/latest/reference/numerics.net.random)


## Troubleshooting

### Common Issues

- **Missing dependencies**: Make sure to run `dotnet restore` before building
- **License verification failed**: Ensure you have a valid trial key from [https://numerics.net/trial-key](https://numerics.net/trial-key)
- **Runtime errors**: Check that you're targeting the correct .NET version (.NET 6 or .NET 8)

### Need Help?

- Check the [Numerics.NET documentation](https://numerics.net/documentation/)
- Contact support at [support@numerics.net](mailto:support@numerics.net?subject=RandomNumberGenerators%20QuickStart%20Sample%20%28F%23%29)

## About Numerics.NET

Numerics.NET is a powerful numerical library for .NET that provides advanced mathematical 
functions and algorithms for scientific computing, data analysis, and machine learning.
See [numerics.net](https://numerics.net) for details.

---

_Last updated on 2025-05-06 3:03:10 PM (version 9.1.3)._
