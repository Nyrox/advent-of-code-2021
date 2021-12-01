open System.IO


[<EntryPoint>]
let main argv =
    let day1Input = (day1.parseInput (File.ReadAllText "src/day1/input"))
    printfn "Day 1: [%A, %A]" (day1.solve1 day1Input) (day1.solve2 day1Input)

    0