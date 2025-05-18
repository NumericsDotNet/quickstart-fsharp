//=====================================================================
//
//  File: vector-operations.fs
//
//---------------------------------------------------------------------
//
//  This file is part of the Numerics.NET Code Samples.
//
//  Copyright (c) 2004-2025 ExoAnalytics Inc. All rights reserved.
//
//=====================================================================

module VectorOperations

#light

open System

open Numerics.NET

// The license is verified at runtime. We're using a 30 day trial key here.
// For more information, see:
//     https://numerics.net/trial-key
let licensed = Numerics.NET.License.Verify("your-trial-key-here")

// Illustrates operations on Vector objects from the
// Numerics.NET.LinearAlgebra namespace of Numerics.NET.

// For details on the basic workings of Vector
// objects, including constructing, copying and
// cloning vectors, see the BasicVectors QuickStart
// Sample.
//
// Let's create some vectors to work with.
let v1 = Vector.Create(1.0, 2.0, 3.0, 4.0, 5.0)
let v2 = Vector.Create(1.0, -2.0, 3.0, -4.0, 5.0)
let v3 = Vector.Create(3.0, 2.0, 1.0, 0.0, -1.0)
// This one will hold results.

//
// Vector Arithmetic
//
// The Vector class defines overloaded addition,
// subtraction, and multiplication and division
// operators:
printfn "v1 = %O" v1
printfn "v2 = %O" v2
printfn "Basic arithmetic:"
// There is a bug in F#'s definition of the negation operator:
printfn "-v1 = %O" (-(v1:>Vector<float>))
printfn "v1 + v2 = %O" (v1 + v1)
printfn "v1 - v2 = %O" (v1 - v2)
// Vectors can only be multiplied or divided by
// a real number. For dot products, see the
// DotProduct method.
printfn "5 * v1 = %O" (5.0 * v1)
printfn "v1 * 5 = %O" (v1 * 5.0)
printfn "v1 / 5 = %O" (v1 / 5.0)
// In F#, we also have elementwise multiplication and division:
printfn "v1 .* v2 = %O" (v1 .* v2)
printfn "v1 ./ v2 = %O" (v1 ./ v2)

// For each operator, there is a corresponding
// static method. For example: v1 + v2 is
// equivalent to:
let v4 = Vector.Add(v1, v2)
// v1 - v2 corresponds to:
let v5 = Vector.Subtract(v1, v2)
// You can also apply these methods to Vector objects.
// In this case, they change the first operand.
printfn "v3 = %O" v3
printfn "v3 + v1 = %O" (v3.AddInPlace(v1))
printfn "v3 = %O" v3

// This method is overloaded so you can directly
// add a scaled vector.
// This is a 'fluent' API: It returns a reference
// to the instance (v3 in this case). We ignore it here.
v3.AddScaledInPlace(-2.0, v1) |> ignore
printfn "v3-2v1 -> v3 = %O" v3
// Corresponding to the * operator, we have the
// MultiplyInPlace method:
v3.MultiplyInPlace(3.0) |> ignore
printfn "3v3 -> v3 = %O" v3
printfn ""

//
// Norms, dot products, etc.
//
printfn "Norms, dot products, etc."
// The dot product is calculated in one of two ways:
// Using the static DotProduct method:
let mutable a = Vector.DotProduct(v1, v2)
// Or using the DotProduct method on one of the two
// vectors:
let b = v1.DotProduct(v2)
printfn "DotProduct(v1, v2) = %.4f = %.4f" a b
// The Norm method returns the standard two norm
// of a Vector:
printfn "|v1| = %O" (v1.Norm())
// .the Norm method is overloaded to allow other norms,
// including the one-norm:
printfn "one norm(v1) = %O" (v1.Norm(1))
// ...the positive infinity norm, which returns the
// absolute value of the largest component:
printfn "+inf norm(v1) = %O" (v1.Norm(infinity))
// ...the negative infinity norm, which returns the
// absolute value of the smallest component:
printfn "-inf norm(v1) = %O" (v1.Norm(-infinity))
// ...and even the zero norm, which simply returns
// the number of components of the vector:
printfn "zero-norm(v1) = %O" (v1.Norm(0))
// You can get the square of the two norm with the
// NormSquared method.
printfn "|v1|^2 = %O" (v1.NormSquared())
printfn ""

//
// Largest and smallest elements
//
// The Vector class defines methods to find the
// largest or smallest element or its index.
printfn "v2 = %O" v2
// The Max method returns the largest element:
printfn "Max(v2) = %.4f" (v2.Max())
// The AbsoluteMax method returns the element with
// the largest absolute value.
printfn "Absolute max(v2) = %.4f" (v2.AbsoluteMax())
// The Min method returns the smallest element:
printfn "Min(v2) = %.4f" (v2.Min())
// The AbsoluteMin method returns the element with
// the smallest absolute value.
printfn "Absolute min(v2) = %.4f" (v2.AbsoluteMin())
// Each of these methods has an equivalent method
// that returns the zero-based index of the element
// instead of its value, for example:
printfn "Index of Min(v2) = %d" (v2.MinIndex())

// Finally, the MapInPlace method lets you apply
// an arbitrary function to each element of the
// vector:
v1.MapInPlace(Func<_,_> Math.Exp) |> ignore
printfn "Exp(v1) = %O" v1
// There is also a static Map method that returns a
// new object:
let v6 = Vector.Map(Func<_,_> Math.Exp, v2)
