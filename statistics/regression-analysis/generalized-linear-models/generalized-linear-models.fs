//=====================================================================
//
//  File: generalized-linear-models.fs
//
//---------------------------------------------------------------------
//
//  This file is part of the Numerics.NET Code Samples.
//
//  Copyright (c) 2004-2025 ExoAnalytics Inc. All rights reserved.
//
//=====================================================================

module GeneralizedLinearModels

#light

open System

open Numerics.NET.Statistics
open Numerics.NET.Data.Text

// The license is verified at runtime. We're using a 30 day trial key here.
// For more information, see:
//     https://numerics.net/trial-key
let licensed = Numerics.NET.License.Verify("your-trial-key-here")

// Illustrates building generalized linear models using
// the GeneralizedLinearModel class in the
// Numerics.NET.Statistics namespace of Numerics.NET.

// Generalized linear models can be computed using
// the GeneralizedLinearModel class.

//
// Poisson regression
//

// This QuickStart sample uses data about the attendance of 316 students
// from two urban high schools. The fields are as follows:
//   daysabs: The number of days the student was absent.
//   male:    A binary indicator of gender.
//   math:    The student's standardized math score.
//   langarts:The student's standardized language arts score.
//
// We want to investigate the relationship between these variables.
//
// See http://www.ats.ucla.edu/stat/stata/dae/poissonreg.htm

// First, read the data from a file into a data frame.
let data = DelimitedTextFile.ReadDataFrame(@"..\..\..\..\..\data\PoissonReg.csv")

// Now create the regression model. Parameters are the name
// of the dependent variable, a let array containing
// the names of the independent variables, and the VariableCollection
// containing all variables.
let model = GeneralizedLinearModel(data, "daysabs", [| "math"; "langarts"; "male" |])

// Alternatively, we can use a formula to describe the variables
// in the model. The dependent variable goes on the left, the
// independent variables on the right of the ~:
let model_2 = GeneralizedLinearModel(data, "daysabs ~ math + langarts + male")

// The ModelFamily specifies the distribution of the dependent variable.
// Since we're dealing with count data, we use a Poisson model:
model.ModelFamily <- ModelFamily.Poisson

// The LinkFunction specifies the relationship between the dependent variable
// and the linear predictor of independent variables. In this case,
// we use the canonical link function, which is the default.
model.LinkFunction <- ModelFamily.Poisson.CanonicalLinkFunction

// The Fit method performs the actual regression analysis.
model.Fit()

// The Parameters collection contains information about the regression
// parameters.
printfn "Variable  Value    Std.Error    z     p-Value"
for parameter in model.Parameters do
    // Parameter objects have the following properties:
    printfn "%-8s%10.6f%10.6f%8.2f %7.5f"
        // Name, usually the name of the variable:
        parameter.Name
        // Estimated value of the parameter:
        parameter.Value
        // Standard error:
        parameter.StandardError
        // The value of the z score for the hypothesis that the parameter
        // is zero.
        parameter.Statistic
        // Probability corresponding to the t statistic.
        parameter.PValue
printfn ""

// In addition to these properties, Parameter objects have a GetConfidenceInterval
// method that returns a confidence interval at a specified confidence level.
// Notice that individual parameters can be accessed using their numeric index.
// Parameter 0 is the intercept, if it was included.
let confidenceInterval = model.Parameters[0].GetConfidenceInterval(0.95)
printfn "95%% confidence interval for constant term: %.4f - %.4f"
    confidenceInterval.LowerBound confidenceInterval.UpperBound

// Parameters can also be accessed by name:
let confidenceInterval2 = model.Parameters.Get("math").GetConfidenceInterval(0.95)
printfn "95%% confidence interval for math score: %.4f - %.4f"
    confidenceInterval2.LowerBound confidenceInterval2.UpperBound
printfn ""

// There is also a wealth of information about the analysis available
// through various properties of the GeneralizedLinearModel object:
printfn "Log likelihood:         %.4f" (model.LogLikelihood)
printfn "Kernel log likelihood:  %.4f" (model.GetKernelLogLikelihood())

// Note that some statistical applications (notably stata) use
// a different definition of some of these "information criteria":
printfn "\"Information Criteria\""
printfn "Akaike (AIC):           %.3f" (model.GetAkaikeInformationCriterion())
printfn "Corrected AIC:          %.3f" (model.GetCorrectedAkaikeInformationCriterion())
printfn "Bayesian (BIC):         %.3f" (model.GetBayesianInformationCriterion())
printfn "Chi Square: %.3f" (model.GetChiSquare())
printfn ""

//
// Probit regression
//

// In a second example, we investigate the relationship between whether a student
// graduates, and the student's GRE scores,grade point averages, the level
// of the school from a "top notch" school. The fields are as follows:
//   admit:    Dependent variable
//   gre:      The student's GRE score.
//   topnotch: A binary indicator of the type of school
//   gpa:      The student's Grade Point Average.
//
// The data was generated.
// See http://www.ats.ucla.edu/stat/stata/dae/probit.htm

// First, read the data from a file into a data frame.
let data2 =
    let options = new FixedWidthTextOptions([| 9; 18; 27 |], columnHeaders=false)
    let df = FixedWidthTextFile
                .ReadDataFrame("..\..\..\..\..\data\probit.dat", options)
    df.WithColumnIndex([| "admit"; "gre"; "topnotch"; "gpa" |])

// Now create the regression model. Parameters are the name
// of the dependent variable, a let array containing
// the names of the independent variables, and the VariableCollection
// containing all variables.
let model2 = GeneralizedLinearModel(data2, "admit", [| "gre"; "topnotch"; "gpa" |])

// The ModelFamily specifies the distribution of the dependent variable.
// Since we're dealing with binary data, we use a Binomial model:
model2.ModelFamily <- ModelFamily.Binomial

// We use the probit link function.
model2.LinkFunction <- LinkFunction.Probit

// The Fit method performs the actual regression analysis.
model2.Fit()

// The Parameters collection contains information about the regression
// parameters.
printfn "Variable  Value    Std.Error    z     p-Value"
for parameter in model2.Parameters do
    printfn "%-8s%10.6f%10.6f%8.2f %7.5f" parameter.Name parameter.Value
        parameter.StandardError parameter.Statistic parameter.PValue
printfn ""

// There is also a wealth of information about the analysis available
// through various properties of the GeneralizedLinearModel object:
printfn "Log likelihood:         %.4f" (model2.LogLikelihood)
printfn "Kernel log likelihood:  %.4f" (model2.GetKernelLogLikelihood())

// Note that some statistical applications (notably stata) use
// a different definition of some of these "information criteria":
printfn "\"Information Criteria\""
printfn "Akaike (AIC):           %.3f" (model2.GetAkaikeInformationCriterion())
printfn "Corrected AIC:          %.3f" (model2.GetCorrectedAkaikeInformationCriterion())
printfn "Bayesian (BIC):         %.3f" (model2.GetBayesianInformationCriterion())
printfn "Chi Square: %.3f" (model2.GetChiSquare())
printfn ""
