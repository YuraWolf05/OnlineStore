# Test Strategy

## Critical scenarios

The following scenarios are considered critical:

1. Creating an order from cart
2. Saving and loading data from JSON
3. Order status transitions
4. Product stock validation
5. Discount strategy execution

---

## Hardest parts to test

### Persistence layer
Reason:
- file I/O
- async operations
- corrupted JSON handling

### Order lifecycle
Reason:
- multiple status transitions
- invalid states
- business restrictions

---

## Mock vs Real Integration

### Mocks
Used for:
- repositories
- strategy testing
- isolated service testing

### Real integration
Used for:
- JSON persistence
- full order workflow
- file recovery scenarios

---

## High-risk negative scenarios

1. Corrupted JSON file
2. Missing data file
3. Empty cart checkout
4. Invalid order status transition
5. Negative product stock
6. Duplicate product insertion
7. Persistence save failure

---

## Testing goals

- prevent regressions
- verify business rules
- validate persistence
- validate fault handling
- improve maintainability