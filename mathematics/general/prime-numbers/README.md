# Prime Numbers

This sample illustrates working with prime numbers and the IntegerMath class in the Numerics.NET namespace using Numerics.NET.

## Overview

This QuickStart sample demonstrates how to work with prime numbers using the IntegerMath class from 
Numerics.NET. The sample shows essential operations for working with prime numbers and factorization.

The sample illustrates several key capabilities:
- Factoring integers into their prime components, including handling of repeated factors
- Testing numbers for primality using the IsPrime method
- Finding the next prime number greater than a given value
- Finding the previous prime number less than a given value
- Working with large numbers up to 48 bits in length

The code demonstrates practical applications like:
- Decomposing composite numbers into their prime factors with multiplicity
- Verifying whether large numbers are prime
- Generating sequences of consecutive prime numbers both forward and backward
- Handling edge cases with large integers and repeated factors

All operations use efficient algorithms optimized for performance while maintaining numerical accuracy.


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
[C#](https://github.com/NumericsDotNet/quickstart-csharp/tree/net8.0/mathematics/general/prime-numbers), [Visual Basic](https://github.com/NumericsDotNet/quickstart-visualbasic/tree/net8.0/mathematics/general/prime-numbers), [IronPython](https://github.com/NumericsDotNet/quickstart-ironpython/tree/net8.0/mathematics/general/prime-numbers).

You can find out more about the methods used in this sample from the Numerics.NET documentation.

### Numerics.NET User's Guide

- [Functions of Integers](https://numerics.net/documentation/latest/mathematics/mathematical-functions/functions-of-integers)
- [Mathematical Constants](https://numerics.net/documentation/latest/mathematics/general-classes/mathematical-constants)
- [Numerical Algorithms Support Classes](https://numerics.net/documentation/latest/mathematics/general-classes/numerical-algorithms-support-classes)

### Numerics.NET API Reference

- [IntegerMath class](https://numerics.net/documentation/latest/reference/numerics.net.integermath)


## Troubleshooting

### Common Issues

- **Missing dependencies**: Make sure to run `dotnet restore` before building
- **License verification failed**: Ensure you have a valid trial key from [https://numerics.net/trial-key](https://numerics.net/trial-key)
- **Runtime errors**: Check that you're targeting the correct .NET version (.NET 6 or .NET 8)

### Need Help?

- Check the [Numerics.NET documentation](https://numerics.net/documentation/)
- Contact support at [support@numerics.net](mailto:support@numerics.net?subject=PrimeNumbers%20QuickStart%20Sample%20%28F%23%29)

## About Numerics.NET

Numerics.NET is a powerful numerical library for .NET that provides advanced mathematical 
functions and algorithms for scientific computing, data analysis, and machine learning.
See [numerics.net](https://numerics.net) for details.

---

_Last updated on 2025-05-06 3:03:10 PM (version 9.1.3)._
