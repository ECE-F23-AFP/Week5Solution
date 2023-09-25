module Week5.Deque

type Deque<'a> = 'a list * 'a list

val length: Deque<'a> -> int
val insert: 'a -> Deque<'a> -> Deque<'a>
val head: Deque<'a> -> 'a
val remove: Deque<'a> -> Deque<'a>