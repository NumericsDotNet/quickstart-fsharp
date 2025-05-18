//=====================================================================
//
//  File: chebyshev-expansions.fs
//
//---------------------------------------------------------------------
//
//  This file is part of the Numerics.NET Code Samples.
//
//  Copyright (c) 2004-2025 ExoAnalytics Inc. All rights reserved.
//
//=====================================================================

module ChebyshevExpansions

// Illustrates the use of the ChebyshevSeries class
// in the Numerics.NET.Curve namespace of Numerics.NET.

#light

open System

open Numerics.NET
// The ChebyshevSeries class resides in the Numerics.NET.Curves
// namespace.
open Numerics.NET.Curves

// The license is verified at runtime. We're using a 30 day trial key here.
// For more information, see:
//     https://numerics.net/trial-key
let licensed = Numerics.NET.License.Verify("your-trial-key-here")

// Chebyshev polynomials form an alternative basis
// for polynomials. A Chebyshev expansion is a
// polynomial expressed as a sum of Chebyshev
// polynomials.
//
// Using the ChebyshevSeries class instead of
// Polynomial can have two major advantages:
//   1. They are numerically more stable. Higher
//      accuracy is maintained even for large problems.
//   2. When approximating other functions with
//      polynomials, the coefficients in the
//      Chebyshev expansion will tend to decrease
//      in size, where those of the normal polynomial
//      approximation will tend to oscillate wildly.

//
// Constructing Chebyshev expansions
//

// Chebyshev expansions are defined over an interval.
// The first constructor requires you to specify the
// boundaries of the interval, and the coefficients
// of the expansion.
let coefficients = Vector.Create([| 1.0; 0.5; -0.3; 0.1 |])
let chebyshev1 = ChebyshevSeries(coefficients, 0.0, 2.0)
// If you omit the boundaries, they are assumed to be
// -1 and +1:
let chebyshev2 = ChebyshevSeries(coefficients)

//
// Chebyshev approximations
//

// A third constructor creates a Chebyshev
// approximation to an arbitrary function. For more
// about the Func<double, double> delegate, see the
// FunctionDelegates QuickStart Sample.
//
// Chebyshev expansions allow us to obtain an
// excellent approximation at minimal cost.
//
// The following creates a Chebyshev approximation
// of degree 7 to Cos(x) over the interval [0, 2]:
let approximation1 = ChebyshevSeries.GetInterpolatingPolynomial(Func<_,_> Math.Cos, 0.0, 2.0, 7)
// The coefficients of the expansion are available through
// the indexer property of the ChebyshevSeries object:
printfn "Chebyshev approximation of cos(x):"
for index in 0..7 do
    printfn "  c%d = %A" index approximation1.[index]

// The largest errors are approximately at the
// zeroes of the Chebyshev polynomial of degree 8:
for index in 0..8 do
    let zero = 1.0 + Math.Cos(float index * Constants.Pi / 8.0)
    let error = approximation1.ValueAt(zero) - Math.Cos(zero)
    printfn " Error %d = %A" index error

//
// Least squares approximations
//

// We will now calculate the least squares polynomial
// of degree 7 through 33 points.
// First, calculate the points:
let xValues = [| for i in 0..32 -> 1.0 + Math.Cos(float i * Constants.Pi / 32.0) |]
let yValues = [| for i in 0..32 -> Math.Cos(xValues.[i]) |]
// Next, define a ChebyshevBasis object for the
// approximation we want: interval [0,2] and degree
// is 7.
let basis = ChebyshevBasis(0.0, 2.0, 7)
// Now we can calculate the least squares fit:
let approximation2 = basis.LeastSquaresFit(xValues, yValues, xValues.Length)
// We can see it is close to the original
// approximation we found earlier:
for index in 0..7 do
    printfn "  c%d = %A" index approximation2.[index]
