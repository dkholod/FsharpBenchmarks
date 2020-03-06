module FsTests.PartialApplication

let tupleAdd(a, b) = 
    a + b

let curriedAdd a b = 
    a + b

let addOne = curriedAdd 1

let test(a, b, addOne, addTuples, addCurried) =
    let ab = (a, b)
    let r1 = tupleAdd ab
    let r2 = tupleAdd(a, b)
    let r3 = curriedAdd a b    
    let r4 = addTuples(a,b)
    let r5 = addOne b
    let r6 = addCurried a b
    (r1, r2, r3, r4, r5, r6)

let exec() =
    test(1, 2, addOne, tupleAdd, curriedAdd)
