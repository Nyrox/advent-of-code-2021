open System.IO


[<EntryPoint>]
let main argv =
    // let day1Input = (day1.parseInput (File.ReadAllText "src/day1/input"))
    // printfn "Day 1: [%A, %A]" (day1.solve1 day1Input) (day1.solve2 day1Input)

    // let day2Input = (day2.parseInput (File.ReadAllText "src/day2/input"))
    // printfn "Day 2: [%A, %A]" (day2.solve1 day2Input) (day2.solve2 day2Input)

    // let day3Input = (day3.parseInput (File.ReadAllText "src/day3/input"))
    // printfn "Day 3: [%A, %A]" (day3.solve1 day3Input) (day3.solve2 day3Input)
    
    // let day6Input = (day6.parseInput (File.ReadAllText "src/day6/input"))
    // printfn "Day 6: [%A, %A]" (day6.solve1 day6Input) 0
    
    let day7Input = (day7.parseInput (File.ReadAllText "src/day7/input"))
    printfn "Day 7: [%A, %A]" (day7.solve1 day7Input) (day7.solve2 day7Input)
    
    0