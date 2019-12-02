using System;
using System.Collections.Generic;
using System.Text;

namespace Class_Work_32
{
	public interface IProductRepository
	{
		int GetProductCount();

		List<string> GetProductList();

		int AddProduct(string name, decimal price);
	}
}
