//=====================================================================
//
//  File: nd-integration.fs
//
//---------------------------------------------------------------------
//
//  This file is part of the Numerics.NET Code Samples.
//
//  Copyright (c) 2004-2025 ExoAnalytics Inc. All rights reserved.
//
//=====================================================================

module NDIntegration

// Illustrates numerical integration in higher dimensions using
// classes in the Numerics.NET.Calculus namespace of Numerics.NET.

#light

open System

open Numerics.NET
// The numerical integration classes reside in the
// Numerics.NET.Calculus namespace.
open Numerics.NET.Calculus

// The license is verified at runtime. We're using a 30 day trial key here.
// For more information, see:
//     https://numerics.net/trial-key
let licensed = Numerics.NET.License.Verify("your-trial-key-here")

//
// Two-dimensional integration
//

// The function we are integrating must be
// provided as a Func<double, double, double> delegate.

// The AdaptiveIntegrator2D class is the most efficient
// 2D integrator in most cases. It uses an adaptive algorithm.

// Construct an instance of the integrator class:
let integrator1 = AdaptiveIntegrator2D()

// An example of setting the integrand and bounds through properties
// is given below. Here, we put the integrand and the bounds
// of the integration region directly in the call to Integrate,
// which performs the calculation:
let result = integrator1.Integrate((fun x -> fun y -> 4.0 / (1.0 + 2.0 * x + 2.0 * y)), 0.0, 1.0, 0.0, 1.0)
printfn "4 / (1 + 2x + 2y) on [0,1] * [0,1]"
printfn "  Value:       %.15f" integrator1.Result
printfn "  Exact value: %.15f = Ln(3125 / 729)" (log(3125.0 / 729.0))
// To see whether the algorithm ended normally,
// inspect the Status property:
printfn "  Status: %A" integrator1.Status
printfn "  Estimated error: %A" integrator1.EstimatedError
printfn "  Iterations: %d" integrator1.IterationsNeeded
printfn "  Function evaluations: %d" integrator1.EvaluationsNeeded

// Another integrator uses repeated 1-dimensional
// integration:
let integrator2 = Repeated1DIntegrator2D()

// You can set the order of integration, as well as
// the integration rules for the X and the Y direction:
integrator2.InitialDirection <- Repeated1DIntegratorDirection.X

// You can set the integrand and the bounds of the integration region
// by setting properties of the integrator object:
integrator2.Integrand <- fun x -> fun y -> 0.25 * Constants.PiSquared * sin(Math.PI * x) * sin(Math.PI * y)
integrator2.XLowerBound <- 0.0
integrator2.XUpperBound <- 1.0
integrator2.YLowerBound <- 0.0
integrator2.YUpperBound <- 1.0

let result2 = integrator2.Integrate()
printfn "Pi^2 / 4 Sin(Pi x) Sin(Pi y)   on [0,1] * [0,1]"
printfn "  Value:       %.15f" integrator2.Result
printfn "  Exact value: %.15f" 1.0
// To see whether the algorithm ended normally,
// inspect the Status property:
printfn "  Status: %A" integrator2.Status
printfn "  Estimated error: %A" integrator2.EstimatedError
printfn "  Iterations: %d" integrator2.IterationsNeeded
printfn "  Function evaluations: %d" integrator2.EvaluationsNeeded

//
// Integration over arbitrary regions
//

// The repeated 1D integrator can also be used to compute
// integrals over arbitrary regions. To do this, you need to
// supply function that return the lower bound and upper bound
// of the region as a function of x.

// Here, we integrate x^2 * y^2 over the unit disk.
integrator2.LowerBoundFunction <- fun x -> if abs(x) >= 1.0 then 0.0 else -sqrt(1.0 - x*x)
integrator2.UpperBoundFunction <- fun x -> if abs(x) >= 1.0 then 0.0 else sqrt(1.0 - x*x)
integrator2.XLowerBound <- -1.0
integrator2.XUpperBound <- 1.0

integrator2.Integrand <- fun x -> fun y -> x * x * y * y

let result3 = integrator2.Integrate()
printfn "x^2 * y^2 on the unit disk"
printfn "  Value:       %.15f" integrator2.Result
printfn "  Exact value: %.15f = Pi / 24" (Math.PI / 24.0)
// To see whether the algorithm ended normally,
// inspect the Status property:
printfn "  Status: %A" integrator2.Status
printfn "  Estimated error: %A" integrator2.EstimatedError
printfn "  Iterations: %d" integrator2.IterationsNeeded
printfn "  Function evaluations: %d" integrator2.EvaluationsNeeded
