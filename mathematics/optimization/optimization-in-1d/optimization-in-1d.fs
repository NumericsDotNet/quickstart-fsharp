//=====================================================================
//
//  File: optimization-in-1d.fs
//
//---------------------------------------------------------------------
//
//  This file is part of the Numerics.NET Code Samples.
//
//  Copyright (c) 2004-2025 ExoAnalytics Inc. All rights reserved.
//
//=====================================================================

module OptimizationIn1D

// Illustrates the use of the Brent and Golden Section optimizers
// in the Numerics.NET.Optimization namespace of Numerics.NET.

#light

open System

open Numerics.NET
// The optimization classes resides in the
// Numerics.NET.EquationSolvers namespace.
open Numerics.NET.Optimization

// The license is verified at runtime. We're using a 30 day trial key here.
// For more information, see:
//     https://numerics.net/trial-key
let licensed = Numerics.NET.License.Verify("your-trial-key-here")

// Several algorithms exist for optimizing functions
// in one variable. The most common one is
// Brent's algorithm.

// The function we are trying to minimize is called the
// objective function and must be provided as a Func<double, double>.

//
// Brent's algorithm
//

// Now let's create the BrentOptimizer object.
let optimizer = BrentOptimizer()

// Set the objective function:
optimizer.ObjectiveFunction <- Func<_,_> (fun x -> x * x * x - 2.0 * x - 5.0)

// Optimizers can find either a minimum or a maximum.
// Which of the two is specified by the ExtremumType
// property
optimizer.ExtremumType <- ExtremumType.Minimum

// The first phase is to find an interval that contains
// a local minimum. This is done by the FindBracket method.
optimizer.FindBracket(0.0, 3.0)
// You can verify that an interval was found from the
// IsBracketValid property:
if (not optimizer.IsBracketValid) then
    raise (Exception("An interval containing a minimum was not found."))

// Finally, we can run the optimizer by calling the FindExtremum method:
let extremum = optimizer.FindExtremum()

printfn "Function 1: x^3 - 2x - 5"
// The Status property indicates
// the result of running the algorithm.
printfn "  Status: %A" optimizer.Status
// The result is available through the
// Result property.
printfn "  Minimum: %A" optimizer.Result
let exactResult = sqrt(2.0/3.0)
let result = optimizer.Extremum
printfn "  Exact minimum: %A" exactResult

// You can find out the estimated error of the result
// through the EstimatedError property:
printfn "  Estimated error: %A" optimizer.EstimatedError
printfn "  Actual error: %A" (abs(result - exactResult))
printfn "  # iterations: %d" optimizer.IterationsNeeded

printfn "Function 2: 1/Exp(x*x - 0.7*x +0.2)"
// You can also perform these calculations more directly
// using the FindMinimum or FindMaximum methods. This implicitly
// calls the FindBracket method.
let f2 = Func<_,_> (fun x -> 1.0 / exp(x*x - 0.7*x + 0.2))
let result2 = optimizer.FindMaximum(f2, 0.0)
printfn "  Maximum: %A" result2
printfn "  Actual maximum: %A" 0.35
printfn "  Estimated error: %A" optimizer.EstimatedError
printfn "  Actual error: %A" (result - 0.35)
printfn "  # iterations: %d" optimizer.IterationsNeeded

//
// Golden section search
//

// A slower but simpler algorithm for finding an extremum
// is the golden section search. It is implemented by the
// GoldenSectionMinimizer class:
let optimizer2 = GoldenSectionOptimizer()

printfn "Using Golden Section optimizer:"
let result3 = optimizer2.FindMaximum(f2, 0.0)
printfn "  Maximum: %A" result3
printfn "  Actual maximum: %A" 0.35
printfn "  Estimated error: %A" optimizer2.EstimatedError
printfn "  Actual error: %A" (result - 0.35)
printfn "  # iterations: %d" optimizer2.IterationsNeeded
