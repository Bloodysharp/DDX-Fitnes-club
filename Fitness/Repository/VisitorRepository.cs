using Fitness.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.Repository
{
    public class VisitorsRepository
    {
        private readonly string _connectionString;

        public VisitorsRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }

        public List<VisitorsModel> GetAllVisitors()
        {
            var visitors = new List<VisitorsModel>();

            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM Visitors";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        visitors.Add(new VisitorsModel
                        {
                            ID = Guid.Parse(reader["ID"].ToString()),
                            FullName = reader["FullName"].ToString(),
                            Email = reader["Email"].ToString(),
                            PhoneNumber = reader["PhoneNumber"].ToString(),
                            SubscriptionType = reader["SubscriptionType"].ToString(),
                            SubscriptionStatus = reader["SubscriptionStatus"].ToString(),
                            SubscriptionStart = Convert.ToDateTime(reader["SubscriptionStart"]),
                            SubscriptionEnd = Convert.ToDateTime(reader["SubscriptionEnd"]),
                            SubscriptionPrice = Convert.ToDecimal(reader["SubscriptionPrice"])
                        });
                    }
                }
            }
            return visitors;
        }

        public static implicit operator VisitorsRepository(InventoryRepository v)
        {
            throw new NotImplementedException();
        }
    }
}