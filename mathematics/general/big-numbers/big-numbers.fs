//=====================================================================
//
//  File: big-numbers.fs
//
//---------------------------------------------------------------------
//
//  This file is part of the Numerics.NET Code Samples.
//
//  Copyright (c) 2004-2025 ExoAnalytics Inc. All rights reserved.
//
//=====================================================================

module BigNumbers

// Illustrates the use of the arbitrary precision number
// classes in Numerics.NET.

#light

open System

// The arbitrary precision types reside in the Numerics.NET
// namespace.
open Numerics.NET

// The license is verified at runtime. We're using a 30 day trial key here.
// For more information, see:
//     https://numerics.net/trial-key
let licensed = Numerics.NET.License.Verify("your-trial-key-here")

// In this QuickStart sample, we'll use 5 different methods to compute
// the value of pi, the ratio of the circumference to the diameter of
// a circle.

// The number of decimal digits.
let digits = 10000
// The equivalent number of binary digits, to account for round-off error:
let binaryDigits = (int)(8.0 + (float digits) * Math.Log(10.0, 2.0))

// First, create an AccuracyGoal for the number of digits we want.
// We'll add 5 extra digits to account for round-off error.
let goal = AccuracyGoal.Absolute(float (digits + 5))
printfn "Calculating %d digits of pi:" digits

// Create a stopwatch so we can time the results.
let sw = System.Diagnostics.Stopwatch()

//
// Method 1: Arctan formula
//
// pi/4 = 88L(172) + 51L(239) + 32L(682) + 44L(5357) + 68L(12943)
// Where L(p) = Arctan(1/p)
// We will use big integer arithmetic for this.
// See the helper function Arctan later in this file.
printfn "Arctan formula using integer arithmetic:"

let IntegerArctanPi binaryDigits =
    let coefficients = [| 88; 51; 32; 44; 68 |]
    let arguments = [| 172; 239; 682; 5357; 12943 |]

    // Helper function to compute Arctan(1/p)
    let Arctan p binaryDigits =
        let rec ArctanRec result (power : BigInteger) k subtract =
            if (power.IsZero) then
                result
            else
                // Expressions involving big integers look exactly like any other arithmetic expression:
                // The kth term is (-1)^k 1/(2k+1) 1/p^2k.
                // So the power is 1/p^2 times the previous power.
                let newPower = power / (p * p)
                let term = newPower / BigInteger(2 * k + 1)
                // And we alternately add and subtract
                let newResult = if subtract then result - term else result + term
                ArctanRec newResult newPower (k+1) (not subtract)
        // We scale the result by a factor of 2^binaryDigits.
        // The first term is 1/p.
        let power = BigInteger(2) ** binaryDigits / p
        let result = ArctanRec power power 1 true
        // Scale the result.
        BigFloat.ScaleByPowerOfTwo(new BigFloat(result), -binaryDigits)

    let mutable pi = BigFloat.Zero
    for k in 0..4 do
        pi <- pi + coefficients.[k] * (Arctan arguments.[k] binaryDigits)
        printfn "Step %d: (%.3f seconds)" (k + 1) sw.Elapsed.TotalSeconds
    // The ScaleByPowerOfTwo is the fastest way to multiply
    // or divide by a power of two:
    BigFloat.ScaleByPowerOfTwo(pi, 2)

sw.Start()
IntegerArctanPi binaryDigits |> ignore
sw.Stop()

printfn "Total time: %.3f seconds." sw.Elapsed.TotalSeconds
printfn ""

//
// Method 2: Rational approximation
//
// pi/2 = 1 + 1/3 + (1*2)/(3*5) + (1*2*3)/(3*5*7) + ...
//      = 1 + 1/3 * (1 + 2/5 * (1 + 3/7 * (1 + ...)))
// We gain 1 bit per iteration, so we know where to start.
printfn "Rational approximation using rational arithmetic."
let RationalPi binaryDigits =
    let rec RationalPiRec n an =
        match n with
        | 0 -> an
        | _ -> RationalPiRec (n-1) (new BigRational(n, 2 * n + 1) * an + 1)
    let an = RationalPiRec binaryDigits BigRational.Zero
    new BigFloat(2 * an, goal, RoundingMode.TowardsNearest)

