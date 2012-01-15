module rsa_cipher

open millerrabin
open rsa_helpers
open System.Numerics

let number_to_check = BigInteger(1259)
let isPrime = isPrimeW [2I;3I] // Two witnesses

isPrime number_to_check |> printfn "%b"

let rsa_key_length = 1024
let p = rsa_helpers.GenPrime rsa_key_length
let q = rsa_helpers.GenPrime rsa_key_length
let n = BigInteger.Multiply(p, q)
let totient = BigInteger.Multiply( (p - BigInteger.One) , (q - BigInteger.One))

let e = BigInteger(257)
let d = PrivateExponent e totient

printfn "RSA Public Key %s%s" (e.ToString()) (n.ToString())

printfn "RSA Private Key %s%s" (d.ToString()) (n.ToString())
  