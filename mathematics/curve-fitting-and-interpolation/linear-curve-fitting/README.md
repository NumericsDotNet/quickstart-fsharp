# Linear Curve Fitting

This sample illustrates how to fit linear combinations of curves to data using the LinearCurveFitter class and other classes in the Numerics.NET.Curves namespace using Numerics.NET.

## Overview

This QuickStart sample demonstrates how to perform linear least squares curve fitting using the LinearCurveFitter 
class in Numerics.NET.

The sample shows two practical applications of linear curve fitting. First, it demonstrates polynomial 
fitting using data from the NIST Statistical Reference Datasets library for calibrating load cells. The 
sample fits a quadratic polynomial to deflection measurements, showing both unweighted and weighted 
least squares approaches.

The second example shows how to fit arbitrary linear combinations of functions. It uses experimental 
data for the temperature-dependent thermal conductivity of copper. The theoretical model expresses 
conductance as a combination of inverse temperature and temperature squared terms. The sample 
demonstrates how to:

- Create custom basis functions for fitting
- Transform data to achieve linearity
- Use the GeneralFunctionBasis class for arbitrary function combinations
- Extract and interpret fitted parameters and their uncertainties
- Calculate residuals to assess fit quality

The code includes examples of working with vectors, setting up fitting problems, handling weights, and
interpreting statistical results. It serves as a practical introduction to linear least squares methods
in Numerics.NET.


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
[C#](https://github.com/NumericsDotNet/quickstart-csharp/tree/net8.0/mathematics/curve-fitting-and-interpolation/linear-curve-fitting), [Visual Basic](https://github.com/NumericsDotNet/quickstart-visualbasic/tree/net8.0/mathematics/curve-fitting-and-interpolation/linear-curve-fitting), [IronPython](https://github.com/NumericsDotNet/quickstart-ironpython/tree/net8.0/mathematics/curve-fitting-and-interpolation/linear-curve-fitting).

You can find out more about the methods used in this sample from the Numerics.NET documentation.

### Numerics.NET User's Guide

- [Linear Curve Fitting](https://numerics.net/documentation/latest/mathematics/curve-fitting/linear-curve-fitting)
- [Nonlinear Curve Fitting](https://numerics.net/documentation/latest/mathematics/curve-fitting/nonlinear-curve-fitting)
- [Polynomials](https://numerics.net/documentation/latest/mathematics/curves-and-interpolation/polynomials)
- [Comparing Floating-Point Numbers](https://numerics.net/documentation/latest/mathematics/general-classes/comparing-floating-point-numbers)

### Numerics.NET API Reference

- [LinearCurveFitter class](https://numerics.net/documentation/latest/reference/numerics.net.curves.linearcurvefitter)
- [FunctionBasis class](https://numerics.net/documentation/latest/reference/numerics.net.curves.functionbasis)
- [LinearCombination class](https://numerics.net/documentation/latest/reference/numerics.net.curves.linearcombination)
- [Numerics.NET.Curves namespace](https://numerics.net/documentation/latest/reference/numerics.net.curves)


## Troubleshooting

### Common Issues

- **Missing dependencies**: Make sure to run `dotnet restore` before building
- **License verification failed**: Ensure you have a valid trial key from [https://numerics.net/trial-key](https://numerics.net/trial-key)
- **Runtime errors**: Check that you're targeting the correct .NET version (.NET 6 or .NET 8)

### Need Help?

- Check the [Numerics.NET documentation](https://numerics.net/documentation/)
- Contact support at [support@numerics.net](mailto:support@numerics.net?subject=LinearCurveFitting%20QuickStart%20Sample%20%28F%23%29)

## About Numerics.NET

Numerics.NET is a powerful numerical library for .NET that provides advanced mathematical 
functions and algorithms for scientific computing, data analysis, and machine learning.
See [numerics.net](https://numerics.net) for details.

---

_Last updated on 2025-05-06 3:03:10 PM (version 9.1.3)._
