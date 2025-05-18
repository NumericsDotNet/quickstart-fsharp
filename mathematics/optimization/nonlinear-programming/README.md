# Nonlinear Programming

This sample illustrates solving nonlinear programs (optimization problems with linear or nonlinear constraints) using the NonlinearProgram and related classes using Numerics.NET.

## Overview

This QuickStart sample demonstrates how to solve nonlinear optimization problems with constraints using the 
NonlinearProgram class in Numerics.NET.

The sample presents three different approaches to solving nonlinear programming problems:

1. A chemical equilibrium problem with linear constraints, demonstrating how to:
   - Define an objective function involving logarithms
   - Set up linear constraints using sparse matrices
   - Handle variable bounds
   - Solve a real-world optimization problem

2. A mathematical optimization problem with nonlinear constraints, showing:
   - How to build a nonlinear program from scratch
   - Adding nonlinear constraints with manually specified gradients
   - Adding constraints where gradients are approximated numerically
   - Setting initial values for the optimization

3. The same mathematical problem solved using automatic differentiation, illustrating:
   - How to simplify implementation by using symbolic functions
   - Letting the system automatically compute required gradients
   - Comparing results with the manual approach

Each approach is fully documented with code and explanatory comments, making it easy to understand
the different ways of setting up and solving nonlinear programming problems.


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
[C#](https://github.com/NumericsDotNet/quickstart-csharp/tree/net6.0/mathematics/optimization/nonlinear-programming), [Visual Basic](https://github.com/NumericsDotNet/quickstart-visualbasic/tree/net6.0/mathematics/optimization/nonlinear-programming), [IronPython](https://github.com/NumericsDotNet/quickstart-ironpython/tree/net6.0/mathematics/optimization/nonlinear-programming).

You can find out more about the methods used in this sample from the Numerics.NET documentation.

### Numerics.NET User's Guide

- [Nonlinear Programming](https://numerics.net/documentation/latest/mathematics/optimization/nonlinear-programming)
- [Optimization Model Basics](https://numerics.net/documentation/latest/mathematics/optimization/optimization-model-basics)

### Numerics.NET API Reference

- [NonlinearProgram class](https://numerics.net/documentation/latest/reference/numerics.net.optimization.nonlinearprogram)
- [Numerics.NET.Optimization namespace](https://numerics.net/documentation/latest/reference/numerics.net.optimization)


## Troubleshooting

### Common Issues

- **Missing dependencies**: Make sure to run `dotnet restore` before building
- **License verification failed**: Ensure you have a valid trial key from [https://numerics.net/trial-key](https://numerics.net/trial-key)
- **Runtime errors**: Check that you're targeting the correct .NET version (.NET 6 or .NET 8)

### Need Help?

- Check the [Numerics.NET documentation](https://numerics.net/documentation/)
- Contact support at [support@numerics.net](mailto:support@numerics.net?subject=NonlinearProgramming%20QuickStart%20Sample%20%28F%23%29)

## About Numerics.NET

Numerics.NET is a powerful numerical library for .NET that provides advanced mathematical 
functions and algorithms for scientific computing, data analysis, and machine learning.
See [numerics.net](https://numerics.net) for details.

---

_Last updated on 2025-05-06 3:03:10 PM (version 9.1.3)._
