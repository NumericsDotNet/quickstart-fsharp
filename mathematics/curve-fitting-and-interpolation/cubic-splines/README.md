# Cubic Splines

This sample illustrates using natural and clamped cubic splines for interpolation using classes in the Numerics.NET.LinearAlgebra namespace using Numerics.NET.

## Overview

This QuickStart sample demonstrates how to create and work with cubic splines in Numerics.NET. Cubic splines 
provide smooth interpolation through a set of data points by constructing piecewise cubic polynomials.

The sample shows several key aspects of working with splines:
- Creating natural splines with zero second derivatives at endpoints
- Creating clamped splines with specified slopes at endpoints
- Creating Akima splines that minimize oscillations
- Creating Hermite splines with specified derivatives at each point
- Accessing and modifying spline parameters
- Evaluating splines and their derivatives at arbitrary points
- Finding tangent lines and computing definite integrals
- Working with the piecewise nature of spline curves

Through practical code examples, you'll learn how to choose appropriate spline types for different
interpolation needs and how to use the key methods and properties of the CubicSpline class. The sample
includes examples of both basic usage and more advanced features like derivative calculation and
integration.


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
[C#](https://github.com/NumericsDotNet/quickstart-csharp/tree/net6.0/mathematics/curve-fitting-and-interpolation/cubic-splines), [Visual Basic](https://github.com/NumericsDotNet/quickstart-visualbasic/tree/net6.0/mathematics/curve-fitting-and-interpolation/cubic-splines), [IronPython](https://github.com/NumericsDotNet/quickstart-ironpython/tree/net6.0/mathematics/curve-fitting-and-interpolation/cubic-splines).

You can find out more about the methods used in this sample from the Numerics.NET documentation.

### Numerics.NET User's Guide

- [Curve Basics](https://numerics.net/documentation/latest/mathematics/curves-and-interpolation/curve-basics)
- [Cubic Splines](https://numerics.net/documentation/latest/mathematics/curves-and-interpolation/cubic-splines)
- [Piecewise Curves and Cubic Splines](https://numerics.net/documentation/latest/mathematics/curves-and-interpolation/piecewise-curves-and-cubic-splines)

### Numerics.NET API Reference

- [CubicSpline class](https://numerics.net/documentation/latest/reference/numerics.net.curves.cubicspline)
- [PiecewiseCurve class](https://numerics.net/documentation/latest/reference/numerics.net.curves.piecewisecurve)
- [Numerics.NET.Curves namespace](https://numerics.net/documentation/latest/reference/numerics.net.curves)


## Troubleshooting

### Common Issues

- **Missing dependencies**: Make sure to run `dotnet restore` before building
- **License verification failed**: Ensure you have a valid trial key from [https://numerics.net/trial-key](https://numerics.net/trial-key)
- **Runtime errors**: Check that you're targeting the correct .NET version (.NET 6 or .NET 8)

### Need Help?

- Check the [Numerics.NET documentation](https://numerics.net/documentation/)
- Contact support at [support@numerics.net](mailto:support@numerics.net?subject=CubicSplines%20QuickStart%20Sample%20%28F%23%29)

## About Numerics.NET

Numerics.NET is a powerful numerical library for .NET that provides advanced mathematical 
functions and algorithms for scientific computing, data analysis, and machine learning.
See [numerics.net](https://numerics.net) for details.

---

_Last updated on 2025-05-06 3:03:10 PM (version 9.1.3)._
