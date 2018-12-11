open System
open System.IO
open System.Collections.Generic
open System.Collections.Generic

module Day3 =

  let caclulatePoints(line:string) = 
    let splits = line.Split(" ")
    
    let claim = splits.[0]

    let startPoint = 
      splits.[2].Replace(":","").Split(",")
      |> Array.map (fun item -> Int32.Parse(item))

    let x, y = startPoint.[0], startPoint.[1]

    let area = 
      splits.[3].Split("x")
      |> Array.map (fun item -> Int32.Parse(item))

    let width, height = area.[0], area.[1]

    seq { for newX in x .. (x + width - 1) do
          for newY in y .. (y + height - 1) do
            yield (claim, newX, newY) }


  [<EntryPoint>]
  let main argv =
    let input = File.ReadAllLines(argv.[0])

    let pointsSeq = Seq.map caclulatePoints input
    Seq.toArray pointsSeq |> printf "%A"

    let points = Seq.concat pointsSeq
    Seq.toArray points |> printf "%A"

    let pointCount = Seq.countBy (fun (a, x, y) -> (x, y) ) points
    Seq.toArray pointCount |> printf "%A"

    let distinctPoint = Seq.distinctBy (fun (a, x, y) -> (x, y) ) points
    printf "Distinct"
    Seq.toArray distinctPoint |> printf "%A"

    let overlap = Seq.filter (fun tup-> snd tup > 1) pointCount 
    Seq.toArray overlap |> printf "%A"

    // input
    // |> Seq.map caclulatePoints
    // |> Seq.concat
    // |> Seq.countBy (fun (a, x, y) -> (x, y) )
    // |> Seq.filter (fun tup-> snd tup > 1)
    // |> Seq.length
    // |> printf "%i"

    0