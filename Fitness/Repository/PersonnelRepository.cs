using Fitness.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.Repository
{
    public class PersonnelRepository
    {
        private readonly string _connectionString;

        public PersonnelRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }

        public List<PersonnelModel> GetAllPersonnel()
        {
            var personnel = new List<PersonnelModel>();

            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM Trainers";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        personnel.Add(new PersonnelModel
                        {
                            ID = Guid.Parse(reader["ID"].ToString()),
                            FullName = reader["FullName"].ToString(),
                            Email = reader["Email"].ToString(),
                            PhoneNumber = reader["PhoneNumber"].ToString(),
                            Salary = Convert.ToDecimal(reader["Salary"]),
                            ExperienceYears = Convert.ToInt32(reader["ExperienceYears"]),
                            Specialty = reader["Specialty"].ToString()

                        });
                    }
                }
            }
            return personnel;
        }
    }
}