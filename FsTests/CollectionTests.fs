module FsTests.Collections
open System
open System.Collections.Generic

let toAmericanOdds (odds: float) =
    int <| (odds - 1.) * 100.0

type Line = {
    Points: int
    DecimalOdds: float
    AmericanOdds: int
}

let rnd = Random()

let getRandomDecOdds =
    let rnd = Random()
    fun () -> rnd.NextDouble() + float (rnd.Next(2))

let generateLinesSeq n =
    seq { for a in 1 .. n
                do yield { Points = rnd.Next(20) + 1
                           DecimalOdds = getRandomDecOdds()
                           AmericanOdds = 0 } }

//================SEQ    
let seqTest lines =
    lines
    |> Seq.map(fun l -> toAmericanOdds l.DecimalOdds)
    |> Seq.filter(fun odds -> odds > 0)
    |> Seq.sum

let ten_lines_seq = generateLinesSeq 10
let thousand_lines_seq = generateLinesSeq 1000
let million_lines_seq = generateLinesSeq 1_000_000

let seqTest10() = seqTest ten_lines_seq
let seqTest1K() = seqTest thousand_lines_seq
let seqTest1M() = seqTest million_lines_seq

//================LIST
let listTest lines =
    lines
    |> List.map(fun l -> toAmericanOdds l.DecimalOdds)
    |> List.filter(fun odds -> odds > 0)
    |> List.sum

let ten_lines_list = generateLinesSeq 10 |> List.ofSeq
let thousand_lines_list = generateLinesSeq 1000 |> List.ofSeq
let million_lines_list = generateLinesSeq 1_000_000 |> List.ofSeq

let listTest10() = listTest ten_lines_list
let listTest1K() = listTest thousand_lines_list
let listTest1M() = listTest million_lines_list

//================ARRAY
let arrayTest lines =
    lines
    |> Array.map(fun l -> toAmericanOdds l.DecimalOdds)
    |> Array.filter(fun odds -> odds > 0)
    |> Array.sum

let ten_lines_array = generateLinesSeq 10 |> Array.ofSeq
let thousand_lines_array = generateLinesSeq 1000 |> Array.ofSeq
let million_lines_array = generateLinesSeq 1_000_000 |> Array.ofSeq

let arrayTest10() = arrayTest ten_lines_array
let arrayTest1K() = arrayTest thousand_lines_array
let arrayTest1M() = arrayTest million_lines_array

//================Seq 2 ARRAY
let seqToArrayTest lines =
    lines
    |> Array.ofSeq
    |> Array.map(fun l -> toAmericanOdds l.DecimalOdds)
    |> Array.filter(fun odds -> odds > 0)
    |> Array.sum

let seqToArrayTest10() = seqToArrayTest ten_lines_seq
let seqToArrayTest1K() = seqToArrayTest thousand_lines_seq
let seqToArrayTest1M() = seqToArrayTest million_lines_seq

//================NESSOS on array
open Nessos.Streams

let nessosTest lines =
    lines
    |> Stream.map(fun l -> toAmericanOdds l.DecimalOdds)
    |> Stream.filter(fun odds -> odds > 0)
    |> Stream.sum

let ten_lines_nessosOfArray = ten_lines_array |> Stream.ofArray
let thousand_lines_nessosOfArray = thousand_lines_array |> Stream.ofArray
let million_lines_nessosOfArray = million_lines_array |> Stream.ofArray

let nessosOnArrayTest10() = nessosTest ten_lines_nessosOfArray
let nessosOnArrayTest1K() = nessosTest thousand_lines_nessosOfArray
let nessosOnArrayTest1M() = nessosTest million_lines_nessosOfArray

//================NESSOS on seq
let ten_lines_nessosOfSeq = ten_lines_seq |> Stream.ofSeq
let thousand_lines_nessosOfSeq = thousand_lines_seq |> Stream.ofSeq
let million_lines_nessosOfSeq = million_lines_seq |> Stream.ofSeq

let nessosOnSeqTest10() = nessosTest ten_lines_nessosOfSeq
let nessosOnSeqTest1K() = nessosTest thousand_lines_nessosOfSeq
let nessosOnSeqTest1M() = nessosTest million_lines_nessosOfSeq

//================LINQ on Array
open System.Linq

let linqTest(lines: IEnumerable<Line>) =
    lines
        .Select(fun l -> toAmericanOdds l.DecimalOdds)
        .Where(fun odds -> odds > 0)
        .Sum()

let linqOnArrayTest10() = linqTest ten_lines_array
let linqOnArrayTest1K() = linqTest thousand_lines_array
let linqOnArrayTest1M() = linqTest million_lines_array

//================LINQ on SEQ
let linqOnSeqTest10() = linqTest ten_lines_seq
let linqOnSeqTest1K() = linqTest thousand_lines_seq
let linqOnSeqTest1M() = linqTest million_lines_seq