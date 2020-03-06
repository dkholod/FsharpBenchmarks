module FsTests.StructuralEquality

type Selection = {
    AmericanOdds: int
    DecimalOdds: double
    IsEnabled: bool
}

let firstValue = { AmericanOdds = 420; DecimalOdds = 5.2; IsEnabled = true }
let secondValue = { AmericanOdds = 420; DecimalOdds = 5.2; IsEnabled = true }

let compare(a: Selection, b: Selection) =
    a = b