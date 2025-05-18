//=====================================================================
//
//  File: basic-polynomials.fs
//
//---------------------------------------------------------------------
//
//  This file is part of the Numerics.NET Code Samples.
//
//  Copyright (c) 2004-2025 ExoAnalytics Inc. All rights reserved.
//
//=====================================================================

module BasicPolynomials

// Illustrates the basic use of the Polynomial class in the
// Numerics.NET.Curve namespace of Numerics.NET.

#light

open System

// The Polynomial class resides in the Numerics.NET.Curves namespace.
open Numerics.NET.Curves

// The license is verified at runtime. We're using a 30 day trial key here.
// For more information, see:
//     https://numerics.net/trial-key
let licensed = Numerics.NET.License.Verify("your-trial-key-here")

// All curves inherit from the Curve abstract base
// class. The Polynomial class overrides implements all
// the methods and properties of the Curve class,
// and adds a few more.

//
// Polynomial constructors
//

// The Polynomial class has multiple constructors. Each
// constructor derives from a different way to define
// a polynomial or parabola.

// 1st option: a polynomial of a specified degree.
let polynomial1 = Polynomial(3)
// Now set the coefficients individually. The coefficients
// can be set using the indexer property. The constant term
// has index 0:
polynomial1.[3] <- 1.0
polynomial1.[2] <- 1.0
polynomial1.[1] <- 0.0
polynomial1.[0] <- -2.0

// 2nd option: specify the coefficients in the constructor
// as an array of doubles:
let coefficients = [| -2.0; 0.0; 1.0; 1.0 |]
let polynomial2 = Polynomial(coefficients)

// In addition, you can create a polynomial that
// has certain roots using the static FromRoots
// method:
let roots = [| 1.0; 2.0; 3.0; 4.0 |]
let polynomial3 = Polynomial.FromRoots(roots)
// Or you can construct the interpolating polynomial
// by calling the static GetInterpolatingPolynomial
// method. The parameters are two double arrays
// containing the x values and y values respectively.
let xValues = [| 1.0; 2.0; 3.0; 4.0 |]
let yValues = [| 1.0; 4.0; 10.0; 8.0 |]
let polynomial4 = Polynomial.GetInterpolatingPolynomial(xValues, yValues)

// The ToString method gives a common let
// representation of the polynomial:
printfn "polynomial3 = %O" polynomial3

//
// Curve Parameters
//

// The shape of any curve is determined by a set of parameters.
// These parameters can be retrieved and set through the
// Parameters collection. The number of parameters for a curve
// is given by this collection's Count property.
//
// For polynomials, the parameters are the coefficients
// of the polynomial. The constant term has index 0:
printfn "polynomial1.Parameters.Count = %d" polynomial1.Parameters.Count
// Parameters can easily be retrieved:
printf "polynomial1 parameters:"

let printParameters (curve : Curve) =
    for index in 0..curve.Parameters.Count-1 do
        printf "%A " curve.Parameters.[index]
    printfn ""

printParameters polynomial1

// We can see that polynomial2 defines the same polynomial
// curve as polynomial1:
printf "polynomial2 parameters:"
printParameters polynomial2

// Parameters can also be set:
polynomial1.Parameters.[0] <- 1.0

// For polynomials and other classes that inherit from
// the LinearCombination class, the parameters are also
// available through the indexer property of Polynomial.
// The following is equivalent to the line above:
polynomial1.[0] <- 1.0

// The degree of the polynomial is returned by
// the Degree property:
printfn "Degree of polynomial3 = %d" polynomial3.Degree

//
// Curve Methods
//

// The ValueAt method returns the y value of the
// curve at the specified x value:
printfn "polynomial1.ValueAt(2) = %A" (polynomial1.ValueAt(2.0))

// The SlopeAt method returns the slope of the curve
// a the specified x value:
printfn "polynomial1.SlopeAt(2) = %A" (polynomial1.SlopeAt(2.0))

// You can also create a new curve that is the
// derivative of the original:
let derivative = polynomial1.GetDerivative()
printfn "Slope at 2 (derivative) = %A" (derivative.ValueAt(2.0))
// For a polynomial, the derivative is a Quadratic curve
// if the degree is equal to three:
printfn "Type of derivative: %s" (derivative.GetType().FullName)
printf "Derivative parameters: "
printParameters derivative

// If the degree is 4 or higher, the derivative is
// once again a polynomial:
printfn "Type of derivative for polynomial3: %s"
    (polynomial3.GetDerivative().GetType().FullName)

// You can get a Line that is the tangent to a curve
// at a specified x value using the TangentAt method:
let tangent = polynomial1.TangentAt(2.0)
printfn "Tangent line at 2:"
printfn "  Y-intercept = %A" tangent.Parameters.[0]
printfn "  Slope = %A" tangent.Parameters.[1]

// For many curves, you can evaluate a definite
// integral exactly:
printfn "Integral of polynomial1 between 0 and 1 = %A"
    (polynomial1.Integral(0.0, 1.0))

// You can find the zeroes or roots of the curve
// by calling the FindRoots method. Note that this
// method only returns the real roots.
let roots1 = polynomial1.FindRoots()
printfn "Number of roots of polynomial1: %d" roots1.Length
printfn "Value of root 1 = %A" roots1.[0]
// Let's find polynomial3's roots again:
let roots2 = polynomial3.FindRoots()
printfn "Number of roots of polynomial3: %d" roots2.Length
printfn "Value of root = %A" roots2.[0]
printfn "Value of root = %A" roots2.[1]
// Root finding isn't an exact science. Note the
// round-off error in these values:
printfn "Value of root = %A" roots2.[2]
printfn "Value of root = %A" roots2.[3]

// For more advanced uses of the Polynomial class,
// see the AdvancedPolynomials QuickStart sample.

