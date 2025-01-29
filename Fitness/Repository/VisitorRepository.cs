using Fitness.EntityFramework.DataModel;
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
            var visitorsList = new List<VisitorsModel>();

            using (var connection = new SqlConnection(_connectionString))
            {
                var query = "SELECT FullName, SubscriptionType, SubscriptionStatus, SubscriptionPrice FROM Visitors";
                var command = new SqlCommand(query, connection);

                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        visitorsList.Add(new VisitorsModel
                        {
                            FullName = reader["FullName"].ToString(),
                            SubscriptionType = reader["SubscriptionType"].ToString(),
                            SubscriptionStatus = reader["SubscriptionStatus"].ToString(),
                            SubscriptionPrice = Convert.ToDecimal(reader["SubscriptionPrice"])
                        });
                    }
                }
            }

            return visitorsList;
        }
    }
}