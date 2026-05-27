# OnlineStore

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

---

## Technologies

- C#
- .NET
- xUnit
- GitHub Actions

---

## Run application

```bash
dotnet run --project src/OnlineStore.Console
```

---

## Run tests

```bash
dotnet test
```
