module Week5.BST

type BST<'a when 'a: comparison> = 
   | Empty                   
   | Node of BST<'a>*'a*BST<'a>
   
let empty = Empty

let private comparer elem = (fun e -> if (e < elem) then -1 elif (e > elem) then 1 else 0)

// 1.2 
let rec insertPred elem pred bst =
   match bst with
   | Empty                          -> Node(Empty, elem, Empty)
   | Node (l, a, r) when pred a < 0 -> Node(l, a, insertPred elem pred r)
   | Node (l, a, r) when pred a > 0 -> Node(insertPred elem pred l, a, r)
   | _                              -> bst

let insert elem bst = insertPred elem (comparer elem) bst

// 1.1
//let rec insert elem bst =
//   match bst with
//   | Empty                        -> Node(Empty, elem, Empty)
//   | Node (l, a, r) when a < elem -> Node(l, a, insert elem r)
//   | Node (l, a, r) when a > elem -> Node(insert elem l, a, r)
//   | _                            -> bst
   

// 1.2 contains
let rec containsPred p = function
   | Empty                        -> false
   | Node (_, a, r) when p a < 0  -> containsPred p r
   | Node (l, a, _) when p a > 0  -> containsPred p l
   | _                            -> true

let contains elem bst = containsPred (comparer elem) bst

// 1.1 contains
//let rec contains elem = function
//   | Empty                        -> false
//   | Node (_, a, r) when a < elem -> contains elem r
//   | Node (l, a, _) when a > elem -> contains elem l
//   | _                            -> true
   
let rec private inOrderSuccessor elem = function
   | Empty -> elem
   | Node(Empty, a, Empty) -> a
   | Node(Empty, _, r) -> inOrderSuccessor elem r
   | Node(l, _, Empty) -> inOrderSuccessor elem l
   | _ -> failwith "Can this ever happen"

// 1.2
let rec removePred pred = function
   | Empty                          -> Empty
   | Node (l, a, r) when pred a < 0 -> Node(l, a, removePred pred r)
   | Node (l, a, r) when pred a > 0 -> Node(removePred pred l, a, r)
   | Node(l, a, r)                  ->
      match (l, r) with
      | (Empty, Empty)            -> Empty
      | (Empty, Node(l', a', r')) -> Node(l', a', r')
      | (Node(l', a', r'), Empty) -> Node(l', a', r')
      | (_, _)                    ->
         let successor = inOrderSuccessor a r
         printfn "Successor: %O" successor
         let r' = removePred (comparer successor) r
         Node(l, successor, r')

let remove elem bst = removePred (comparer elem) bst

// 1.1 remove
//let rec remove elem = function
//   | Empty                        -> Empty
//   | Node (l, a, r) when a < elem -> Node(l, a, remove elem r)
//   | Node (l, a, r) when a > elem -> Node(remove elem l, a, r)
//   | Node(l, a, r)                ->
//      match (l, r) with
//      | (Empty, Empty)            -> Empty
//      | (Empty, Node(l', a', r')) -> Node(l', a', r')
//      | (Node(l', a', r'), Empty) -> Node(l', a', r')
//      | (_, _)                    ->
//         let successor = inOrderSuccessor a r
//         printfn "Successor: %O" successor
//         let r' = remove successor r
//         Node(l, successor, r')