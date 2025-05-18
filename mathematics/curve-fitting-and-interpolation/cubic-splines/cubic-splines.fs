//=====================================================================
//
//  File: cubic-splines.fs
//
//---------------------------------------------------------------------
//
//  This file is part of the Numerics.NET Code Samples.
//
//  Copyright (c) 2004-2025 ExoAnalytics Inc. All rights reserved.
//
//=====================================================================

module CubicSplines

#light

open System

// The CubicSpline class resides in the
// Numerics.NET.Curves namespace.
open Numerics.NET.Curves

// The license is verified at runtime. We're using a 30 day trial key here.
// For more information, see:
//     https://numerics.net/trial-key
let licensed = Numerics.NET.License.Verify("your-trial-key-here")

/// Illustrates creating natural and clamped cubic splines using
/// the CubicSpline class in the Numerics.NET.Curves
/// namespace of Numerics.NET.

// A cubic spline is a piecewise curve that is made up
// of pieces of cubic polynomials. Its value as well as its first
// derivative are continuous, giving it a smooth appearance.
//
// Cubic splines are implemented by the CubicSpline class,
// which inherits from PiecewiseCurve.
//
// For an example of piecewise constant and piecewise
// linear curves, see the PiecewiseCurves QuickStart
// Sample.
//

//
// Creating Cubic Splines
//

// In order to define a spline curve completely, two extra
// conditions must be imposed.

// 'Natural' splines have zero second derivatives. This is
// the default.

// The data points are specified as double arrays containing
// the x and y values:
let xValues = [|1.0; 2.0; 3.0; 4.0; 5.0; 6.0|]
let yValues = [|1.0; 3.0; 4.0; 3.0; 4.0; 2.0|]
let naturalSpline = CubicSpline(xValues, yValues)

// 'Clamped' splines have a fixed slope or first derivative at the
// leftmost and rightmost points. The slopes are specified as
// two extra parameters in the constructor:
let clampedSpline = CubicSpline(xValues, yValues, -1.0, 1.0)

// 'Akima' splines minimize the oscillations in the interpolating
// curve. The constructor takes an extra argument of type
// CubicSplineKind:
let akimaSpline = CubicSpline(xValues, yValues, CubicSplineKind.Akima)
// The factory method does not require the extra parameter:
let akimaSpline2 = CubicSpline.CreateAkima(xValues, yValues)

// Hermite splines have fixed values for the first derivative at each
// data point. The first derivatives must be supplied as an array
// or list:
let yPrimeValues = [| 0.0; 1.0; -1.0; 1.0; 0.0; -1.0 |]
let hermiteSpline = CubicSpline(xValues, yValues, yPrimeValues)
// Likewise for the factory method:
let hermiteSpline2 = CubicSpline.CreateHermiteInterpolant(xValues, yValues, yPrimeValues)

//
// Curve Parameters
//

// The shape of any curve is determined by a set of parameters.
// These parameters can be retrieved and set through the
// Parameters collection. The number of parameters for a curve
// is given by this collection's Count property.
//
// Cubic splines have 2n+2 parameters, where n is the number of
// data points. The first n parameters are the x-values. The next
// n parameters are the y-values. The last two parameters are
// the values of the derivative at the first and last point. For natural
// splines, these parameters are unused.

printfn "naturalSpline.Parameters.Count = %d" naturalSpline.Parameters.Count
// Parameters can easily be retrieved:
printfn "naturalSpline.Parameters[0] = %A" naturalSpline.Parameters[0]
// Parameters can also be set:
naturalSpline.Parameters[0] <- 1.0

//
// Piecewise curve methods and properties
//

// The NumberOfIntervals property returns the number of subintervals
// on which the curve has unique definitions.
printfn "Number of intervals: %d" naturalSpline.NumberOfIntervals

// The IndexOf method returns the index of the interval
// that contains a specific value.
printfn "naturalSpline.IndexOf(1.4) = %d" (naturalSpline.IndexOf(1.4))
// The method returns -1 when the value is smaller than the lower bound
// of the first interval, and NumberOfIntervals if the value is equal to or larger than
// the upper bound of the last interval.

//
// Curve Methods
//

// The ValueAt method returns the y value of the
// curve at the specified x value:
printfn "naturalSpline.ValueAt(2.4) = %A" (naturalSpline.ValueAt(2.4))

// The SlopeAt method returns the slope of the curve
// a the specified x value:
printfn "naturalSpline.SlopeAt(2) = %A" (naturalSpline.SlopeAt(2.0))
// You can verify that the clamped spline has the correct slope at the end points:
printfn "clampedSpline.SlopeAt(1) = %A" (clampedSpline.SlopeAt(1.0))
printfn "clampedSpline.SlopeAt(6) = %A" (clampedSpline.SlopeAt(6.0))

// Cubic splines do not have a defined derivative. The GetDerivative method
// returns a GeneralCurve:
let derivative = naturalSpline.GetDerivative()
printfn "Type of derivative: %O" (derivative.GetType())
printfn "derivative(2) = %A" (derivative.ValueAt(2.0))

// You can get a Line that is the tangent to a curve
// at a specified x value using the TangentAt method:
let tangent = clampedSpline.TangentAt(2.0)
printfn "Slope of tangent line at 2 = %A" tangent.Parameters[1]

// The integral of a spline curve can be calculated exactly. This technique is
// often used to approximate the integral of a tabulated function:
printfn "Integral of naturalSpline between 1.4 and 4.6 = %A"
    (naturalSpline.Integral(1.4, 4.6))
