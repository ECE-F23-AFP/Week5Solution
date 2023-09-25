module Week5.BST

type BST<'a when 'a: comparison> = 
   | Empty                   
   | Node of BST<'a>*'a*BST<'a>
   
val empty:        BST<'a>
val insertPred:   'a -> ('a -> int) -> BST<'a> -> BST<'a>
val insert:       'a -> BST<'a> -> BST<'a>
val containsPred: ('a -> int) -> BST<'a> -> bool
val contains:     'a -> BST<'a> -> bool
val removePred:   ('a -> int) -> BST<'a> -> BST<'a>
val remove:       'a -> BST<'a> -> BST<'a>
