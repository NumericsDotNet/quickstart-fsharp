# Iterative Sparse Solvers

This sample illustrates the use of iterative sparse solvers and preconditioners for efficiently solving large, sparse systems of linear equations using Numerics.NET.

## Overview

This QuickStart sample demonstrates how to solve large sparse systems of linear equations using iterative 
solvers and preconditioners in Numerics.NET.

The sample shows two main examples:

1. Solving a non-symmetric sparse system loaded from Matrix Market files using the BiConjugate Gradient 
solver. It demonstrates how to:
   - Load sparse matrices from files
   - Create and configure an iterative solver
   - Apply preconditioners to improve convergence
   - Monitor solution progress and error estimates

2. Solving the Laplace equation on a rectangular grid using a symmetric solver. This example shows how to:
   - Construct a sparse matrix representing the discretized Laplace operator
   - Set up boundary conditions
   - Solve the resulting system using the Quasi-Minimal Residual method
   - Handle symmetric vs non-symmetric systems appropriately

The sample illustrates proper error handling, solver selection based on matrix properties, and the 
benefits of preconditioning for convergence acceleration. It provides a practical introduction to solving
large-scale sparse linear systems efficiently.


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
[C#](https://github.com/NumericsDotNet/quickstart-csharp/tree/net8.0/linear-algebra/solving-equations-and-least-squares/iterative-sparse-solvers), [Visual Basic](https://github.com/NumericsDotNet/quickstart-visualbasic/tree/net8.0/linear-algebra/solving-equations-and-least-squares/iterative-sparse-solvers), [IronPython](https://github.com/NumericsDotNet/quickstart-ironpython/tree/net8.0/linear-algebra/solving-equations-and-least-squares/iterative-sparse-solvers).

You can find out more about the methods used in this sample from the Numerics.NET documentation.

### Numerics.NET User's Guide

- [Solving Sparse Systems](https://numerics.net/documentation/latest/vector-and-matrix/sparse-vectors-and-matrices/solving-sparse-systems)
- [Sparse Matrices](https://numerics.net/documentation/latest/vector-and-matrix/sparse-vectors-and-matrices/sparse-matrices)

### Numerics.NET API Reference

- [ConjugateGradientSolver&lt;T&gt; class](https://numerics.net/documentation/latest/reference/numerics.net.linearalgebra.iterativesolvers.conjugategradientsolver-1)
- [BiConjugateGradientStabilizedSolver&lt;T&gt; class](https://numerics.net/documentation/latest/reference/numerics.net.linearalgebra.iterativesolvers.biconjugategradientstabilizedsolver-1)
- [IncompleteLUPreconditioner&lt;T&gt; class](https://numerics.net/documentation/latest/reference/numerics.net.linearalgebra.iterativesolvers.preconditioners.incompletelupreconditioner-1)
- [SparseMatrix&lt;T&gt; class](https://numerics.net/documentation/latest/reference/numerics.net.linearalgebra.sparsematrix-1)
- [Numerics.NET.LinearAlgebra.IterativeSolvers namespace](https://numerics.net/documentation/latest/reference/numerics.net.linearalgebra.iterativesolvers)


## Troubleshooting

### Common Issues

- **Missing dependencies**: Make sure to run `dotnet restore` before building
- **License verification failed**: Ensure you have a valid trial key from [https://numerics.net/trial-key](https://numerics.net/trial-key)
- **Runtime errors**: Check that you're targeting the correct .NET version (.NET 6 or .NET 8)

### Need Help?

- Check the [Numerics.NET documentation](https://numerics.net/documentation/)
- Contact support at [support@numerics.net](mailto:support@numerics.net?subject=IterativeSparseSolvers%20QuickStart%20Sample%20%28F%23%29)

## About Numerics.NET

Numerics.NET is a powerful numerical library for .NET that provides advanced mathematical 
functions and algorithms for scientific computing, data analysis, and machine learning.
See [numerics.net](https://numerics.net) for details.

---

_Last updated on 2025-05-06 3:03:10 PM (version 9.1.3)._
