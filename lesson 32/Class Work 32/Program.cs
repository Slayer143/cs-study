using System;
using System.Collections.Generic;

namespace Class_Work_32
{
	class Program
	{
		static void Main(string[] args)
		{
			var repository = new OnlineStoreRepository(@"Data Source=WIN-HNJP61VLN18\SQLEXPRESS;Initial Catalog=OnlineStore;Integrated Security=True;");

			Console.WriteLine($"Product count: {repository.GetProductCount()}");
			List<string> products = repository.GetProductList();

			foreach (var product in products)
			{
				Console.WriteLine(product);
			}

			Console.WriteLine(repository.AddProduct("Super Watch", (decimal)9999.99));

			Console.WriteLine($"Order count: {repository.GetOrderCount()}");

			List<string> orders = repository.GetOrderDiscountList();

			foreach (var order in orders)
			{
				Console.WriteLine(order);
			}
		}
	}
}
