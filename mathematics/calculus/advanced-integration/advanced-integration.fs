//=====================================================================
//
//  File: advanced-integration.fs
//
//---------------------------------------------------------------------
//
//  This file is part of the Numerics.NET Code Samples.
//
//  Copyright (c) 2004-2025 ExoAnalytics Inc. All rights reserved.
//
//=====================================================================

module AdvancedIntegration

// Illustrates the more advanced use of the
// numerical integrator classes in the
// Numerics.NET.Calculus namespace of Numerics.NET.

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

// Numerical integration algorithms fall into two
// main categories: adaptive and non-adaptive.
// This QuickStart Sample illustrates the use of
// the adaptive numerical integrator implemented by
// the AdaptiveIntegrator class. This class is the
// most advanced of the numerical integration
// classes.
//
// All numerical integration classes derive from
// NumericalIntegrator. This abstract base class
// defines properties and methods that are shared
// by all numerical integration classes.

//
// The integrand
//

// The function we are integrating must be
// provided as a Func<double, double>. For more
// information about this delegate, see the
// FunctionDelegates QuickStart sample.
//
// Variable to hold the result:
// Construct an instance of the integrator class:
let integrator = AdaptiveIntegrator()

//
// Adaptive integrator basics
//

// All the properties and methods defined by the
// NumericalIntegrator base class are available.
// See the BasicIntegration QuickStart Sample
// for details. The AdaptiveIntegrator class defines
// the following additional properties:
//
// The IntegrationRule property gets or sets the
// integration rule that is to be used for
// integrating subintervals. It can be any
// object derived from IntegrationRule.
//
// For convenience, a series of Gauss-Kronrod
// integration rules of order 15, 21, 31, 41, 51,
// and 61 have been provided.
integrator.IntegrationRule <- IntegrationRule.CreateGaussKronrod15PointRule()
// The UseAcceleration property specifies whether
// precautions should be taken for singularities
// in the integration interval.
integrator.UseExtrapolation <- false
// Finally, the Singularities property allows you
// to specify singularities or discontinuities
// inside the integration interval. See the
// sample below for details.

//
// Integration over infinite intervals
//
integrator.AbsoluteTolerance <- 1e-8
integrator.ConvergenceCriterion <- ConvergenceCriterion.WithinAbsoluteTolerance
// The Integrate method performs the actual
// integration. To integrate over an infinite
// interval, simply use either or both of
// -infinity and infinity as bounds:
let result = integrator.Integrate((fun (x:float) -> exp(-x - x*x)), -infinity, infinity)
printfn "Exp(-x^2-x) on [-inf,inf]"
printfn "  Value:       %A" integrator.Result
printfn "  Exact value: %A" (Math.Exp(0.25) * Constants.SqrtPi)
// To see whether the algorithm ended normally,
// inspect the Status property:
printfn "  Status: %O" (box integrator.Status)
printfn "  Estimated error: %A" integrator.EstimatedError
printfn "  Iterations: %d" integrator.IterationsNeeded
printfn "  Function evaluations: %d" integrator.EvaluationsNeeded

//
// Functions with singularities at the end points
// of the integration interval.
//

// Thanks to the adaptive nature of the algorithm,
// special measures can be taken to accelerate
// convergence near singularities. To enable this
// acceleration, set the Singularities property
// to true.
integrator.UseExtrapolation <- true
// We'll use the function that gives the Romberg
// integrator in the BasicIntegration QuickStart
// sample trouble.
let result2 = integrator.Integrate((fun (x:float) -> x**(-0.9) * log(1.0/x)), 0.0, 1.0)
printfn "Singularities on boundary:"
printfn "  Value:       %A" integrator.Result
printfn "  Exact value: 100"
printfn "  Status: %O" integrator.Status
printfn "  Estimated error: %A" integrator.EstimatedError
// Where Romberg integration failed after 1,000,000
// function evaluations, we find the correct answer
// to within tolerance using only 135 function
// evaluations!
printfn "  Iterations: %d" integrator.IterationsNeeded
printfn "  Function evaluations: %d" integrator.EvaluationsNeeded

//
// Functions with singularities or discontinuities
// inside the interval.
//
integrator.UseExtrapolation <- true
// We will pass an array containing the interior
// singularities to the integrator through the
// Singularities property:
integrator.SetSingularities(1.0, Math.Sqrt(2.0))
let result3 = integrator.Integrate((fun x -> x*x*x * log(abs((x*x - 1.0) * (x*x - 2.0)))), 0.0, 3.0)
printfn "Singularities inside the interval:"
printfn "  Value:       %A" integrator.Result
printfn "  Exact value: 52.740748383471444998"
printfn "  Status: %O" integrator.Status
printfn "  Estimated error: %A" integrator.EstimatedError
printfn "  Iterations: %d" integrator.IterationsNeeded
printfn "  Function evaluations: %d" integrator.EvaluationsNeeded
