open System.IO


[<EntryPoint>]
let main argv =
    let day1Input = (day1.parseInput (File.ReadAllText "src/day1/input"))
    printfn "Day 1: [%A, %A]" (day1.solve1 day1Input) (day1.solve2 day1Input)

    let day2Input = (day2.parseInput (File.ReadAllText "src/day2/input"))
    printfn "Day 2: [%A, %A]" (day2.solve1 day2Input) (day2.solve2 day2Input)
    0