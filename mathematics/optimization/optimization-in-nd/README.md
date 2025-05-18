# Optimization In Multiple Dimensions

This sample illustrates the use of the multi-dimensional optimizer classes in the Numerics.NET.Optimization namespace for optimization in multiple dimensions using Numerics.NET.

## Overview

This QuickStart sample demonstrates how to use various optimization algorithms in Numerics.NET to find minima 
of multidimensional functions.

The sample shows how to use several different optimization methods:

* BFGS (Broyden-Fletcher-Goldfarb-Shanno) method - A quasi-Newton method that approximates the 
  Hessian matrix to find minima efficiently. The sample demonstrates both manual gradient 
  specification and automatic differentiation.

* Conjugate Gradient methods - Including Fletcher-Reeves and Polak-Ribiere variants, which are
  particularly effective for large-scale problems.

* Powell's method - A derivative-free method that can work when gradients are unavailable or
  difficult to compute.

* Nelder-Mead simplex method - A robust method that can handle discontinuous functions, though
  it converges more slowly than gradient-based methods.

The sample uses the classic Rosenbrock function as a test case, showing how to specify objective
functions, gradients, and initial guesses. It demonstrates both manual gradient implementation and
the use of automatic differentiation. For each method, it shows how to configure the optimizer
and interpret the results, including solution quality and performance metrics.


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
[C#](https://github.com/NumericsDotNet/quickstart-csharp/tree/net8.0/mathematics/optimization/optimization-in-nd), [Visual Basic](https://github.com/NumericsDotNet/quickstart-visualbasic/tree/net8.0/mathematics/optimization/optimization-in-nd), [IronPython](https://github.com/NumericsDotNet/quickstart-ironpython/tree/net8.0/mathematics/optimization/optimization-in-nd).

You can find out more about the methods used in this sample from the Numerics.NET documentation.

### Numerics.NET User's Guide

- [Multidimensional Optimization](https://numerics.net/documentation/latest/mathematics/optimization/multidimensional-optimization)
- [Global Optimization](https://numerics.net/documentation/latest/mathematics/optimization/global-optimization)
- [Optimization Model Basics](https://numerics.net/documentation/latest/mathematics/optimization/optimization-model-basics)

### Numerics.NET API Reference

- [MultidimensionalOptimizer class](https://numerics.net/documentation/latest/reference/numerics.net.optimization.multidimensionaloptimizer)
- [ConjugateGradientOptimizer class](https://numerics.net/documentation/latest/reference/numerics.net.optimization.conjugategradientoptimizer)
- [NelderMeadOptimizer class](https://numerics.net/documentation/latest/reference/numerics.net.optimization.neldermeadoptimizer)
- [QuasiNewtonOptimizer class](https://numerics.net/documentation/latest/reference/numerics.net.optimization.quasinewtonoptimizer)
- [Numerics.NET.Optimization namespace](https://numerics.net/documentation/latest/reference/numerics.net.optimization)


## Troubleshooting

### Common Issues

- **Missing dependencies**: Make sure to run `dotnet restore` before building
- **License verification failed**: Ensure you have a valid trial key from [https://numerics.net/trial-key](https://numerics.net/trial-key)
- **Runtime errors**: Check that you're targeting the correct .NET version (.NET 6 or .NET 8)

### Need Help?

- Check the [Numerics.NET documentation](https://numerics.net/documentation/)
- Contact support at [support@numerics.net](mailto:support@numerics.net?subject=OptimizationInND%20QuickStart%20Sample%20%28F%23%29)

## About Numerics.NET

Numerics.NET is a powerful numerical library for .NET that provides advanced mathematical 
functions and algorithms for scientific computing, data analysis, and machine learning.
See [numerics.net](https://numerics.net) for details.

---

_Last updated on 2025-05-06 3:03:10 PM (version 9.1.3)._
