// Learn more about F# at http://fsharp.org

open System
open System.IO

module Day2 =

  let getCountOfNumbers(matchCount: int)(input: string) =
     input.ToCharArray()
    |> Seq.groupBy (fun c -> c)
    |> Map.ofSeq
    |> Map.map (fun k v -> Seq.length v)
    |> Map.exists (fun _ value -> value = matchCount)

  let CreateChecksum input =
    
    input 
    |> Seq.map (fun line -> (getCountOfNumbers 2 line, getCountOfNumbers 3 line))
    |> Seq.fold (fun accum item -> item) 0

  [<EntryPoint>]
  let main argv =
    let input = File.ReadLines(argv.[0])

    input 
    |> CreateChecksum
    |> Console.WriteLine
    
    0 // return an integer exit code
