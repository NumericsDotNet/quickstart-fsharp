//=====================================================================
//
//  File: piecewise-curves.fs
//
//---------------------------------------------------------------------
//
//  This file is part of the Numerics.NET Code Samples.
//
//  Copyright (c) 2004-2025 ExoAnalytics Inc. All rights reserved.
//
//=====================================================================

module PiecewiseCurves

// Illustrates the use of the PiecewiseConstantCurve and
// PiecewiseLinearCurve classes.

#light

open System

open Numerics.NET
// The piecewise curve classes reside in the
// Numerics.NET.Curves namespace.
open Numerics.NET.Curves

// The license is verified at runtime. We're using a 30 day trial key here.
// For more information, see:
//     https://numerics.net/trial-key
let licensed = Numerics.NET.License.Verify("your-trial-key-here")

// A piecewise curve is a curve that has a different definition
// on subintervals of its domain.
//
// This QuickStart Sample illustrates constant and linear piecewise
// curves, which - as the name suggest - are constant or linear
// on each interval.
//
// For an example of cubic splines, see the CubicSplines QuickStart
// Sample.
//

//
// Piecewise constants
//

// All piecewise curves inherit from the PiecewiseCurve class.
// Piecewise constant curves are implemented by the
// PiecewiseConstantCurve class. It has two constructors.

// The first constructor takes two double arrays as parameters.
// These contain the x and y values of the data points:
let xValues = Vector.Create([|1.0; 2.0; 3.0; 4.0; 5.0; 6.0|])
let yValues = Vector.Create([|1.0; 3.0; 4.0; 3.0; 4.0; 2.0|])
let piecewiseConstant = PiecewiseConstantCurve(xValues, yValues)

// The second constructor only takes one parameter: an array of
// Point structures that represent the data point.
let dataPoints =
    [|
        Point(1.0, 1.0);
        Point(2.0, 3.0);
        Point(3.0, 4.0);
        Point(4.0, 3.0);
        Point(5.0, 4.0);
        Point(6.0, 2.0)
    |]
let constant3 = PiecewiseConstantCurve(dataPoints)

//
// Curve Parameters
//

// The shape of any curve is determined by a set of parameters.
// These parameters can be retrieved and set through the
// Parameters collection. The number of parameters for a curve
// is given by this collection's Count property.
//
// Piecewise constant curves have 2n parameters, where n is the number of
// data points. The first n parameters are the x-values. The next
// n parameters are the y-values.

printfn "piecewiseConstant.Parameters.Count = %d" piecewiseConstant.Parameters.Count
// Parameters can easily be retrieved:
printfn "piecewiseConstant.Parameters.[0] = %A" piecewiseConstant.Parameters.[0]
// Parameters can also be set:
piecewiseConstant.Parameters.[0] <- 1.0

//
// Curve Methods
//

// The ValueAt method returns the y value of the
// curve at the specified x value:
printfn "piecewiseConstant.ValueAt(2.4) = %A" (piecewiseConstant.ValueAt(2.4))

// The SlopeAt method returns the slope of the curve
// a the specified x value:
printfn "piecewiseConstant.SlopeAt(2.4) = %A" (piecewiseConstant.SlopeAt(2.4))
// The slope at the data points is Double.NaN if the value of the constant
// is different on either side of the data point:
printfn "piecewiseConstant.SlopeAt(2) = %A" (piecewiseConstant.SlopeAt(2.0))

// Piecewise constant curves do not have a defined derivative.
// The GetDerivative method returns a GeneralCurve:
let derivative = piecewiseConstant.GetDerivative()
printfn "Type of derivative: %s" (derivative.GetType().ToString())
printfn "derivative(2.4) = %A" (derivative.ValueAt(2.4))

// You can get a Line that is the tangent to a curve
// at a specified x value using the TangentAt method:
let tangent = piecewiseConstant.TangentAt(2.4)
printfn "Slope of tangent line at 2.4 = %A" tangent.Parameters.[1]

// The integral of a piecewise constant curve can be calculated exactly.
printfn "Integral of piecewiseConstant between 1.4 and 4.6 = %A"
    (piecewiseConstant.Integral(1.4, 4.6))

//
// Piecewise linear curves
//

// Piecewise linear curves are used for linear interpolation
// between data points. They are implemented by the
// PiecewiseLinearCurve class. It has two constructors,
// similar to the constructors for the PiecewiseLinearCurve
// class. These constructors create the linear interpolating
// curve between the data points.

// The first constructor takes two double arrays as parameters.
// These contain the x and y values of the data points:
let piecewiseLinear1 = PiecewiseLinearCurve(xValues, yValues)

// The second constructor only takes one parameter: an array of
// Point structures that represent the data point.
let line2 = PiecewiseLinearCurve(dataPoints)

//
// Curve Parameters
//

// Piecewise linear curves have 2n parameters, where n is the number of
// data points. The first n parameters are the x-values. The next
// n parameters are the y-values.

printfn "piecewiseLinear1.Parameters.Count = %d" piecewiseLinear1.Parameters.Count
// Parameters can easily be retrieved:
printfn "piecewiseLinear1.Parameters.[0] = %A" piecewiseLinear1.Parameters.[0]
// Parameters can also be set:
piecewiseLinear1.Parameters.[0] <- 1.0

//
// Curve Methods
//

// The ValueAt method returns the y value of the
// curve at the specified x value:
printfn "piecewiseLinear1.ValueAt(2.4) = %A" (piecewiseLinear1.ValueAt(2.4))

// The SlopeAt method returns the slope of the curve
// a the specified x value:
printfn "piecewiseLinear1.SlopeAt(2.4) = %A" (piecewiseLinear1.SlopeAt(2.4))
// The slope at the data points is Double.NaN if the slope of the line
// is different on either side of the data point:
printfn "piecewiseLinear1.SlopeAt(2) = %A" (piecewiseLinear1.SlopeAt(2.0))

// Piecewise line curves do not have a defined derivative.
// The GetDerivative method returns a GeneralCurve:
let derivative2 = piecewiseLinear1.GetDerivative()
printfn "Type of derivative: %s" (derivative2.GetType().ToString())
printfn "derivative(2.4) = %A" (derivative2.ValueAt(2.4))

// You can get a Line that is the tangent to a curve
// at a specified x value using the TangentAt method:
let tangent2 = piecewiseLinear1.TangentAt(2.4)
printfn "Slope of tangent line at 2.4 = %A" tangent2.Parameters.[1]

// The integral of a piecewise line curve can be calculated exactly.
printfn "Integral of piecewiseLinear1 between 1.4 and 4.6 = %A"
    (piecewiseLinear1.Integral(1.4, 4.6))
