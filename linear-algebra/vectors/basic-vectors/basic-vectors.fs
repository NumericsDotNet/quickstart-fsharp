//=====================================================================
//
//  File: basic-vectors.fs
//
//---------------------------------------------------------------------
//
//  This file is part of the Numerics.NET Code Samples.
//
//  Copyright (c) 2004-2025 ExoAnalytics Inc. All rights reserved.
//
//=====================================================================

module BasicVectors

/// Illustrates the use of the Vector class in the Numerics.NET
/// namespace of Numerics.NET.

#light

open System

// The Vector class resides in the Numerics.NET.LinearAlgebra
// namespace.
open Numerics.NET

// The license is verified at runtime. We're using a 30 day trial key here.
// For more information, see:
//     https://numerics.net/trial-key
let licensed = Numerics.NET.License.Verify("your-trial-key-here")

//
// Constructing vectors
//

// Option #1: specify the number of elements. All
// elements are set to 0.
let v1 = Vector.Create<double>(5)
// Option #2: specify the elements:
let v2 = Vector.Create(1.0, 2.0, 3.0, 4.0, 5.0)
// Option #3: specify the elements as a double array.
// By default, the elements are copied to a storage
// area internal to the Vector.
let elements = [| 1.0; 2.0; 3.0; 4.0; 5.0 |]
let v3 = Vector.Create(elements)
// Option #4: same as above, but specify whether
// to copy the elements, or use the array as
// internal storage.
let v4 = Vector.CreateFromArray(elements, true)
// Changing a value in the original vector changes
// the resulting vector.
printfn "v4 = %O" (v4.ToString("F4"))
elements.[3] <- 1.0
printfn "v4 = %O" (v4.ToString("F4"))
// Option #5: same as #4, but specify the length of
// the Vector. The remaining elements in the element
// array will be ignored.
let v5 = Vector.CreateFromArray(4, elements, true, ArrayMutability.Immutable)

//
// Vector properties
//

// The Length property gives the number of elements
// of a Vector:
printfn "v1.Length = %d" v1.Length
// The ToArray method returns a double array
// that contains the elements of the vector.
// This is always a copy:
let elements2 = v2.ToArray()
printfn "Effect of shared storage:"
printfn "v2.[2] = %A" v2.[2]
elements2.[2] <- 1.0
printfn "v2.[2] = %A" v2.[2]

//
// Accessing vector elements
//

// The Vector class defines an indexer property that
// takes a zero-based index.
printfn "Assigning with private storage:"
printfn "v1.[2] = %A" v1.[2]
// You can assign to this property:
v1.[2] <- 7.0
printfn "v1.[2] = %A" v1.[2]
// The vectors v4 and v5 had the reuse parameter in the
// constructor set to true. As a result, they share
// their element storage. Changing one vector also
// changes the other:
printfn "Assigning with shared storage:"
printfn "v5.[1] = %A" v5.[1]
v4.[1] <- 7.0
printfn "v5.[1] = %A" v5.[1]

// The SetValue method sets all elements of a vector
// to the same value:
v1.SetValue(1.0) |> ignore
printfn "v1 = %O" (v1.ToString("F4"))
// The SetToZero method sets all elements to 0:
v1.SetToZero() |> ignore
printfn "v1 = %O" (v1.ToString("F4"))

//
// Copying and cloning vectors
//

// A shallow copy of a vector constructs a vector
// that shares the element storage with the original.
// This is done using the ShallowCopy method:
printfn "Shallow copy vs. clone:"
let v7 = v2.ShallowCopy()
// The clone method creates a full copy.
let v8 = v2.Clone()
// When we change v2, v7 changes, but v8 is left
// unchanged.
printfn "v2.[1] = %A" v2.[1]
v2.[1] <- -2.0
printfn "v7.[1] = %A" v7.[1]
printfn "v8.[1] = %A" v8.[1]
// We can give a vector its own element storage
// by calling the CloneData method:
printfn "CloneData:"
v7.CloneData()
// Now, changing the original v2 no longer changes v7:
v2.[1] <- 4.0
printfn "v7.[1] = %A" v7.[1]
// The CopyTo method copies the elements of a Vector
// to a variety of destinations. It may be a Vector:
printfn "CopyTo:"
// The CopyTo method returns its argument, so it can be
// used in expressions. We ignore the return value here.
v5.CopyTo(v1) |> ignore
printfn "v5 = %O" (v5.ToString("F4"))
printfn "v1 = %O" (v1.ToString("F4"))
// You can specify an index where to start copying
// in the destination vector:
v5.CopyTo(v1, 1) |> ignore
printfn "v1 = %O" (v1.ToString("F4"))
// Or you can copy to a double array:
v5.CopyTo(elements)
