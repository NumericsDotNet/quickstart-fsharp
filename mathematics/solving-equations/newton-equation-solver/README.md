# Newton-Raphson Equation Solver

This sample illustrates the use of the NewtonRaphsonSolver class for solving equations in one variable and related functions for numerical differentiation using Numerics.NET.

## Overview

This QuickStart sample demonstrates how to use the NewtonRaphsonSolver class to find roots of nonlinear equations in
one variable using the Newton-Raphson method.

The Newton-Raphson method is an iterative technique that uses both a function and its derivative to find
roots (zeros) of equations. Starting from an initial guess, it generates progressively better
approximations to the root. The sample shows:

* How to create and configure a NewtonRaphsonSolver object
* Using the solver with functions that have analytical derivatives (like Math.Sin)
* Using numerical differentiation when analytical derivatives aren't available
* How to control the iteration process by setting parameters like:
  - Maximum number of iterations
  - Convergence criteria
  - Relative and absolute tolerances
* How to interpret results and error estimates
* Using the convenient FindZero extension method for simple cases

The sample includes practical examples using both trigonometric functions and special functions (Bessel
functions), demonstrating the solver's versatility with different types of equations.


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
[C#](https://github.com/NumericsDotNet/quickstart-csharp/tree/net8.0/mathematics/solving-equations/newton-equation-solver), [Visual Basic](https://github.com/NumericsDotNet/quickstart-visualbasic/tree/net8.0/mathematics/solving-equations/newton-equation-solver), [IronPython](https://github.com/NumericsDotNet/quickstart-ironpython/tree/net8.0/mathematics/solving-equations/newton-equation-solver).

You can find out more about the methods used in this sample from the Numerics.NET documentation.

### Numerics.NET User's Guide

- [The EquationSolver Class](https://numerics.net/documentation/latest/mathematics/solving-equations/equationsolver-class)
- [Methods that use the Derivative](https://numerics.net/documentation/latest/mathematics/solving-equations/methods-that-use-the-derivative)
- [Numerical Differentiation](https://numerics.net/documentation/latest/mathematics/calculus/numerical-differentiation)

### Numerics.NET API Reference

- [NewtonRaphsonSolver class](https://numerics.net/documentation/latest/reference/numerics.net.equationsolvers.newtonraphsonsolver)
- [FunctionMath class](https://numerics.net/documentation/latest/reference/numerics.net.functionmath)
- [Numerics.NET.EquationSolvers namespace](https://numerics.net/documentation/latest/reference/numerics.net.equationsolvers)


## Troubleshooting

### Common Issues

- **Missing dependencies**: Make sure to run `dotnet restore` before building
- **License verification failed**: Ensure you have a valid trial key from [https://numerics.net/trial-key](https://numerics.net/trial-key)
- **Runtime errors**: Check that you're targeting the correct .NET version (.NET 6 or .NET 8)

### Need Help?

- Check the [Numerics.NET documentation](https://numerics.net/documentation/)
- Contact support at [support@numerics.net](mailto:support@numerics.net?subject=NewtonEquationSolver%20QuickStart%20Sample%20%28F%23%29)

## About Numerics.NET

Numerics.NET is a powerful numerical library for .NET that provides advanced mathematical 
functions and algorithms for scientific computing, data analysis, and machine learning.
See [numerics.net](https://numerics.net) for details.

---

_Last updated on 2025-05-06 3:03:10 PM (version 9.1.3)._
