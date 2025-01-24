using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessPersonnel.Model
{
    public class UserModel
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Salary { get; set; }
        public string Role { get; set; }
    }
}
