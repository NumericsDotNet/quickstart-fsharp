//=====================================================================
//
//  File: nonlinear-curve-fitting.fs
//
//---------------------------------------------------------------------
//
//  This file is part of the Numerics.NET Code Samples.
//
//  Copyright (c) 2004-2025 ExoAnalytics Inc. All rights reserved.
//
//=====================================================================

module NonlinearCurveFitting

// Illustrates nonlinear least squares curve fitting using the
// NonlinearCurveFitter class in the
// Numerics.NET.Curves namespace of Numerics.NET.

#light

open System

open Numerics.NET
// The curve fitting classes reside in the
// Numerics.NET.Curves namespace.
open Numerics.NET.Curves
// The predefined non-linear curves reside in the
// Numerics.NET.Curves namespace.
open Numerics.NET.Curves.Nonlinear
// Vectors reside in the Numerics.NET.Mathemaics.LinearAlgebra
// namespace
open Numerics.NET.LinearAlgebra
// The non-linear least squares optimizer resides in the
// Numerics.NET.Optimization namespace.
open Numerics.NET.Optimization

// The license is verified at runtime. We're using a 30 day trial key here.
// For more information, see:
//     https://numerics.net/trial-key
let licensed = Numerics.NET.License.Verify("your-trial-key-here")

// Nonlinear least squares fits are calculated using the
// NonlinearCurveFitter class:
let fitter = NonlinearCurveFitter()

// In the first example, we fit a dose response curve
// to a data set that includes error information.

// The data points must be supplied as Vector objects:
let dose =
    Vector.Create(1.46247, 2.3352, 4.0,
        7.0, 12.0, 18.0, 23.0, 30.0, 40.0, 60.0, 90.0, 160.0, 290.0, 490.0, 860.0)
let response =
    Vector.Create(95.49073, 95.14551, 94.86448,
        92.66762, 85.36377, 74.72183, 62.76747, 51.04137, 38.20257,
        28.01712, 19.40086, 13.18117, 9.87161, 7.64622, 7.21826)
let error =
    Vector.Create(4.74322, 4.74322, 4.74322,
        4.63338, 4.26819, 3.73609, 3.13837, 3.55207, 3.91013,
        2.40086, 2.6, 3.65906, 2.49358, 2.38231, 2.36091)

// You must supply the curve whose parameters will be
// fit to the data. The curve must inherit from NonlinearCurve.
// The FourParameterLogistic curve is one of several
// predefined nonlinear curves:
let doseResponseCurve = FourParameterLogisticCurve()

// Now we set the curve fitter's Curve property:
fitter.Curve <- doseResponseCurve
// The GetInitialFitParameters method sets the curve parameters
// to initial values appropriate for the data:
fitter.InitialGuess <- doseResponseCurve.GetInitialFitParameters(dose, response)

// and the data values:
fitter.XValues <- dose
fitter.YValues <- response
// The GetWeightVectorFromErrors method of the WeightFunctions
// class lets us convert the error values to weights:
fitter.WeightVector <- WeightFunctions.GetWeightVectorFromErrors(error)

// The Fit method performs the actual calculation.
let result = fitter.Fit()
// The standard deviations associated with each parameter
// are available through the GetStandardDeviations method.
let s = fitter.GetStandardDeviations()

// We can now print the results:
printfn "Dose response curve"

printfn "Initial value: %10.6f +/- %.4f" doseResponseCurve.InitialValue s.[0]
printfn "Final value:   %10.6f +/- %.4f" doseResponseCurve.FinalValue s.[1]
printfn "Center:        %10.6f +/- %.4f" doseResponseCurve.Center s.[2]
printfn "Hill slope:    %10.6f +/- %.4f" doseResponseCurve.HillSlope s.[3]

// We can also show some statistics about the calculation:
printfn "Residual sum of squares: %A" (fitter.Residuals.Norm())
// The Optimizer property returns the MultidimensionalOptimization object
// used to perform the calculation:
printfn "# iterations: %d" fitter.Optimizer.IterationsNeeded
printfn "# function evaluations: %d" fitter.Optimizer.EvaluationsNeeded

printfn ""

//
// Defining your own nonlinear curve
//

// In this example, we use one of the datasets (MGH10)
// from the National Institute for Statistics and Technology
// (NIST) Statistical Reference Datasets.
// See http://www.itl.nist.gov/div898/strd for details

