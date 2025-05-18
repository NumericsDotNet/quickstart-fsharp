//=====================================================================
//
//  File: linear-curve-fitting.fs
//
//---------------------------------------------------------------------
//
//  This file is part of the Numerics.NET Code Samples.
//
//  Copyright (c) 2004-2025 ExoAnalytics Inc. All rights reserved.
//
//=====================================================================

module LinearCurveFitting

// Illustrates least squares curve fitting of polynomials and
// other linear functions using the LinearCurveFitter class in the
// Numerics.NET.Curves namespace of Numerics.NET.

#light

open System

open Numerics.NET
// The curve fitting classes reside in the
// Numerics.NET.Curves namespace.
open Numerics.NET.Curves

// The license is verified at runtime. We're using a 30 day trial key here.
// For more information, see:
//     https://numerics.net/trial-key
let licensed = Numerics.NET.License.Verify("your-trial-key-here")

// This QuickStart sample illustrates linear least squares
// curve fitting using polynomials and linear combinations
// of arbitrary functions.

// Linear least squares fits are calculated using the
// LinearCurveFitter class:
let fitter = LinearCurveFitter()

// We use data from the National Institute for Standards
// and Technology's Statistical Reference Datasets library
// at http://www.itl.nist.gov/div898/strd/.

// Note that, due to round-off error, the results here will not be exactly
// the same as the NIST results, which were calculated using 500 digits
// of precision!

// We use the 'Pontius' dataset, which contains measurement data
// from the calibration of load cells. The independent variable is the load.
// The dependent variable is the deflection.
let deflectionData =
    Vector.Create(0.11019, 0.21956,
        0.32949, 0.43899, 0.54803, 0.65694, 0.76562, 0.87487, 0.98292,
        1.09146, 1.20001, 1.30822, 1.41599, 1.52399, 1.63194, 1.73947,
        1.84646, 1.95392, 2.06128, 2.16844, 0.11052, 0.22018, 0.32939,
        0.43886, 0.54798, 0.65739, 0.76596, 0.87474, 0.98300, 1.09150,
        1.20004, 1.30818, 1.41613, 1.52408, 1.63159, 1.73965, 1.84696,
        1.95445, 2.06177, 2.16829)
let loadData =
    Vector.Create(
        150.0, 300.0, 450.0, 600.0, 750.0, 900.0,
        1050.0, 1200.0, 1350.0, 1500.0, 1650.0, 1800.0,
        1950.0, 2100.0, 2250.0, 2400.0, 2550.0, 2700.0,
        2850.0, 3000.0, 150.0, 300.0, 450.0, 600.0,
        750.0, 900.0, 1050.0, 1200.0, 1350.0, 1500.0,
        1650.0, 1800.0, 1950.0, 2100.0, 2250.0, 2400.0,
        2550.0, 2700.0, 2850.0, 3000.0)

// You must supply the curve whose parameters will be
// fit to the data. The curve must inherit from LinearCombination.
//
// Here, we use a quadratic polynomial:
fitter.Curve <- Polynomial(2)

// The X values go into the XValues property:
fitter.XValues <- loadData
// ...and Y values go into the YValues property:
fitter.YValues <- deflectionData

// The Fit method performs the actual calculation:
let result = fitter.Fit()

// A Vector containing the parameters of the best fit
// can be obtained through the
// BestFitParameters property.
let solution = fitter.BestFitParameters
// The standard deviations associated with each parameter
// are available through the GetStandardDeviations method.
let s = fitter.GetStandardDeviations()

printfn "Calibration of load cells"
printfn "    deflection = c1 + c2*load + c3*load^2 "
printfn "Solution:"
printfn "c1: %20.10e %20.10e" solution.[0] s.[0]
printfn "c2: %20.10e %20.10e" solution.[1] s.[1]
printfn "c3: %20.10e %20.10e" solution.[2] s.[2]

printfn "Residual sum of squares: %A" (fitter.Residuals.Norm())

// Now let's redo the same operation, but with observations weighted
// by 1/Y^2. To do this, we set the WeightFunction property.
// The WeightFunctions class defines a set of ready-to-use weight functions.
fitter.WeightFunction <- WeightFunctions.OneOverYSquared
// Refit the curve:
let result2 = fitter.Fit()
let solution2 = fitter.BestFitParameters
let s2 = fitter.GetStandardDeviations()

// The solution is slightly different:
printfn "Solution (weighted observations):"
printfn "c1: %20.10e %20.10e" solution2.[0] s2.[0]
printfn "c2: %20.10e %20.10e" solution2.[1] s2.[1]
printfn "c3: %20.10e %20.10e" solution2.[2] s2.[2]
printfn ""

//
// Fitting combinations of arbitrary functions
//

// The following example estimates the two parameters, c1 and c2
// in the theoretical model for conductance:
//     k(T) = 1 / (c1 / T + c2 * T*T)

let temperature =
    Vector.Create(12.2900, 13.7500, 14.8200,
        16.1200, 18.0400, 18.6700, 20.5200, 22.6800, 25.1500,
        27.7200, 30.2400, 33.2100, 36.4800, 39.8600, 50.4000)
let conductance =
    Vector.Create(25.3500, 27.8800, 29.9300,
        30.4200, 31.0000, 31.9600, 32.4700, 30.3300, 31.1400,
        27.4600, 23.2900, 20.7200, 17.2400, 14.7100,  9.5000)

// First, we transform the dependent variable:
let y = Vector.Reciprocal(conductance)

// y is a linear combination of basis functions 1/T and T*T.
// Create a function basis object:
let basis = GeneralFunctionBasis((fun x -> 1.0 / x), (fun x -> x*x))

// Create a LinearCombination curve using this function basis:
let curve = LinearCombination(basis)

// Set the curve fitter properties:
fitter.Curve <- curve
fitter.XValues <- temperature
fitter.YValues <- y
// Reset the weights
fitter.WeightFunction <- null
fitter.WeightVector <- null

// Now compute the solution:
let result3 = fitter.Fit()
let solution3 = fitter.BestFitParameters
let s3 = fitter.GetStandardDeviations()

// Print the results
printfn "Conductance of copper: k(T) = 1 / (c1/T + c2*T^2)"
printfn "Solution:"
printfn "c1: %20.10e %20.10e" solution3.[0] s3.[0]
printfn "c2: %20.10e %20.10e" solution3.[1] s3.[1]

printfn "Residual sum of squares: %A" (fitter.Residuals.Norm())
