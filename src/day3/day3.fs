module day3


type Input = char seq seq


let parseInput (input: string): Input =
    let lines = Array.toSeq (input.Split("\n"))
    Seq.map (Seq.cast) lines


let findMostCommonBit input =
    Seq.fold (fun (state: int seq) num ->
        Seq.zip state num
        |> Seq.map (fun (sc, nc) ->
            match nc with
            | '0' -> sc - 1
            | '1' -> sc + 1
        )
    ) (Seq.map (fun _ -> 0) (Seq.head input)) input
    |> Seq.map (fun i -> 
        if i <= 0 then '0' else '1')

let parseBinary (input: char seq) =
    System.String.Concat input
    |> (fun s -> System.Convert.ToUInt32(s, 2))

let solve1 (input: Input) =
    findMostCommonBit input
    |> parseBinary
    |> (fun i -> i * (~~~i &&& (uint 0b111111111111)))


let rec filter op mask (input: (char seq * char seq) seq) =
    let remaining = Seq.filter (fun (x, _) ->
        op (Seq.head mask) (Seq.head x)) input
    if Seq.length remaining > 1 then
        filter op (Seq.tail mask) (Seq.map (fun (x, og) -> (Seq.tail x, og)) remaining)
    else
        let (rest, og) = Seq.head remaining
        printfn "%A, %A" (Seq.toArray og, Seq.toArray rest) (Seq.length mask)
        og

let solve2 (input: Input) =
    let mask = findMostCommonBit input
    let (oxy, co2) = (
        filter (=) mask (Seq.map (fun x -> x, x) input),
        filter (<>) mask (Seq.map (fun x -> x, x) input))
    let (oxy, co2) = (parseBinary oxy, parseBinary co2)
    printfn "%A" (oxy, co2)
    (oxy * co2)
