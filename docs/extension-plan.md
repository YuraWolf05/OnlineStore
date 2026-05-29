# Extension Plan

# Extension A - Dynamic Filter Pipeline

Goal:
Create flexible product filtering using delegates and predicates.

Result:
A reusable filtering mechanism for analytics and search.

---

# Extension B - Advanced Analytics

Goal:
Build advanced LINQ analytics on top of the filtering pipeline.

Features:

* top expensive products;
* grouped statistics;
* dynamic filtering.

Result:
Reusable analytics layer.

---

# Extension C - Parameterized Tests

Goal:
Create Theory-based tests for the filtering and analytics pipeline.

Result:
Improved reliability and edge-case validation.

---

# Dependency Chain

Extension B depends on Extension A.

Extension C tests Extension B and A together.
