module rsa_cipher

open millerrabin
open rsa_helpers
open System.Numerics

let number_to_check = BigInteger(1259)
let isPrime = isPrimeW [2I;3I] // Two witnesses
//let p = pown 2I 4423 - 1I // 20th Mersenne prime. 1,332 digits
isPrime number_to_check |> printfn "%b"

let rsa_key_length = 1024
let primeNumberA = rsa_helpers.GenPrime rsa_key_length
let primeNumberB = rsa_helpers.GenPrime rsa_key_length


  