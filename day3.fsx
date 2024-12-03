open System.IO
open System.Text.RegularExpressions

let stage1 = File.ReadAllText "inputs/day3"
let pattern = @"do\(\)|don't\(\)|mul\((\d+),(\d+)\)"
let matches = Regex(pattern).Matches(stage1)

let findInstructions skip =
    let mutable isEnabled = true
    let mutable enabledMulInstructions = []
    for m in matches do
        let instruction = m.Value
        match instruction with
        | "do()" ->
            isEnabled <- skip || true
        | "don't()" ->
            isEnabled <- skip || false
        | _ when instruction.StartsWith("mul") && isEnabled ->
            enabledMulInstructions <- (int m.Groups.[1].Value, int m.Groups.[2].Value) :: enabledMulInstructions
        | _ -> ()
    enabledMulInstructions

printfn "Answer 1: %d" (findInstructions true |> List.sumBy (fun (n1, n2) -> n1 * n2))
printfn "Answer 2: %d" (findInstructions false |> List.sumBy (fun (n1, n2) -> n1 * n2))
