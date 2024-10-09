# Poznámky z lekce 3 - Interakce s REST API 🦄

- ukázka zapracování změn ze šablony Csharp3, viz návod
- před každou lekcí nová aktualizace do mainu - git pull template main --allow-unrelated-histories (viz návod) a mergování a řešení merge konflitků
- s REST API kounikujeme na základě requestů a responses, CRUD operace (těmi se dotazujeme serverů)

Zkoušíme GET
-dotnet watch - průběžně aktualizuje změny aplikace, nemusíme ji vypínat a zapínat, jen se někdy musí restartovat (lze automatizovat)

Web API Endpoint
- URL, která reprezentuje konkrétní zdroj, každý zdroj má unikátní endpoint, který umožňuje k němu přistupovat
- náš bude http://localhost:5000/ToDoItems - bude dělat CRUD metody, kromě POST /ToDoItems/1 (jedinečné ID konkrétního úkolu)
- C# metody viz prezentace
- server klientovi dává response ve formátu JSON
- měli bychom počítat i s chybami, že se něco pokazí - pošleme jiný status kód (200 je OK) - 4xx (nic se nenašlo, chyba na straně klienta) nebo 5xx (např. pád aplikace)
