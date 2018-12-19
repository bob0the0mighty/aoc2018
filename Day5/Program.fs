open System
open System.IO
open System.Text.RegularExpressions

module List =

  let foldBackNormal f s input = List.foldBack f input s

module Day5 =

  let matchChars char1 char2 =
    char1 <> char2 && Char.ToLower char1 = Char.ToLower char2

  let processString chr rest=
    match rest with
      | x::xs when matchChars x chr -> xs
      | xs -> chr :: xs

  let stripChars text (chars:string) =
    let upAndLower = chars.ToUpper() + chars.ToLower()
    Array.fold (
        fun (s:string) c -> s.Replace(c.ToString(),"")
    ) text (upAndLower.ToCharArray())

  [<EntryPoint>]
  let main argv =
    let input = File.ReadAllText(argv.[0])

    //Day 5 Part 1
    input
    |> List.ofSeq
    //|> List.take 10
    |> List.foldBackNormal processString []
    |> String.Concat
    |> String.length
    |> printf "%i\n"

    //Day 5 Part 2    
    seq {'a'..'z'}
    |> Seq.map (fun charToRemove -> 
        stripChars input (string charToRemove)
        |> List.ofSeq
        |> List.foldBackNormal processString []
        |> String.Concat
        |> String.length
      )
    |> Seq.min
    |> printf "%i\n"

    0
 