# Generic Algorithms

This sample illustrates how to write algorithms that are generic over the numerical type of the arguments using Numerics.NET.

## Overview

This QuickStart sample demonstrates how to write numerical algorithms that can work with different numeric types
using Numerics.NET's generic arithmetic capabilities.

The sample implements a Newton-Raphson root-finding algorithm that can work with any numeric type
that supports the required operations. It shows how to:

- Create a generic solver class that can work with different numeric types
- Use the Operations<T> class to perform arithmetic operations generically
- Solve equations using different numeric types including:
  - BigFloat for arbitrary-precision floating point
  - BigRational for exact rational arithmetic
  - Double for standard floating point

The sample includes concrete examples that:
- Compute π by finding the root of sin(x) using arbitrary precision arithmetic
- Calculate √2 using exact rational arithmetic
- Find the value of Lambert's W function using double precision

It demonstrates how to write truly generic numerical code that can work with any numeric type while
maintaining good performance and numerical stability. The sample also shows how to use
Numerics.NET's generic provider system and license verification.


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
[C#](https://github.com/NumericsDotNet/quickstart-csharp/tree/net6.0/mathematics/general/generic-algorithms), [Visual Basic](https://github.com/NumericsDotNet/quickstart-visualbasic/tree/net6.0/mathematics/general/generic-algorithms).

You can find out more about the methods used in this sample from the Numerics.NET documentation.

### Numerics.NET User's Guide

- [Generic Arithmetic](https://numerics.net/documentation/latest/mathematics/generic-arithmetic)
- [Machine Constants](https://numerics.net/documentation/latest/mathematics/general-classes/machine-constants)
- [Methods that use the Derivative](https://numerics.net/documentation/latest/mathematics/solving-equations/methods-that-use-the-derivative)
- [Arbitrary Precision Floating-Point Numbers](https://numerics.net/documentation/latest/mathematics/arbitrary-precision-arithmetic/arbitrary-precision-floating-point-numbers)
- [Arbitrary Precision Rationals](https://numerics.net/documentation/latest/mathematics/arbitrary-precision-arithmetic/arbitrary-precision-rationals)

### Numerics.NET API Reference

- [Operations&lt;T&gt; class](https://numerics.net/documentation/latest/reference/numerics.net.operations-1)
- [Numerics.NET.Algorithms namespace](https://numerics.net/documentation/latest/reference/numerics.net.algorithms)


## Troubleshooting

### Common Issues

- **Missing dependencies**: Make sure to run `dotnet restore` before building
- **License verification failed**: Ensure you have a valid trial key from [https://numerics.net/trial-key](https://numerics.net/trial-key)
- **Runtime errors**: Check that you're targeting the correct .NET version (.NET 6 or .NET 8)

### Need Help?

- Check the [Numerics.NET documentation](https://numerics.net/documentation/)
- Contact support at [support@numerics.net](mailto:support@numerics.net?subject=GenericAlgorithms%20QuickStart%20Sample%20%28F%23%29)

## About Numerics.NET

Numerics.NET is a powerful numerical library for .NET that provides advanced mathematical 
functions and algorithms for scientific computing, data analysis, and machine learning.
See [numerics.net](https://numerics.net) for details.

---

_Last updated on 2025-05-06 3:03:10 PM (version 9.1.3)._
