# Poznámky z lekce 8 - Blazor 🦄

- backend už máme hotový, ve firmě bychom přehodili na frontenďačku
- takto si sami dokončíme celý projekt, porozumíme full-stacku
- uvidíme, jak se používá naše API
- Razor- syntax, který kombinuje HTML a C#
- Blazor - framework na tvorbu webových aplikací (pomocí Razoru), Single Page Application (měníme pouze to, co je potřeba, neloadujeme celou stránku)

### HTML

- definuje obsah a strukturu, není programovací jazyk
- statické
- skládá se z HTML elementů
- <head> a <body> hlavní elementy
- syntax - viz prezentace - start tag, content, end tag
- <h1>Titulek</h1>
- <p>odstavec</p>
- <br> - nový řádek, line break, nemá closing tag
- <table>
- <tr> table row
- <td> table data

### Interaktivita

- @rendermode InteractiveServer

### Komponenty

- dílky rozhraní, přepoužitelný kus UI
- podobné HTML tagům, píšeme v PascalCase (ale je case insensitive)
- <Routes / > nebo <PageTitle>
- stránka je komponenta, která má sovjí cestu
- @page "/" direktiva zaregistruje cestu ke komponentě
