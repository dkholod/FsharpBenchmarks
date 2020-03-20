module FsTests.UnitsOfMeasure
open FSharp.UMX

[<Measure>] type customerId
[<Measure>] type customerName
type CustomerId = string<customerId>
type CustomerName = string<customerName>

type Customer = {
    Id: CustomerId
    Name: CustomerName
}

let createCustomer id name =
    { Name = id
      Id = name }

let lookupById (id: CustomerId) (customers: Customer[]) = 
    customers
    |> Array.filter(fun c -> c.Id = id)
    
let don = createCustomer %"Don Syme" %"1-34-5"

let customer' = Array.empty |> lookupById don.Id // compiles 

//let customer = Array.empty |> lookupById "1-34-5" // compiler error 
//  UnitsOfMeasure.fs(18, 33): [FS0001] This expression was expected to have type
//    'CustomerId' but here has type 'string'

