//=====================================================================
//
//  File: basic-integration.fs
//
//---------------------------------------------------------------------
//
//  This file is part of the Numerics.NET Code Samples.
//
//  Copyright (c) 2004-2025 ExoAnalytics Inc. All rights reserved.
//
//=====================================================================

module BasicIntegration

#light

open System

// The numerical integration classes reside in the
// Numerics.NET.Calculus namespace.
open Numerics.NET.Calculus
// Function delegates reside in the Numerics.NET
// namespace.
open Numerics.NET

// The license is verified at runtime. We're using a 30 day trial key here.
// For more information, see:
//     https://numerics.net/trial-key
let licensed = Numerics.NET.License.Verify("your-trial-key-here")

// Illustrates the basic use of the numerical integration
// classes in the Numerics.NET.Calculus namespace of Numerics.NET.

// Numerical integration algorithms fall into two
// main categories: adaptive and non-adaptive.
// This QuickStart Sample illustrates the use of
// the non-adaptive numerical integrators.
//
// All numerical integration classes derive from
// NumericalIntegrator. This abstract base class
// defines properties and methods that are shared
// by all numerical integration classes.

printfn "sin(x) on [0,2]"

//
// SimpsonIntegrator
//

// The simplest numerical integration algorithm
// is Simpson's rule.
printfn "Simpson integrator:"

let simpson = SimpsonIntegrator()
// You can set the relative or absolute tolerance
// to which to evaluate the integral.
simpson.RelativeTolerance <- 1e-5
// You can select the type of tolerance using the
// ConvergenceCriterion property:
simpson.ConvergenceCriterion <- ConvergenceCriterion.WithinRelativeTolerance
// The Integrate method performs the actual integration:
let result = simpson.Integrate(Func<_,_> Math.Sin, 0.0, 2.0)
// The result is also available in the Result property:
printfn "  Value: %A" simpson.Result
// To see whether the algorithm ended normally,
// inspect the Status property:
printfn "  Status: %A" simpson.Status
// You can find out the estimated error of the result
// through the EstimatedError property:
printfn "  Estimated error: %A" simpson.EstimatedError
// The number of iterations to achieve the result
// is available through the IterationsNeeded property.
printfn "  Iterations: %d" simpson.IterationsNeeded
// The number of function evaluations is available
// through the EvaluationsNeeded property.
printfn "  Function evaluations: %d" simpson.EvaluationsNeeded

//
// Gauss-Kronrod Integration
//

printfn "Non-adaptive Gauss-Kronrod rule:"

// Gauss-Kronrod integrators also use a fixed point
// scheme, but with certain optimizations in the
// choice of points where the integrand is evaluated.

// The NonAdaptiveGaussKronrodIntegrator uses a
// succession of 10, 21, 43, and 87 point rules
// to approximate the integral.
let nagk = NonAdaptiveGaussKronrodIntegrator()
let result2 = nagk.Integrate(Func<_,_> Math.Sin, 0.0, 2.0)
printfn "  Value: %A" nagk.Result
printfn "  Status: %A" nagk.Status
printfn "  Estimated error: %A" nagk.EstimatedError
printfn "  Iterations: %d" nagk.IterationsNeeded
printfn "  Function evaluations: %d" nagk.EvaluationsNeeded

//
// Romberg Integration
//

printfn "Romberg integration:"

// Romberg integration combines Simpson's Rule
// with a scheme to accelerate convergence.
// This algorithm is useful for smooth integrands.
let romberg = RombergIntegrator()
let result3 = romberg.Integrate(Func<_,_> Math.Sin, 0.0, 2.0)
printfn "  Value: %A" romberg.Result
printfn "  Status: %A" romberg.Status
printfn "  Estimated error: %A" romberg.EstimatedError
printfn "  Iterations: %d" romberg.IterationsNeeded
printfn "  Function evaluations: %d" romberg.EvaluationsNeeded

// However, it breaks down if the integration
// algorithm contains singularities or
// discontinuities.

// The AdaptiveIntegrator can handle this type
// of integrand, and many other difficult cases.
// See the AdvancedIntegration QuickStart sample
// for details.
printfn "Romberg on hard integrand:"

let result4 = romberg.Integrate((fun x -> if x <= 0.0 then 0.0 else x**(-0.9) * log(1.0/x)), 0.0, 1.0)
printfn "  Value: %A" romberg.Result
printfn "  Actual value: 100"
printfn "  Status: %A" romberg.Status
printfn "  Estimated error: %A" romberg.EstimatedError
printfn "  Iterations: %d" romberg.IterationsNeeded
printfn "  Function evaluations: %d" romberg.EvaluationsNeeded

