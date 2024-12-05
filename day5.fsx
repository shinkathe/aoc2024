open System
let uncurry f (x, y) = f x y

let input = IO.File.ReadAllText "inputs/day5" |> _.Split("\n\n")
let orderingRules = input |> Array.head |> _.Split("\n") |> Array.map (fun line -> line.Split('|') |> fun p -> int p[0], int p[1])
let lines = input |> Array.last |> _.Split("\n") |> Array.map (fun line -> line.Split(',') |> Array.map int)

let getMiddleElement (array:int[]) = array.[array.Length / 2]

let rec swap (a:int[]) rules =
    let (newA, changed) =
        rules |> Array.fold (fun (acc, changed) (v1, v2) ->
            match Array.tryFindIndex ((=) v1) acc, Array.tryFindIndex ((=) v2) acc with
            | Some i1, Some i2 when i1 > i2 -> (acc |> Array.mapi (fun i x -> if i = i1 then v2 elif i = i2 then v1 else x), true)
            | _ -> (acc, changed)
        ) (a, false)
    if changed then swap newA rules else newA

let swappedLines = lines |> Array.map (fun line -> (line, swap line orderingRules))

swappedLines |> Array.filter (uncurry (=)) |> Array.map (fst >> getMiddleElement) |> Array.sum |> printfn "Answer 1: %A"
swappedLines |> Array.filter (uncurry (<>)) |> Array.map (snd >> getMiddleElement) |> Array.sum |> printfn "Answer 2: %A"
