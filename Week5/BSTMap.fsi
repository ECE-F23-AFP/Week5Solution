module Week5.BSTMap

open Week5.BST

type BSTMap<'a, 'b when 'a: comparison and 'b : comparison> = BST<('a*'b)>

val empty:    BSTMap<'a, 'b>
val insert:   'a -> 'b -> BSTMap<'a, 'b> -> BSTMap<'a, 'b>
val contains: 'a -> BSTMap<'a, 'b> -> bool
//val value:    'a -> BSTMap<'a, 'b> -> 'b
val remove:   'a -> BSTMap<'a, 'b> -> BSTMap<'a, 'b>