module day6

type Input = uint64 list
type Colony = (uint64) array

let zero = uint64 0
let one = uint64 1

let parseInput (input: string): Input =
    input.Split(",")
        |> Seq.map (uint64)
        |> Seq.toList

let colonyFromInput (input: Input): Colony =
    let colony = Array.create 9 zero
    Seq.iter (fun (i: uint64)-> Array.set colony (int i) (colony.[int i] + one)) input
    colony

let rec step left (input: Colony) =
    let newColony = Array.create (input.Length) zero
    if left <> 0 then
        for i in 1..8 do
                Array.set newColony (i - 1) (input.[i])
        Array.set newColony 8 (input.[0])
        Array.set newColony 6 (input.[0] + newColony.[6])
        step (left - 1) newColony
    else
        input

let solve1 (input: Input) =
    Seq.sum <| step 256 (colonyFromInput input)