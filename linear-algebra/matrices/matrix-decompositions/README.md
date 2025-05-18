# Matrix Decompositions

This sample illustrates how compute various decompositions of a matrix using classes in the Numerics.NET.LinearAlgebra namespace using Numerics.NET.

## Overview

This QuickStart sample demonstrates how to compute and work with various matrix decompositions using the 
Numerics.NET library. Matrix decompositions are fundamental tools in linear algebra that break down
matrices into products of simpler matrices with special properties.

The sample covers four major matrix decompositions:

- LU Decomposition (A = PLU): Shows how to factor a matrix into a product of a permutation matrix
  (P), lower triangular matrix (L), and upper triangular matrix (U). Demonstrates solving linear
  systems and computing matrix inverses and determinants.

- QR Decomposition (A = QR): Illustrates factoring a matrix into a product of an orthogonal matrix
  (Q) and upper triangular matrix (R). Shows how to solve least squares problems for
  overdetermined systems.

- Singular Value Decomposition (A = USVᵀ): Demonstrates computing the SVD which factors a matrix
  into orthogonal matrices U and V and a diagonal matrix S containing singular values. Shows how
  to compute pseudoinverses and solve under/overdetermined systems.

- Cholesky Decomposition (A = LLᵀ): Shows how to factor a symmetric positive definite matrix into
  a product of a lower triangular matrix and its transpose. Demonstrates solving linear systems
  and computing matrix inverses.

The sample also includes eigenvalue decomposition of symmetric matrices, showing how to compute
eigenvalues and eigenvectors. For each decomposition, it demonstrates practical applications like
solving linear systems, computing matrix properties, and working with the factors.


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
[C#](https://github.com/NumericsDotNet/quickstart-csharp/tree/net462/linear-algebra/matrices/matrix-decompositions), [Visual Basic](https://github.com/NumericsDotNet/quickstart-visualbasic/tree/net462/linear-algebra/matrices/matrix-decompositions), [IronPython](https://github.com/NumericsDotNet/quickstart-ironpython/tree/net462/linear-algebra/matrices/matrix-decompositions).

You can find out more about the methods used in this sample from the Numerics.NET documentation.

### Numerics.NET User's Guide

- [The LU Decomposition](https://numerics.net/documentation/latest/vector-and-matrix/matrix-decompositions/lu-decomposition)
- [The QR Decomposition](https://numerics.net/documentation/latest/vector-and-matrix/matrix-decompositions/qr-decomposition)
- [The Singular Value Decomposition](https://numerics.net/documentation/latest/vector-and-matrix/matrix-decompositions/singular-value-decomposition)
- [The Cholesky Decomposition](https://numerics.net/documentation/latest/vector-and-matrix/matrix-decompositions/cholesky-decomposition)
- [The Eigenvalue Decomposition](https://numerics.net/documentation/latest/vector-and-matrix/matrix-decompositions/eigenvalue-decomposition)

### Numerics.NET API Reference

- [LUDecomposition&lt;T&gt; class](https://numerics.net/documentation/latest/reference/numerics.net.linearalgebra.ludecomposition-1)
- [QRDecomposition&lt;T&gt; class](https://numerics.net/documentation/latest/reference/numerics.net.linearalgebra.qrdecomposition-1)
- [SingularValueDecomposition&lt;T&gt; class](https://numerics.net/documentation/latest/reference/numerics.net.linearalgebra.singularvaluedecomposition-1)
- [CholeskyDecomposition&lt;T&gt; class](https://numerics.net/documentation/latest/reference/numerics.net.linearalgebra.choleskydecomposition-1)
- [EigenvalueDecomposition&lt;T&gt; class](https://numerics.net/documentation/latest/reference/numerics.net.linearalgebra.eigenvaluedecomposition-1)
- [Numerics.NET.LinearAlgebra namespace](https://numerics.net/documentation/latest/reference/numerics.net.linearalgebra)


## Troubleshooting

### Common Issues

- **Missing dependencies**: Make sure to run `dotnet restore` before building
- **License verification failed**: Ensure you have a valid trial key from [https://numerics.net/trial-key](https://numerics.net/trial-key)
- **Runtime errors**: Check that you're targeting the correct .NET version (.NET 6 or .NET 8)

### Need Help?

- Check the [Numerics.NET documentation](https://numerics.net/documentation/)
- Contact support at [support@numerics.net](mailto:support@numerics.net?subject=MatrixDecompositions%20QuickStart%20Sample%20%28F%23%29)

## About Numerics.NET

Numerics.NET is a powerful numerical library for .NET that provides advanced mathematical 
functions and algorithms for scientific computing, data analysis, and machine learning.
See [numerics.net](https://numerics.net) for details.

---

_Last updated on 2025-05-06 3:03:10 PM (version 9.1.3)._
