# Poznámky z lekce 2 - Webové technologie 🦄

- téma celého kurzu
- viz prezentace
- internet - má nějaké standardy, ale není jeden majitel, organizátor
- IP Adresa - Internet Protocol Address, jedinečné číslo zařízení na internetu
- 4,29 mld. - max. počet IP adres (32 bit, verze 4), docházejí nám -> postupně probíhá migrace na verzi 6 (128 bit), kde nehrozí, že by adresy došly
- DNS - Domain Name System - "internetový telefonní seznam"
- prohlížeče - způsob, kterým komunikujeme s internetem - webové stárnky hledáme podle URL (Uniform Resource Locator)
- Ctrl + Shift + I - developer tools na webu, taky F12
- port - jeden z přístupových bodů k serveru (HTTP má port 80)
- HTTP - HyperText Transfer Protocol
- pomocí tohoto protokolu posíláme informace ze serveru na server nebo ke klientovi
- první je GET request
- HTML - HyperText Markup Language, jazyk, kterým definujeme strukturu a obsah webové stránky, není to programovací jazyk, nepotřebuje zbuildovat, neprobíhá kompilace
- CSS - definuje vzhled stránky, Cascading Style Sheets
- inlinovaný styl - přímo v tagu, často jsou styly v samostatném souboru
- JavaScript - chování, interaktivita, už je programovací jazyk
- místo JavaScriptu můžeme psát C# díky Blazor - jak back-end na serveru, tak i v prohlížeči, který data zobrazuje
- další obsah webu - média
- HTML dokument je reprezentovaný DOM - Document Object Model, všechny prvky, udává strukturu dokumentu v prohlížeči -> to, co my vidíme, už je vyrenderované
- prohlížeč také spouští JavaScript soubory, které targetují DOM, resp. jeho prvky a přidávají jim interaktivitu

## Web API
- request typu POST - snažíme se poslat nějaká data na server (payload)
- způsob, jakým requestujeme a posíláme data ze serveru a na něj (klient <-> server)
- Application Programming Interface
- má nějakou definici toho, jak komunikovat se serverem tak, aby služba rozuměla a splnila klientem zadaný požadavek (request)
- Web API je typ API, které je dostupné na počítačové síti, např. internetu, typicky využívá ke komunikaci protokol HTTP
- requesty - POST, GET, PUT, DELETE
- API si postavíme v C# (backend, tímto začneme) + frontend Blazor (zkompiluje C# kód do Web assembly - jazky, kterému web nativně rozumí) + databáze úkolů (backend), viz schéma v prezentaci
- JSON - JavaScript Object Notation - běžný formát, kterým se posílají requesty/data, lehce se převádí do JavaScriptu a zároveň je lidsky čitelný

## REST API
- REpresentional State Transfer
- jeden způsob, jak můžeme psát API, má nějaké principy, jak má API fungovat
- Stateless, Client-Server, Uniform Interface, Layered System, Cacheable, Code on demand
- často nejsou všechny principy v praxi naplněny
- dodržuje REST architekturální styl
- zdroj v REST API - jakýkoliv objekt, dokument nebo věc, kterou API dokáže přijímat nebo posílat kleintům
- URI - Uniform Resource Identifier
- jak interagovat s REST API - CRUD operace - odpovídají HTTP metodám
- Create - POST, vytvoří nový zdroj, často se v praxi používá i pro jiné věci, pozor
- Read - GET, získá reprezentaci/stav zdroje
- Update - PUT, modifikace zdroje
- Delete - DELETE, smaže zdroj

- Ctrl + C - ukončí běh programu
