using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Class_Work_32
{
	public partial class OnlineStoreRepository : IProductRepository
	{
		public int GetProductCount()
		{
			using (var sqlConnection = GetOpenedSqlConnection())
			{
				var sqlCommand = sqlConnection.CreateCommand();
				sqlCommand.CommandType = System.Data.CommandType.Text;
				sqlCommand.CommandText = "select count (*) from dbo.Product";

				return (int)sqlCommand.ExecuteScalar();
			}
		}

		public List<string> GetProductList()
		{
			using (var sqlConnection = GetOpenedSqlConnection())
			{
				var sqlCommand = sqlConnection.CreateCommand();
				sqlCommand.CommandType = System.Data.CommandType.Text;
				sqlCommand.CommandText = "select [Id], [Name], [Price] from dbo.Product order by [Price] ASC";

				var result = new List<string>();

				using (var reader = sqlCommand.ExecuteReader())
				{
					if (!reader.HasRows)
						return result;

					int idColumnIndex = reader.GetOrdinal("Id"),
						nameColumnIndex = reader.GetOrdinal("Name"),
						priceColumnIndex = reader.GetOrdinal("Price");

					while (reader.Read())
					{
						var id = reader.GetInt32(idColumnIndex);
						var name = reader.GetString(nameColumnIndex);
						var price = reader.GetDecimal(priceColumnIndex);

						result.Add($"product ID: {id}\tName: {name}\tPrice: {price:0.00}");
					}
				}

				return result;
			}
		}

		public int AddProduct(string name, decimal price)
		{
			using (var sqlConnection = GetOpenedSqlConnection())
			{
				var sqlCommand = sqlConnection.CreateCommand();
				sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
				sqlCommand.CommandText = "dbo.AddProduct";

				sqlCommand.Parameters.AddWithValue("@name", name);
				sqlCommand.Parameters.AddWithValue("@price", price);

				var outputIdParameter = new SqlParameter("@id", System.Data.SqlDbType.Int, 1);
				outputIdParameter.Direction = System.Data.ParameterDirection.Output;
				sqlCommand.Parameters.Add(outputIdParameter);

				sqlCommand.ExecuteNonQuery();

				return (int)outputIdParameter.Value;
			}
		}
	}
}
