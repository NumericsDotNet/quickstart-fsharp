//=====================================================================
//
//  File: differential-equations.fs
//
//---------------------------------------------------------------------
//
//  This file is part of the Numerics.NET Code Samples.
//
//  Copyright (c) 2004-2025 ExoAnalytics Inc. All rights reserved.
//
//=====================================================================

module DifferentialEquations

// Illustrates integrating systems of ordinary
// differential equations (ODE's) using classes in the
// Numerics.NET.Calculus.OrdinaryDifferentialEquations
// namespace of Numerics.NET.

#light

open System

open Numerics.NET
open Numerics.NET.Calculus.OrdinaryDifferentialEquations

// The license is verified at runtime. We're using a 30 day trial key here.
// For more information, see:
//     https://numerics.net/trial-key
let licensed = Numerics.NET.License.Verify("your-trial-key-here")

// The ClassicRungeKuttaIntegrator class implements the
// well-known 4th order fixed step Runge-Kutta method.
let rk4 = ClassicRungeKuttaIntegrator()

// The differential equation is expressed in terms of a
// DifferentialFunction delegate. This is a function that
// takes a double (time value) and two Vectors (y value and
// return value)  as arguments.
//
// The Lorentz function below defines the differential function
// for the Lorentz attractor.
// the differential function for the Lorentz attractor.
let Lorentz (t : float) (y : Vector<float>) (dy : Vector<float>) =
    let sigma = 10.0
    let beta = 8.0 / 3.0
    let rho = 28.0
    dy.[0] <- sigma * (y.[1] - y.[0])
    dy.[1] <- y.[0] * (rho - y.[2]) - y.[1]
    dy.[2] <- y.[0] * y.[1] - beta * y.[2]
    dy

rk4.DifferentialFunction <- DifferentialFunction Lorentz

// To perform the computations, we need to set the initial time...
rk4.InitialTime <- 0.0
// and the initial value.
rk4.InitialValue <- Vector.Create(1.0, 0.0, 0.0)
// The Runge-Kutta integrator also requires a step size:
rk4.InitialStepsize <- 0.1

printfn "Classic 4th order Runge-Kutta"
for i in 0..5 do
    let t = 0.2 * float i
    // The Integrate method performs the integration.
    // It takes as many steps as necessary up to
    // the specified time and returns the result:
    let y = rk4.Integrate(t)
    // The IterationsNeeded always shows the number of steps
    // needed to arrive at the final time.
    printfn "%.2f: %20s (%d steps)" t (y.ToString("F14")) rk4.IterationsNeeded

// The RungeKuttaFehlbergIntegrator class implements a variable-step
// Runge-Kutta method. This method chooses the stepsize, and so
// is generally more reliable.
let mutable rkf45 = RungeKuttaFehlbergIntegrator()

rkf45.InitialTime <- 0.0
rkf45.InitialValue <- Vector.Create(1.0, 0.0, 0.0)
rkf45.DifferentialFunction <- DifferentialFunction Lorentz
rkf45.AbsoluteTolerance <- 1e-8

printfn "Classic 4/5th order Runge-Kutta-Fehlberg"
for i in 0..5 do
    let t = 0.2 * float i
    let y = rkf45.Integrate(t)
    printfn "%.2f: %20s (%d steps)" t (y.ToString("F14")) rk4.IterationsNeeded

// The CVODE integrator, part of the SUNDIALS suite of ODE solvers,
// is the most advanced of the ODE integrators.
let mutable cvode = CvodeIntegrator()

cvode.InitialTime <- 0.0
cvode.InitialValue <- Vector.Create(1.0, 0.0, 0.0)
cvode.DifferentialFunction <- DifferentialFunction Lorentz
cvode.AbsoluteTolerance <- 1e-8

printfn "CVODE (multistep Adams-Moulton)"
for i in 0..5 do
    let t = 0.2 * float i
    let y = cvode.Integrate(t)
    printfn "%.2f: %20s (%d steps)" t (y.ToString("F14")) rk4.IterationsNeeded

//
// Other properties and methods
//

// The IntegrateSingleStep method takes just a single step
// in the direction of the specified final time:
cvode.IntegrateSingleStep(2.0) |> ignore
// The CurrentTime property returns the corresponding time value.
printfn "t after single step: %A" cvode.CurrentTime
// CurrentValue returns the corresponding value:
printfn "Value at this t: %s" (cvode.CurrentValue.ToString("F14"))
// The IntegrateMultipleSteps method performs the integration
// until at least the final time, and returns the last
// value that was computed:
cvode.IntegrateMultipleSteps(2.0) |> ignore
printfn "t after multiple steps: %A" cvode.CurrentTime

//
// Stiff systems
//

printfn "Stiff systems"

// The CVODE integrator is the only ODE integrator that can
// handle stiff problems well. The following example uses
// an equation for the size of a flame. The smaller
// the initial size, the more stiff the equation is.

// We compare the performance of the variable step Runge-Kutta method
// and the CVODE integrator:

let delta = 0.0001
let tFinal = 2.0 / delta

// Represents the differential function for the flame expansion problem.
let Flame t (y : Vector<float>) (dy : Vector<float>) =
    dy.[0] <- y.[0] * y.[0] * (1.0 - y.[0])
    dy

// Represents the Jacobian of the differential function
// for the flame expansion problem.
// The Jacobian is the matrix of partial derivatives of each
// equation in the system with respect to each variable in the system.
// J may be null on input.
let FlameJacobian (t:float) (y : Vector<float>) (dy : Vector<float>) (J : Matrix<float>) =
    J.[0, 0] <- (2.0 - 3.0 * y.[0]) * y.[0]
    J

rkf45 <- new RungeKuttaFehlbergIntegrator()
rkf45.InitialTime <- 0.0
rkf45.InitialValue <- Vector.Create(delta)
rkf45.DifferentialFunction <- DifferentialFunction Flame

printfn "Classic 4/5th order Runge-Kutta-Fehlberg"
for i in 0..10 do
    let t = float i * 0.1 * tFinal
    let y = rkf45.Integrate(t)
    printfn "%.2f: %20s (%d steps)" t (y.ToString("F14")) rk4.IterationsNeeded

// The CVODE integrator will use a special (implicit) method
// for stiff problems. To select this method, pass
// EdeKind.Stiff as an argument to the constructor.
let cvodeStiff = CvodeIntegrator(OdeKind.Stiff)
cvodeStiff.InitialTime <- 0.0
cvodeStiff.InitialValue <- Vector.Create(delta)
cvodeStiff.DifferentialFunction <- DifferentialFunction Flame
// When solving stiff problems, a Jacobian for the system
// must be supplied. See below for the definition.
cvodeStiff.SetDenseJacobian(DifferentialJacobianFunction FlameJacobian)

// Notice how the CVODE integrator takes a lot fewer steps,
// and is also more accurate than the variable-step
// Runge-Kutta method.
printfn "CVODE (Stiff - Backward Differentiation Formula)"
for i in 0..10 do
    let t = float i * 0.1 * tFinal
    let y = cvodeStiff.Integrate(t)
    printfn "%.2f: %20s (%d steps)" t (y.ToString("F14")) rk4.IterationsNeeded
