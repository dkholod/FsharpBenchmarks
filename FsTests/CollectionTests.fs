module FsTests.Collections

let arrayItems = [|1..1_000|]

let arrayFilterItems() =
    arrayItems |> Array.filter(fun f -> f%2 = 0)
    
let setItems = Set.ofArray arrayItems
let setFilterItems() =
    setItems |> Set.filter(fun f -> f%2 = 0)
    
let listItems = List.ofArray arrayItems
let listFilter500kItems() =
    listItems |> List.filter(fun f -> f%2 = 0)

let setToArrayFilter500kItems() =
    setItems
    |> Set.toArray
    |> Array.filter(fun f -> f%2 = 0)
