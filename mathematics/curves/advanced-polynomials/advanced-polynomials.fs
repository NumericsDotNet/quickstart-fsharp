//=====================================================================
//
//  File: advanced-polynomials.fs
//
//---------------------------------------------------------------------
//
//  This file is part of the Numerics.NET Code Samples.
//
//  Copyright (c) 2004-2025 ExoAnalytics Inc. All rights reserved.
//
//=====================================================================

module AdvancedPolynomials

// Illustrates the more advanced uses of the Polynomial class
// in the Numerics.NET.Curve namespace of Numerics.NET.

#light

open System

// The Complex<float> structure resides in the Numerics.NET namespace.
open Numerics.NET
// The Polynomial class resides in the Numerics.NET.Curves namespace.
open Numerics.NET.Curves

// The license is verified at runtime. We're using a 30 day trial key here.
// For more information, see:
//     https://numerics.net/trial-key
let licensed = Numerics.NET.License.Verify("your-trial-key-here")

// Basic operations on polynomials are covered in the
// BasicPolynomials QuickStart Sample. This QuickStart
// Sample focuses on more advanced topics, including
// finding complex roots, calculating least-squares
// polynomials, and polynomial arithmetic.

//
// Complex<float> numbers and polynomials
//

let polynomial = Polynomial([| -2.0; 0.0; 1.0; 1.0 |])

// The Polynomial class supports complex numbers
// as arguments for polynomials. It does not support
// polynomials with complex coefficients.
//
// For more about complex numbers, see the
// ComplexNumbers QuickStart Sample.
let z1 = Complex<float>(1.0, 2.0)

// Polynomial provides variants of ValueAt and
// SlopeAt for complex arguments:
printfn "polynomial.ComplexValueAt(%A) = %A" z1 (polynomial.ComplexValueAt(z1))
printfn "polynomial.ComplexSlopeAt(%A) = %A" z1 (polynomial.ComplexSlopeAt(z1))

//
// Real and complex roots
//
// Our polynomial has only one real root:
let roots = polynomial.FindRoots()
printfn "Number of roots of polynomial1: %d" roots.Length
printfn "Value of root 1 = %A" roots.[0]
// The FindComplexRoots method returns all three
// roots, two of which are complex:
let complexRoots = polynomial.FindComplexRoots()
printfn "Number of complex roots: %d" complexRoots.Length
printfn "Value of root 1 = %A" complexRoots.[0]
printfn "Value of root 2 = %A" complexRoots.[1]
printfn "Value of root 3 = %A" complexRoots.[2]

//
// Least squares polynomials
//

// Let's approximate 7 points on the unit circle
// by a fourth degree polynomial in the least squares
// sense.
// First, we create two arrays containing the x and
// y values of our data points:
let xValues = Vector.Create([| for i in 0..6 -> Math.Cos(float i * Constants.Pi / 6.0) |])
let yValues = Vector.Create([| for i in 0..6 -> -Math.Sin(float i * Constants.Pi / 6.0) |])
// Now we can find the least squares polynomial
// by calling the ststic LeastSquaresFit method.
// The last parameter is the degree of the desired
// polynomial.
let lsqPolynomial = Polynomial.LeastSquaresFit(xValues, yValues, 4)
// Note that, as expected, the odd coefficients
// are close to zero.
printfn "Least squares fit: %O" lsqPolynomial

//
// Polynomial arithmetic
//

// We can add, subtract, multiply and divide
// polynomials using overloaded operators:
let a = Polynomial([| 4.0; -2.0; 4.0 |])
let b = Polynomial([| -3.0; 1.0 |])

printfn "a = %O" a
printfn "b = %O" b
printfn "a + b = %O" (a + b)
printfn "a - b = %O" (a - b)
printfn "a * b = %O" (a * b)
printfn "a / b = %O" (a / b)
printfn "a %% b = %O" (a % b)
// You can also calculate quotient and remainder
// at the same time by calling the overloaded Divide
// method:
let (c,d) = Polynomial.Divide(a, b)
printfn "Using Divide method:"
printfn "  a / b = %O" c
printfn "  a %% b = %O" d
