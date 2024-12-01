open System.IO

let stage1 =
    File.ReadAllLines "inputs/day1"
    |> Array.map (fun line -> line.Split("   ") |> Array.map int)
    |> Array.transpose
    |> Array.map (Array.sort)
    |> fun arr -> (arr.[0], arr.[1])

let answer1 =
    stage1
    ||> Array.map2 (-)
    |> Array.sumBy abs

let answer2 =
    stage1
    ||> fun a b -> a |> Array.sumBy (fun x -> x * (Array.filter ((=) x) b |> Array.length))

printfn "Answer1: %d" answer1
printfn "Answer2: %d" answer2