printfn "This is very inefficient, so we only do up to 10,000 digits."
let rationalBinaryDigits = (int)(8.0 + 10000.0 * Math.Log(10.0, 2.0))
sw.Restart()
RationalPi rationalBinaryDigits |> ignore
sw.Stop()
printfn "Total time: %.3f seconds." sw.Elapsed.TotalSeconds
printfn ""

//
// Method 3: Arithmetic-Geometric mean
//
// By Salamin & Brent, based on discoveries by C.F.Gauss.
// See http://www.cs.miami.edu/~burt/manuscripts/gaussagm/agmagain-hyperref.pdf
printfn "Arithmetic-Geometric Mean:"
let ArithmeticGeometricMeanPi goal =
    let rec AGMPiRec k x1 x2 (S:BigFloat) =
        let aMean = BigFloat.ScaleByPowerOfTwo(x1 + x2, -1)
        let gMean = BigFloat.Sqrt(x1 * x2)
        let c = (aMean + gMean) * (aMean - gMean)
        // GetDecimalDigits returns the approximate number of digits in a number.
        // A negative return value means the number is less than 1.
        let correctionDigits = -c.GetDecimalDigits()
        printfn "Iteration %d: %.1f digits (%.3f seconds)" k correctionDigits sw.Elapsed.TotalSeconds
        if (correctionDigits >= float digits) then
            x1 * x1 / (1 - S)
        else
            AGMPiRec (k+1) aMean gMean (S + BigFloat.ScaleByPowerOfTwo(c, k))
    let x1 = BigFloat.Sqrt(BigFloat(2), goal, RoundingMode.TowardsNearest)
    let x2 = BigFloat.One
    let S = BigFloat(2)
    AGMPiRec 0 x1 x2 S

sw.Restart()
ArithmeticGeometricMeanPi goal |> ignore
sw.Stop()
printfn "Total time: %.3f seconds." sw.Elapsed.TotalSeconds
printfn ""

//
// Method 4: Borweins' quartic formula
//
// This algorithm quadruples the number of correct digits
// in each iteration.
// See http://en.wikipedia.org/wiki/Borwein's_algorithm
printfn "Quartic formula:"
let QuarticPi goal =
    let rec QuarticPiRec k a (y4 : BigFloat) =
        let qrt = BigFloat.Root(1 - y4, 4)
        let y = (1 - qrt) / (1 + qrt)
        let y2 = y * y
        let y3 = y * y2
        let y4 = y2 * y2
        let (daRaw : BigFloat) = (a * (BigFloat.ScaleByPowerOfTwo(y + y3, 2) + (6 * y2 + y4))
            - BigFloat.ScaleByPowerOfTwo(y + y2 + y3, 2 * k + 1))
        let da = daRaw.RestrictPrecision(goal, RoundingMode.TowardsNearest)
        let aNew = (a + da)
        let correctionDigits = -da.GetDecimalDigits()
        printfn "Iteration %d: %.1f digits (%.3f seconds)" k correctionDigits sw.Elapsed.TotalSeconds
        if (4.0 * correctionDigits < float digits) then
            QuarticPiRec (k+1) aNew y4
        else
            aNew
    let sqrt2 = BigFloat.Sqrt(BigFloat(2), goal, RoundingMode.TowardsNearest)
    let y = sqrt2 - BigFloat.One
    let a = BigFloat(6, goal) - BigFloat.ScaleByPowerOfTwo(sqrt2, 2)
    let invPi = QuarticPiRec 1 a (y ** 4)
    BigFloat.Inverse(invPi)
sw.Restart()
QuarticPi goal |> ignore
sw.Stop()
printfn "Total time: %.3f seconds." sw.Elapsed.TotalSeconds
printfn ""

//
// Method 5: The built-in method
//
// The method used to compute pi internally is an order of magnitude
// faster than any of the above.
printfn "Built-in function:"
sw.Reset()
sw.Start()
let piBuiltIn = BigFloat.GetPi(goal)
sw.Stop()
printfn "Total time: %.3f seconds." sw.Elapsed.TotalSeconds
// The highest precision value of pi is cached, so
// getting pi to any precision up to that is super fast.
printfn "Built-in function (cached):"
sw.Reset()
sw.Start()
let piBuiltInCached = BigFloat.GetPi(goal)
sw.Stop()
printfn "Total time: %.3f seconds." sw.Elapsed.TotalSeconds
