using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace nopCommerce.Library.Selenium.Utilities
{
    public class SqlClient
    {
        private readonly string _connectionString;

        public SqlClient(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void ExecuteCommand(string sql)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand(sql, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        public string ExecuteScalar(string sql)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand(sql, connection))
                {
                    return FormatValue(command.ExecuteScalar());
                }
            }
        }

        public List<KeyValuePair<string, object>[]> ExecuteQuery(string sql)
        {
            var result = new List<KeyValuePair<string, object>[]>();

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand(sql, connection))
                {
                    using (var reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        while (reader.Read())
                        {
                            var row = new KeyValuePair<string, object>[reader.FieldCount];
                            for (var i = 0; i < reader.FieldCount; i++)
                            {
                                row[i] = new KeyValuePair<string, object>(reader.GetName(i), FormatValue(reader.GetValue(i)));
                            }
                            result.Add(row);
                        }
                    }
                }
            }
            return result;
        }

        private string FormatValue(object value)
        {
            return value == null || value == DBNull.Value ? string.Empty : value.ToString();
        }
    }
}
