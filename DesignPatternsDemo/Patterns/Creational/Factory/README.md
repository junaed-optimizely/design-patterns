
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

---

## Abstract Factory

The Abstract Factory pattern provides an interface for creating families of related or dependent objects without specifying their concrete classes. It is useful when your code needs to work with various families of products, but you want to ensure that products from the same family are used together.

### Example: Cross-Platform UI Library

This example demonstrates the Abstract Factory pattern using a cross-platform UI library scenario:

- **Product Interfaces**: `IButton` and `IDialog` define the interfaces for UI components.
- **Concrete Products**: `WinButton`, `WinDialog`, `MacButton`, and `MacDialog` implement the product interfaces for Windows and Mac platforms.
- **Abstract Factory**: `IGUIFactory` declares methods for creating abstract products (`CreateButton`, `CreateDialog`).
- **Concrete Factories**: `WinGUIFactory` and `MacGUIFactory` implement the abstract factory to create platform-specific products.

#### Code Structure

```csharp
interface IButton { string SetSize(ButtonSize size); }
interface IDialog { string SetDimensions(int w, int h); string AddButton(IButton button); }

class WinButton : IButton { public string SetSize(ButtonSize size) => "[Windows Button]" + size; }
class WinDialog : IDialog {
	public string SetDimensions(int w, int h) => $"[Windows Dialog W: {w}, H: {h}]";
	public string AddButton(IButton button) => "[Windows Dialog Button]";
}
class MacButton : IButton { public string SetSize(ButtonSize size) => "[Mac Button]" + size; }
class MacDialog : IDialog {
	public string SetDimensions(int w, int h) => $"[Mac Dialog W: {w}, H: {h}]";
	public string AddButton(IButton button) => "[Mac Dialog Button]";
}

interface IGUIFactory {
	IButton CreateButton();
	IDialog CreateDialog();
}
class WinGUIFactory : IGUIFactory {
	public IButton CreateButton() => new WinButton();
	public IDialog CreateDialog() => new WinDialog();
}
class MacGUIFactory : IGUIFactory {
	public IButton CreateButton() => new MacButton();
	public IDialog CreateDialog() => new MacDialog();
}
```

#### Usage

```csharp
// Client code can work with any factory implementation
void ClientMethod(IGUIFactory factory) {
	var button = factory.CreateButton();
	var dialog = factory.CreateDialog();
	Console.WriteLine(button.SetSize(ButtonSize.Small));
	Console.WriteLine(dialog.AddButton(button));
	Console.WriteLine(dialog.SetDimensions(10, 20));
}

// Example usage:
ClientMethod(new WinGUIFactory()); // Windows UI
ClientMethod(new MacGUIFactory()); // Mac UI
```

This pattern allows you to easily switch between product families (e.g., Windows or Mac UI) without changing the client code, ensuring consistency among related products.

**File:** [AbstractFactory.cs](./AbstractFactory.cs)
