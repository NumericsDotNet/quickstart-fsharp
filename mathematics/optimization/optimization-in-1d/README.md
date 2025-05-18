# Optimization In One Dimension

This sample illustrates the use of the Brent and Golden Section optimizer classes in the Numerics.NET.Optimization namespace for one-dimensional optimization using Numerics.NET.

## Overview

This QuickStart sample demonstrates how to find the minimum or maximum of a function in one dimension using 
Numerics.NET's optimization capabilities.

The sample shows two different optimization algorithms:

- Brent's algorithm - A sophisticated and efficient method that combines golden section search with 
  parabolic interpolation. It is the recommended method for most one-dimensional optimization problems.
  The sample demonstrates how to:
  - Create and configure a BrentOptimizer
  - Find an interval containing an extremum using FindBracket
  - Locate the precise minimum or maximum
  - Access results and error estimates

- Golden Section Search - A simpler but slower algorithm based on the golden ratio. The sample shows 
  how to use the GoldenSectionOptimizer class to find extrema.

Both methods are demonstrated on two test functions:
1. A cubic polynomial f(x) = x� - 2x - 5
2. An exponential function f(x) = 1/exp(x� - 0.7x + 0.2)

The sample illustrates proper error handling, accessing optimization results, and comparing estimated 
versus actual errors. It also shows how to use lambda expressions for defining objective functions in 
C# 3.0 and later.


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
[C#](https://github.com/NumericsDotNet/quickstart-csharp/tree/net6.0/mathematics/optimization/optimization-in-1d), [Visual Basic](https://github.com/NumericsDotNet/quickstart-visualbasic/tree/net6.0/mathematics/optimization/optimization-in-1d), [IronPython](https://github.com/NumericsDotNet/quickstart-ironpython/tree/net6.0/mathematics/optimization/optimization-in-1d).

You can find out more about the methods used in this sample from the Numerics.NET documentation.

### Numerics.NET User's Guide

- [One-Dimensional Optimization](https://numerics.net/documentation/latest/mathematics/optimization/one-dimensional-optimization)
- [Methods that do not use the derivative](https://numerics.net/documentation/latest/mathematics/solving-equations/methods-that-do-not-use-the-derivative)
- [Optimization Model Basics](https://numerics.net/documentation/latest/mathematics/optimization/optimization-model-basics)

### Numerics.NET API Reference

- [BrentOptimizer class](https://numerics.net/documentation/latest/reference/numerics.net.optimization.brentoptimizer)
- [GoldenSectionOptimizer class](https://numerics.net/documentation/latest/reference/numerics.net.optimization.goldensectionoptimizer)
- [Numerics.NET.Optimization namespace](https://numerics.net/documentation/latest/reference/numerics.net.optimization)


## Troubleshooting

### Common Issues

- **Missing dependencies**: Make sure to run `dotnet restore` before building
- **License verification failed**: Ensure you have a valid trial key from [https://numerics.net/trial-key](https://numerics.net/trial-key)
- **Runtime errors**: Check that you're targeting the correct .NET version (.NET 6 or .NET 8)

### Need Help?

- Check the [Numerics.NET documentation](https://numerics.net/documentation/)
- Contact support at [support@numerics.net](mailto:support@numerics.net?subject=OptimizationIn1D%20QuickStart%20Sample%20%28F%23%29)

## About Numerics.NET

Numerics.NET is a powerful numerical library for .NET that provides advanced mathematical 
functions and algorithms for scientific computing, data analysis, and machine learning.
See [numerics.net](https://numerics.net) for details.

---

_Last updated on 2025-05-06 3:03:10 PM (version 9.1.3)._
