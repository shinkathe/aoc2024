open System.IO
open System.Text.RegularExpressions

let stage1 = File.ReadAllText "inputs/day3"
let cleanedInput = Regex.Replace(stage1, @"don't\(\).*?do\(\)", "", RegexOptions.Singleline)
let instructionPattern = @"mul\((\d+),(\d+)\)"
let answer1Matches = Regex.Matches(stage1, instructionPattern)
let answer2Matches = Regex.Matches(cleanedInput, instructionPattern)

printfn "Answer1: %d" <| (answer1Matches |> Seq.map (fun m -> int m.Groups.[1].Value * int m.Groups.[2].Value )|> Seq.sum)
printfn "Answer1: %d" <| (answer2Matches |> Seq.map (fun m -> int m.Groups.[1].Value * int m.Groups.[2].Value )|> Seq.sum)
