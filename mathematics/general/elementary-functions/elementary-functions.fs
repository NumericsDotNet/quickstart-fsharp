//=====================================================================
//
//  File: elementary-functions.fs
//
//---------------------------------------------------------------------
//
//  This file is part of the Numerics.NET Code Samples.
//
//  Copyright (c) 2004-2025 ExoAnalytics Inc. All rights reserved.
//
//=====================================================================

module ElementaryFunctions

// Illustrates the use of the elementary functions implemented
// by the Elementary class in the Numerics.NET.Curve namespace of Numerics.NET.

#light

open System

// We use many classes from the Numerics.NET namespace.
open Numerics.NET

// The license is verified at runtime. We're using a 30 day trial key here.
// For more information, see:
//     https://numerics.net/trial-key
let licensed = Numerics.NET.License.Verify("your-trial-key-here")

// This QuickStart sample deals with elementary
// functions, implemented in the Elementary class.

//
// Elementary functions
//

// Evaluating Log(1+x) directly causes significant
// round-off error when x is close to 0. The
// Log1PlusX function allows high precision evaluation
// of this expression for values of x close to 0:
printfn "Logarithm of 1+1e-12"
printfn "  Math.Log: %A" (Math.Log(1.0 + 1e-12))
printfn "  Log1PlusX: %A" (Elementary.Log1PlusX(1e-12))

// In a similar way, Exp(x) - 1 has a variant,
// ExpXMinus1, for values of x close to 0:
printfn "Exponential of 1e-12 minus 1."
printfn "  Math.Exp: %A" (Math.Exp(1e-12) - 1.0)
printfn "  ExpMinus1: %A" (Elementary.ExpMinus1(1e-12))

// The hypotenuse of two numbers that are very large
// may cause an overflow when not evaluated properly:
printfn "Hypotenuse:"
let a = 3e200
let b = 4e200
printf "  Simple method: "
try
    let sumOfSquares = a*a + b*b
    printfn "%A" (Math.Sqrt(sumOfSquares))
with
| :? OverflowException -> printfn "Overflow!"

printfn "  Elementary.Hypot: %A" (Elementary.Hypot(a, b))

// Raising numbers to integer powers is much faster
// than raising numbers to real numbers. The
// overloaded Pow method implements this:
printfn "2.5^19 = %A" (Elementary.Pow(2.5, 19))
// You can raise numbers to negative integer powers
// as well:
printfn "2.5^-19 = %A" (Elementary.Pow(2.5,-19))
