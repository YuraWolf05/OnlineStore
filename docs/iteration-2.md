# Iteration 2 - Lab 35

## Implemented

- JSON persistence (Load/Save)
- Order lifecycle (Pending → Paid → Shipped → Cancelled)
- Cart checkout use case
- Product catalog management
- Strategy pattern (discounts)
- LINQ analytics
- In-memory + Dictionary repository

---

## Business rules

- Order cannot be paid if cancelled
- Only paid orders can be shipped
- Stock is reduced on order creation
- Cart cannot be empty for checkout
- Product price must be > 0

---

## Use cases implemented

1. Add product
2. Add to cart
3. Create order
4. Pay order
5. View orders
6. Analytics (revenue)

---

## Patterns used

- Repository
- Strategy

---

## Risks

- Serialization dependency on domain model
- No database abstraction yet

---

## For next iteration (Lab 36)

- integration tests
- logging
- fault tolerance
- retry policies
- improved persistence layer