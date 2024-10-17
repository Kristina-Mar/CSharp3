# Poznámky z lekce 4 - Testování kódu 🦄

### Routing

- rozhoduje, jaká akce nebo část kódu se má spustit na základě cesty zadané v URL a podle použité metody

### DTO

- objekt, který slouží na přenos dat mezi procesy nebo aplikacemi
- JSON je asi nejpopulárnější formát pro DTO, nativní pro prohlížeče (vytvořeno pro JavaScript)
- serializace - ze C# objektu na JSON, zpět je to deserializace
- hlavní důvod, proč definujeme jak třídy, tak DTOs - pokud bychom např. provedli změnu ve třídě, nastala by chyba u klienta, takhle si můžeme měnit věci na backendu ve třídě a DTO může zůstat stejné

### Testování - unit testing

- testování dílčích jednotek, které testujeme separátně
- každá část kódu je testována v izolaci bez externích závislostí
- u REST API (i obecně) jsou jednotkami jednotlivé metody, na jednotku může být víc testů
- jednou z částí pro unit testy u REST API jsou kontrolery, další budeme probírat později
- je to rychlá kontrola správnosti kódu
- výhodou je, že napíšeme jen jednou, dále můžeme testovaný kód upravovat bez obav
- snížení dopadu chyb
- živá dokumentace a specifikace - vlastně vysvětlujeme, jak se má kód chovat, napomáhá srozumitelnosti
- mělo by jich být nejvíce v pyramidě testování (levné, rychlé) -> dále integrační testy (propojení jednotek) a E2E (end-to-end, celá aplikace, složité na napsání, jednodušší je rozbít - časté změny UI, pomalejší)

### Testovací frameworky

- nástroje na testování
- v .NET - nUnit, MSTest, xUnit - principy všude stejné
- NuGet.org - package manager (balíčky), kdokoliv tam může zveřejnit svou knihovnu a sdílet, řeší za nás verzování nebo závislosti balíčků, přepoužitelnost kódu

### Jak psát testy

- AAA pattern - Arrange (příprava kódu pro test), Act (vykonání testované akce), Assert (kontrola výstupu akce)
- dotnet test - nebo záložka testy a tam šipkou
- dělení nulou - u int vrátí DivideByZeroException u float nekonečno (float.PositiveInfinity)

### Test Driven Development

- kontroverzní koncept
- častá otázka na pohovorech (taky testovací pyramida)
- nejdřív se píšou testy, potom se píše kód
- přístup k vývoji softwaru, který je založen na psaní testů před napsáním logiky produkčního kódu
- cyklus write a failing test -> make the test pass -> refactor, viz prezentace
- vývoj je zaměřený na požadavky/funkcionalitu, ne na implementaci
- větší pokrytí produkčního kódy testy
- když se vezme příliš daleko, strávíme velký čas psaním testů a následně zjistíme, že to nefunguje, předpokládaná struktura nefunguje apod.
- vyzkoušíme si, ať si můžeme udělat vlastní názor

### Mocking

- proces vytváření objektů (Mocků), které simulují chování reálných objektů
- mocky lze v testovacím prostředí upravovat a nastavovat jejich chování
- typy zástupných objektů - dummy, stub, spy, mock, fake - podobné, abychom věděly, o co se jedná zhruba

### Mockovací frameworky

- N substitute, MOQ, Fake It Easy

### Tipy

- testujeme pouze jeden scénář
- jméno přesně říká, co se testuje (Metoda_Scénář_Výsledek)
- nejjednodušší procházející test
- konzistentní struktura
- co nejméně logiky
- debugger je kamarád
- [Theory]
- FluentAssertions
