//=====================================================================
//
//  File: nonlinear-systems.fs
//
//---------------------------------------------------------------------
//
//  This file is part of the Numerics.NET Code Samples.
//
//  Copyright (c) 2004-2025 ExoAnalytics Inc. All rights reserved.
//
//=====================================================================

module NonlinearSystems

// Illustrates solving systems of non-linear equations using
// classes in the Numerics.NET.EquationSolvers namespace
// of Numerics.NET.

open System

// The equation solver classes reside in the
// Numerics.NET.EquationSolvers namespace.
open Numerics.NET.EquationSolvers
// Function delegates reside in the Numerics.NET
// namespace.
open Numerics.NET

// The license is verified at runtime. We're using a 30 day trial key here.
// For more information, see:
//     https://numerics.net/trial-key
let licensed = Numerics.NET.License.Verify("your-trial-key-here")

//
// Target function
//

// The function we are trying to solve can be provided
// on one of two ways. The first is as an array of
// MultivariateFunc<double, double> delegates. See the end of this
// sample for definitions of the methods that are referenced here.
let f =
    [|
        Func<_,_> (fun (x : Vector<float>) -> exp(x.[0]) * cos(x.[1]) - x.[0]*x.[0] + x.[1]*x.[1]) ;
        Func<_,_> (fun (x : Vector<float>) -> exp(x.[0]) * sin(x.[1]) - 2.0*x.[0]*x.[1])
    |]

// We can also supply the Jacobian, which is the matrix of partial
// derivatives. We do so by providing the gradient of each target
// function as a FastMultivariateVectorFunction delegate.
//
// The FastMultivariateVectorFunction takes a second argument:
// the vector that is to hold the return value. This avoids unnecessary
// creation of new Vector instances.
let df =
    [|
        Func<_,_,_> (fun (x : Vector<float>) -> fun (df : Vector<float>) ->
            df.[0] <-  exp(x.[0])*cos(x.[1]) - 2.0*x.[0]
            df.[1] <- -exp(x.[0])*sin(x.[1]) + 2.0*x.[1]
            df)
        Func<_,_,_> (fun (x : Vector<float>) -> fun (df : Vector<float>) ->
            df.[0] <- exp(x.[0])*sin(x.[1]) - 2.0*x.[1]
            df.[1] <- exp(x.[0])*cos(x.[1]) - 2.0*x.[0]
            df)
    |]
// The initial values are supplied as a vector:
let initialGuess = Vector.Create(0.5, 0.5)

//
// Newton-Raphson Method
//

// The Newton-Raphson method is implemented by
// the NewtonRaphsonSystemSolver class.
let solver = new NewtonRaphsonSystemSolver(f, df, initialGuess)

// and call the Solve method to obtain the solution:
let solution = solver.Solve()

printfn "N-dimensional Newton-Raphson Solver:"
printfn "exp(x)*cos(y) - x^2 + y^2 = 0"
printfn "exp(x)*sin(y) - 2xy = 0"
printfn "  Initial guess: %O" (initialGuess.ToString("F2"))
// The Status property indicates
// the result of running the algorithm.
printfn "  Status: %A" solver.Status
// The result is also available through the
// Result property.
printfn "  Solution: %A" solver.Result
printfn "  Function value: %A" solver.ValueTest.Error
// You can find out the estimated error of the result
// through the EstimatedError property:
printfn "  Estimated error: %A" solver.EstimatedError
printfn "  # iterations: %A" solver.IterationsNeeded
printfn "  # evaluations: %A" solver.EvaluationsNeeded

//
// When you don't have the derivatives of the target functions,
// the equation solver will use a numerical approximation.
//

//
// Controlling the process
//
printfn "Same with modified parameters:"
// You can set the maximum # of iterations:
// If the solution cannot be found in time, the
// Status will return a value of
// IterationStatus.IterationLimitExceeded
solver.MaxIterations <- 10

// The ValueTest property returns the convergence
// test based on the function value. We can set
// its tolerance property:
solver.ValueTest.Tolerance <- 1e-10
// Its Norm property determines how the error
// is calculated. Here, we choose the maximum
// of the function values:
solver.ValueTest.Norm <- Algorithms.VectorConvergenceNorm.Maximum

// The SolutionTest property returns the test
// on the change in location of the solution.
solver.SolutionTest.Tolerance <- 1e-8
// You can specify how convergence is to be tested
// through the ConvergenceCriterion property:
solver.SolutionTest.ConvergenceCriterion <- ConvergenceCriterion.WithinRelativeTolerance

solver.InitialGuess <- initialGuess
let solution2 = solver.Solve()
printfn "  Status: %A" solver.Status
printfn "  Solution: %A" solver.Result
// The estimated error will be less than 5e-14
printfn "  Estimated error: %A" solver.SolutionTest.Error
printfn "  # iterations: %A" solver.IterationsNeeded
printfn "  # evaluations: %A" solver.EvaluationsNeeded

//
// Powell's dogleg method
//

// The dogleg method is more robust than Newton's method.
// It will converge often when Newton's method fails.
let dogleg = new DoglegSystemSolver(f, df, initialGuess)

// Unique to the dogleg method is the TrustRegionRadius property.
// Any step of the algorithm is not larger than this value.
// It is adjusted at each iteration.
dogleg.TrustRegionRadius <- 0.5

// Call the Solve method to obtain the solution:
let solution3 = dogleg.Solve()

printfn "Powell's Dogleg Solver:"
printfn "  Initial guess: %O" (initialGuess.ToString("F2"))
printfn "  Status: %A" dogleg.Status
printfn "  Solution: %A" dogleg.Result
printfn "  Estimated error: %A" dogleg.EstimatedError
printfn "  # iterations: %A" dogleg.IterationsNeeded
printfn "  # evaluations: %A" dogleg.EvaluationsNeeded

// The dogleg method can work without derivatives. Care is taken
// to keep the number of evaluations down to a minimum.
dogleg.JacobianFunction <- null
// Call the Solve method to obtain the solution:
let solution4 = dogleg.Solve()

printfn "Powell's Dogleg Solver (no derivatives):"
printfn "  Initial guess: %O" (initialGuess.ToString("F2"))
printfn "  Status: %A" dogleg.Status
printfn "  Solution: %A" dogleg.Result
printfn "  Estimated error: %A" dogleg.EstimatedError
printfn "  # iterations: %A" dogleg.IterationsNeeded
printfn "  # evaluations: %A" dogleg.EvaluationsNeeded
