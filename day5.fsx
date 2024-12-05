open System.IO

let stage1 = File.ReadAllLines("inputs/day5")
let orderingRules = stage1 |> Array.filter (fun line -> line.Contains("|")) |> Array.map (fun line -> line.Split('|') |> fun parts -> (int parts.[0], int parts.[1]))
let lines = stage1 |> Array.filter (fun line -> line.Contains(",")) |> Array.map (fun line -> line.Split(',') |> Array.map int)
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

let answer1 = swappedLines |> Array.filter (fun (original, swapped) -> original = swapped) |> Array.map (fun (original, _) -> getMiddleElement original) |> Array.sum
let answer2 = swappedLines |> Array.filter (fun (original, swapped) -> original <> swapped) |> Array.map (fun (_, swapped) -> getMiddleElement swapped) |> Array.sum

printfn "Answer 1: %A" answer1
printfn "Answer 2: %A" answer2
