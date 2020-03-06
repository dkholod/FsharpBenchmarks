module FsTests.PipesAndFuncs

let test() =
    [1..10]
    |> List.filter(fun i -> i > 5)
    |> List.map((*) 2)
    |> List.groupBy(fun i -> i > 14)