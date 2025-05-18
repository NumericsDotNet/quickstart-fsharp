//=====================================================================
//
//  File: quasi-random.fs
//
//---------------------------------------------------------------------
//
//  This file is part of the Numerics.NET Code Samples.
//
//  Copyright (c) 2004-2025 ExoAnalytics Inc. All rights reserved.
//
//=====================================================================

module QuasiRandom

/// Illustrates the use of quasi-random sequences by computing
/// a multi-dimensional integral.

#light

open System

open Numerics.NET
open Numerics.NET.Random

// The license is verified at runtime. We're using a 30 day trial key here.
// For more information, see:
//     https://numerics.net/trial-key
let licensed = Numerics.NET.License.Verify("your-trial-key-here")

// This QuickStart Sample demonstrates the use of
// quasi-random sequences by computing
// a multi-dimensional integral.

// We will use one million points.
let length = 10000
// The number of dimensions:
let dimension = 5

// We will evaluate the function
//
//    Product(i = 1 -> # dimensions) |4 x.[i] - 2|
//
// over the hypercube 0 <= x.[i] <= 1. The value of this integral
// is exactly 1.

// Compute the integral by summing over all points:
let f (point : Vector<float>) =
    let mutable functionValue = 1.0
    for j in 0..point.Length-1 do
        functionValue <- functionValue * abs(4.0*point.[j]-2.0)
    functionValue

let integrate f sequence =
    printfn "# iter.  Estimate"
    let mutable sum = 0.0
    let mutable i = 0
    for point in sequence do
        if (i % 1000 = 0) then
            printfn "%6d  %8.4f" i (sum / float i)
        sum <- sum + f point
        i <- i + 1
    sum / (float i)

// Create the sequence:
let halton = QuasiRandom.HaltonSequence(dimension, length)
let haltonResult = integrate f halton

printfn "Final estimate (Halton): %8.4f" haltonResult
printfn "Exact value: 1.0000"

// Sobol sequences require more data and more initialization.
// Fortunately, different sequences of the same dimension
// can share much of the work and storage. The
// SobolSequenceGenerator class should be used in this case:

let skip = 1000;
let sobol = new SobolSequenceGenerator(dimension, length + skip);
// Sobol sequences are more flexible: they let you skip
// a number of points at the start of the sequence.
// The cost of skipping points is O(1).
let sobolResult = integrate f (sobol.Generate(length, skip))

// Print the final result.
printfn "Final estimate (Sobol): %8.4f" sobolResult
printfn "Exact value: 1.0000"
