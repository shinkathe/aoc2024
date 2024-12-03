open System.IO
open System.Text.RegularExpressions

let input = File.ReadAllText "inputs/day3"
let instructionPattern = @"mul\((\d+),(\d+)\)"
let answer1Matches = Regex.Matches(input, instructionPattern)
let answer2Matches = Regex.Matches(Regex.Replace(input, @"don't\(\).*?do\(\)", "", RegexOptions.Singleline), instructionPattern)

printfn "Answer1: %d" <| (answer1Matches |> Seq.sumBy (fun m -> int m.Groups.[1].Value * int m.Groups.[2].Value ))
printfn "Answer2: %d" <| (answer2Matches |> Seq.sumBy (fun m -> int m.Groups.[1].Value * int m.Groups.[2].Value ))
