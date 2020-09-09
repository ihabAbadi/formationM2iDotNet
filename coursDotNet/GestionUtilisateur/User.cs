using System;
using System.Collections.Generic;
using System.Text;

namespace GestionUtilisateur
{
    public class User
    {
        private string firstName;
        private string lastName;

        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
    }
}
