module FsTests.Memoization

open System.Collections.Generic
open System.Text.RegularExpressions

let memoize fn =
    // Dictionary may grow in time 
    // May require LRU cache or Eviction mechanism 
    let cache = Dictionary<_,_>()
    fun x -> match cache.TryGetValue x with
             | true, v -> v
             | false, _ -> let v = fn (x)
                           cache.Add(x,v)
                           v

let regex(input, pattern) =
    Regex.Matches(input, pattern, RegexOptions.IgnoreCase)

// Function converted to memoized function
let memoizedRegex = regex