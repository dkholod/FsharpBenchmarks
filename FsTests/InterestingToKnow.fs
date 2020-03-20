module FsTests.InterestingToKnow

open System

// 30 cases, Soccer is first, Greyhounds - last
type Branch =
    | Soccer
    | Basketball
    | AmericanFootball
    | Tennis
    | Baseball
    | IceHockey
    | Handball
    | RugbyLeague
    | Snooker
    | Darts
    | Volleyball
    | Boxing
    | Hockey
    | Futsal
    | TableTennis
    | Bowls
    | BeachVolleyball
    | Badminton
    | RugbyUnion
    | AussieRules
    | Cricket
    | Netball
    | ESport
    | SoccerCorners
    | Tote
    | Trotting
    | HorseRacing
    | Greyhounds
    | Others

// 30 cases, Soccer is first, Greyhounds - last
//type Branch = | Soccer | Basketball...

let branchToString(b: Branch) =
    string b

let concat (st:string, i:int) =
    sprintf "%s:%i" st i

let format (st:string, i:int) =
    String.Format("{0}:{1}", st, i)
    
let extractData(event) =
    struct (Greyhounds, "" )

let e = 1

[<Struct>]
type Selection = {
        Title: string
        Odds: int
    }

[<Struct>]
type RacingBranch =
    | HorseRacing
    | Greyhounds
    | Tote

let struct (selection, branch) = extractData(e)

type MutableSelection = {
        mutable MutableTitle: string
        Odds: int
    }

let ms = { MutableTitle = "title"; Odds = 1 }
ms.MutableTitle <- "new title"

[<StructuralEquality; StructuralComparison>]
[<Struct>]
type ValueOption<'T> =
    | ValueNone
    | ValueSome of 'T

[<StructuralEquality; StructuralComparison>]
[<CompiledName("FSharpResult`2")>]
[<Struct>]
type Result<'T,'TError> =
    | Ok of ResultValue:'T
    | Error of ErrorValue:'TError


// BAD
let nullCheck x = (x = null)
let isDefaulf x = x = Unchecked.defaultof<_>

// GOOD
let nullCheckMatch x = match x with null -> true | _ -> false
let nullCheckRefEqls (x : 't when 't : null) = System.Object.ReferenceEquals(x, null)
