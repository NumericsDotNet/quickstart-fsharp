# Nonlinear Systems

This sample illustrates the use of the NewtonRaphsonSystemSolver and DoglegSystemSolver classes for solving systems of nonlinear equations using Numerics.NET.

## Overview

This QuickStart sample demonstrates how to solve systems of nonlinear equations using Numerics.NET's equation 
solver classes.

The sample illustrates solving a system of two nonlinear equations using both the Newton-Raphson method
and Powell's dogleg method. It shows:

- How to define systems of equations using delegates
- How to provide derivatives (the Jacobian matrix) for better performance
- How to use automatic differentiation when derivatives are not available
- How to control convergence criteria and iteration limits
- How to interpret solver status and results
- How to use Powell's dogleg method for more robust convergence
- How to solve systems without providing derivatives

The sample includes extensive comments explaining each step and demonstrates various solver options
and parameters that control the solution process. It shows how to handle both simple cases and more
complex scenarios where additional control over the solution process is needed.


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
[C#](https://github.com/NumericsDotNet/quickstart-csharp/tree/net6.0/mathematics/solving-equations/nonlinear-systems), [Visual Basic](https://github.com/NumericsDotNet/quickstart-visualbasic/tree/net6.0/mathematics/solving-equations/nonlinear-systems), [IronPython](https://github.com/NumericsDotNet/quickstart-ironpython/tree/net6.0/mathematics/solving-equations/nonlinear-systems).

You can find out more about the methods used in this sample from the Numerics.NET documentation.

### Numerics.NET User's Guide

- [Solving Systems of Non-Linear Equations](https://numerics.net/documentation/latest/mathematics/solving-equations/solving-systems-of-non-linear-equations)
- [Methods that use the Derivative](https://numerics.net/documentation/latest/mathematics/solving-equations/methods-that-use-the-derivative)
- [Methods that do not use the derivative](https://numerics.net/documentation/latest/mathematics/solving-equations/methods-that-do-not-use-the-derivative)

### Numerics.NET API Reference

- [NewtonRaphsonSystemSolver class](https://numerics.net/documentation/latest/reference/numerics.net.equationsolvers.newtonraphsonsystemsolver)
- [DoglegSystemSolver class](https://numerics.net/documentation/latest/reference/numerics.net.equationsolvers.doglegsystemsolver)
- [Numerics.NET.EquationSolvers namespace](https://numerics.net/documentation/latest/reference/numerics.net.equationsolvers)


## Troubleshooting

### Common Issues

- **Missing dependencies**: Make sure to run `dotnet restore` before building
- **License verification failed**: Ensure you have a valid trial key from [https://numerics.net/trial-key](https://numerics.net/trial-key)
- **Runtime errors**: Check that you're targeting the correct .NET version (.NET 6 or .NET 8)

### Need Help?

- Check the [Numerics.NET documentation](https://numerics.net/documentation/)
- Contact support at [support@numerics.net](mailto:support@numerics.net?subject=NonlinearSystems%20QuickStart%20Sample%20%28F%23%29)

## About Numerics.NET

Numerics.NET is a powerful numerical library for .NET that provides advanced mathematical 
functions and algorithms for scientific computing, data analysis, and machine learning.
See [numerics.net](https://numerics.net) for details.

---

_Last updated on 2025-05-06 3:03:10 PM (version 9.1.3)._
