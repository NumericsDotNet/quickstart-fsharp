# Piecewise Curves

This sample illustrates working with piecewise constant and piecewise linear curves using classes from the Numerics.NET.Curves namespace using Numerics.NET.

## Overview

This QuickStart sample demonstrates how to work with piecewise constant and piecewise linear curves in 
Numerics.NET. These curves are useful for interpolating discrete data points where the function behavior 
between points is either constant or linear.

The sample covers:
- Creating piecewise constant curves using different constructor overloads
- Creating piecewise linear curves using different constructor overloads 
- Accessing and modifying curve parameters
- Evaluating curves at specific points using ValueAt()
- Computing slopes and derivatives
- Finding tangent lines at points
- Computing definite integrals

The code demonstrates practical usage of the PiecewiseConstantCurve and PiecewiseLinearCurve classes from
the Numerics.NET.Curves namespace. It shows how to construct curves from arrays of x,y coordinates or
Point objects, access curve parameters, evaluate curve values and derivatives, and compute integrals.

This sample is particularly useful for developers working with discrete data that requires interpolation,
such as in signal processing, data analysis, or scientific computing applications where data points need
to be connected using either constant or linear segments.


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
[C#](https://github.com/NumericsDotNet/quickstart-csharp/tree/net8.0/mathematics/curve-fitting-and-interpolation/piecewise-curves), [Visual Basic](https://github.com/NumericsDotNet/quickstart-visualbasic/tree/net8.0/mathematics/curve-fitting-and-interpolation/piecewise-curves), [IronPython](https://github.com/NumericsDotNet/quickstart-ironpython/tree/net8.0/mathematics/curve-fitting-and-interpolation/piecewise-curves).

You can find out more about the methods used in this sample from the Numerics.NET documentation.

### Numerics.NET User's Guide

- [Piecewise Curves and Cubic Splines](https://numerics.net/documentation/latest/mathematics/curves-and-interpolation/piecewise-curves-and-cubic-splines)
- [Curve Basics](https://numerics.net/documentation/latest/mathematics/curves-and-interpolation/curve-basics)
- [Comparing Curve classes and delegates](https://numerics.net/documentation/latest/mathematics/curves-and-interpolation/comparing-curve-classes-and-delegates)

### Numerics.NET API Reference

- [PiecewiseCurve class](https://numerics.net/documentation/latest/reference/numerics.net.curves.piecewisecurve)
- [Curve class](https://numerics.net/documentation/latest/reference/numerics.net.curves.curve)
- [Numerics.NET.Curves namespace](https://numerics.net/documentation/latest/reference/numerics.net.curves)


## Troubleshooting

### Common Issues

- **Missing dependencies**: Make sure to run `dotnet restore` before building
- **License verification failed**: Ensure you have a valid trial key from [https://numerics.net/trial-key](https://numerics.net/trial-key)
- **Runtime errors**: Check that you're targeting the correct .NET version (.NET 6 or .NET 8)

### Need Help?

- Check the [Numerics.NET documentation](https://numerics.net/documentation/)
- Contact support at [support@numerics.net](mailto:support@numerics.net?subject=PiecewiseCurves%20QuickStart%20Sample%20%28F%23%29)

## About Numerics.NET

Numerics.NET is a powerful numerical library for .NET that provides advanced mathematical 
functions and algorithms for scientific computing, data analysis, and machine learning.
See [numerics.net](https://numerics.net) for details.

---

_Last updated on 2025-05-06 3:03:10 PM (version 9.1.3)._
