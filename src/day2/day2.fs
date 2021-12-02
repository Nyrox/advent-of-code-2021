module day2

type Command =
    | Forward of int
    | Down of int
    | Up of int


type Input = Command seq

let parseInputLine (input: string): Command =
    input.Split(" ")
        |> (fun [|com; i|] ->
            let i = int i
            match com with
            | "forward" -> Forward i
            | "down" -> Down i
            | "up" -> Up i
        )

let parseInput (input: string): Input =
    input.Split("\n")
        |> Seq.map parseInputLine

let solve1 (input: Input): int =
    let (h, d) =
        Seq.fold (fun (h, d) command ->
            match command with
            | Forward i -> (h + i, d)
            | Down i -> (h, d + i)
            | Up i -> (h, d - i)
        ) (0, 0) input
    h * d

let solve2 (input: Input) =
    let (h, d, _) =
        Seq.fold (fun (h, d, a) command ->
            match command with
            | Forward i -> (h + i, d + a * i, a)
            | Down i -> (h, d, a + i)
            | Up i -> (h, d, a - i)
        ) (0, 0, 0) input
    h * d