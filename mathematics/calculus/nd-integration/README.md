# Higher Dimensional Numerical Integration

This sample illustrates numerical integration of functions in higher dimensions using classes in the Numerics.NET.Calculus namespace using Numerics.NET.

## Overview

This QuickStart sample demonstrates how to perform numerical integration of functions in two dimensions using 
Numerics.NET's integration capabilities.

The sample shows several key aspects of multi-dimensional integration:

- Using the `AdaptiveIntegrator2D` class for efficient integration over rectangular regions
- Working with the `Repeated1DIntegrator2D` class that uses repeated one-dimensional integration
- Setting up integrand functions using delegates
- Integrating over arbitrary non-rectangular regions by specifying boundary functions
- Monitoring integration progress through properties like Status, EstimatedError, and function 
  evaluation counts
- Comparing numerical results with known analytical solutions

The example includes integration of several test functions including:
- A rational function: 4/(1 + 2x + 2y) over the unit square
- A trigonometric function: (π²/4)sin(πx)sin(πy) over the unit square
- A polynomial function: x²y² over the unit disk

For each integration, the sample demonstrates how to set up the problem, execute the integration, 
and analyze the results including error estimates and computational effort required.


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
[C#](https://github.com/NumericsDotNet/quickstart-csharp/tree/net6.0/mathematics/calculus/nd-integration), [Visual Basic](https://github.com/NumericsDotNet/quickstart-visualbasic/tree/net6.0/mathematics/calculus/nd-integration), [IronPython](https://github.com/NumericsDotNet/quickstart-ironpython/tree/net6.0/mathematics/calculus/nd-integration).

You can find out more about the methods used in this sample from the Numerics.NET documentation.

### Numerics.NET User's Guide

- [Numerical Integration in Two Dimensions](https://numerics.net/documentation/latest/mathematics/calculus/numerical-integration-in-two-dimensions)
- [Adaptive Numerical Integration](https://numerics.net/documentation/latest/mathematics/calculus/numerical-integration/adaptive-numerical-integration)
- [The NumericalIntegrator Class](https://numerics.net/documentation/latest/mathematics/calculus/numerical-integration/numericalintegrator-class)

### Numerics.NET API Reference

- [AdaptiveIntegrator2D class](https://numerics.net/documentation/latest/reference/numerics.net.calculus.adaptiveintegrator2d)
- [Repeated1DIntegrator2D class](https://numerics.net/documentation/latest/reference/numerics.net.calculus.repeated1dintegrator2d)
- [NumericalIntegratorND class](https://numerics.net/documentation/latest/reference/numerics.net.calculus.numericalintegratornd)
- [Numerics.NET.Calculus namespace](https://numerics.net/documentation/latest/reference/numerics.net.calculus)


## Troubleshooting

### Common Issues

- **Missing dependencies**: Make sure to run `dotnet restore` before building
- **License verification failed**: Ensure you have a valid trial key from [https://numerics.net/trial-key](https://numerics.net/trial-key)
- **Runtime errors**: Check that you're targeting the correct .NET version (.NET 6 or .NET 8)

### Need Help?

- Check the [Numerics.NET documentation](https://numerics.net/documentation/)
- Contact support at [support@numerics.net](mailto:support@numerics.net?subject=NDIntegration%20QuickStart%20Sample%20%28F%23%29)

## About Numerics.NET

Numerics.NET is a powerful numerical library for .NET that provides advanced mathematical 
functions and algorithms for scientific computing, data analysis, and machine learning.
See [numerics.net](https://numerics.net) for details.

---

_Last updated on 2025-05-06 3:03:10 PM (version 9.1.3)._
