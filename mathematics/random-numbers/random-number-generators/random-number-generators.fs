//=====================================================================
//
//  File: random-number-generators.fs
//
//---------------------------------------------------------------------
//
//  This file is part of the Numerics.NET Code Samples.
//
//  Copyright (c) 2004-2025 ExoAnalytics Inc. All rights reserved.
//
//=====================================================================

module RandomNumberGenerators

// Illustrates the use of the classes that implement
// pseudo-random number generators.

open System

open Numerics.NET
open Numerics.NET.Random

// The license is verified at runtime. We're using a 30 day trial key here.
// For more information, see:
//     https://numerics.net/trial-key
let licensed = Numerics.NET.License.Verify("your-trial-key-here")

// This QuickStart Sample gives an overview of the pseudo-random
// number generators that provide an alternative for the
// System.Random class..

//
// ExtendedRandom class
//

// The ExtendedRandom class simply extends the functionality
// of the System.Random class:
let extended = ExtendedRandom()
let intValues = Array.zeroCreate<int>(100)
let doubleValues = Array.zeroCreate<float>(100)

// The fill method fills an array of integers with random numbers
extended.Fill(intValues)
printfn "integer(99) = %d" intValues[99]

// Or, it can generate uniform real values:
extended.Fill(doubleValues)
printfn "double(99) = %A" doubleValues[99]

// All random number generators can also produce variates
// from any user-specified probability distribution.
// The NonUniformRandomNumbers sample illustrates
// how to do this.

//
// RANLUX Generators
//

// The RANLUX generators are available with three different
// 'luxury levels.' Each level produces random numbers of
// increasing quality at a performance cost.
//
// There are four constructors. The first constructor uses the
// default seed and the default (lowest) luxury level:
let ranLux1 = RanLux()

// We can specify a seed value as well:
let ranLux2 = RanLux(99)

// We can specify the luxury level in the constructor:
let ranLux3 = RanLux(RanLuxLuxuryLevel.Better)

// Finally, we can specify both a seed and the luxury level:
let ranLux4 = RanLux(99, RanLuxLuxuryLevel.Best)

// All methods of System.Random and ExtendedRandom are available:
ranLux1.Fill(intValues)
ranLux2.Fill(doubleValues)
printfn "Integer from RanLux(Best): %d" (ranLux3.Next(100))

//
// Generalized Feedback Shift Register Generator
//

// This generator is implemented by the GfsrGenerator class.
// It has three constructors. A default constructor that uses
// a default seed value:
let gfsr1 = GfsrGenerator()

// A constructor that takes a single integer seed:
let gfsr2 = GfsrGenerator(99)

// And a constructor that takes an array of integers
// as its seed. The maximum size of this seed array
// is 2^14-1 = 16383.
let gfsr3 = GfsrGenerator([| 99; 17; Int32.MaxValue |])

// Once again, all standard methods are available.
printfn "Float from GFSR: %A" (gfsr2.NextDouble())

//
// Mersenne Twister
//

// The Mersenne Twister is a variation on the GFSR generator and,
// not surprisingly, also has three constructors:
let mersenne1 = MersenneTwister()
let mersenne2 = MersenneTwister(99)
let mersenne3 = MersenneTwister([| 99; 17; Int32.MaxValue |])
