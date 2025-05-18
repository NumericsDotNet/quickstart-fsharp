//=====================================================================
//
//  File: prime-numbers.fs
//
//---------------------------------------------------------------------
//
//  This file is part of the Numerics.NET Code Samples.
//
//  Copyright (c) 2004-2025 ExoAnalytics Inc. All rights reserved.
//
//=====================================================================

module PrimeNumbers

// Illustrates working with prime numbers using the
// IntegerMath class in the Numerics.NET
// namespace of Numerics.NET.

#light

open System

// We use many classes from the Numerics.NET
// namespace.
open Numerics.NET

// The license is verified at runtime. We're using a 30 day trial key here.
// For more information, see:
//     https://numerics.net/trial-key
let licensed = Numerics.NET.License.Verify("your-trial-key-here")

//
// Factoring numbers
//

let formatFactor = function
    | struct (p, 1) -> sprintf "%O" p
    | struct (p, n) -> sprintf "%O^%d" p n

let printFactors (n : 'T) (factors: struct ('T * int) seq) =
    printf "%O = " n
    factors
    |> Seq.map formatFactor
    |> String.concat " * "
    |> printfn "%s"

let n = 1001110110
let factors = IntegerMath.Factor(n)
printFactors n factors

// Factors that occur multiple times is repeated as many times as necessary:
let n2 = 256 * 6157413
let factors2 = IntegerMath.Factor(n2)
printFactors n2 factors2

// The 64bit version can safely factor numbers up to 48 bits long:
let n3 = 1296523L * 1177157L
let factors3 = IntegerMath.Factor(n3)
printFactors n3 factors3

//
// Prime numbers
//

// The IsPrime method verifies if a number is prime or not.
let p1 = 801853937
printfn "%d is prime? %b!" p1 (IntegerMath.IsPrime(p1))
let p2 = 801853939
printfn "%d is prime? %b!" p2 (IntegerMath.IsPrime(p2))

// MextPrime gets the first prime after a specified number.
// You can call it repeatedly to get successive primes.
// Let//s get the 10 smallest primes larger than one billion:
let mutable pn = 1000000000
printfn "\nFirst 10 primes greater than 1 billion:"
for index in 1..10 do
    pn <- IntegerMath.NextPrime(pn)
    printf "%16d" n
printfn ""

// PreviousPrime gets the last prime before a specified number.
pn <- 1000000000
printfn "Last 10 primes less than 1 billion:"
for index in 1..10 do
    pn <- IntegerMath.PreviousPrime(pn)
    printf "%16d" n
printfn ""
