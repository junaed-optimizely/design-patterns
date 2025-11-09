namespace Patterns.Structural
{
	public interface IDevice
	{
		int Volume { get; }
		bool IsOff { get; }
		void TurnOn();
		void TurnOff();
		void SetVolume(int volume);
	}


	// Concrete Impl.

	public class TV : IDevice
	{
		public int Volume { get; private set; }
		public bool IsOff { get; private set; } = true;
		public int Channel { get; private set; } = 1;

		public void SetVolume(int volume)
		{
			if (IsOff)
			{
				Console.WriteLine("TV is off. Turn it on first.");
				return;
			}
			Volume = Math.Clamp(volume, 0, 100);
			Console.WriteLine($"TV volume set to {Volume}");
		}

		public void TurnOff()
		{
			IsOff = true;
			Console.WriteLine("TV turned off");
		}

		public void TurnOn()
		{
			IsOff = false;
			Console.WriteLine($"TV turned on. Channel {Channel}, Volume {Volume}");
		}

		public void ChangeChannel(int channel)
		{
			if (IsOff)
			{
				Console.WriteLine("TV is off. Turn it on first.");
				return;
			}
			Channel = channel;
			Console.WriteLine($"TV channel changed to {Channel}");
		}
	}

	public class Radio : IDevice
	{
		public int Volume { get; private set; }
		public bool IsOff { get; private set; } = true;
		public double Frequency { get; private set; } = 88.0;

		public void SetVolume(int volume)
		{
			Volume = Math.Clamp(volume, 0, 50); // Radio has lower max volume
			Console.WriteLine($"Radio volume set to {Volume}");
		}

		public void TurnOff()
		{
			IsOff = true;
			Console.WriteLine("Radio turned off");
		}

		public void TurnOn()
		{
			IsOff = false;
			Console.WriteLine($"Radio turned on. Frequency {Frequency} FM, Volume {Volume}");
		}

		public void TuneFrequency(double frequency)
		{
			if (IsOff)
			{
				Console.WriteLine("Radio is off. Turn it on first.");
				return;
			}
			Frequency = Math.Clamp(frequency, 88.0, 108.0);
			Console.WriteLine($"Radio tuned to {Frequency} FM");
		}
	}

	// Remote
	public abstract class RemoteControl
	{
		protected readonly IDevice _device;

		public RemoteControl(IDevice device)
		{
			_device = device;
		}

		public abstract void VolumeUp();

		public abstract void VolumeDown();
		
	}

	public class SmartRemote : RemoteControl
	{

		public SmartRemote(IDevice device) : base(device) { }
		
		public void Toggle() {
			if(_device.IsOff) {
				_device.TurnOn();
				return;
			}
			_device.TurnOff();
		}
		public override void VolumeDown()
		{
			_device.SetVolume(_device.Volume + 5);
		}

		public override void VolumeUp()
		{
			_device.SetVolume(_device.Volume - 5);
		}
	}


	public static class BridgeDemo{
		public static void Run() {
			IDevice tv = new TV();
			IDevice radio = new Radio();

			SmartRemote tvRemote = new(tv);
			SmartRemote radioRemote = new(radio);

			tvRemote.Toggle();
			tvRemote.VolumeDown();
			radioRemote.Toggle();
			radioRemote.VolumeUp();
		}
	}
}
