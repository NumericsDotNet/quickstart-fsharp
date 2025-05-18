//=====================================================================
//
//  File: indexes-and-labels.fs
//
//---------------------------------------------------------------------
//
//  This file is part of the Numerics.NET Code Samples.
//
//  Copyright (c) 2004-2025 ExoAnalytics Inc. All rights reserved.
//
//=====================================================================

module IndexesAndLabels

#light

open System
open System.Data

open Numerics.NET
open Numerics.NET.DataAnalysis

// The license is verified at runtime. We're using a 30 day trial key here.
// For more information, see:
//     https://numerics.net/trial-key
let licensed = Numerics.NET.License.Verify("your-trial-key-here")

// Illustrates how to use indexes to label
// the rows and columns of a data frame or matrix,
// or the elements of a vector.

//
// Indexes
//

// An index is a set of keys that can be used
// to label one or more dimensions of a vector,
// matrix, or data frame.

//
// Construction
//

// The simplest way to create an index is from an array:
let index = Index.Create([| "a"; "b"; "c"; "d" |])
// We can then assign this to the Index property of a vector:
let v = Vector.Create([| 1.0; 2.0; 3.0; 4.0 |])
v.Index <- index
printfn "%O" v

// An index by position is very common,
// and can be created efficiently using the
// Default method:
let numbers = Index.Default(10) // 0, 1, ..., 9
let numbers2 = Index.Default(10, 20) // 10, 11, ..., 19

// Various options exist to create indexes over date ranges,
// for example:
let dateIndex = Index.CreateDateRange(new DateTime(2015, 4, 25), 10)
// 2015/4/25, 2015/4/26, ..., 2015/5/4

// Finally, for some purposes it may be useful to create
// an index of intervals, for example when you want to
// categorize people into age groups:
let ages = [| 0; 18; 35; 65 |]
let ageGroups = Index.CreateBins(ages, SpecialBins.AboveMaximum)

//
// Properties
//

// Indexes have a length
printfn "# of keys in index: %d" index.Length
// Indexes usually have unique elements.
printfn "Keys are unique? %b" index.IsUnique
// The elements may be sorted or not.
printfn "Keys are sorted? %b" index.IsSorted
printfn "Sort order: %A" index.SortOrder

//
// Lookup
//

// Once created, you can look up the position of a key:
let mutable position = index.Lookup("c") // = 2
match index.TryLookup("e") with
| true, _ -> failwith "We shouldn't be here."
| _ -> printfn "Lookup failed, as expected."

// You can also look up the nearest date.
let dates = Index.CreateDateRange(DateTime.Today.AddDays(-5.0), 10)
let now = DateTime.Now
// An exact lookup fails in this case:
match dates.TryLookup(now) with
| false, _ -> printfn "Exact lookup failed."
| _ -> printfn "Success!"

// But looking for the nearest key works fine:
position <- dates.LookupNearest(now, Direction.Backward) // = 5
position <- dates.LookupNearest(now, Direction.Forward) // = 6

//
// Automatic alignment
//

// One of the useful features of indexes is that
// values are aligned on key values automatically.
// For example, given two vectors:
let a = Vector.Create(
          [| 1.0; 2.0; 3.0; 4.0 |],
          [| "a"; "b"; "c"; "d" |])
let b = Vector.Create(
          [| 10.0; 30.0; 40.0; 50.0 |],
          [| "a"; "c"; "d"; "e" |])
// We can compute their sum:
printfn "%O" (a + b)
// and we find that elements are added
// when they have the same key,
// not when they have the same position.

// Indexes also propagate through calculations:
printfn "Exp(a) = \n%O" (Vector.Exp(a))
printfn "a[a %% 2 = 0] =\n%O" (a.[fun x -> x % 2.0 = 0.0])

// Matrices can have a row and/or a column index:
let c = Matrix.CreateRandom(100, 4)
c.ColumnIndex <- Index.Create([| "a"; "b"; "c"; "d" |])
let cTc = c.Transpose() * c
Console.WriteLine($"C^T*C = \n{cTc.Summarize()}")
