rsa_cipher fsharp
==
Простая реализация алгоритма RSA для шифрования c использованием генерации публичных/приватных ключей
http://en.wikipedia.org/wiki/RSA_cipher

### Модуль `millerrabin.fs` 

Функция 
`isPrimeW : seq<BigInteger> -> BigInteger -> bool` 
реализует [Алгоритм Миллера-Рабина](http://ru.wikipedia.org/wiki/%D0%A2%D0%B5%D1%81%D1%82_%D0%9C%D0%B8%D0%BB%D0%BB%D0%B5%D1%80%D0%B0_%E2%80%94_%D0%A0%D0%B0%D0%B1%D0%B8%D0%BD%D0%B0),
основанный на http://www.haskell.org/haskellwiki/Testing_primality и взятый отсюда http://fssnip.net/2w
Проверяет простоту чисел. Для очень больших чисел, например 1024 битных, определение строгой простоты занимает излишне много времени, алгоритм Миллера-Робина дает неплохую псевдопростоту.

### Модуль `rsa_helpers`

Содержит вспомогательные функции, например, такие как   
  `val GenPrime : int -> BigInteger` - создание сильно псевдопростого числа заданной длины с использованием побитовой случайной генерации и теста Миллера-Робина

### Алгоритм `program.fs`

1. Для первого этапа необходимо получить два простых числа `p` и `q` заданной длины `rsa_key_length`. 

2. Вычисляем модуль `n = p * q`

3. Вычисляем Euler totien function `totient`

4. В качестве публичного экспоненты берем 257 

5. Вычисляем приватную экспоненту с помощью функции `PrivateExponent` из модуля `rsa_helpers`

6. Публичные и приватные ключи готовы

### Полезные ссылки

Очень простая реализация http://www.fsharp.it/2008/12/01/implementation-of-rsa-in-f/
Миллер-Робин на Haskell http://www.haskell.org/haskellwiki/Testing_primality