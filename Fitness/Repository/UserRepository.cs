using DDX_Fitness.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Media.Imaging;
using System.Windows.Media;

namespace DDX_Fitness.Repository
{
    public class UserRepository : RepositoryBase, IUserRepository
    {
     

        public bool AuthenticateUser(NetworkCredential credential)
        {
            bool validUser;
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "select *from [Users] where username=@username and [passcode]=@passcode";
                command.Parameters.Add("@username", SqlDbType.NVarChar).Value = credential.UserName;
                command.Parameters.Add("@passcode", SqlDbType.NVarChar).Value = credential.Password;
                validUser = command.ExecuteScalar() == null ? false : true;
            }
            return validUser;
        }
     
        public IEnumerable<UserModel> GetByAll()
        {
            throw new NotImplementedException();
        }
        public UserModel GetById(int id)
        {
            throw new NotImplementedException();
        }
        public UserModel GetByUsername(string username)
        {
            UserModel user = null;
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "select * from [Users] where username=@username";
                command.Parameters.Add("@username", SqlDbType.NVarChar).Value = username;
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        user = new UserModel()
                        {
                            Id = reader["ID"].ToString(),
                            Username = reader["Username"].ToString(),
                            Password = string.Empty, // Пропускаем пароль для безопасности
                            FullName = reader["FullName"].ToString(),
                            PhoneNumber = reader["PhoneNumber"].ToString(),
                            Email = reader["Email"].ToString(),
                            Salary = reader["Salary"].ToString(),
                            Role = reader["Role"].ToString() // Добавляем роль
                            //profilePics = ConvertToImageSource((byte[])reader["profilePics"])
                        };
                    }
                }
            }
            return user;
        }
        //private ImageSource ConvertToImageSource(byte[] imageData)
        //{
        //    if (imageData == null || imageData.Length == 0)
        //        return null;

        //    using (var memoryStream = new MemoryStream(imageData))
        //    {
        //        var image = new BitmapImage();
        //        image.BeginInit();
        //        image.CacheOption = BitmapCacheOption.OnLoad;
        //        image.StreamSource = memoryStream;
        //        image.EndInit();
        //        return image;
        //    }
        //}
        public void Add(UserModel userModel)
        {
            throw new NotImplementedException();
        }
        public void Edit(UserModel userModel)
        {
            throw new NotImplementedException();
        }
        public void Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}

