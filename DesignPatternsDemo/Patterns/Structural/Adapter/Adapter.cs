namespace Patterns.Structural
{
	interface IPaymentProcessor
	{
		bool Pay(decimal amount);
	}


	// THIRD PARTY CODE STARTS
	class StripePayment
	{
		public bool MakePayment(decimal amount)
		{
			Console.WriteLine($"[Stripe: Payment]: ${amount}");
			return true;
		}
	}

	class PaypalPayment
	{
		public bool SendPayment(decimal amount)
		{
			Console.WriteLine($"[Paypal: Payment] ${amount}");
			return true;
		}
	}

	// THIRD PARTY CODE ENDS

	class StripeAdapter : IPaymentProcessor
	{
		private StripePayment _stripe;

		public StripeAdapter(StripePayment stripe)
		{
			_stripe = stripe;
		}

		public bool Pay(decimal amount)
		{
			return _stripe.MakePayment(amount);
		}
	}

	class PaypalAdapter : IPaymentProcessor
	{
		private PaypalPayment _paypal;

		public PaypalAdapter(PaypalPayment paypal)
		{
			_paypal = paypal;
		}

		public bool Pay(decimal amount)
		{
			return _paypal.SendPayment(amount);
		}
	}

	
	class AdapterDemo
	{
		public static void Run()
		{
			Console.Write("Enter payment option (stripe/paypal): ");
			var paymentOption = Console.ReadLine()?.ToLower() ?? "stripe";
			
			Console.Write("Enter amount: ");
			var amountInput = Console.ReadLine();
			decimal amount = decimal.TryParse(amountInput, out var parsedAmount) ? parsedAmount : 0;
			
			StripeAdapter stripeAdapter = new(new());
			PaypalAdapter paypalAdapter = new(new());
			
			if(paymentOption == "paypal")
			{
				paypalAdapter.Pay(amount);
			} 
			else if(paymentOption == "stripe")
			{
				stripeAdapter.Pay(amount);
			}
			else
			{
				Console.WriteLine($"Invalid payment option: {paymentOption}. Please use 'stripe' or 'paypal'.");
			}
		}
	}
}
