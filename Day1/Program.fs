open System
open System.IO

module Seq =
  let repeat items = seq { while true do yield! items }

module Day1 = 

  let CalculateFrequency inputs = 
    Seq.sumBy Int32.Parse inputs

  [<EntryPoint>]
  let day1 args =
    let input = File.ReadLines(args.[0])
    
    //Day 1 Part 1
    input
    |> CalculateFrequency
    |> Console.WriteLine

    //Day 1 Part 2
    //Coppied from https://github.com/andreasjhkarlsson/aoc-2018/blob/master/src/Day1.fs
    //I realize how use to imperitive structures I am when reading other peoples code.
    input
    |> Seq.map Int32.Parse
    |> Seq.repeat
    |> Seq.scan (fun (f, seen) d ->  f + d, seen |> Set.add f) (0, Set.empty) // Calculate intermediate frequency sums
    |> Seq.find (fun (f, seen) -> seen |> Set.contains f) // Find first frequency sum that is already in seen set
    |> fst
    |> Console.WriteLine

    1
