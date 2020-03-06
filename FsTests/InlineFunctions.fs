module FsTests.InlineFunctions

open System

let condition() = Guid.NewGuid().ToString().StartsWith("a")

let inline add a b =
    if condition() then a + b else b + a

let addNumbers(a:int, b: int) =
    add a b

let addLinesAndNumbers() = 
    let s1 = add 70 7
    let s2 = add "dream " "big "
    (s1,s2)

type Line = {
        Title: string
        OverPoints: int
        UnderPoints: int
    }

type Selection = {
        Title: string
        Odds: int
    }

let setTitle title (l: Line) =
    { l with Title = title }

let setUnder(l: Line) =
    { l with UnderPoints = 1; }

let setOver(l: Line) =
    { l with OverPoints = 2 }    

let setOverUnder() =
    { Title = ""; OverPoints = 0; UnderPoints = 0 }
    |> setTitle "Over/Under"
    |> setOver
    |> setUnder
    
let inline fold f a (xs: _ []) =
    let mutable a = a
    for i=0 to xs.Length-1 do
       a <- f a xs.[i]
    a

let inline plus acc v = acc + v 
let count = fold plus 0 [|1..4|]  