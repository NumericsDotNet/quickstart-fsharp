//=====================================================================
//
//  File: complex-numbers.fs
//
//---------------------------------------------------------------------
//
//  This file is part of the Numerics.NET Code Samples.
//
//  Copyright (c) 2004-2025 ExoAnalytics Inc. All rights reserved.
//
//=====================================================================

module ComplexNumbers

// Illustrates the use of the Complex<float> class in
// Numerics.NET.

#light

open System

// The Complex<T> class resides in the Numerics.NET namespace.
open Numerics.NET

// The license is verified at runtime. We're using a 30 day trial key here.
// For more information, see:
//     https://numerics.net/trial-key
let licensed = Numerics.NET.License.Verify("your-trial-key-here")

//
// Complex<float> constants:
//
printfn "Complex<float>.Zero = %A" Complex<float>.Zero
printfn "Complex<float>.One = %A" Complex<float>.One
// The imaginary unit is given by Complex<float>.I:
printfn "Complex<float>.I = %A" Complex<float>.I
printfn ""

//
// Construct some complex numbers
//
// Real and imaginary parts:
//   a = 2 + 4i
let a = Complex<float>(2.0, 4.0)
printfn "a = %A" a
//   b = 1 - 3i
let b = Complex<float>(1.0, -3.0)
printfn "b = %A" b
// From a real number:
//   c = -3 + 0i
let c = Complex<float>(-3.0)
printfn "c = %A" c
// Polar form:
//   d = 2 (cos(Pi/3) + i sin(Pi/3))
let d = Complex<float>.FromPolar(2.0, Constants.Pi/3.0)
// To print this number, use the overloaded ToString
// method and specify the format let for the real
// and imaginary parts:
printfn "d = %A" d
printfn ""

//
// Parts of complex numbers
//
printfn "Parts of a = %A:" a
printfn "Real part of a = %A" a.Re
printfn "Imaginary part of a = %A" a.Im
printfn "Modulus of a = %A" a.Magnitude
printfn "Argument of a = %A" a.Phase
printfn ""

//
// Basic arithmetic:
//
printfn "Basic arithmetic:"
printfn "-a = %A" (-a)
printfn "a + b = %A" (a + b)
printfn "a - b = %A" (a - b)
printfn "a * b = %A" (a * b)
printfn "a / b = %A" (a / b)
// The conjugate of a complex number corresponds to
// the "Conjugate" method:
printfn "Conjugate(a) = ~a = %A" (a.Conjugate())
printfn ""

//
// Functions of complex numbers
//
// Most of these have corresponding static methods
// in the System.Math class, but are extended to complex
// arguments.
printfn "Functions of complex numbers:"

// Exponentials and logarithms
printfn "Exponentials and logarithms:"

printfn "Exp(a) = %A" (Complex<float>.Exp(a))
printfn "Log(a) = %A" (Complex<float>.Log(a))
printfn "Log10(a) = %A" (Complex<float>.Log10(a))
// You can get a point on the unit circle by calling
// the ExpI method:
printfn "ExpI(2*Pi/3) = %A" (Complex<float>.ExpI(2.0*Constants.Pi/3.0))
// The RootOfUnity method also returns points on the
// unit circle. The above is equivalent to the second
// root of z^6 = 1:
printfn "RootOfUnity(6, 2) = %A" (Complex<float>.RootOfUnity(6, 2))

// The Pow method is overloaded for integer, double,
// and complex argument. We can use the exponentiation operator:
printfn "Pow(a,3) = %A" (a ** 3)
printfn "Pow(a,1.5) = %A" (a ** 1.5)
printfn "Pow(a,b) = %A" (a ** b)

// Square root
printfn "Sqrt(a) = %A" (Complex<float>.Sqrt(a))
// The Sqrt method is overloaded. Here's the square
// root of a negative double:
printfn "Sqrt(-4) = %A" (Complex<float>.Sqrt(-4.0))
printfn ""

//
// Trigonometric functions:
//
printfn "Trigonometric function:"
printfn "Sin(a) = %A" (Complex<float>.Sin(a))
printfn "Cos(a) = %A" (Complex<float>.Cos(a))
printfn "Tan(a) = %A" (Complex<float>.Tan(a))

// Inverse Trigonometric functions:
printfn "Asin(a) = %A" (Complex<float>.Asin(a))
printfn "Acos(a) = %A" (Complex<float>.Acos(a))
printfn "Atan(a) = %A" (Complex<float>.Atan(a))

// Asin and Acos have overloads with real argument
// not restricted to [-1,1]:
printfn "Asin(2) = %A" (Complex<float>.Asin(2.0))
printfn "Acos(2) = %A" (Complex<float>.Acos(2.0))
printfn ""

//
// Hyperbolic and inverse hyperbolic functions:
//
printfn "Hyperbolic function:"
printfn "Sinh(a) = %A" (Complex<float>.Sinh(a))
printfn "Cosh(a) = %A" (Complex<float>.Cosh(a))
printfn "Tanh(a) = %A" (Complex<float>.Tanh(a))
printfn "Asinh(a) = %A" (Complex<float>.Asinh(a))
printfn "Acosh(a) = %A" (Complex<float>.Acosh(a))
printfn "Atanh(a) = %A" (Complex<float>.Atanh(a))
printfn ""
