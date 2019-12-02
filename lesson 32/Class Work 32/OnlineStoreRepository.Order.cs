using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Class_Work_32
{
	public partial class OnlineStoreRepository : IOrderRepository
	{
		public int GetOrderCount()
		{
			using (var sqlConnection = GetOpenedSqlConnection())
			{
				var sqlCommand = sqlConnection.CreateCommand();
				sqlCommand.CommandType = System.Data.CommandType.Text;
				sqlCommand.CommandText = "select count (*) from dbo.[Order]";

				return (int)sqlCommand.ExecuteScalar();
			}
		}

		public List<string> GetOrderDiscountList()
		{
			using (var sqlConnection = GetOpenedSqlConnection())
			{
				var sqlCommand = sqlConnection.CreateCommand();
				sqlCommand.CommandType = System.Data.CommandType.Text;
				sqlCommand.CommandText = "select [Id], [Discount] from dbo.[Order] order by [Discount] ASC";

				var result = new List<string>();

				using (var reader = sqlCommand.ExecuteReader())
				{
					if (!reader.HasRows)
						return result;

					int idColumnIndex = reader.GetOrdinal("Id"),
						discountColumnIndex = reader.GetOrdinal("Discount");

					while (reader.Read())
					{
						var id = reader.GetInt32(idColumnIndex);

						var discount = reader.IsDBNull(discountColumnIndex)
							? 0
							: reader.GetDouble(discountColumnIndex);

						result.Add($"product ID: {id}\tDiscount: {discount * 100:0.00}%");
					}
				}

				return result;
			}
		}
	}
}
