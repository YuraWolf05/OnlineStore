# User Guide

## Application Purpose

OnlineStore is a console application for managing products, carts, and orders.

---

# Start Application

```bash
dotnet run --project src/OnlineStore.Console
```

---

# Main Features

## Product Management

Users can:

* view products
* create products
* manage stock

---

## Cart Operations

Users can:

* add products to cart
* remove products
* view total price

---

## Orders

Users can:

* create orders
* pay orders
* ship orders
* cancel orders

---

## Persistence

Application supports:

* saving to JSON
* loading from JSON

---

# Analytics

Users can:

* view order statistics
* filter products
* sort data

---

# Error Handling

The application validates:

* invalid prices
* invalid quantities
* invalid order transitions
* corrupted persistence files
