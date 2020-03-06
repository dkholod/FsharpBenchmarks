module FsTests.PatternMathc
    open System

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

    let private getEventType b = b
    let private footballEventType b = b
    let private tennisEventType b = b
    let private getRacingEventType b = b
    let private getBoxingEventType b = b

    let getBranchCases() =
        [|Soccer;Tennis;Greyhounds;Boxing;Others|]

    // Production code
    let getBranchEventType(b: Branch) =
        match b with
        | Soccer -> footballEventType b
        | Tennis -> tennisEventType b
        | Tote | HorseRacing | Greyhounds -> getRacingEventType b
        | Boxing -> getBoxingEventType b
        | _ -> getEventType b
    
    let data = [|true;false|]
        
    let getCondition() =
        data.[0]
        
    // Demo purpose re-write
    let getBranchEventTypeConditional(b: Branch) =
        match b with
        | Soccer when getCondition() -> footballEventType b
        | Tennis when not <| getCondition() -> tennisEventType b
        | Tote | HorseRacing | Greyhounds -> getRacingEventType b
        | Boxing -> getBoxingEventType b
        | _ -> getEventType b
    
    // Demo purpose re-write
    let getBranchEventTypeIFs(b: Branch) =
        if b = Soccer then footballEventType b
        else if b = Tennis then tennisEventType b
        else if b = Tote || b = HorseRacing || b = Greyhounds then getRacingEventType b
        else if b = Boxing then getBoxingEventType b
        else getEventType b
    
    // Demo purpose re-write
    let applyAmericanFlag(f: bool, team1: string, team2: string) =
        match f with
        | true  -> team2, team1
        | false -> team1, team2
 
    type Line = {
        Title: string
        OverPoints: int
        UnderPoints: int
    }
    
    let getTestLines() =
        let line = { Title = ""; OverPoints = 1; UnderPoints = 3 }
        [|
            {line with Title = "over"}
            {line with Title = "under"}
            {line with Title = "other"}
        |]
        
    let (|Over|Under|Underfined|) (title:string) =
        if title.StartsWith("over", StringComparison.OrdinalIgnoreCase) then Over
        else if title.StartsWith("under", StringComparison.OrdinalIgnoreCase) then Under
        else Underfined
    
    let getPoints(line) =
        match line.Title with
        | Over -> Some line.OverPoints
        | Under -> Some line.UnderPoints
        | Underfined -> None
    
    // prim-types.fs
//    [<StructuralEquality; StructuralComparison>]
//    [<CompiledName("FSharpChoice`2")>]
//    type Choice<'T1,'T2> = 
//      | Choice1Of2 of 'T1 
//      | Choice2Of2 of 'T2
      
    let (|Over'|_|) (title:string) =
        if title.StartsWith("over", StringComparison.OrdinalIgnoreCase)
        then Some Over' else None
    
    let (|Under'|_|) (title:string) =
        if title.StartsWith("under", StringComparison.OrdinalIgnoreCase)
        then Some Under' else None

    let getOverPoints(line) =
        match line.Title with
        | Over' -> Some (true, line)
        | _ -> None
    
    let getPointsPartial(line) =
        match line.Title with
        | Over' -> Some line.OverPoints
        | Under' -> Some line.UnderPoints
        | _ -> None
        