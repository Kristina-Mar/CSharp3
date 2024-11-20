# Poznámky z lekce 9 - HTTP Client, Asynchronní Programování 🦄

### HTTP Client

- posílá a zpracovává HTTP requesty a přijímá DTOs (ve formátu JSON)

### Asynchronní programování

- dosud jsme používali synchronní sériové programování
- viz prezentace
- šetří čas, nemusíme čekat na konec každé operace, pokud to není potřeba
- u našeho projektu: lepší výkon, škálovatelnost, zjednodušení kódu díky Task (s i bez return typu) objektům a async/await keywords

### Paralelní práce

- multithreading, ne vždy máme k dispozici více threads (vlákna), můžeme si je udělat, ale může být potom těžší s nimi pracovat
- lze kombinovat s asynchronním programováním, nevylučuje se

### Závěrečný projekt

- úkol - přidat kategorie úkolů do celého projektu (backend + frontened)
- nullable string? field Category - nepovinný string, nemáme výběr apod.
- rozbijou se i testy!
- na příští lekci probereme editaci úkolů - EditItem component
- flow odevzdávání viz prezentace, na příští lekci upravit backend + testy
- do 4. 12 úprava frontendu + EditItem, opravy BE
- do 11. 12 vylepšení vzhledu, opravy, refactoring dle potřeby
- v komunitě na vše bude deadline 11. 12., ale odevzdávat průběžně na každou lekci
- k tomu budou i další povinné úkoly a funkcionality
