//=====================================================================
//
//  File: tensor-operations.fs
//
//---------------------------------------------------------------------
//
//  This file is part of the Numerics.NET Code Samples.
//
//  Copyright (c) 2004-2025 ExoAnalytics Inc. All rights reserved.
//
//=====================================================================

module TensorOperations

// Illustrates how to perform operations on tensors.

open System

// Tensor classes reside in the Numerics.NET.Tensors
// namespace.
open Numerics.NET
open Numerics.NET.Tensors
open Numerics.NET.FSharp

// The license is verified at runtime. We're using
// a 30 day trial key here. For more information, see
//     https://numerics.net/trial-key
let licensed = Numerics.NET.License.Verify("your-trial-key-here")

// For details on the basic workings of Tensors
// objects, including constructing, copying and
// cloning tensors, see the BasicTensors QuickStart
// Sample.
//

// Let's create some tensors to work with.

let t1 = Tensor.CreateRange(6.0).Reshape(3, 2)
Console.WriteLine($"t1 = {t1}")
// [[ 0, 1 ],
//  [ 2, 3 ],
//  [ 4, 5 ]]

let t2 = Tensor.CreateRange(6.0).PowInPlace(2).Reshape(3, 2)
Console.WriteLine($"t2 = {t2}")
// [[ 0,  1 ],
//  [ 4,  9 ],
//  [16, 25 ]]

//
// Tensor arithmetic
//

// The Tensor<T> class defines operator overloads for
// most operations, including addition, subtraction,
// and multiplication.

// Addition:
Console.WriteLine($"Tensor arithmetic:")
Console.WriteLine($"t1 + t2 = {t1 + t2}")
// Subtraction:
Console.WriteLine($"t1 - t2 = {t1 - t2}")
// Multiplication and division are element-wise:
Console.WriteLine($"t1 * t2 = {t1 * t2}")
Console.WriteLine($"t2 / t1 = {t2 / t1}")

// For each of these, equivalent static methods exist in the Tensor class
// that offer more options. Here, we add t1 and t2 into an existing tensor:
let t = Tensor.Create(t1.Shape)
Tensor.Add(t1, t2, result=t) |> ignore
Console.WriteLine($"t1 + t2 = {t}")

// You can pass in a mask to limit where the operation is performed.
// Other elements are left unchanged:
Tensor.Add(t1, t2, result=t, mask=Tensor.EqualTo(t1 % 2.0, 0.0)) |> ignore
Console.WriteLine($"t1 + t2 = {t}")

// There's an InPlace method on the tensor itself:
t1.AddInPlace(t2) |> ignore
Console.WriteLine($"t1 += t2 = {t1}")
t1.SubtractInPlace(t2) |> ignore

Console.WriteLine()

//
// Other functions
//

// The static Tensor class contains methods for computing
// mathematical functions for all elements of a tensor.
// For example:
Console.WriteLine($"sin(t1) = {Tensor.Sin(t1)}")

//
// Broadcasting
//

// Broadcasting is a mechanism for performing operations on
// tensors of different shapes. Dimensions with only one element
// are expanded to match the number of elements along that dimension
// in other operands.
let tRow = Tensor.CreateRange(2.0).Reshape(1, 2) * 10.0
let tColumn = Tensor.CreateRange(3.0).Reshape(3, 1)
Console.WriteLine($"tRow = {tRow}")
Console.WriteLine($"tColumn = {tColumn}")

// The sum of the row and column vector is a 2D tensor:
Console.WriteLine($"tRow + tColumn = {tRow + tColumn}")

// When tensors have different ranks, the dimensions are aligned
// from the end. In other words: dimensions of length 1 are inserted
// to make the ranks match. The following works because tRow,
// with shape (2) is reshaped to (1, 2) and then broadcast to (3, 2):
let tRow2 = Tensor.CreateRange(2.0) * 10.0
Console.WriteLine($"tRow2 + tColumn = {tRow2 + tColumn}")

//
// Manipulating tensor shapes
//

// Sometimes it's useful to manually insert dimensions of length 1
// in order to line up the dimensions for broadcasting. This is done
// with the InsertAxis method:
let tRow3 = tRow2.InsertAxis(0); // tRow3 has shape (1, 2)

// Other times, axes have to be rearranged. There are several methods
// that perform this operation, such as Transpose, SwapAxes,
// and MoveAxes.
//
// Conditional operations
//

// Adding the optional 'where' argument performs the operation only
// when the corresponding element in the where tensor is true.
t1.AddInPlace(t2, mask=Tensor.EqualTo(t1 % 2.0, 1.0)) |> ignore
Console.WriteLine($"Add t2 to t1 where t1 is odd = {t1}")

// The mask tensor is also broadcast:
Tensor.Add(t1, 100, t, mask=Tensor.EqualTo(tColumn % 2.0, 1.0)) |> ignore
Console.WriteLine($"Add t2 to t1 where tColumn is odd = {t}")

//
// Reduction operations
//

// Reduction operations are operations that reduce the number of
// dimensions in a tensor. For example, the Sum method sums all
// elements in a tensor.

// Reduction operations come in two forms.

// The first form is a reduction of the entire tensor to a scalar:
let t3 = Tensor.CreateRange(6.0).Reshape(3, 2)
// [[ 0, 1 ],
//  [ 2, 3 ],
//  [ 4, 5 ]]
let sum = t3.Sum()
// sum = 15

// The second form is a reduction along one or more axes:
let sum1 = t3.Sum(axis=1)
Console.WriteLine($"sum = {sum1}")
// [ 6, 9 ]

// An optional argument, keepDimensions, can be used to keep the
// reduced dimensions in the result tensor. This is useful when
// you want to broadcast the result back to the original shape:
let mean = Tensor.Mean(t3, axis=0, keepDimensions=true)
// [[ 0.5 ],
//  [ 2.5 ],
//  [ 4.5 ]]
let t3Centered = t3 - mean
// [[ -0.5 0.5 ],
//  [ -0.5 0.5 ],
//  [ -0.5 0.5 ]]
Console.WriteLine($"t3Centered = {t3Centered}")

//
// Tensor views
//

// Sometimes, returning a new tensor for an operation is extremely inefficient.
// For such scenarios, a tensor view is returned. This is a tensor that shares
// the underlying storage with the original tensor. The value of an element
// is only computed when needed.

// Example are RealPart and ImaginaryPart, which operate on tensors of complex numbers:
let tc = Tensor.CreateFromFunction(3, fun i -> Complex<int>(i, 2 * i + 1))
// [ 0 + 1i, 1 + 3i, 2 + 5i ]
let tcReal = tc.RealPart()
// [ 0, 1, 2 ]
let tcImag = tc.ImaginaryPart()
// [ 1, 3, 5 ]

// The tensor view is updated when the original tensor is changed:
tc.SetValue(Complex<int>(8, 9), 1)
Console.WriteLine($"{tc.GetValue(1)} == ({tcReal.GetValue(1)}, {tcImag.GetValue(1)})")
// Likewise, when you update a view, the original tensor is updated as well:
tcReal.SetValue(6, 1)
// tc[1] = (6, 9)

// You can even do fun things like swap the real and imaginary parts:
Console.WriteLine($"Before swap: {tc}")
Tensor.Swap(tcReal, tcImag)
// tc -> [ 1 + 0i, 9 + 6i, 5 + 2i ]
Console.WriteLine($"After swap:  {tc}")
