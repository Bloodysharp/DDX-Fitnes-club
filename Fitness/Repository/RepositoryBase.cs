﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDX_Fitness.Repository
{
    public abstract class RepositoryBase
    {
        private readonly string connectionString;
        public RepositoryBase()
        {
            connectionString = "Server=DESKTOP-Q1VPJHS\\SQLEXPRESS; Database=MVVMDB; Integrated Security=true; trustservercertificate=True";
        }
        protected SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
