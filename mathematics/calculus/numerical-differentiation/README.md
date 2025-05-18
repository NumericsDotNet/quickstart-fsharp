# Numerical Differentiation

This sample illustrates how to approximate the derivative of a function using Numerics.NET.

## Overview

This QuickStart sample demonstrates how to perform numerical differentiation using Numerics.NET. It shows how to 
calculate derivatives of functions using different numerical methods including central, forward, and 
backward differences.

The sample covers:
- Using central differences for standard numerical differentiation
- Handling edge cases with forward and backward differences when central differences aren't suitable
- Error estimation in numerical differentiation results
- Creating derivative functions as delegates that can be passed to other methods
- Working with functions that have domain restrictions or discontinuities

The code demonstrates practical scenarios where each differentiation method is most appropriate, 
including functions undefined on part of their domain and functions with discontinuities. It also shows 
how to obtain error estimates for the calculated derivatives, which is crucial for assessing the 
accuracy of the numerical results.


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
[C#](https://github.com/NumericsDotNet/quickstart-csharp/tree/net8.0/mathematics/calculus/numerical-differentiation), [Visual Basic](https://github.com/NumericsDotNet/quickstart-visualbasic/tree/net8.0/mathematics/calculus/numerical-differentiation), [IronPython](https://github.com/NumericsDotNet/quickstart-ironpython/tree/net8.0/mathematics/calculus/numerical-differentiation).

You can find out more about the methods used in this sample from the Numerics.NET documentation.

### Numerics.NET User's Guide

- [Numerical Differentiation](https://numerics.net/documentation/latest/mathematics/calculus/numerical-differentiation)
- [Enumeration Types](https://numerics.net/documentation/latest/mathematics/appendices/enumeration-types)

### Numerics.NET API Reference

- [FunctionMath class](https://numerics.net/documentation/latest/reference/numerics.net.functionmath)
- [FiniteDifferenceMethod class](https://numerics.net/documentation/latest/reference/numerics.net.calculus.finitedifferencemethod)
- [Numerics.NET.Calculus namespace](https://numerics.net/documentation/latest/reference/numerics.net.calculus)


## Troubleshooting

### Common Issues

- **Missing dependencies**: Make sure to run `dotnet restore` before building
- **License verification failed**: Ensure you have a valid trial key from [https://numerics.net/trial-key](https://numerics.net/trial-key)
- **Runtime errors**: Check that you're targeting the correct .NET version (.NET 6 or .NET 8)

### Need Help?

- Check the [Numerics.NET documentation](https://numerics.net/documentation/)
- Contact support at [support@numerics.net](mailto:support@numerics.net?subject=NumericalDifferentiation%20QuickStart%20Sample%20%28F%23%29)

## About Numerics.NET

Numerics.NET is a powerful numerical library for .NET that provides advanced mathematical 
functions and algorithms for scientific computing, data analysis, and machine learning.
See [numerics.net](https://numerics.net) for details.

---

_Last updated on 2025-05-06 3:03:10 PM (version 9.1.3)._
