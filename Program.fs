// Learn more about F# at http://fsharp.net

open System.Numerics

let rec toBinary (n:BigInteger) r =
    if n > BigInteger.Zero then
        toBinary (n/(BigInteger 2)) (r @ [n% (BigInteger 2)])
    else
        r

let test (a:BigInteger) (n:BigInteger) =
    let (b:List<BigInteger>) = toBinary (n - BigInteger.One) []
    let mutable d = BigInteger.One
    let mutable Prime = false
    let CheckList = [0 .. b.Length-1 ] |> List.rev
    for i in CheckList do
        let x = d
        d <- (d*d) % n
        if (d = BigInteger.One && x <> BigInteger.One && x <> n-BigInteger.One) then
            Prime <- true // complex
        if b.[i] = BigInteger.One then
            d <- (d*a) % n
    if d <> BigInteger.One then
        Prime <- true //complex
    Prime //if its still false then prime

let Rand = new System.Random()

let MillerRabin (n:int) (s:int) =
    let mutable Prime = true
    for j in [1 .. s+1] do
        let a = Rand.Next(1, n - 1)
        if (test (BigInteger a) (BigInteger n)) then
            Prime <- false
    Prime