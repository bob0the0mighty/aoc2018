open System
open System.IO
open System.Collections.Generic
open System.Collections.Generic

module Seq =
  let rec cycle xs = 
    seq { yield! xs; yield! cycle xs}

module Day1 = 

  let CalculateFrequency inputs = 
    Seq.sumBy Int32.Parse inputs

  let CalculateAndStoreFrequency(dictionary: Dictionary<int, int>, sum: int, input: string) =
    input
    |> Int32.Parse
    |> Array.mapi

    

  let CalculateDuplicateFreq inputs =
    let frequencies = new Dictionary<int, int>()
    let mut sum = 0

    inputs
    |> Seq.takeWhile (fun item -> CalculateAndStoreFrequency(frequencies, sum, item))



  [<EntryPoint>]
  let day1 args =
    let input = File.ReadLines(args.[0])
    let values = Seq.append ["0"] input
    
    values
    |> CalculateFrequency
    |> Console.WriteLine

    values
    |> Seq.cycle
    |> CalculateDuplicateFreq

    1
