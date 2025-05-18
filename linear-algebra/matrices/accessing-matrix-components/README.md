# Accessing Matrix Elements

This sample illustrates different ways of iterating through the rows and columns of a matrix using classes in the Numerics.NET.LinearAlgebra namespace using Numerics.NET.

## Overview

This QuickStart sample demonstrates the various ways to access and manipulate elements, rows, columns, and 
submatrices in Numerics.NET matrices.

The sample shows how to:
- Access individual matrix elements using index notation
- Extract complete or partial rows and columns using range syntax
- Use the `GetRow` and `GetColumn` methods for accessing matrix components
- Enumerate through matrix rows and columns 
- Access matrix diagonals and superdiagonals
- Work with submatrices through both indexing and dedicated methods
- Assign values to matrix components, including rows, columns and submatrices

The sample provides practical examples of each operation, demonstrating both read and write 
operations on matrices. It illustrates the flexibility of Numerics.NET's matrix access methods,
from simple element access to sophisticated operations on matrix substructures.


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
[C#](https://github.com/NumericsDotNet/quickstart-csharp/tree/net462/linear-algebra/matrices/accessing-matrix-components), [Visual Basic](https://github.com/NumericsDotNet/quickstart-visualbasic/tree/net462/linear-algebra/matrices/accessing-matrix-components), [IronPython](https://github.com/NumericsDotNet/quickstart-ironpython/tree/net462/linear-algebra/matrices/accessing-matrix-components).

You can find out more about the methods used in this sample from the Numerics.NET documentation.

### Numerics.NET User's Guide

- [Matrix Basics](https://numerics.net/documentation/latest/vector-and-matrix/matrices/matrix-basics)
- [Dense Matrices](https://numerics.net/documentation/latest/vector-and-matrix/matrices/dense-matrices)
- [Accessing Rows and Columns](https://numerics.net/documentation/latest/vector-and-matrix/matrices/accessing-rows-and-columns)

### Numerics.NET API Reference

- [Matrix&lt;T&gt; class](https://numerics.net/documentation/latest/reference/numerics.net.matrix-1)
- [Vector&lt;T&gt; class](https://numerics.net/documentation/latest/reference/numerics.net.vector-1)
- [Range structure](https://numerics.net/documentation/latest/reference/numerics.net.range)


## Troubleshooting

### Common Issues

- **Missing dependencies**: Make sure to run `dotnet restore` before building
- **License verification failed**: Ensure you have a valid trial key from [https://numerics.net/trial-key](https://numerics.net/trial-key)
- **Runtime errors**: Check that you're targeting the correct .NET version (.NET 6 or .NET 8)

### Need Help?

- Check the [Numerics.NET documentation](https://numerics.net/documentation/)
- Contact support at [support@numerics.net](mailto:support@numerics.net?subject=AccessingMatrixComponents%20QuickStart%20Sample%20%28F%23%29)

## About Numerics.NET

Numerics.NET is a powerful numerical library for .NET that provides advanced mathematical 
functions and algorithms for scientific computing, data analysis, and machine learning.
See [numerics.net](https://numerics.net) for details.

---

_Last updated on 2025-05-06 3:03:10 PM (version 9.1.3)._
