namespace Patterns.Creational
{
	public interface ITransport
	{
		public string Deliver();
	}

	public class Ship : ITransport
	{
		public string Deliver() => "Delivering overseas by Ship.";
	}
	public class Truck : ITransport
	{
		public string Deliver() => "Delivering Road by Truck.";
	}


	public abstract class Logistics
	{
		public abstract ITransport CreateTransport();

		public string PlanDelivery()
		{
			var t = CreateTransport();
			return "Logistics: " + t.Deliver();
		}
	}

	public class RoadLogistics : Logistics
	{
		public override ITransport CreateTransport()
		{
			return new Truck();
		}
	}
	public class OverSeaLogistics : Logistics
	{
		public override ITransport CreateTransport()
		{
			return new Ship();
		}
	}


	public class FactoryDemo
	{
		public void Run()
		{
			ClientCode(new RoadLogistics());
			ClientCode(new OverSeaLogistics());
		}

		public void ClientCode(Logistics logistics)
		{
			Console.WriteLine(logistics.PlanDelivery());
		}
	}
}

