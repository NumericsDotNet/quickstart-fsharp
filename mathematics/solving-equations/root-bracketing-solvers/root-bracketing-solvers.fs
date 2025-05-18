//=====================================================================
//
//  File: root-bracketing-solvers.fs
//
//---------------------------------------------------------------------
//
//  This file is part of the Numerics.NET Code Samples.
//
//  Copyright (c) 2004-2025 ExoAnalytics Inc. All rights reserved.
//
//=====================================================================

module RootBracketingSolvers

#light

open System

open Numerics.NET
// The RootBracketingSolver and derived classes reside in the
// Numerics.NET.EquationSolvers namespace.
open Numerics.NET.EquationSolvers

// The license is verified at runtime. We're using a 30 day trial key here.
// For more information, see:
//     https://numerics.net/trial-key
let licensed = Numerics.NET.License.Verify("your-trial-key-here")

// Illustrates the use of the root bracketing solvers
// in the Numerics.NET.EquationSolvers namespace of Numerics.NET.

// Root bracketing solvers are used to solve
// non-linear equations in one variable.
//
// Root bracketing solvers start with an interval
// which is known to contain a root. This interval
// is made smaller and smaller in successive
// iterations until a certain tolerance is reached,
// or the maximum number of iterations has been
// exceeded.
//
// The properties and methods that give you control
// over the iteration are shared by all classes
// that implement iterative algorithms.

//
// Target function
//

// The function we are trying to solve must be
// provided as a Func<double, double>. For more
// information about this delegate, see the
// FunctionDelegates QuickStart sample.

// All root bracketing solvers inherit from
// RootBracketingSolver, an abstract base class.

//
// Bisection method
//

// The bisection method halves the interval during
// each iteration. It is implemented by the
// BisectionSolver class.
printfn "BisectionSolver: cos(x) = 0 over [1,2]"
let solver1 = BisectionSolver()
solver1.LowerBound <- 1.0
solver1.UpperBound <- 2.0
// The target function is a Func<double, double>.
// See above.
solver1.TargetFunction <- Func<_,_> Math.Cos
let result1 = solver1.Solve()
// The Status property indicates
// the result of running the algorithm.
printfn "  Result: %A" solver1.Status
// The result is also available through the
// Result property.
printfn "  Solution: %A" solver1.Result
// You can find out the estimated error of the result
// through the EstimatedError property:
printfn "  Estimated error: %A" solver1.EstimatedError
printfn "  # iterations: %d" solver1.IterationsNeeded

//
// Regula Falsi method
//
// The Regula Falsi method optimizes the selection
// of the next interval. Unfortunately, the
// optimization breaks down in some cases.
// Here is an example:
printfn "RegulaFalsiSolver: cos(x) = 0 over [1,2]"
let solver2 = RegulaFalsiSolver()
solver2.LowerBound <- 1.0
solver2.UpperBound <- 2.0
solver2.MaxIterations <- 1000
solver2.TargetFunction <- Func<_,_> Math.Cos
let result2 = solver2.Solve()
printfn "  Result: %A" solver2.Status
printfn "  Solution: %A" solver2.Result
printfn "  Estimated error: %A" solver2.EstimatedError
printfn "  # iterations: %d" solver2.IterationsNeeded

// However, for sin(x) = 0, everything is fine:
printfn "RegulaFalsiSolver: sin(x) = 0 over [-0.5,1]"
let solver3 = RegulaFalsiSolver()
solver3.LowerBound <- -0.5
solver3.UpperBound <- 1.0
solver3.TargetFunction <- Func<_,_> Math.Sin
let result3 = solver3.Solve()
printfn "  Result: %A" solver3.Status
printfn "  Solution: %A" solver3.Result
printfn "  Estimated error: %A" solver3.EstimatedError
printfn "  # iterations: %d" solver3.IterationsNeeded

//
// Dekker-Brent method
//
// The Dekker-Brent method combines the best of
// both worlds. It is the most robust and, on average,
// the fastest method.
printfn "DekkerBrentSolver: cos(x) = 0 over [1,2]"
let solver4 = DekkerBrentSolver()
solver4.LowerBound <- 1.0
solver4.UpperBound <- 2.0
solver4.TargetFunction <- Func<_,_> Math.Cos
let result4 = solver4.Solve()
printfn "  Result: %A" solver4.Status
printfn "  Solution: %A" solver4.Result
printfn "  Estimated error: %A" solver4.EstimatedError
printfn "  # iterations: %d" solver4.IterationsNeeded

//
// Controlling the process
//
printfn "Same with modified parameters:"
// You can set the maximum # of iterations:
// If the solution cannot be found in time, the
// Status will return a value of
// IterationStatus.IterationLimitExceeded
solver4.MaxIterations <- 20
// You can specify how convergence is to be tested
// through the ConvergenceCriterion property:
solver4.ConvergenceCriterion <- ConvergenceCriterion.WithinRelativeTolerance
// And, of course, you can set the absolute or relative tolerance.
solver4.RelativeTolerance <- 1e-6
// In this example, the absolute tolerance will be ignored.
solver4.AbsoluteTolerance <- 1e-24
solver4.LowerBound <- 157081.0
solver4.UpperBound <- 157082.0
solver4.TargetFunction <- Func<_,_> Math.Cos
let result5 = solver4.Solve()
printfn "  Result: %A" solver4.Status
printfn "  Solution: %A" solver4.Result
// The estimated error will be less than 0.157
printfn "  Estimated error: %A" solver4.EstimatedError
printfn "  # iterations: %d" solver4.IterationsNeeded
