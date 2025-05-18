//=====================================================================
//
//  File: optimization-in-nd.fs
//
//---------------------------------------------------------------------
//
//  This file is part of the Numerics.NET Code Samples.
//
//  Copyright (c) 2004-2025 ExoAnalytics Inc. All rights reserved.
//
//=====================================================================

module OptimizationInND

// Illustrates unconstrained optimization in multiple dimensions
// using classes in the Numerics.NET.Optimization
// namespace of Numerics.NET.

#light

open System

open Numerics.NET
// The optimization classes reside in the
// Numerics.NET.Optimization namespace.
open Numerics.NET.Optimization

// The license is verified at runtime. We're using a 30 day trial key here.
// For more information, see:
//     https://numerics.net/trial-key
let licensed = Numerics.NET.License.Verify("your-trial-key-here")

//
// Objective function
//

// The objective function must be supplied as a
// Func<Vector, double> delegate. This is a method
// that takes one Vector argument and returns a real number.

// The famous Rosenbrock test function.
let fRosenbrock(x : Vector<float>) =
    let p = 1.0 - x.[0]
    let q = x.[1] - x.[0]*x.[0]
    p*p + 105.0 * q*q

// The gradient of the objective function can be supplied either
// as a MultivariateVectorFunction delegate, or a
// MultivariateVectorFunction delegate. The former takes
// one vector argument and returns a vector. The latter
// takes a second vector argument, which is an existing
// vector that is used to return the result.

// Gradient of the Rosenbrock test function.
let gRosenbrock (x : Vector<float>) (f : Vector<float>) =
    let p = 1.0 - x.[0]
    let q = x.[1] - x.[0]*x.[0]
    f.[0] <- -2.0*p - 420.0*x.[0]*q
    f.[1] <- 210.0*q
    f

// The initial values are supplied as a vector:
let initialGuess = Vector.Create(-1.2, 1.0)
// The actual solution is [1, 1].

//
// Quasi-Newton methods: BFGS and DFP
//

// For most purposes, the quasi-Newton methods give
// excellent results. There are two variations: DFP and
// BFGS. The latter gives slightly better results.

// Which method is used, is specified by a constructor
// parameter of type QuasiNewtonMethod:
let bfgs = QuasiNewtonOptimizer(QuasiNewtonMethod.Bfgs)

bfgs.InitialGuess <- initialGuess
bfgs.ExtremumType <- ExtremumType.Minimum

// Set the ObjectiveFunction:
bfgs.ObjectiveFunction <- Func<Vector<float>,double> fRosenbrock
// Set either the GradientFunction or FastGradientFunction:
bfgs.FastGradientFunction <- Func<Vector<float>,Vector<float>,Vector<float>> gRosenbrock
// The FindExtremum method does all the hard work:
let bfgsResult = bfgs.FindExtremum()

printfn "BFGS Method:"
printfn "  Solution: %O" bfgs.Extremum
printfn "  Estimated error: %A" bfgs.EstimatedError
printfn "  # iterations: %d" bfgs.IterationsNeeded
// Optimizers return the number of function evaluations
// and the number of gradient evaluations needed:
printfn "  # function evaluations: %d" bfgs.EvaluationsNeeded
printfn "  # gradient evaluations: %d" bfgs.GradientEvaluationsNeeded

//
// Conjugate Gradient methods
//

// Conjugate gradient methods exist in three variants:
// Fletcher-Reeves, Polak-Ribiere, and positive Polak-Ribiere.

// Which method is used, is specified by a constructor
// parameter of type ConjugateGradientMethod:
let cg = ConjugateGradientOptimizer(ConjugateGradientMethod.PositivePolakRibiere)
// Everything else works as before:
cg.ObjectiveFunction <-
    fun x ->
        let p = 1.0 - x.[0]
        let q = x.[1] - x.[0]*x.[0]
        p*p + 105.0 * q*q

cg.FastGradientFunction <- Func<Vector<float>,Vector<float>,Vector<float>> gRosenbrock
cg.InitialGuess <- initialGuess
let cgResult = cg.FindExtremum()

printfn "Conjugate Gradient Method:"
printfn "  Solution: %O" cg.Extremum
printfn "  Estimated error: %A" cg.EstimatedError
printfn "  # iterations: %d" cg.IterationsNeeded
printfn "  # function evaluations: %d" cg.EvaluationsNeeded
printfn "  # gradient evaluations: %d" cg.GradientEvaluationsNeeded

//
// Powell's method
//

// Powell's method is a conjugate gradient method that
// does not require the derivative of the objective function.
// It is implemented by the PowellOptimizer class:
let pw = PowellOptimizer()
pw.InitialGuess <- initialGuess
// Powell's method does not use derivatives:
pw.ObjectiveFunction <- Func<Vector<float>,double> fRosenbrock
let pwResult = pw.FindExtremum()

printfn "Powell's Method:"
printfn "  Solution: %O" pw.Extremum
printfn "  Estimated error: %A" pw.EstimatedError
printfn "  # iterations: %d" pw.IterationsNeeded
printfn "  # function evaluations: %d" pw.EvaluationsNeeded
printfn "  # gradient evaluations: %d" pw.GradientEvaluationsNeeded

//
// Nelder-Mead method
//

// Also called the downhill simplex method, the method of Nelder
// and Mead is useful for functions that are not tractable
// by other methods. For example, other methods
// may fail if the objective function is not continuous.
// Otherwise it is much slower than other methods.

// The method is implemented by the NelderMeadOptimizer class:
let nm = NelderMeadOptimizer()

// The class has three special properties, that help determine
// the progress of the algorithm. These parameters have
// default values and need not be set explicitly.
nm.ContractionFactor <- 0.5
nm.ExpansionFactor <- 2.0
nm.ReflectionFactor <- -2.0

// Everything else is the same.
nm.SolutionTest.AbsoluteTolerance <- 1e-15
nm.InitialGuess <- initialGuess
// The method does not use derivatives:
nm.ObjectiveFunction <- Func<Vector<float>,double> fRosenbrock
let nmResult = nm.FindExtremum()

printfn "Nelder-Mead Method:"
printfn "  Solution: %O" nm.Extremum
printfn "  Estimated error: %A" nm.EstimatedError
printfn "  # iterations: %d" nm.IterationsNeeded
printfn "  # function evaluations: %d" nm.EvaluationsNeeded
