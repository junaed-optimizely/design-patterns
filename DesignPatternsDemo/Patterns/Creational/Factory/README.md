
## Factory

- Use the Factory Method when you don't know beforehand the exact types and dependencies of the objects your code should work with.
- Use the Factory Method when you want to provide users of your library or framework with a way to extend its internal components.
- Use the Factory Method when you want to save system resources by reusing existing objects instead of rebuilding them each time.

### Example: Logistics Scenario

This example demonstrates the Factory Method pattern using a logistics scenario:

- **Product Interface**: `ITransport` defines a `Deliver()` method.
- **Concrete Products**: `Truck` and `Ship` implement `ITransport`.
- **Creator (Abstract Factory)**: `Logistics` defines the factory method `CreateTransport()` and a method `PlanDelivery()` that uses the product.
- **Concrete Creators**: `RoadLogistics` and `OverSeaLogistics` override `CreateTransport()` to return a `Truck` or `Ship` respectively.

#### Code Structure

```csharp
public interface ITransport { string Deliver(); }
public class Truck : ITransport { public string Deliver() => "Delivering Road by Truck."; }
public class Ship : ITransport { public string Deliver() => "Delivering overseas by Ship."; }

public abstract class Logistics {
	public abstract ITransport CreateTransport();
	public string PlanDelivery() {
		var t = CreateTransport();
		return "Logistics: " + t.Deliver();
	}
}
public class RoadLogistics : Logistics {
	public override ITransport CreateTransport() => new Truck();
}
public class OverSeaLogistics : Logistics {
	public override ITransport CreateTransport() => new Ship();
}
```

#### Usage

```csharp
var road = new RoadLogistics();
Console.WriteLine(road.PlanDelivery()); // Logistics: Delivering Road by Truck.

var sea = new OverSeaLogistics();
Console.WriteLine(sea.PlanDelivery()); // Logistics: Delivering overseas by Ship.
```

This pattern allows the client code to work with factories and products without knowing their concrete types, making the code flexible and extensible.

**File:** [Factory.cs](./Factory.cs)
