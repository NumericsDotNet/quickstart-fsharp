# Least Squares

This sample illustrates how to solve least squares problems using classes in the Numerics.NET.LinearAlgebra namespace using Numerics.NET.

## Overview

This QuickStart sample demonstrates how to solve least squares problems using the LeastSquaresSolver class in 
Numerics.NET. Least squares problems are fundamental in data analysis and numerical computing, where you 
need to find the best-fitting solution to an overdetermined system of equations.

The sample shows several approaches to solving least squares problems:
- Using the LeastSquaresSolver class with both QR decomposition and normal equations methods
- Direct solution using matrix operations to form and solve the normal equations
- Working with both vector and matrix right-hand sides

Key concepts covered include:
- Creating and initializing matrices and vectors
- Configuring and using the LeastSquaresSolver
- Accessing solution information like predictions and residuals
- Understanding different solution methods and their tradeoffs
- Working with normal equations directly

The sample includes detailed comments explaining each step and provides practical examples of common least
squares operations. It serves as a foundation for applications in curve fitting, regression analysis, and
other areas where least squares solutions are needed.


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
[C#](https://github.com/NumericsDotNet/quickstart-csharp/tree/net8.0/linear-algebra/solving-equations-and-least-squares/least-squares), [Visual Basic](https://github.com/NumericsDotNet/quickstart-visualbasic/tree/net8.0/linear-algebra/solving-equations-and-least-squares/least-squares), [IronPython](https://github.com/NumericsDotNet/quickstart-ironpython/tree/net8.0/linear-algebra/solving-equations-and-least-squares/least-squares).

You can find out more about the methods used in this sample from the Numerics.NET documentation.

### Numerics.NET User's Guide

- [Solving Least Squares Problems](https://numerics.net/documentation/latest/vector-and-matrix/matrices/solving-least-squares-problems)
- [The QR Decomposition](https://numerics.net/documentation/latest/vector-and-matrix/matrix-decompositions/qr-decomposition)
- [Solving Linear Systems](https://numerics.net/documentation/latest/vector-and-matrix/matrix-decompositions/solving-linear-systems)
- [Linear Curve Fitting](https://numerics.net/documentation/latest/mathematics/curve-fitting/linear-curve-fitting)

### Numerics.NET API Reference

- [Matrix&lt;T&gt; class](https://numerics.net/documentation/latest/reference/numerics.net.matrix-1)
- [LeastSquaresSolver&lt;T&gt; class](https://numerics.net/documentation/latest/reference/numerics.net.linearalgebra.leastsquaressolver-1)
- [QRDecomposition&lt;T&gt; class](https://numerics.net/documentation/latest/reference/numerics.net.linearalgebra.qrdecomposition-1)
- [Numerics.NET.LinearAlgebra namespace](https://numerics.net/documentation/latest/reference/numerics.net.linearalgebra)


## Troubleshooting

### Common Issues

- **Missing dependencies**: Make sure to run `dotnet restore` before building
- **License verification failed**: Ensure you have a valid trial key from [https://numerics.net/trial-key](https://numerics.net/trial-key)
- **Runtime errors**: Check that you're targeting the correct .NET version (.NET 6 or .NET 8)

### Need Help?

- Check the [Numerics.NET documentation](https://numerics.net/documentation/)
- Contact support at [support@numerics.net](mailto:support@numerics.net?subject=LeastSquares%20QuickStart%20Sample%20%28F%23%29)

## About Numerics.NET

Numerics.NET is a powerful numerical library for .NET that provides advanced mathematical 
functions and algorithms for scientific computing, data analysis, and machine learning.
See [numerics.net](https://numerics.net) for details.

---

_Last updated on 2025-05-06 3:03:10 PM (version 9.1.3)._
