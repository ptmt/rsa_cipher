rsa_cipher fsharp
==
Простая реализация алгоритма RSA для шифрования c использованием генерации публичных/приватных ключей
[wiki:RSA_cipher](http://en.wikipedia.org/wiki/RSA_cipher)

### Модуль `millerrabin.fs` 

`millerRabinPrimality` [Алгоритм Миллера-Рабина](http://ru.wikipedia.org/wiki/%D0%A2%D0%B5%D1%81%D1%82_%D0%9C%D0%B8%D0%BB%D0%BB%D0%B5%D1%80%D0%B0_%E2%80%94_%D0%A0%D0%B0%D0%B1%D0%B8%D0%BD%D0%B0)
Проверяет простоту чисел. 
Например, 1024 бит. Определение того, что число псевдопростое занимает гораздо меньше времени, при этом алгоритм Миллера-Рабина даёт неплохую сильную псевдопростоту. 
Реализация основана на http://www.haskell.org/haskellwiki/Testing_primality и взята отсюда http://fssnip.net/2w

### `rsa_helpers`

### Алгоритм

1. Для первого этапа необходимо получить два простых числа заданной длины `rsa_key_length`. 

3. 

### Полезные ссылки

Очень простая реализация http://www.fsharp.it/2008/12/01/implementation-of-rsa-in-f/