# Poznámky z lekce 5 - Databáze 🦄

- budeme používat ORM
- organizovaná kolekce dat, která umožňuje efektivní ukládání, správu a práci s daty
- table - columns a rows
- my použijeme SQLite, snadná instalace a ke komunikace Entity Framework Core (ORM, knihovna)

### Keys - primary a foreign
- PK jednoznačně identifikuje řádek, unikátní
- FK odkazuje na PK v jiné tabulce
- viz prezentace

### SQL - Structured Query Language
- programovací jazyk
- slouží k interakci s databází
- používáme protokol SQL query, dostáváme SQL response

### SQL vs NoSQL
- jsou i databáze, které nepoužívají SQL (například mapy fungují podle bodů - křižovatek - které si pamatují podle vektorů, se kterými dalšími body sousedí)
- např. články také neukládáme do tabulky
- obecně jsou SQL databáze nejvíce používané

### ORM
- object-relational mapping
- technika, která propojuje objetky z OOP jazyka s databázovými tabulkami

- k databázi přistupujeme vždy přes DbContext - třída, která nám přes Entity Framework umožňuje nahlížet na DB (SQL i NoSQL)
