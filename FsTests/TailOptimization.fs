module FsTests.TailOptimization

open System

type Item = {
    Id: string
}

type CacheItem = {
    Item: Item
    UpdatedAt: DateTime
}

let createNewCacheItem(item: Item, updatedAt) =
    printfn "side effect to hit breakpoint"
    { Item = item
      UpdatedAt = updatedAt }

let updateCacheItem(newItem: Item, oldItem: CacheItem option, updatedAt, createCacheItem) =
    match oldItem with
    | Some existingItem -> if existingItem.Item = newItem
                           then { existingItem with UpdatedAt = updatedAt }
                           else createCacheItem(newItem, updatedAt)
    | None -> createCacheItem(newItem, updatedAt)
    
let test1() =
    let oldCacheItem = Some { Item = { Id = "1"}; UpdatedAt = DateTime.UtcNow }
    let newItem = { Id = "2"}
    updateCacheItem(newItem, oldCacheItem, DateTime.UtcNow, createNewCacheItem)

// === Academic example ===
// Converted to loop - no
// .tail optimization - no
// Stack overflow - yes
let rec sumList xs =
    if List.head xs = 200
        then printf "breakpoint"
    match xs with
    | [] -> 0
    | h::t -> h + sumList t



// === Academic example ===
// Converted to loop - yes
// Stack overflow - no 
let rec sumListTail acc xs =
    if List.head xs = 200
        then printf "breakpoint"
    match xs with
    | [] -> acc
    | h::t -> sumListTail (acc + h) t


let test() =
    sumListTail 0 [1..300]