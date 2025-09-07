namespace Patterns.Creational
{
	public class ObjectPool<T>
	{
		private readonly Queue<T> _availableObjects = new Queue<T>();

		public ObjectPool(int maxSize)
		{
			for (int i = 0; i < maxSize; i++)
			{
				_availableObjects.Enqueue(Activator.CreateInstance<T>());
			}
		}
		public T Occupy()
		{
			if (_availableObjects.Count > 0)
			{
				return _availableObjects.Dequeue();
			}
			else
			{
				return Activator.CreateInstance<T>();
			}
		}

		public void Release(T obj)
		{
			_availableObjects.Enqueue(obj);
		}
	}


	public class ObjectPoolDemo
	{
		public class Connection
		{
			public void Execute(string query)
			{
				Console.WriteLine($"Executing query: {query}");
				Thread.Sleep(100); // Simulate query execution time
			}
		}
		public static void Run()
		{
			var connectionPool = new ObjectPool<Connection>(3);
			var conn = connectionPool.Occupy();
			conn.Execute("SELECT * FROM Users");
			connectionPool.Release(conn);
		}
	}
}
