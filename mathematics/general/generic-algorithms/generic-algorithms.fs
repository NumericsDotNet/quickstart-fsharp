//=====================================================================
//
//  File: generic-algorithms.fs
//
//---------------------------------------------------------------------
//
//  This file is part of the Numerics.NET Code Samples.
//
//  Copyright (c) 2004-2025 ExoAnalytics Inc. All rights reserved.
//
//=====================================================================

module GenericAlgorithms

#light

open System

// Basic generic types live in Numerics.NET.Generics.
open Numerics.NET.Generic
// We'll also need the big number types.
open Numerics.NET

// The license is verified at runtime. We're using a 30 day trial key here.
// For more information, see:
//     https://numerics.net/trial-key
let licensed = Numerics.NET.License.Verify("your-trial-key-here")

// Illustrates writing generic algorithms that can be
// applied to different operand types using the types in the
// Numerics.NET.Generic namespace.

// We will implement a simple Newton-Raphson solver class.
// The code for the solver is below.

// Here we will call the generic solver with three
// different operand types: BigFloat, BigRational and Double.

let f a b = a - b

// Class that contains the generic Newton-Raphson algorithm.
type Solver<'a>(f : 'a -> 'a, df : 'a -> 'a) =

    let mutable maxIterations = 100

    // The core algorithm.
    // Arithmetic operations are replaced by calls to
    // methods on the arithmetic object (ops).
    let rec solveRec x0 tolerance maxIterations iterations =
        // Compute the denominator of the correction term.
        let dfx = df(x0)
        // Relational operators map to the Compare method.
        // We also use the value of zero for the operand type.
        // if (dfx == 0)
        let dx =
            if (Operations<'a>.Compare(dfx, Operations<'a>.Zero) = 0) then
                // Change value by 2x tolerance.
                // When multiplying by a power of two, it's more efficient
                // to use the ScaleByPowerOfTwo method.
                Operations<'a>.ScaleByPowerOfTwo(tolerance, 1)
            else
                // dx = f(x) / df(x)
                let fx = f(x0)
                Operations<'a>.Divide(fx, dfx)

        // x -= dx
        let x = Operations<'a>.Subtract(x0, dx)

        // if |dx|^2<tolerance
        // Convergence is quadratic (in most cases), so we should be good here:
        if (Operations<'a>.Compare(Operations<'a>.Multiply(dx,dx), tolerance) < 0 || iterations > maxIterations) then
            x
        else
            solveRec x tolerance maxIterations (iterations+1)

    let solve initialGuess tolerance maxIterations =
        solveRec initialGuess tolerance maxIterations 0

    // The maximum number of iterations.
    member this.MaxIterations
        with get() = maxIterations
        and set(value) = maxIterations <- value

    member this.Solve initialGuess tolerance = solve initialGuess tolerance this.MaxIterations

// First, let's compute pi to 100 digits
// by solving the equation sin(x) == 0 with
// an initual guess of 3.
printfn "Computing pi by solving sin(x) == 0 with x0 = 3 using BigFloat:"
// Create the solver object.
let bigFloatSolver =
    let f = fun (x : BigFloat) -> sin(x)
    let df = fun (x : BigFloat) -> cos(x)
    Solver(f, df)
// Now solve to within a tolerance of 10^-100.
let pi = bigFloatSolver.Solve (BigFloat 3) (BigFloat.Pow(BigFloat 10, -100))
// Print the results...
printfn "Computed value: %s" (pi.ToString("F100"))
// and verify:
printfn "Known value:    %s" (BigFloat.GetPi(AccuracyGoal.Absolute(100.0)).ToString("F100"))
printfn ""

// Next, we will use rational numbers to compute
// an approximation to the square root of 2.
printfn "Computing sqrt(2) by solving x^2 == 2 using BigRational:"
// Create the solver...
let bigRationalSolver =
    let f = fun (x : BigRational) -> x ** 2 - 2
    let df = fun (x : BigRational) -> 2 * x
    Solver(f, df)
// Compute the solution...
let sqrt2 = bigRationalSolver.Solve BigRational.One (BigRational.Pow(BigRational(10,1), -100))
// And print the result.
printfn "Rational approximation: %A" sqrt2
// To verify, we convert the BigRational to a BigFloat:
printfn "As real number: %s" (BigFloat(sqrt2, AccuracyGoal.Absolute(100.0), RoundingMode.TowardsNearest).ToString("F100"))
printfn "Known value:    %s" (BigFloat.Sqrt(BigFloat 2, AccuracyGoal.Absolute(100.0), RoundingMode.TowardsNearest).ToString("F100"))
printfn ""

// Now, we compute the Lambert W function at x = 3.
printfn "Computing Lambert's W at x = 3 by solving x*exp(x) == 3 using double solver:"
// Create the solver...
let doubleSolver =
    let f = fun x -> x * exp(x) - 3.0
    let df = fun x -> (1.0 + x) * exp(x)
    Solver(f, df)
// Compute the solution...
let W3 = doubleSolver.Solve 1.0 1e-15
// And print the result.
printfn "Solution:    %A" W3
printfn "Known value: %A" (Elementary.LambertW(3.0))

// Finally, we use generic functions:
printfn "Using generic function delegates:"

// We can define some inline helper functions:
let inline (+) (a : 'a) b = Operations<'a>.Add(a, b)
let inline (-) (a : 'a) b = Operations<'a>.Subtract(a, b)
let inline (*) (a : 'a) b = Operations<'a>.Multiply(a, b)
let inline one<'a> = Operations<'a>.One
let inline zero<'a> = Operations<'a>.One
let inline exp (x : 'a) = Operations<'a>.Exp(x)
let inline ofint<'a> n = Operations<'a>.FromInt32(n)

// Using these definitions, we can use standard notation:
let fGeneric x = x * exp x - ofint 3
let dfGeneric x = exp x * (x + one<_>)

let solve<'a> f df = Solver<'a>(f, df).Solve
let solveW<'a> = solve<'a> fGeneric dfGeneric

let genericW3 = solveW 1.0 1e-15
printfn "Double:      %A" genericW3

let bigW3 = solveW BigFloat.One (BigFloat 10) ** -100
printfn "BigFloat:    %s" (bigW3.ToString("F100"))
