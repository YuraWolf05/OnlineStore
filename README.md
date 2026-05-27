# OnlineStore

<<<<<<< HEAD
Підсумковий міні-проєкт з дисципліни ООП.  
Проєкт реалізує консольний інтернет-магазин із багатошаровою архітектурою, бізнес-логікою, persistence, тестуванням та CI/CD.

---

# Опис проєкту

OnlineStore — це консольний застосунок для управління інтернет-магазином.

Система дозволяє:
- працювати з каталогом товарів;
- створювати кошик;
- оформлювати замовлення;
- змінювати статуси замовлень;
- виконувати аналітичні запити;
- зберігати та відновлювати дані з JSON.

Проєкт створений як ітеративний capstone-проєкт для лабораторних робіт 34–37.

---

# Архітектура

Проєкт побудований за принципами:
- SOLID
- Separation of Concerns
- Layered Architecture

## Структура solution

```text
OnlineStore/
├── src/
│   ├── OnlineStore.Domain/
│   ├── OnlineStore.Application/
│   ├── OnlineStore.Infrastructure/
│   └── OnlineStore.Console/
│
├── tests/
│   └── OnlineStore.Tests/
│
├── docs/
│   ├── vision.md
│   ├── backlog.md
│   ├── class-diagram.md
│   ├── sequence-diagram.md
│   ├── iteration-1.md
│   └── iteration-2.md
│
├── .github/workflows/
│   └── dotnet.yml
│
└── OnlineStore.sln
=======
Підсумковий міні-проєкт з дисципліни ООП.

OnlineStore — це консольний інтернет-магазин, реалізований із використанням багатошарової архітектури, принципів SOLID, бізнес-логіки, persistence, тестування та CI/CD.

Проєкт розвивається ітеративно протягом лабораторних робіт 34–37.
>>>>>>> ff548fc (lab36 ready)

---

# Опис проєкту

Система дозволяє:

- працювати з каталогом товарів;
- додавати товари в кошик;
- створювати замовлення;
- змінювати статуси замовлення;
- виконувати аналітичні LINQ-запити;
- зберігати та відновлювати дані з JSON;
- виконувати автоматичне тестування;
- перевіряти quality gate через GitHub Actions.

---

# Архітектура

Проєкт побудований за принципами:

- SOLID
- Separation of Concerns
- Layered Architecture
- Dependency Inversion

---

# Структура solution

OnlineStore/
├── src/
│   ├── OnlineStore.Domain/
│   ├── OnlineStore.Application/
│   ├── OnlineStore.Infrastructure/
│   └── OnlineStore.Console/
│
├── tests/
│   └── OnlineStore.Tests/
│
├── docs/
│   ├── vision.md
│   ├── backlog.md
│   ├── class-diagram.md
│   ├── sequence-diagram.md
│   ├── iteration-1.md
│   ├── iteration-2.md
│   ├── iteration-3.md
│   ├── test-strategy.md
│   └── test-matrix.md
│
├── .github/workflows/
│   └── dotnet.yml
│
├── TESTING.md
│
└── OnlineStore.sln
---

# Основний функціонал

Реалізовано
- Каталог товарів
- Кошик
- Створення замовлення
- Зміна статусів замовлення
- JSON persistence
- LINQ-запити
- Аналітика
- Logging
- Unit tests
- Integration tests
- Coverage
- CI/CD pipeline
- Бізнес-правила
- Товар не може мати ціну <= 0
- Кількість товару не може бути від’ємною
- Замовлення не може бути порожнім
- Тільки оплачене замовлення може бути відправлене
- Відправлене замовлення не можна скасувати
- Скасоване замовлення не можна оплатити
- Патерни проєктування

---

У проєкті використано:

- Repository Pattern
- Strategy Pattern

---

Технології
- C#
- .NET 10
- xUnit
- System.Text.Json
- Coverlet
- GitHub Actions

---

<<<<<<< HEAD
## Run application

```bash
dotnet run --project src/OnlineStore.Console
```

---

## Run tests

```bash
dotnet test
```
=======
Запуск проєкту
- Build
- dotnet build
- Run application
- dotnet run --project src/OnlineStore.Console

---

Тестування
- Run tests
- dotnet test
- Run coverage
- dotnet test /p:CollectCoverage=true /p:CoverletOutputFormat=opencover
>>>>>>> ff548fc (lab36 ready)
