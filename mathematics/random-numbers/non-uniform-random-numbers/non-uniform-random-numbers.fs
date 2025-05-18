//=====================================================================
//
//  File: non-uniform-random-numbers.fs
//
//---------------------------------------------------------------------
//
//  This file is part of the Numerics.NET Code Samples.
//
//  Copyright (c) 2004-2025 ExoAnalytics Inc. All rights reserved.
//
//=====================================================================

module NonUniformRandomNumbers

#light

open System

open Numerics.NET.Random
open Numerics.NET.Statistics.Distributions

// The license is verified at runtime. We're using a 30 day trial key here.
// For more information, see:
//     https://numerics.net/trial-key
let licensed = Numerics.NET.License.Verify("your-trial-key-here")

// Illustrates generating non-uniform random numbers
// using the classes in the Numerics.NET.Statistics.Random
// namespace.

// Random number generators and the generation
// of uniform pseudo-random numbers are illustrated
// in the UniformRandomNumbers QuickStart Sample.

// In this sample, we will generate numbers from
// an exponential distribution, and compare summary
// results to what would be expected from
// the corresponding Poisson distribution.

let meanTimeBetweenEvents = 0.42

// We will use the exponential distribution to generate the time
// between events. The number of events per unit time follows
// a Poisson distribution.

// The parameter of the exponential distribution is the time between events.
let exponential = ExponentialDistribution(meanTimeBetweenEvents);
// The parameter of the Poisson distribution is the mean number of events
// per unit time, which is the reciprocal of the time between events:
let poisson = PoissonDistribution(1.0 / meanTimeBetweenEvents)

// We use a MersenneTwister to generate the random numbers:
let random = MersenneTwister()

// The totals array will track the number of events per time unit.
let totals = Array.zeroCreate<int>(15)

let rec SampleTimeUnit sampler startTime eventsSoFar =
    if (startTime < 1.0) then
        SampleTimeUnit sampler (startTime + sampler()) (eventsSoFar + 1)
    else
        startTime - 1.0, eventsSoFar

let rec SampleUnits sampler (totals : int[]) iterationsRemaining startTime currentCount =
    match iterationsRemaining with
    | 0 -> currentCount
    | _ ->
        let nextStartTime, eventsInUnit = SampleTimeUnit sampler startTime 0
        if (eventsInUnit >= totals.Length) then
            totals.[totals.Length-1] <- totals.[totals.Length-1] + 1
        else
            totals.[eventsInUnit] <- totals.[eventsInUnit] + 1
        SampleUnits sampler totals (iterationsRemaining - 1) nextStartTime (currentCount + eventsInUnit)

let count = SampleUnits (fun () -> exponential.Sample(random)) totals 1000000 0.0 0

// Now print the totals
printfn "# Events    Actual  Expected"
for i in 0..totals.Length-1 do
    let expected = (int)(1000000.0 * poisson.Probability(i))
    printfn "%8d  %8d  %8d" i totals.[i] expected
