# Basic Tensors

This sample illustrates the basic use of the Tensor class for working with tensors using Numerics.NET.

## Overview

This QuickStart sample demonstrates the fundamental operations for creating and working with tensors in Numerics.NET.

The sample shows various ways to construct tensors, from simple scalar values to multi-dimensional arrays.
It demonstrates creating tensors from arrays, memory blocks, and generator functions. Key features covered
include:

- Creating scalar tensors
- Constructing tensors from arrays and memory blocks
- Generating tensors using functions
- Creating tensors with ranges and random values
- Accessing tensor properties like rank, shape, and layout

The sample provides practical examples of each approach, with explanatory comments showing the expected
output. This makes it an excellent starting point for developers new to tensor operations in
Numerics.NET, while also serving as a quick reference for common tensor creation patterns.


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
[C#](https://github.com/NumericsDotNet/quickstart-csharp/tree/net462/linear-algebra/tensors/basic-tensors), [Visual Basic](https://github.com/NumericsDotNet/quickstart-visualbasic/tree/net462/linear-algebra/tensors/basic-tensors).

You can find out more about the methods used in this sample from the Numerics.NET documentation.

### Numerics.NET User's Guide

- [Tensor Basics](https://numerics.net/documentation/latest/vector-and-matrix/tensors/tensor-basics)
- [Creating Tensors](https://numerics.net/documentation/latest/vector-and-matrix/tensors/creating-tensors)
- [Accessing Tensor Elements](https://numerics.net/documentation/latest/vector-and-matrix/tensors/accessing-tensor-elements)

### Numerics.NET API Reference

- [Tensor class](https://numerics.net/documentation/latest/reference/numerics.net.tensors.tensor)
- [Tensor&lt;T&gt; class](https://numerics.net/documentation/latest/reference/numerics.net.tensors.tensor-1)
- [TensorShape class](https://numerics.net/documentation/latest/reference/numerics.net.tensors.tensorshape)
- [Numerics.NET.Tensors namespace](https://numerics.net/documentation/latest/reference/numerics.net.tensors)


## Troubleshooting

### Common Issues

- **Missing dependencies**: Make sure to run `dotnet restore` before building
- **License verification failed**: Ensure you have a valid trial key from [https://numerics.net/trial-key](https://numerics.net/trial-key)
- **Runtime errors**: Check that you're targeting the correct .NET version (.NET 6 or .NET 8)

### Need Help?

- Check the [Numerics.NET documentation](https://numerics.net/documentation/)
- Contact support at [support@numerics.net](mailto:support@numerics.net?subject=BasicTensors%20QuickStart%20Sample%20%28F%23%29)

## About Numerics.NET

Numerics.NET is a powerful numerical library for .NET that provides advanced mathematical 
functions and algorithms for scientific computing, data analysis, and machine learning.
See [numerics.net](https://numerics.net) for details.

---

_Last updated on 2025-05-06 3:03:10 PM (version 9.1.3)._
