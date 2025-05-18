//=====================================================================
//
//  File: newton-equation-solver.fs
//
//---------------------------------------------------------------------
//
//  This file is part of the Numerics.NET Code Samples.
//
//  Copyright (c) 2004-2025 ExoAnalytics Inc. All rights reserved.
//
//=====================================================================

module NewtonEquationSolver

// Illustrates the use of the Newton-Raphson equation solver
// in the Numerics.NET.EquationSolvers namespace of Numerics.NET.

#light

open System

// The NewtonRaphsonSolver class resides in the
// Numerics.NET.EquationSolvers namespace.
open Numerics.NET.EquationSolvers
// Function delegates reside in the Numerics.NET
// namespace.
open Numerics.NET

// The license is verified at runtime. We're using a 30 day trial key here.
// For more information, see:
//     https://numerics.net/trial-key
let licensed = Numerics.NET.License.Verify("your-trial-key-here")

// The Newton-Raphson solver is used to solve
// non-linear equations in one variable.
//
// The algorithm starts with one starting value,
// and uses the target function and its derivative
// to iteratively find a closer approximation to
// the root of the target function.
//
// The properties and methods that give you control
// over the iteration are shared by all classes
// that implement iterative algorithms.

//
// Target function
//
// The function we are trying to solve must be
// provided as a Func<double, double>.

// Now let's create the NewtonRaphsonSolver object.
let solver = NewtonRaphsonSolver()
// Set the target function and its derivative:
solver.TargetFunction <- Func<_,_> Math.Sin
solver.DerivativeOfTargetFunction <- Func<_,_> Math.Cos
// Set the initial guess:
solver.InitialGuess <- 4.0
// These values can also be passed in a constructor:
let solver2 = NewtonRaphsonSolver(Func<_,_> Math.Sin, Func<_,_> Math.Cos, 4.0)

printfn "Newton-Raphson Solver: sin(x) = 0"
printfn "  Initial guess: 4"
let result = solver.Solve()
// The Status property indicates
// the result of running the algorithm.
printfn "  Result: %A" solver.Status
// The result is also available through the
// Result property.
printfn "  Solution: %A" solver.Result
// You can find out the estimated error of the result
// through the EstimatedError property:
printfn "  Estimated error: %A" solver.EstimatedError
printfn "  # iterations: %d" solver.IterationsNeeded

//
// When you don't have the derivative...
//
// You can still use this class if you don't have
// the derivative of the target function. In this
// case, use the static CreateDelegate method of the
// FunctionMath class (Numerics.NET.Calculus
// namespace) to create a Func<double, double>
// that represents the numerical derivative of the
// target function:
solver.TargetFunction <- Func<_,_> Special.BesselJ0
solver.DerivativeOfTargetFunction <- (Func<_,_> Special.BesselJ0).GetNumericalDifferentiator()
solver.InitialGuess <- 5.0
printfn "Zero of Bessel function near x=5:"
let result2 = solver.Solve()
printfn "  Result: %A" solver.Status
printfn "  Solution: %A" solver.Result
printfn "  Estimated error: %A" solver.EstimatedError
printfn "  # iterations: %d" solver.IterationsNeeded

//
// Controlling the process
//
printfn "Same with modified parameters:"
// You can set the maximum # of iterations:
// If the solution cannot be found in time, the
// Status will return a value of
// IterationStatus.IterationLimitExceeded
solver.MaxIterations <- 10
// You can specify how convergence is to be tested
// through the ConvergenceCriterion property:
solver.ConvergenceCriterion <- ConvergenceCriterion.WithinRelativeTolerance
// And, of course, you can set the absolute or
// relative tolerance.
solver.RelativeTolerance <- 1e-14
// In this example, the absolute tolerance will be
// ignored.
solver.AbsoluteTolerance <- 1e-4
solver.InitialGuess <- 5.0
let result3 = solver.Solve()
printfn "  Result: %A" solver.Status
printfn "  Solution: %A" solver.Result
// The estimated error will be less than 5e-14
printfn "  Estimated error: %A" solver.EstimatedError
printfn "  # iterations: %d" solver.IterationsNeeded
