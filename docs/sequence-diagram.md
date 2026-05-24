# Sequence Diagram

```mermaid
sequenceDiagram

actor User

participant ConsoleUI
participant ProductService
participant Repository
participant Product

User->>ConsoleUI: Add product
ConsoleUI->>ProductService: CreateProduct()
ProductService->>Repository: Save(product)
Repository-->>ProductService: Product saved
ProductService-->>ConsoleUI: Success
ConsoleUI-->>User: Product added
```