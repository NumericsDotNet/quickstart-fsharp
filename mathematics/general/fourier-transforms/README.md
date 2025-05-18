# FFT/Fourier Transforms

This sample illustrates how to compute the forward and inverse Fourier transform of a real or complex signal using classes in the Numerics.NET.SignalProcessing namespace using Numerics.NET.

## Overview

This QuickStart sample demonstrates how to compute Fast Fourier Transforms (FFT) using Numerics.NET's signal
processing capabilities.

The sample shows several approaches to computing Fourier transforms:

- Using static methods for one-time FFT computations on both real and complex vectors
- Creating reusable FFT objects for efficient repeated transforms of the same size
- Working with one-sided FFTs for real signals
- Computing 2D Fourier transforms on matrices

The code illustrates important concepts including:
- Handling complex conjugate symmetry in real signal transforms
- Setting scale factors for forward and inverse transforms
- Using different FFT formats and overloads
- Proper resource management with disposable FFT objects
- Working with both one-dimensional and two-dimensional transforms

The sample includes examples with both synthetic test data and more realistic signal processing
scenarios, making it a practical introduction to FFT computations in Numerics.NET.


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
[C#](https://github.com/NumericsDotNet/quickstart-csharp/tree/net462/mathematics/general/fourier-transforms), [Visual Basic](https://github.com/NumericsDotNet/quickstart-visualbasic/tree/net462/mathematics/general/fourier-transforms), [IronPython](https://github.com/NumericsDotNet/quickstart-ironpython/tree/net462/mathematics/general/fourier-transforms).

You can find out more about the methods used in this sample from the Numerics.NET documentation.

### Numerics.NET User's Guide

- [One-Dimensional Fast Fourier Transforms](https://numerics.net/documentation/latest/mathematics/fast-fourier-transforms/one-dimensional-fast-fourier-transforms)
- [Two-Dimensional Fast Fourier Transforms](https://numerics.net/documentation/latest/mathematics/fast-fourier-transforms/two-dimensional-fast-fourier-transforms)
- [Window Functions](https://numerics.net/documentation/latest/mathematics/fast-fourier-transforms/window-functions)

### Numerics.NET API Reference

- [FFT&lt;T&gt; class](https://numerics.net/documentation/latest/reference/numerics.net.signalprocessing.fft-1)
- [FFT2D&lt;T&gt; class](https://numerics.net/documentation/latest/reference/numerics.net.signalprocessing.fft2d-1)
- [Complex&lt;T&gt; structure](https://numerics.net/documentation/latest/reference/numerics.net.complex-1)
- [Numerics.NET.SignalProcessing namespace](https://numerics.net/documentation/latest/reference/numerics.net.signalprocessing)


## Troubleshooting

### Common Issues

- **Missing dependencies**: Make sure to run `dotnet restore` before building
- **License verification failed**: Ensure you have a valid trial key from [https://numerics.net/trial-key](https://numerics.net/trial-key)
- **Runtime errors**: Check that you're targeting the correct .NET version (.NET 6 or .NET 8)

### Need Help?

- Check the [Numerics.NET documentation](https://numerics.net/documentation/)
- Contact support at [support@numerics.net](mailto:support@numerics.net?subject=FourierTransforms%20QuickStart%20Sample%20%28F%23%29)

## About Numerics.NET

Numerics.NET is a powerful numerical library for .NET that provides advanced mathematical 
functions and algorithms for scientific computing, data analysis, and machine learning.
See [numerics.net](https://numerics.net) for details.

---

_Last updated on 2025-05-06 3:03:10 PM (version 9.1.3)._
