# Developer Guide

# Architecture

The project uses layered architecture:

* Domain
* Application
* Infrastructure
* Console UI

---

# SOLID Principles

Implemented principles:

* Single Responsibility
* Open/Closed
* Dependency Inversion

---

# Design Patterns

Used patterns:

* Repository Pattern
* Strategy Pattern

---

# Running Tests

```bash
dotnet test
```

---

# Running Coverage

```bash
dotnet test /p:CollectCoverage=true /p:CoverletOutputFormat=opencover
```

---

# Persistence

Persistence layer uses:

* JSON files
* async file operations
* System.Text.Json

---

# Extending Project

New functionality should:

* respect layer boundaries
* avoid business logic in UI
* use interfaces for abstractions
* include tests

---

# CI/CD

GitHub Actions pipeline:

* restore
* build
* test
* coverage
