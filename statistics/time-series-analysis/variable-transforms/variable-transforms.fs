//=====================================================================
//
//  File: variable-transforms.fs
//
//---------------------------------------------------------------------
//
//  This file is part of the Numerics.NET Code Samples.
//
//  Copyright (c) 2004-2025 ExoAnalytics Inc. All rights reserved.
//
//=====================================================================

module VariableTransforms

#light

open System

open Numerics.NET.Data.Text
open Numerics.NET
open Numerics.NET.DataAnalysis

// The license is verified at runtime. We're using a 30 day trial key here.
// For more information, see:
//     https://numerics.net/trial-key
let licensed = Numerics.NET.License.Verify("your-trial-key-here")

// Illustrates various kinds of transformations of numerical variables
// by showing how to compute several financial indicators.

// Time series data frames can be created in a variety of ways.
// Here we read from a CSV file and specify the column to use as the index:
let timeSeries = DelimitedTextFile.ReadDataFrame<DateTime>(
                    "..\..\..\..\..\Data\MicrosoftStock.csv", "Date")

// The following are all equivalent ways of getting
// a strongly typed vector from a data frame:
let opening = timeSeries.["Open"].As<double>()
let close = timeSeries.GetColumn("Close")
let high = timeSeries.GetColumn<double>("High")
let low = timeSeries.["Low"] :?> Vector<double>

let volume = timeSeries.["Volume"].As<double>();

//
// Arithmetic operations
//

// The NumericalVariable class defines the standard
// arithmetic operators. Operands can be either
// numerical variables or constants.

// The Typical Price (TP) is the average of the day's high, low and close:
let TP = (high + low + close) / 3.0

// Exponentiation is available through the Power method:
let inverseVolume = Vector.ElementwisePow(volume, -1)

//
// Simple transformations
//

// By including the Numerics.NET.Statistics namespace,
// we've enabled a number of extension methods
// on vectors that compute common transformations.

// The Lag method returns a variable whose observations
// are moved ahead by the specified amount:
let close1 = close.Lag(1)
// You can get cumulative sums and products:
let cumVolume = volume.CumulativeSum()

//
// Indicators of change
//

// You can get the absolute change, percent change,
// or (exponential) growth rate of a variable. The optional
// parameter is the number of periods to go back.
// The default is 1.
let closeChange = close.Change(10)

// You can extrapolate the change to a longer number of periods.
// The additional argument is the number of large periods.
let monthyChange = close.ExtrapolatedChange(10, 20.0)

//
// Moving averages
//

// You can get simple, exponential, and weighted moving averages.
let MA20 = close.MovingAverage(20)

// Weighted moving averages can use either a fixed array or vector
// to specify the weight. The weights are automatically normalized.
let weights = [| 1.0; 2.0; 3.0 |]
let WMA3 = close.WeightedMovingAverage(weights)
// You can also specify another variable for the weights.
// In this case, the corresponding observations are used.
// For example, to obtain the volume weighted average
// of the close price over a 14 day period, you can write:
let VWA14 = close.WeightedMovingAverage(14, volume)

// Other statistics, such as maximum, minimum and standard
// deviation are also available.

//
// Misc. transforms
//

// The Box-Cox transform is often used to reduce the effects
// of non-normality of a variable. It takes one parameter,
// which must be between 0 and 1.
let bcVolume = volume.BoxCoxTransform(0.4)

//
// Creating more complicated indicators
//

// All these transformations can be combined to create
// more complicated transformations. We give some examples
// of common Technical Analysis indicators.

// The Accumulation Distribution is a leading indicator of price movements.
// It is used in many other indicators.
// The formula uses only arithmetic operations:
let AD = (close - opening) ./ (high - low) .* volume

// The Chaikin oscillator is used to monitor the flow of money into
// and out of a market.  It is the difference between a 3 day and a 10 day
// moving average of the Accumulation Distribution.
// We use the GetExponentialMovingAverage method for this purpose.
let CO = AD.ExponentialMovingAverage(3) - AD.ExponentialMovingAverage(10)

// Bollinger bands provide an envelope around the price that indicates
// whether the current price level is relatively high or low.
// It uses a 20 day simple average as a central line:
let TPMA20 = TP.MovingAverage(20)
// The actual bands are at 2 standard deviations (over the same period)
// from the central line. We have to pass the moving average
// over the same period as the second parameter.
let SD20 = TP.MovingStandardDeviation(20, TPMA20)
let BOLU = MA20 + 2.0*SD20
let BOLD = MA20 - 2.0*SD20

// The Relative Strength Index is an index that compares
// the average price gain to the average loss.
// The GetPositiveToNegativeIndex method performs this
// calculation in one operation. The first argument is the period.
// The second argument is the variable that determines
// if an observation counts towards the plus or the minus side.
let change = close.Change(1)
let RSI = change.PositiveToNegativeIndex(14, change)

// Finally, let's print some of our results:
let index = timeSeries.RowIndex.Lookup(DateTime(2002, 9, 17))
printfn "Data for September 17, 2002:"
printfn "Acumulation Distribution (in millions): %.2f" (AD.[index] / 1000000.0)
printfn "Chaikin Oscillator (in millions): %.2f" (CO.[index] / 1000000.0)
printfn "Bollinger Band (Upper): %.2f" BOLU.[index]
printfn "Bollinger Band (Central): %.2f" TPMA20.[index]
printfn "Bollinger Band (Lower): %.2f" BOLD.[index]
printfn "Relative Strength Index: %.2f" RSI.[index]
