using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Models
{
    public class Euser
    {
        private int id;
        private string firstName;
        private string lastName;
        private string email;
        private string password;
        private Erole role;
        public int Id { get => id; set => id = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string Email { get => email; set => email = value; }
        public string Password { get => password; set => password = value; }
        public Erole Role { get => role; set => role = value; }
    }
}
