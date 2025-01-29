using Fitness.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.Repository
{
    public class StatisticRepository
    {
        private readonly string _connectionString;

        public StatisticRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<StatisticModel> GetAllStatts()
        {
            var StatsList = new List<StatisticModel>();

            using (var connection = new SqlConnection(_connectionString))
            {
                var query = "SELECT MonthYear, TotalSubscriptionsRevenue, TrainersSalaryExpense, ManagersSalaryExpense, RepairCosts, EquipmentPurchaseCosts FROM Statts";
                var command = new SqlCommand(query, connection);

                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        StatsList.Add(new StatisticModel
                        {
                            MonthYear = Convert.ToDateTime(reader["MonthYear"]),
                            TotalSubscriptionsRevenue = Convert.ToDecimal(reader["TotalSubscriptionsRevenue"]),
                            TrainersSalaryExpense = Convert.ToDecimal(reader["TrainersSalaryExpense"]),
                            ManagersSalaryExpense = Convert.ToDecimal(reader["ManagersSalaryExpense"]),
                            RepairCosts = Convert.ToDecimal(reader["RepairCosts"]),
                            EquipmentPurchaseCosts= Convert.ToDecimal(reader["EquipmentPurchaseCosts"])
                        });
                    }
                }
            }

            return StatsList;
        }
    }
}
