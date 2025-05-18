# Quadratic Programming

This sample illustrates how to solve optimization problems a quadratic objective function and linear constraints using classes in the Numerics.NET.Optimization namespace using Numerics.NET.

## Overview

This QuickStart sample demonstrates how to solve quadratic programming (QP) problems using the
Numerics.NET optimization classes. The sample focuses on portfolio optimization as a practical
application of quadratic programming.

The sample illustrates three different approaches to creating and solving quadratic programming
problems:

1. Matrix-based approach - Shows how to construct a QP problem using matrices and vectors to
   represent the objective function and constraints. This is the most concise approach when working
   with problems already formulated in matrix form.

2. Incremental construction - Demonstrates building a QP problem step by step by adding variables,
   constraints, and quadratic terms individually. This approach provides more flexibility and can
   be easier to understand for problems naturally specified in terms of individual relationships.

3. MPS file input - Shows how to load a quadratic programming problem from an industry-standard
   MPS file format, useful when working with problems defined in external systems.

The portfolio optimization example minimizes investment risk (represented by the variance of
returns) while meeting constraints on total investment and minimum expected return. The quadratic
term represents the covariance matrix of asset returns, capturing how different investments
interact to affect overall portfolio risk.


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
[C#](https://github.com/NumericsDotNet/quickstart-csharp/tree/net462/mathematics/optimization/quadratic-programming), [Visual Basic](https://github.com/NumericsDotNet/quickstart-visualbasic/tree/net462/mathematics/optimization/quadratic-programming), [IronPython](https://github.com/NumericsDotNet/quickstart-ironpython/tree/net462/mathematics/optimization/quadratic-programming).

You can find out more about the methods used in this sample from the Numerics.NET documentation.

### Numerics.NET User's Guide

- [Quadratic Programming](https://numerics.net/documentation/latest/mathematics/optimization/quadratic-programming)
- [Optimization Model Basics](https://numerics.net/documentation/latest/mathematics/optimization/optimization-model-basics)
- [Dense Matrices](https://numerics.net/documentation/latest/vector-and-matrix/matrices/dense-matrices)

### Numerics.NET API Reference

- [QuadraticProgram class](https://numerics.net/documentation/latest/reference/numerics.net.optimization.quadraticprogram)
- [LinearConstraint class](https://numerics.net/documentation/latest/reference/numerics.net.optimization.linearconstraint)
- [DecisionVariable class](https://numerics.net/documentation/latest/reference/numerics.net.optimization.decisionvariable)
- [Numerics.NET.Optimization namespace](https://numerics.net/documentation/latest/reference/numerics.net.optimization)


## Troubleshooting

### Common Issues

- **Missing dependencies**: Make sure to run `dotnet restore` before building
- **License verification failed**: Ensure you have a valid trial key from [https://numerics.net/trial-key](https://numerics.net/trial-key)
- **Runtime errors**: Check that you're targeting the correct .NET version (.NET 6 or .NET 8)

### Need Help?

- Check the [Numerics.NET documentation](https://numerics.net/documentation/)
- Contact support at [support@numerics.net](mailto:support@numerics.net?subject=QuadraticProgramming%20QuickStart%20Sample%20%28F%23%29)

## About Numerics.NET

Numerics.NET is a powerful numerical library for .NET that provides advanced mathematical 
functions and algorithms for scientific computing, data analysis, and machine learning.
See [numerics.net](https://numerics.net) for details.

---

_Last updated on 2025-05-06 3:03:10 PM (version 9.1.3)._
