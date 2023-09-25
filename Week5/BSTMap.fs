module Week5.BSTMap

open Week5.BST

type BSTMap<'a, 'b when 'a: comparison and 'b : comparison> = BST<('a*'b)>

let empty:BSTMap<'a, 'b> = Empty
let insert key value (map: BSTMap<'a, 'b>): BSTMap<'a, 'b> =
    insertPred (key, value) (fun e -> if (key < fst e) then -1 elif (key > fst e) then 1 else 0) map

let private comparer elem = (fun e -> if (elem < fst e) then -1 elif (elem > fst e) then 1 else 0)

let contains a (map: BSTMap<'a, 'b>) =
    containsPred (comparer a) map

let remove a (map: BSTMap<'a, 'b>): BSTMap<'a, 'b> =
    removePred (comparer a) map
    