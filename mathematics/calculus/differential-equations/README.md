# Differential Equations

This sample illustrates integrating systems of ordinary differential equations (ODE's) using Numerics.NET.

## Overview

This QuickStart sample demonstrates how to solve ordinary differential equations (ODEs) using Numerics.NET's 
ODE solver capabilities.

The sample illustrates three different ODE solvers:
- The classic 4th order Runge-Kutta method with fixed step size
- The Runge-Kutta-Fehlberg method (RKF45) with adaptive step size control
- The CVODE solver from the SUNDIALS suite, which can efficiently handle both non-stiff and stiff 
  problems

The sample uses these solvers on two test problems:
1. The Lorenz attractor - a nonlinear system of three coupled equations that exhibits chaotic 
   behavior. This demonstrates basic usage of the solvers on a non-stiff system.
2. A flame expansion problem - a single nonlinear equation that becomes increasingly stiff as the 
   initial condition approaches zero. This shows how CVODE's implicit methods can efficiently handle 
   stiff problems where explicit methods struggle.

The code shows how to:
- Set up and configure different ODE solvers
- Define systems of differential equations using delegate functions
- Provide Jacobian matrices for stiff problems
- Control integration accuracy through step size and tolerance settings
- Access solver statistics and intermediate results


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
[C#](https://github.com/NumericsDotNet/quickstart-csharp/tree/net462/mathematics/calculus/differential-equations), [Visual Basic](https://github.com/NumericsDotNet/quickstart-visualbasic/tree/net462/mathematics/calculus/differential-equations), [IronPython](https://github.com/NumericsDotNet/quickstart-ironpython/tree/net462/mathematics/calculus/differential-equations).

You can find out more about the methods used in this sample from the Numerics.NET documentation.

### Numerics.NET User's Guide

- [Ordinary Differential Equations](https://numerics.net/documentation/latest/mathematics/calculus/ordinary-differential-equations)
- [Numerical Integration](https://numerics.net/documentation/latest/mathematics/calculus/numerical-integration)
- [Numerical Differentiation](https://numerics.net/documentation/latest/mathematics/calculus/numerical-differentiation)

### Numerics.NET API Reference

- [OdeIntegrator class](https://numerics.net/documentation/latest/reference/numerics.net.calculus.ordinarydifferentialequations.odeintegrator)
- [ClassicRungeKuttaIntegrator class](https://numerics.net/documentation/latest/reference/numerics.net.calculus.ordinarydifferentialequations.ClassicRungeKuttaIntegrator)
- [Numerics.NET.Calculus.OrdinaryDifferentialEquations namespace](https://numerics.net/documentation/latest/reference/numerics.net.calculus.ordinarydifferentialequations)


## Troubleshooting

### Common Issues

- **Missing dependencies**: Make sure to run `dotnet restore` before building
- **License verification failed**: Ensure you have a valid trial key from [https://numerics.net/trial-key](https://numerics.net/trial-key)
- **Runtime errors**: Check that you're targeting the correct .NET version (.NET 6 or .NET 8)

### Need Help?

- Check the [Numerics.NET documentation](https://numerics.net/documentation/)
- Contact support at [support@numerics.net](mailto:support@numerics.net?subject=DifferentialEquations%20QuickStart%20Sample%20%28F%23%29)

## About Numerics.NET

Numerics.NET is a powerful numerical library for .NET that provides advanced mathematical 
functions and algorithms for scientific computing, data analysis, and machine learning.
See [numerics.net](https://numerics.net) for details.

---

_Last updated on 2025-05-06 3:03:10 PM (version 9.1.3)._
