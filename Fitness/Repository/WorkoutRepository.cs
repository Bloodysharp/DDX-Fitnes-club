using Fitness.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.Repository
{
    public class WorkoutRepository
    {
        private readonly string _connectionString;

        public WorkoutRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }

        public List<WorkoutModel> GetAllWorkout()
        {
            var workout = new List<WorkoutModel>();

            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM Workouts";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        workout.Add(new WorkoutModel
                        {
                            ID = Guid.Parse(reader["ID"].ToString()),
                            Name = reader["Name"].ToString(),
                            StartTime = Convert.ToDateTime(reader["StartTime"]),
                            EndTime = Convert.ToDateTime(reader["EndTime"]),
                            TotalTime = reader["TotalTime"].ToString(),
                            TrainerFullName = reader["TrainerFullName"].ToString()

                        });
                    }
                }
            }
            return workout;
        }
    }
}