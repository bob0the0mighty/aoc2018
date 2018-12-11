open System
open System.IO

module Array =

  //http://www.fssnip.net/fF/title/Combinations-n-choose-k
  let chooseK k n = 
    let rec choose lo  =
      function
        |0 -> [[]]
        |i -> [for j=lo to (Array.length n)-1 do
                    for ks in choose (j+1) (i-1) do
                      yield n.[j] :: ks ]

      in choose 0 k

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

  let hammingDistance(string1:string)(string2:string) =
    string1
    |> Seq.zip string2
    |> Seq.fold (fun state (ch1, ch2) -> if ch1 = ch2 then state else state + 1) 0

  [<EntryPoint>]
  let main argv =
    let input = File.ReadLines(argv.[0])

    //Day 2 Part 1
    input 
    |> CreateChecksum
    |> fun (x,y) -> x * y
    |> printf "%i"

    //Day 2 Part 2
    input
    |> Array.ofSeq
    |> Array.chooseK 2
    |> List.map (fun item -> (item.[0], item.[1]))
    |> List.filter (fun (a, b) -> (hammingDistance a b) = 1)
    |> List.toArray
    |> printf "%A"

    0 // return an integer exit code
