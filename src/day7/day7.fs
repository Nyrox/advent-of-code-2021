module day7


type Input = int seq

let parseInput (input: string): Input =
    input.Split(",")
    |> Seq.map int


let calculateCostLin (target: int) (input: Input): int =
    input
    |> Seq.sumBy (fun i -> abs <| i - target)


let sumNNat n =
    (n * (n + 1)) / 2

let calculateCostH (target: int) (input: Input): int =
    input
    |> Seq.sumBy (fun i -> sumNNat (abs <| i - target))


let solve (heuristic: int -> Input -> int) (input: Input) =
    let average = int (Seq.average <| Seq.map float input)

    let dir = 
        if (heuristic average input) > (heuristic (average + 1) input) then
            (+)
        else
            (-)

    let mutable lastI = average
    let mutable last = heuristic average input
    let mutable next = 0

    let step () =
        next <- heuristic (dir lastI 1) input
        lastI <- dir lastI 1
        next < last

    while step() do
        last <- next

    last


let solve1 input = solve calculateCostLin input
let solve2 input = solve calculateCostH input