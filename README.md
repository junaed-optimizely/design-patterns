## Design Patterns
- [Object Pool](./DesignPatternsDemo/Patterns/Creational/ObjectPool/README.md)
- [Factory](./DesignPatternsDemo/Patterns/Creational/Factory/README.md#factory)
- [Abstract Factory](./DesignPatternsDemo/Patterns/Creational/Factory/README.md#abstract-factory)
- [Builder](./DesignPatternsDemo/Patterns/Creational/Builder/README.md)


## OOP relationships

| Relationship Type | Conceptual Phrase | Example | Strength | Lifetime Dependency |
|-------------------|------------------|----------|-----------|----------------------|
| **Inheritance** | *is-a* | `Dog` → `Animal` | Strong | Child class depends on parent class |
| **Composition** | *strong has-a* | `Car` → `Engine` | Strong | Owned object destroyed with owner |
| **Aggregation** | *weak has-a* | `Employee` → `Department` | Medium | Owned object can outlive owner |
| **Association** | *uses-a / knows-a* | `Driver` → `Car` | Weak | Temporary or contextual |
| **Dependency** | *depends-on* | `OrderService` → `PaymentGateway` | Weak | Used only during interaction |

