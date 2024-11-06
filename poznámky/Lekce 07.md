# Poznámky z lekce 7 - Opakování, Refactoring, Dependency Injection 🦄

- backend máme prakticky hotový, od příští lekce frontend (asi 3 lekce)
- opakování mockování, viz prezentace
- repositoryMock.When().Do() - generické
- repositoryMock.Read().Returns() - nastavujeme return value
- repositoryMock.Throws() - vyhazujeme výjimku
- repositoryMock.Received().Read() - kontrolujeme zavolání metody

### Dependencies (závislosti)

- viz prezentace (definice)
- nevýhody - tight coupling (moje třída ovlivněna změnami v závislostech), moje třída musí vědět, jak se vytváří nebo konfigurují její závislosti, těžké vytvořit izolované unit testy, protože musím vytvořit reálnou implementaci závislé třídy
- v našem projektu mezi controller a repository - problém
- chceme využívat metody závislé třídy, ale její vytvoření chceme někde extrahovat
- direct dependencies chceme nahradit dependency injection

### Dependency injection

- závislost dáme jako paramtetr do konstruktoru
- umožňuje použití Depedency Inversion - kód by měl záviset na abstrakcích (interface) místo na konkrétních implementacích
- DI Container (nebo IoC Container) - struktura, která vytváří naše třídy, IServiceProvider (service container) - musíme do kontejneru zaregistrovat jednotlivé třídy, řeší závisloti, tj. která třída se má vytvořit (Resolve, Construct, Inject), takto z jednoho místa spravujeme všechny třídy
- náš kontejner nastavujeme přes builder.Services

### Swagger

- 
