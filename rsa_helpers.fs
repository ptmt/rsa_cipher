module rsa_helpers

open System.Numerics
open millerrabin

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

let modulus n m =
    ((n % m) + m) % m

let rec extended_gcd a b =
    if (a % b = BigInteger.Zero) then
        (BigInteger.Zero, BigInteger.One)
    else
        let (x, y) = extended_gcd b (a % b)
        (y, x - y * (a / b))

 
/// modulo_inverse(a,n) = b, such that a*b = 1 [mod n]
let modulo_inverse a n =
    let (x, y) = extended_gcd a n
    modulus x n

let IsLegalPublicExponent e totient =
    (BigInteger.One < e) && (e < totient) && (BigInteger.One = (BigInteger.GreatestCommonDivisor(e, totient)))

let PrivateExponent e totient =
    if (IsLegalPublicExponent e totient) then
        modulo_inverse e totient
    else
        raise (new System.Exception("Not a legal public exponent for that modulus"))