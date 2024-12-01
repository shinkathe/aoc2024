open System.IO

let stage1 =
    File.ReadAllLines "inputs/day1"
    |> Array.map (fun line -> line.Split("   ") |> Array.map int)
    |> Array.transpose

let answer1 =
    stage1
    |> Array.map Array.sort
    |> fun [| left; right |] -> Array.sumBy (fun (x, y) -> abs (x - y)) (Array.zip left right)

let answer2 =
    stage1
    |> fun [| left; right |] -> Array.sumBy (fun x -> x * (Array.filter ((=) x) right |> Array.length)) left

printfn "Answer1: %d" answer1
printfn "Answer2: %d" answer2
