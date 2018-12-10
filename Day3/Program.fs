open System
open System.IO

module Day3 =

  let caclulateAreas(line:string) = 
    let splits = line.Split(" ")
    
    let start = (splits.[2].Replace(":","").Split(","))
    |> Array.map (fun item -> Int32.Parse(item))

    let area = splits.[3].Split("x")
    |> Array.map Int32.Parse

    seq { for newX in x .. (x + width) do
          for newY in y .. (y + height) do
            yield (newX, newY) }


  [<EntryPoint>]
  let main argv =
    let input = File.ReadAllLines(argv.[0])
    
    input 
    |> Seq.map caclulateAreas

    0