open System.IO

let generatePermutations (nums: int[]) = [| for i in 0 .. nums.Length - 1 -> Array.append (nums.[..i-1]) (nums.[i+1..]) |]
let isOrdered (seq) = seq |> Array.pairwise |> Array.forall (fun (a, b) -> a > b && abs (a-b) <= 3)
let stage1 = File.ReadAllLines "inputs/day2" |> Array.map (fun line -> line.Split() |> Array.map int)

let answer1 =
    stage1
    |> Array.collect (fun row -> [| row; Array.rev row |])
    |> Array.filter isOrdered
    |> Array.length

let answer2 =
    stage1
    |> Array.filter (fun row ->
        [| row; Array.rev row |]
        |> Array.collect generatePermutations
        |> Array.exists isOrdered
    )
    |> Array.length

printfn "Answer 1: %d" answer1
printfn "Answer 2: %d" answer2
