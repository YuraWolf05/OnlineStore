# Defense Checklist

# Main Demo Scenario

1. Start application
2. Show products
3. Create order
4. Pay order
5. Ship order
6. Save data
7. Restart application
8. Load saved data

---

# Negative Scenario

Attempt to ship unpaid order.

Expected result:
Business exception is thrown and handled.

---

# Architecture Questions

## Where is SRP used?

Services, repositories and entities have separated responsibilities.

---

## Where is OCP used?

Strategy Pattern allows adding new behaviors without changing existing logic.

---

## Where is DIP used?

Application layer depends on interfaces instead of implementations.

---

## Why layered architecture?

To isolate UI, business logic and persistence.

---

## Why Repository Pattern?

To abstract data storage implementation.

---

# Testing Questions

## Which tests are most important?

Order status transition tests.

---

## Why integration tests?

To verify persistence and interaction between layers.

---

## Why coverage is not enough?

Coverage does not guarantee correct assertions.

---

## What is tested with Theory?

Filtering and analytics scenarios.

---

## What is the most dangerous bug?

Invalid order state transitions.

---

# Tradeoff Questions

## Why JSON instead of database?

Simpler for educational capstone scope.

---

## Why console UI?

Focus was placed on architecture and business logic.

---

## What would be implemented next?

Database support and web API.
