# BigNumbers

This sample illustrates the basic use of the arbitrary precision classes: BigInteger, BigRational, BigFloat using Numerics.NET.

## Overview

This QuickStart sample demonstrates how to use Numerics.NET's arbitrary precision number types to 
perform high-precision mathematical calculations, specifically computing pi to thousands of digits.

The sample implements and compares five different methods for computing pi:

1. Using an arctan formula with BigInteger arithmetic
2. Using a rational approximation with BigRational arithmetic 
3. Using the arithmetic-geometric mean algorithm with BigFloat arithmetic
4. Using Borweins' quartic formula with BigFloat arithmetic
5. Using the built-in BigFloat.GetPi method

Each method demonstrates different aspects of arbitrary precision arithmetic and shows how to work
with the various number types. The sample includes performance timing for each approach and shows
how to control precision and rounding modes. It also demonstrates important concepts like:

- Converting between different arbitrary precision types
- Controlling precision and accuracy goals
- Handling performance considerations
- Using mathematical functions with arbitrary precision
- Working with rational numbers and continued fractions
- Understanding convergence rates of different algorithms


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
[C#](https://github.com/NumericsDotNet/quickstart-csharp/tree/net462/mathematics/general/big-numbers), [Visual Basic](https://github.com/NumericsDotNet/quickstart-visualbasic/tree/net462/mathematics/general/big-numbers), [IronPython](https://github.com/NumericsDotNet/quickstart-ironpython/tree/net462/mathematics/general/big-numbers).

You can find out more about the methods used in this sample from the Numerics.NET documentation.

### Numerics.NET User's Guide

- [Arbitrary Precision Integers](https://numerics.net/documentation/latest/mathematics/arbitrary-precision-arithmetic/arbitrary-precision-integers)
- [Arbitrary Precision Rationals](https://numerics.net/documentation/latest/mathematics/arbitrary-precision-arithmetic/arbitrary-precision-rationals)
- [Arbitrary Precision Floating-Point Numbers](https://numerics.net/documentation/latest/mathematics/arbitrary-precision-arithmetic/arbitrary-precision-floating-point-numbers)
- [Mathematical Constants](https://numerics.net/documentation/latest/mathematics/general-classes/mathematical-constants)

### Numerics.NET API Reference

- [BigFloat class](https://numerics.net/documentation/latest/reference/numerics.net.bigfloat)
- [BigInteger class](https://numerics.net/documentation/latest/reference/numerics.net.biginteger)
- [BigRational class](https://numerics.net/documentation/latest/reference/numerics.net.bigrational)
- [AccuracyGoal class](https://numerics.net/documentation/latest/reference/numerics.net.accuracygoal)


## Troubleshooting

### Common Issues

- **Missing dependencies**: Make sure to run `dotnet restore` before building
- **License verification failed**: Ensure you have a valid trial key from [https://numerics.net/trial-key](https://numerics.net/trial-key)
- **Runtime errors**: Check that you're targeting the correct .NET version (.NET 6 or .NET 8)

### Need Help?

- Check the [Numerics.NET documentation](https://numerics.net/documentation/)
- Contact support at [support@numerics.net](mailto:support@numerics.net?subject=BigNumbers%20QuickStart%20Sample%20%28F%23%29)

## About Numerics.NET

Numerics.NET is a powerful numerical library for .NET that provides advanced mathematical 
functions and algorithms for scientific computing, data analysis, and machine learning.
See [numerics.net](https://numerics.net) for details.

---

_Last updated on 2025-05-06 3:03:10 PM (version 9.1.3)._
