module Tests

open System
open Xunit
open Week5.BST

[<Fact>]
let ``Inserted elements should be stored in`` () =
    let empty' = empty
    let nonEmpty = insert 2 empty'
    Assert.True(contains 2 nonEmpty)

[<Fact>]    
let ``Inserted element should be able to remove`` () =
    let empty' = empty
    let nonEmpty = insert 2 empty'
    Assert.Equal(Empty, remove 2 nonEmpty)
    
[<Fact>]    
let ``Inserted elements should be able to remove`` () =
    let empty' = empty
    let nonEmpty = remove 2 (insert 1 (insert 2 empty'))
    Assert.True(contains 1 nonEmpty)
    

[<Fact>]    
let ``Inserted 3 elements should be able to remove`` () =
    let empty' = empty
    let tree = (insert 3 (insert 1 (insert 2 empty')))
    printfn "%O" tree
    let nonEmpty = remove 2 tree
    Assert.True(contains 1 nonEmpty)
    Assert.True(contains 3 nonEmpty)
    
