// Learn more about F# at http://fsharp.org

open System
open System.IO

module Day2 =

  let charactersAppearTimes(matchCount: int)(input: string) =
     input.ToCharArray()
    |> Seq.groupBy (fun c -> c)
    |> Map.ofSeq
    |> Map.map (fun k v -> Seq.length v)
    |> Map.exists (fun _ value -> value = matchCount)

  let countAppearances state input =
    let firstCount = 
      if fst input then (fst state) + 1 
      else (fst state)

    let secoundCount = 
      if snd input then (snd state) + 1 
      else (snd state)

    (firstCount, secoundCount)

  let CreateChecksum input =
    input 
    |> Seq.map (fun line -> (charactersAppearTimes 2 line, charactersAppearTimes 3 line))
    |> Seq.fold countAppearances (0, 0)

  [<EntryPoint>]
  let main argv =
    let input = File.ReadLines(argv.[0])

    //Day 2 Part 1
    input 
    |> CreateChecksum
    |> fun (x,y) -> x * y
    |> printf "%i"

    //Day 2 Part 2
    
    
    0 // return an integer exit code
