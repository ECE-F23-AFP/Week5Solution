module Week5.Deque

type Deque<'a> = 'a list * 'a list

let length ((l, r): Deque<'a>) = List.length l + List.length r
let insert a ((l, r): Deque<'a>) = (l, a::r)
let head ((l,_): Deque<'a>) = List.head l

let rec remove = function
    | ([], []) -> failwith "Remove from empty"
    | ([], r)  -> remove (List.rev r, [])
    | (l, r)   -> (List.tail l, r)
