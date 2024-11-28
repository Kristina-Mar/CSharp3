# Lekce 10 - Blazor 2 🦄

- druhá a poslední část Blazoru - bude hotový frontend

### CSS

- Cascading Style Sheets
- stylovací jazyk
- definujeme - interně (v hlavičce), externě (odkaz na soubor), inline (přímo v HTML tagu)
- kaskádování - výchozí CSS prohlížečů (dodnes není sjednocené) -> externí soubor -> CSS z hlavičky -> inline CSS
- syntax - selector (na co aplikujeme) {property:value; property:value}
- dá se lehce ukrást, není nijak zašifrované, např. extension Button Stealer

### Bootstrap

- nejpopulárnější CSS framework, často se používá s Blazorem
- není se třeba učit CSS
- obsahuje i nějakou interaktivitu
- v prezentaci viz pár základních tříd pro náš projekt
- class - typ selektoru
- <div> sám o sobě nic nedělá, organizace elementů a společné stylování

### Formy

- pro získání vstupu od uživatelů
- mají pokročilejší nástroje na validaci
- Two-Way Data Binding - navázání dat v UI a databázi/backendu, pomocí eventu onchange se propíše změnená hodnota z formu do backendu

### Hotový frontend?

- zatím jen načítáme položky z databáze (Get), ale nemáme použité další metody
