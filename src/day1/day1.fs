module day1


type Input = int seq

let parseInput (input: string): Input =
    input.Split("\n")
        |> Seq.map int

let solve1 (input: Input) =
    Seq.windowed 2 input
        |> Seq.filter (fun [|a; b|] -> a < b)
        |> Seq.length

let solve2 (input: Input) =
    Seq.windowed 3 input
        |> Seq.windowed 2
        |> Seq.filter (fun [|a; b|] -> 
            Seq.sum a < Seq.sum b
            )
        |> Seq.length
