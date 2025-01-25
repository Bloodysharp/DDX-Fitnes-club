using Fitness.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.Repository
{
    public class InventoryRepository
    {
        private readonly string _connectionString;

        public InventoryRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }

        public List<InventoryModel> GetAllInventory()
        {
            var inventory = new List<InventoryModel>();

            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM Equipment";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        inventory.Add(new InventoryModel
                        {
                            ID = reader["ID"] != DBNull.Value ? Guid.Parse(reader["ID"].ToString()) : Guid.Empty,
                            Name = reader["Name"] != DBNull.Value ? reader["Name"].ToString() : string.Empty,
                            Status = reader["Status"] != DBNull.Value ? reader["Status"].ToString() : string.Empty,
                            Quantity = reader["Quantity"] != DBNull.Value ? Convert.ToInt32(reader["Quantity"]) : 0,
                            InRepair = reader["InRepair"] != DBNull.Value ? Convert.ToInt32(reader["InRepair"]) : 0,
                            Price = reader["Price"] != DBNull.Value ? Convert.ToDecimal(reader["Price"]) : 0.0m


                        });
                    }
                }
            }
            return inventory;
        }

    }
}