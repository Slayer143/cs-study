using System;
using System.Collections.Generic;
using System.Text;

namespace Class_Work_32
{
	public interface IOrderRepository
	{
		int GetOrderCount();

		List<string> GetOrderDiscountList();

		int AddOrder(
			int customerId,
			DateTimeOffset dateTime,
			float? discount,
			List<Tuple<int, int>> productIdCountList);
	}
}
