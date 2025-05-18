# Triangular Matrices

This sample illustrates how to work efficiently with upper or lower triangular or trapezoidal matrices using Numerics.NET.

## Overview

This QuickStart sample demonstrates how to work with triangular matrices in Numerics.NET. Triangular 
matrices are special matrices where all elements either above the diagonal (lower triangular) or below 
the diagonal (upper triangular) are zero.

The sample covers:
- Creating upper and lower triangular matrices through various constructors
- Working with unit diagonal triangular matrices (matrices with all 1's on the diagonal)
- Extracting triangular parts from dense matrices
- Accessing matrix properties like IsLowerTriangular and IsUpperTriangular
- Handling matrix elements and the restrictions on modifying zero elements
- Working with rows and columns of triangular matrices

The code illustrates proper error handling when attempting to modify read-only elements and shows how 
to efficiently work with these specialized matrix types. This is particularly useful in numerical 
algorithms where triangular matrices arise naturally, such as in LU decomposition or backward 
substitution.


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
[C#](https://github.com/NumericsDotNet/quickstart-csharp/tree/net462/linear-algebra/matrices/triangular-matrices), [Visual Basic](https://github.com/NumericsDotNet/quickstart-visualbasic/tree/net462/linear-algebra/matrices/triangular-matrices), [IronPython](https://github.com/NumericsDotNet/quickstart-ironpython/tree/net462/linear-algebra/matrices/triangular-matrices).

You can find out more about the methods used in this sample from the Numerics.NET documentation.

### Numerics.NET User's Guide

- [Triangular Matrices](https://numerics.net/documentation/latest/vector-and-matrix/structured-matrix-types/triangular-matrices)
- [Matrix Basics](https://numerics.net/documentation/latest/vector-and-matrix/matrices/matrix-basics)
- [The LU Decomposition](https://numerics.net/documentation/latest/vector-and-matrix/matrix-decompositions/lu-decomposition)

### Numerics.NET API Reference

- [TriangularMatrix&lt;T&gt; class](https://numerics.net/documentation/latest/reference/numerics.net.linearalgebra.triangularmatrix-1)
- [MatrixTriangle enumeration](https://numerics.net/documentation/latest/reference/numerics.net.matrixtriangle)
- [Numerics.NET.LinearAlgebra namespace](https://numerics.net/documentation/latest/reference/numerics.net.linearalgebra)


## Troubleshooting

### Common Issues

- **Missing dependencies**: Make sure to run `dotnet restore` before building
- **License verification failed**: Ensure you have a valid trial key from [https://numerics.net/trial-key](https://numerics.net/trial-key)
- **Runtime errors**: Check that you're targeting the correct .NET version (.NET 6 or .NET 8)

### Need Help?

- Check the [Numerics.NET documentation](https://numerics.net/documentation/)
- Contact support at [support@numerics.net](mailto:support@numerics.net?subject=TriangularMatrices%20QuickStart%20Sample%20%28F%23%29)

## About Numerics.NET

Numerics.NET is a powerful numerical library for .NET that provides advanced mathematical 
functions and algorithms for scientific computing, data analysis, and machine learning.
See [numerics.net](https://numerics.net) for details.

---

_Last updated on 2025-05-06 3:03:10 PM (version 9.1.3)._
