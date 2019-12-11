using Reminder.Storage.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Reminder.Storage.SqlServer.ADO
{
    public class SqlReminderStorage : IReminderStorage
    {
        private string _connectionString;

        public SqlReminderStorage(string connectionString)
        {
            _connectionString = connectionString;
        }

        public Guid Add(DateTimeOffset date, string message, string contactId, ReminderItemStatus status)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                var cmd = sqlConnection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "dbo.AddReminderItem";

                cmd.Parameters.AddWithValue("@contactId", contactId);
                cmd.Parameters.AddWithValue("@targetDate", date);
                cmd.Parameters.AddWithValue("@message", message);
                cmd.Parameters.AddWithValue("@statusId", (byte)status);

                return (Guid)cmd.ExecuteScalar();
            }

        }

        public ReminderItem Get(Guid id)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                var cmd = sqlConnection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "dbo.GetReminderItemById";

                cmd.Parameters.AddWithValue("@id", id);

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows && reader.Read())
                    {
                        int idIndex = reader.GetOrdinal("Id");
                        int contactIdIndex = reader.GetOrdinal("ContactId");
                        int targetDateIndex = reader.GetOrdinal("TargetDate");
                        int messageIndex = reader.GetOrdinal("Message");
                        int statusIdIndex = reader.GetOrdinal("StatusId");

                        return new ReminderItem(
                            reader.GetGuid(idIndex),
                            reader.GetDateTimeOffset(targetDateIndex),
                            reader.GetString(messageIndex),
                            reader.GetString(contactIdIndex),
                            (ReminderItemStatus)reader.GetByte(statusIdIndex));
                    }

                    return null;
                }
            }
        }

        public List<ReminderItem> Get(ReminderItemStatus status)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                var cmd = sqlConnection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "dbo.GetReminderItemByStatus";

                cmd.Parameters.AddWithValue("@statusId", (byte)status);

                using (var reader = cmd.ExecuteReader())
                {
                    var result = new List<ReminderItem>();

                    while (reader.Read())
                    {
                        int idIndex = reader.GetOrdinal("Id");
                        int contactIdIndex = reader.GetOrdinal("ContactId");
                        int targetDateIndex = reader.GetOrdinal("TargetDate");
                        int messageIndex = reader.GetOrdinal("Message");
                        int statusIdIndex = reader.GetOrdinal("StatusId");

                        result.Add(new ReminderItem(
                            reader.GetGuid(idIndex),
                            reader.GetDateTimeOffset(targetDateIndex),
                            reader.GetString(messageIndex),
                            reader.GetString(contactIdIndex),
                            (ReminderItemStatus)reader.GetByte(statusIdIndex)));
                    }

                    return result;
                }
            }
        }

        public void Update(Guid id, ReminderItemStatus status)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                var cmd = sqlConnection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "dbo.UpdateReminderItemStatus";

                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@statusId", (byte)status);

                cmd.ExecuteNonQuery();
            }
        }
    }
}
