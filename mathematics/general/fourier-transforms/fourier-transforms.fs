//=====================================================================
//
//  File: fourier-transforms.fs
//
//---------------------------------------------------------------------
//
//  This file is part of the Numerics.NET Code Samples.
//
//  Copyright (c) 2004-2025 ExoAnalytics Inc. All rights reserved.
//
//=====================================================================

module FourierTransforms

// Illustrates the use of the FftProvider and Fft classes for computing
// the Fourier transform of real and complex signals.

#light

open System

// We'll need real and complex vectors...
open Numerics.NET
// The FFT classes reside in the Numerics.NET.SignalProcessing
// namespace.
open Numerics.NET.SignalProcessing

// The license is verified at runtime. We're using a 30 day trial key here.
// For more information, see:
//     https://numerics.net/trial-key
let licensed = Numerics.NET.License.Verify("your-trial-key-here")

// This QuickStart sample shows how to compute the Fouier
// transform of real and complex signals.

// Some vectors to play with:
let r1 = Vector.CreateFromFunction(1000, fun i -> 1.0 / (float (1+i)))
let c1 = Vector.CreateFromFunction(1000,
            fun i -> Complex<float>(sin(0.03 * float i), cos(0.07 * float i)))

let r2 = Vector.Create(1.0, 2.0, 3.0, 4.0)
let c2 = Vector.Create(
            Complex<float>(1.0, 2.0),
            Complex<float>(3.0, 4.0),
            Complex<float>(5.0, 6.0),
            Complex<float>(7.0, 8.0))

//
// One-time FFT's
//

// The Vector and ComplexVector classes have static methods to compute FFT's:
let c3 = Vector.FourierTransform(r2)
let r3 = Vector.InverseFourierTransform(c3)
printfn "fft(r2) = %s" (c3.ToString("F3"))
printfn "ifft(fft(r2)) = %s" (r3.ToString("F3"))
// The ComplexConjugateSignalVector type represents a complex vector
// that is the Fourier transform of a real signal.
// It enforces certain symmetry properties:
printfn "c3.[i] == conj(c3.[N-i]): %A == conj(%A)" c3.[1] c3.[3]

//
// FFT Providers
//

// FFT's require a fair bit of pre-computation. Using the FftProvider class,
// you can get an Fft object that caches these computations.

// Here, we create an FFT implementation for a real signal:
let realFft = Fft<float>.CreateReal(r1.Length)
// For a complex to complex transform:
let complexFft = Fft<float>.CreateComplex(c1.Length)

// You can set the scale factor for the forward transform.
// The default is 1/N.
realFft.ForwardScaleFactor <- 1.0 / Math.Sqrt(float c1.Length)
// and the backward transform, with default 1:
realFft.BackwardScaleFactor <- realFft.ForwardScaleFactor

// The ForwardTransform method performs a forward transform:
let c4 = realFft.ForwardTransform(r1)
printfn "First 5 terms of fft(r1):"
for i in 0..4 do
    printfn "   %d: %A" i c4.[i]
let c5 = complexFft.ForwardTransform(c1)
printfn "First 5 terms of fft(c1):"
for i in 0..4 do
    printfn "   %d: %A" i c5.[i]

// ForwardTransform has many overloads for real to complex and
// complex to complex transforms.

// A one-sided transform returns only the first half of the FFT of
// a real signal. The rest can be deduced from the symmetry properties.
// Here's how to compute a one-sided FFT:
let c6 = Vector.Create<Complex<float>>(r1.Length / 2 + 1)
realFft.ForwardTransform(r1, c6, RealFftFormat.OneSided)

// The BackwardTransform method has a similar set of overloads:
let r4 = Vector.Create<float>(r1.Length)
realFft.BackwardTransform(c6, r4, RealFftFormat.OneSided)

// The two FFT implementations are automatically disposed.

//
// 2D transforms
//

// 2D transforms are handled in a completely analogous way.
let m = Matrix.CreateFromFunction(36, 56,
    fun i j -> exp(-0.1 * float i) * Math.Sin(0.01 * (float (i * i + j * j - i * j))))
let mFft = Matrix.Create(m.RowCount, m.ColumnCount)

let fft2 = Fft2D.CreateReal(m.RowCount, m.ColumnCount)
fft2.ForwardTransform(m, mFft)

printfn "First few terms of fft(m):"
for i in 0..3 do
    for j in 0..3 do
        if j > 0 then
            printf ", "
        printf "%s" (mFft.[i, j].ToString("F4"))
    printfn ""

// and the backward transform:
fft2.BackwardTransform(mFft, m)

// Dispose is called automatically.
