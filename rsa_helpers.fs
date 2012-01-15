module rsa_helpers

open System.Numerics

let Rand = new System.Random()

let rec BigIntegerSize n =
    if n > BigInteger.Zero then
        BigIntegerSize(n>>>1) + 1
    else
       0

let GetRandomBit =    
    Rand.Next(0,2)

let rec GenRandomCandidate (size:int, i:int, c:BigInteger) =
    if (i=size) then c
    else GenRandomCandidate (size, (i+1), (c<<<1)+BigInteger(GetRandomBit))

let PrimalityTestWrapper (n:BigInteger) =    
    if n % BigInteger(2) = BigInteger.Zero then
        false
    else 
        millerrabin.isPrimeW [2I;3I] n

let rec SearchPrime c =    
    match PrimalityTestWrapper c  with
    | true -> c
    | _ -> SearchPrime (c + BigInteger.One)
      
// сгенирировать случайное простое (псевдопростое) число заданного размера size 
let GenPrime size =
    SearchPrime (GenRandomCandidate(size, 1, BigInteger.One))

