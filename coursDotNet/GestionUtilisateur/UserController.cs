using System;
using System.Collections.Generic;
using System.Text;

namespace GestionUtilisateur
{
    public class UserController
    {
        private IData data;

        public UserController(IData d)
        {
            data = d;
        }
        public User GetUserByName(string name)
        {
            return data.GetUserByLastName(name);
        }
    }
}
