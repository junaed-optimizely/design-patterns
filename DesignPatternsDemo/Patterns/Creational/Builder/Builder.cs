namespace Patterns.Creational
{
	interface IClient
	{
		string GetConfig();
		void ProcessEvent(); 
	}
	interface IClientBuilder
	{
		IClientBuilder WithConfig(string config);
		IClientBuilder WithEventProcessor(string processor);
		IClient GetClient();
	}


	class ConcreteClient : IClient
	{

		public string Config { get; set; } = string.Empty;
		public string EventProcessor { get; set; } = string.Empty;
		public string GetConfig()
		{
			return Config;
		}

		public void ProcessEvent()
		{
			Console.WriteLine($"Processing event with [{EventProcessor}]");
		}
	}

	class ConcreteClientBuilder : IClientBuilder
	{
		private ConcreteClient _client = new();


		public IClientBuilder WithConfig(string config)
		{
			_client.Config = config;
			return this;
		}

		public IClientBuilder WithEventProcessor(string processor)
		{
			_client.EventProcessor = processor;
			return this;
		}

		public IClient GetClient()
		{
			var tempClient = _client;
			// Resetting the builder after client retrieval 
			_client = new();
			return tempClient;
		}
		
	}


	public class BuilderDemo
	{
		public static void Run()
		{
			Console.WriteLine("=== Builder Pattern Demo ===\n");
			
			// Create a new builder instance
			var clientBuilder = new ConcreteClientBuilder();
			
			// Use method chaining to configure the client
			var client = clientBuilder
				.WithConfig("production-config.json")
				.WithEventProcessor("KafkaEventProcessor")
				.GetClient();

			// Demonstrate the built client
			Console.WriteLine($"Client 1 configuration: {client.GetConfig()}");
			client.ProcessEvent();
			Console.WriteLine();

			// Test the reset functionality - reuse the same builder!
			Console.WriteLine("=== Testing Builder Reset ===");
			var client2 = clientBuilder
				.WithConfig("staging-config.json")
				.WithEventProcessor("RabbitMQEventProcessor")
				.GetClient();

			Console.WriteLine($"Client 2 configuration: {client2.GetConfig()}");
			client2.ProcessEvent();
			Console.WriteLine();

			// Verify that the first client wasn't affected
			Console.WriteLine("=== Verifying Independence ===");
			Console.WriteLine($"Client 1 still has: {client.GetConfig()}");
			Console.WriteLine($"Client 2 has: {client2.GetConfig()}");
			
			// Build another client with different configuration using new builder
			var testClient = new ConcreteClientBuilder()
				.WithConfig("test-config.json")
				.WithEventProcessor("InMemoryEventProcessor")
				.GetClient();

			Console.WriteLine($"Client 3 configuration: {testClient.GetConfig()}");
			testClient.ProcessEvent();
		}
	}
}