let fitter2 = NonlinearCurveFitter()
// Here, we need to define our own curve.
// The MyCurve class is defined below.

// This is our nonlinear curve implementation. For details, see
// http://www.itl.nist.gov/div898/strd/nls/data/mgh10.shtml
// You must inherit from NonlinearCurve:
type MyCurve() as this =
    // Call the base constructor with the number of parameters.
    inherit NonlinearCurve(3)

    do
        // It is convenient to set common starting values
        // for the curve parameters in the constructor:
        this.Parameters.[0] <- 0.2
        this.Parameters.[1] <- 40000.0
        this.Parameters.[2] <- 2500.0

    override this.ValueAt x =
        this.Parameters.[0] * exp(this.Parameters.[1] / (x + this.Parameters.[2]))

    override this.SlopeAt x =
        this.Parameters.[0] * this.Parameters.[1] * exp(this.Parameters.[1] / (x + this.Parameters.[2]))
            / (pown (x + this.Parameters.[2]) 2)

    // The FillPartialDerivatives evaluates the partial derivatives
    // with respect to the curve parameters, and returns
    // the result in a vector. If you don't supply this method,
    // a numerical approximation is used.
    override this.FillPartialDerivatives (x, f) =
        let exp = Math.Exp(this.Parameters.[1] / (x + this.Parameters.[2]))
        f.[0] <- exp
        f.[1] <- this.Parameters.[0] * exp / (x + this.Parameters.[2])
        f.[2] <- -this.Parameters.[0] * this.Parameters.[1] * exp / (pown (x + this.Parameters.[2]) 2)

fitter2.Curve <- MyCurve()

// The data is provided as Vector objects.
// X values go into the XValues property...
fitter2.XValues <- Vector.Create(
    [|
        5.000000E+01; 5.500000E+01; 6.000000E+01; 6.500000E+01;
        7.000000E+01; 7.500000E+01; 8.000000E+01; 8.500000E+01;
        9.000000E+01; 9.500000E+01; 1.000000E+02; 1.050000E+02;
        1.100000E+02; 1.150000E+02; 1.200000E+02; 1.250000E+02
    |])
// ...and Y values go into the YValues property:
fitter2.YValues <- Vector.Create(
    [|
        3.478000E+04; 2.861000E+04; 2.365000E+04; 1.963000E+04;
        1.637000E+04; 1.372000E+04; 1.154000E+04; 9.744000E+03;
        8.261000E+03; 7.030000E+03; 6.005000E+03; 5.147000E+03;
        4.427000E+03; 3.820000E+03; 3.307000E+03; 2.872000E+03
    |])
fitter2.InitialGuess <- Vector.Create(fitter2.Curve.Parameters.ToArray())
fitter2.WeightVector <- null
// The Fit method performs the actual calculation:
let result2 = fitter2.Fit()

// A Vector containing the parameters of the best fit
// can be obtained through the
// BestFitParameters property.
let solution2 = fitter2.BestFitParameters
let s2 = fitter2.GetStandardDeviations()

printfn "NIST Reference Data Set"
printfn "Solution:"
printfn "b1: %20f %20f" solution2.[0] s2.[0]
printfn "b2: %20f %20f" solution2.[1] s2.[1]
printfn "b3: %20f %20f" solution2.[2] s2.[2]

printfn "Certified values:"
printfn "b1: %20f %20f" 5.6096364710E-03 1.5687892471E-04
printfn "b2: %20f %20f" 6.1813463463E+03 2.3309021107E+01
printfn "b3: %20f %20f" 3.4522363462E+02 7.8486103508E-01

// Now let's redo the same operation, but with observations weighted
// by 1/Y^2. To do this, we set the WeightFunction property.
// The WeightFunctions class defines a set of ready-to-use weight functions.
fitter2.WeightFunction <- WeightFunctions.OneOverX
// Refit the curve:
let result3 = fitter2.Fit()
let solution3 = fitter2.BestFitParameters
let s3 = fitter2.GetStandardDeviations()

// The solution is slightly different:
printfn "Solution (weighted observations):"
printfn "b1: %20f %20f" solution3.[0] s3.[0]
printfn "b2: %20f %20f" solution3.[1] s3.[1]
printfn "b3: %20f %20f" solution3.[2] s3.[2]
