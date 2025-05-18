# Mixed Integer Programming

This sample illustrates how to solve mixed integer programming by solving Sudoku puzzles using the linear programming solver using Numerics.NET.

## Overview

This QuickStart sample demonstrates how to use mixed integer programming capabilities to solve complex constraint 
satisfaction problems, using a Sudoku puzzle as an engaging example.

The sample shows how to formulate the Sudoku puzzle as a mixed integer programming problem by:
- Creating binary variables to represent possible digit placements
- Expressing Sudoku rules as linear constraints
- Setting up constraints for each position, row, column, and 3x3 block
- Using bound constraints to fix known values
- Solving the system to find a valid solution

The code specifically tackles the puzzle known as "the world's hardest Sudoku" to demonstrate the 
power of the approach. It showcases key features of the LinearProgram class including:
- Adding binary variables
- Creating linear constraints
- Setting variable bounds
- Solving mixed integer programs

This example illustrates how mathematical programming can be used to solve constraint satisfaction
problems that might be difficult to solve using traditional algorithmic approaches.


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
[C#](https://github.com/NumericsDotNet/quickstart-csharp/tree/net8.0/mathematics/optimization/mixed-integer-programming), [Visual Basic](https://github.com/NumericsDotNet/quickstart-visualbasic/tree/net8.0/mathematics/optimization/mixed-integer-programming), [IronPython](https://github.com/NumericsDotNet/quickstart-ironpython/tree/net8.0/mathematics/optimization/mixed-integer-programming).

You can find out more about the methods used in this sample from the Numerics.NET documentation.

### Numerics.NET User's Guide

- [Optimization Model Basics](https://numerics.net/documentation/latest/mathematics/optimization/optimization-model-basics)
- [Linear Programming](https://numerics.net/documentation/latest/mathematics/optimization/linear-programming)
- [Nonlinear Programming](https://numerics.net/documentation/latest/mathematics/optimization/nonlinear-programming)

### Numerics.NET API Reference

- [LinearProgram class](https://numerics.net/documentation/latest/reference/numerics.net.optimization.linearprogram)
- [LinearProgramVariable class](https://numerics.net/documentation/latest/reference/numerics.net.optimization.linearprogramvariable)
- [Numerics.NET.Optimization namespace](https://numerics.net/documentation/latest/reference/numerics.net.optimization)


## Troubleshooting

### Common Issues

- **Missing dependencies**: Make sure to run `dotnet restore` before building
- **License verification failed**: Ensure you have a valid trial key from [https://numerics.net/trial-key](https://numerics.net/trial-key)
- **Runtime errors**: Check that you're targeting the correct .NET version (.NET 6 or .NET 8)

### Need Help?

- Check the [Numerics.NET documentation](https://numerics.net/documentation/)
- Contact support at [support@numerics.net](mailto:support@numerics.net?subject=MixedIntegerProgramming%20QuickStart%20Sample%20%28F%23%29)

## About Numerics.NET

Numerics.NET is a powerful numerical library for .NET that provides advanced mathematical 
functions and algorithms for scientific computing, data analysis, and machine learning.
See [numerics.net](https://numerics.net) for details.

---

_Last updated on 2025-05-06 3:03:10 PM (version 9.1.3)._
