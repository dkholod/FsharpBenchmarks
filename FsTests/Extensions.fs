module FsTests.Extensions

open Microsoft.FSharp.Reflection

let toString<'DU>() =
    typeof<'DU>
    |> FSharpType.GetUnionCases
    |> Array.map(fun i -> i.Name)

let fromString<'a> (s:string) =
    match FSharpType.GetUnionCases typeof<'a> |> Array.filter (fun case -> case.Name = s) with
    |[|case|] -> Some(FSharpValue.MakeUnion(case,[||]) :?> 'a)
    |_ -> None