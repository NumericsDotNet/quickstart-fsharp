//=====================================================================
//
//  File: numerical-differentiation.fs
//
//---------------------------------------------------------------------
//
//  This file is part of the Numerics.NET Code Samples.
//
//  Copyright (c) 2004-2025 ExoAnalytics Inc. All rights reserved.
//
//=====================================================================

module NumericalDifferentiation

// Illustrates numerical differentiation using the
// FunctionMath class in the Numerics.NET
// namespace of Numerics.NET.

#light

open System

open Numerics.NET

// The license is verified at runtime. We're using a 30 day trial key here.
// For more information, see:
//     https://numerics.net/trial-key
let licensed = Numerics.NET.License.Verify("your-trial-key-here")

// Numerical differentiation is a fairly simple
// procedure. Its accuracy is inherently limited
// because of unavoidable round-off error.
//
// All calculations are performed by static methods
// of the FunctionMath class. All methods are extension
// methods, so they can be applied to the delegates
// directly.

//
// Standard numerical differentiation.
//

// Central differences are the standard way of
// approximating the result of a function.
// For this to work, it must be possible to
// evaluate the target function on both sides of
// the point where the numerical result is
// requested.

// The function must be provided as a
// Func<double, double>. For more information about
// this delegate, see the FunctionDelegates
// QuickStart Sample.
let fCentral = Func<_,_> Math.Cos

printfn "Central differences:"
// The actual calculation is performed by the
// CentralDerivative method.
let result = fCentral.CentralDerivative(1.0)
printfn "  Result = %A" result
printfn "  Actual = %A" (-Math.Sin(1.0))
// This method is overloaded. It has an optional
// out parameter that returns an estimate for the
// error in the result. In F#, we can get both
// value and error in a tuple:
let _, estimatedError = fCentral.CentralDerivative(1.0)
printfn "Estimated error = %A" estimatedError

//
// Forward and backward differences.
//

// Some functions are not defined everywhere.
// If the result is required on a boundary
// of the domain where it is defined, the central
// differences method breaks down. This also happens
// if the function has a discontinuity close to the
// differentiation point.
//
// In these cases, either forward or backward
// differences may be used instead.
//
// Here is an example of a function that may require
// forward differences. It is undefined for
// x < -2:
let fForward = Func<_,_> (fun x -> (pown (x+2.0) 2) * sqrt(x+2.0))

// Calculating the derivative using central
// differences returns NaN (Not a Number):
let result2, estimatedError2 = fForward.CentralDerivative(-2.0)
printfn "Using central differences may not work:"
printfn "  Derivative = %A" result2
printfn "  Estimated error = %A" estimatedError2

// Using the ForwardDerivative method does work:
printfn "Using forward differences instead:"
let result3, estimatedError3 = fForward.ForwardDerivative(-2.0)
printfn "  Derivative = %A" result3
printfn "  Estimated error = %A" estimatedError3

// The FBackward function at the end of this file
// is an example of a function that requires
// backward differences for differentiation at
// x = 0.
let fBackward = Func<_,_> (fun x -> if x > 0.0 then 1.0 else sin(x))
printfn "Using backward differences:"
let result4, estimatedError4 = fBackward.BackwardDerivative(0.0)
printfn "  Derivative = %A" result4
printfn "  Estimated error = %A" estimatedError4

//
// Derivative function
//

// In some cases, it may be useful to have the
// derivative of a function in the form of a
// Func<double, double>, so it can be passed as
// an argument to other methods. This is very
// easy to do.
printfn "Using delegates:"

// For central differences:
let dfCentral = fCentral.GetNumericalDifferentiator().Invoke
printfn "Central: f'(1) = %A" (dfCentral 1.0)

// For forward differences:
let dfForward = fForward.GetForwardDifferentiator().Invoke
printfn "Forward: f'(-2) = %A" (dfForward -2.0)

// For backward differences:
let dfBackward = fBackward.GetBackwardDifferentiator().Invoke
printfn "Backward: f'(0) = %A" (dfBackward 0.0)
