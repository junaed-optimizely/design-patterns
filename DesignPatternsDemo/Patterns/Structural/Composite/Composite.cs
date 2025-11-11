namespace Patterns.Structural
{
	interface IGraphic
	{
		void Move(int x, int y);
		void Draw();
	}

	class Dot: IGraphic
	{
		protected int _x;
		protected int _y;

		public Dot(int x, int y)
		{
			_x = x;
			_y = y;
		}

		public void Move(int x, int y)
		{
			this._x += x;
			this._y += y;
		}

		public virtual void Draw()
		{
			Console.WriteLine($"({this._x}, {this._y})");	
		} 

	}

	class Circle : Dot
	{
		protected int _radius;
		public Circle(int x, int y, int radius) : base(x, y)
		{
			_radius = radius;
		}

		public override void Draw()
		{
			Console.WriteLine($"({this._x}, {this._y}) - radius: {this._radius}");
		}

	}

	class CompoundGraphic: IGraphic
	{
		private List<IGraphic> _graphics = new();


		public void Add(IGraphic graphic)
		{
			_graphics.Add(graphic);
		}

		public void Remove(IGraphic graphic)
		{
			_graphics.Remove(graphic);
		}
		
		public void Draw()
		{	
			foreach(var graphic in _graphics)
			{
				graphic.Draw();
			}
		}

		public void Move(int x, int y)
		{
			foreach(var graphic in _graphics)
			{
				graphic.Move(x, y);
			}
		}
	}
	
	class ImageEditor
	{
		private CompoundGraphic _all = new();

		public void Load(List<IGraphic> graphics)
		{
			foreach(var graphic in graphics)
			{
				_all.Add(graphic);
			}
		}

		public void Paint()
		{
			_all.Draw();
		}
	}

	public static class CompositeDemo
	{
		public static void Run()
		{
			ImageEditor im = new();
			im.Load([new Dot(1,2), new Circle(3,4,10)]);
			im.Paint();	
		}
	}
}
