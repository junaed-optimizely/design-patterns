using System.Threading;

namespace Patterns.Creational
{
	public sealed class Singleton
	{
		private static Singleton? _instance;

		public static Singleton GetInstance(string value)
		{
			if (_instance == null)
			{
				_instance = new Singleton();
				_instance.Value = value;
			}

			return _instance;
		}
		public string Value { get; set; } = string.Empty;
	}


	public sealed class ThreadSafeSingleton
	{
		private static ThreadSafeSingleton? _instance;
		private static readonly Lock _balanceLock = new();

		public string Value { get; set; } = string.Empty;

		public static ThreadSafeSingleton GetInstance(string value)
		{
			if (_instance == null)
			{
				lock (_balanceLock)
				{
					if (_instance == null)
					{
						_instance = new ThreadSafeSingleton();
						_instance.Value = value;
					}
				}
			}
			return _instance;
		}
	}


	public class SingletonDemo
	{
		public static void GetBasic(string value)
		{
			var s1 = Singleton.GetInstance(value);
			Console.WriteLine(s1.Value);
		}
		public static void GetThreadSafeOne(string value)
		{
			var s1 = ThreadSafeSingleton.GetInstance(value);
			Console.WriteLine(s1.Value);
		}
		public static void CheckThreadSafety(Action<string> func)
		{
			Thread process1 = new Thread(() =>
			{
				func("Foo");
			});

			Thread process2 = new Thread(() =>
			{
				func("Bar");
			});

			process1.Start();
			process2.Start();
			process1.Join();
			process2.Join();
		}

		public static void CheckBasic(Action<string> func)
		{
			func("Foo");
			func("Bar");
		}

		public static void Run()
		{
			// Basic Storage
			// CheckBasic(GetBasic);
			// CheckThreadSafety(GetBasic);
			// Thread Safe Storage
			// CheckBasic(GetThreadSafeOne);
			CheckThreadSafety(GetThreadSafeOne);
		}
	}


}
