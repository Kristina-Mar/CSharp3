# Poznámky z lekce 6 - Generika a repository pattern 🦄

### Generika

- vysvětlujeme mimo projekt
- špatně se vysvětluje, jasnější ukázka na příkladu
- generické typy nejsou specifické k určitému typu
- parametrizované typy
- výraz generics přesnější, český ekvivalent nic moc
- generické mohou být třídy, metody, rozhraní---
- bere 1 nebo několik typových parametrů
- přepoužitelnost kódu, silné typování (odlišné typy vyhodí kompilační chybu), lepší výkon (neboxujeme hodnotové typy)

Omezení pomocí where
- nechceme vždy povolovat všechny typy
- silnější typování
- můžeme využívat metody constrained typu

Generické kolekce
- nejčastější
- viz prezentace
- před generikou ArrayList

- pozor, ne všechno musí být generické

### Repository

- (návrhové) vzory - obecné řešení na problémy, které se běžně vyskytují
- toto je jeden ze vzorů, něco jako knihovna
- použijeme na obalení databáze, abychom k ní nepřistupovali napřímo
- poměrně často využívaný pattern, lze na tom vidět vrstvení jednotlivých pater architektury
- přepoužitelnost, centralizovaná logika, lepší testování, "oddělená" datová vrstva, může reprezentovat několik datových zdrojů, jednodušší vyměnit datový zdroj

### Mocking

- náhražka, falešná implementace
- mockování je proces vytváření objektů, které simulují chování reálných objektů
- výhody - nemusíme testovat DB, jen naší logiku, DB nám nerozbije testy, testy nespadnou při paralelním běhu
