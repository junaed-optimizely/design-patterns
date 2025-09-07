namespace Patterns.Creational
{
	enum ButtonSize
	{
		Small,
		Medium,
		Large
	}
	interface IButton
	{
		string SetSize(ButtonSize size);
	}


	interface IDialog
	{
		string SetDimensions(int width, int height);

		string AddButton(IButton button);
	}


	// WIN UI COMPONENTS
	class WinButton : IButton
	{
		public string SetSize(ButtonSize size)
		{
			return "[Windows Button]" + size.ToString();
		}
	}

	class WinDialog : IDialog
	{
		public string SetDimensions(int width, int height)
		{
			return $"[Windows Dialog W: {width}, H: {height}]";
		}

		public string AddButton(IButton button)
		{
			return "[Windows Dialog Button]";
		}
	}

	// MAC UI COMPONENTS
	class MacButton : IButton
	{
		public string SetSize(ButtonSize size)
		{
			return "[Mac Button]" + size.ToString();
		}
	}
	class MacDialog : IDialog
	{
		public string SetDimensions(int width, int height)
		{
			return $"[Mac Dialog W: {width}, H: {height}]";
		}

		public string AddButton(IButton button)
		{
			return "[Mac Dialog Button]";
		}
	}


	// FACTORY
	interface IGUIFactory
	{
		IButton CreateButton();

		IDialog CreateDialog();
	}

	// WIN FACTORY

	class WinGUIFactory : IGUIFactory
	{
		public IButton CreateButton()
		{
			return new WinButton();
		}
		public IDialog CreateDialog()
		{
			return new WinDialog();
		}
	}


	// Mac Factory

	class MacGUIFactory : IGUIFactory
	{
		public IButton CreateButton()
		{
			return new MacButton();
		}
		public IDialog CreateDialog()
		{
			return new MacDialog();
		}
	}



	class ClientAbstractFactory
	{
		public static void Run()
		{
			Console.WriteLine("Setting Windows UI");
			ClientMethod(new WinGUIFactory());

			Console.WriteLine("Setting Mac UI");
			ClientMethod(new MacGUIFactory());
		}

		public static void ClientMethod(IGUIFactory factory)
		{
			var button = factory.CreateButton();
			var dialog = factory.CreateDialog();

			Console.WriteLine(button.SetSize(ButtonSize.Small));
			Console.WriteLine(dialog.AddButton(button));
			Console.WriteLine(dialog.SetDimensions(10, 20));
		}

	}


	public class AbstractFactoryDemo
	{
		public static void Run()
		{
			ClientAbstractFactory.Run(); 
		}
	}

}

