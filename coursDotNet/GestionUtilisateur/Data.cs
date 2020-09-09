using System;
using System.Collections.Generic;
using System.Text;

namespace GestionUtilisateur
{
    public class Data : IData
    {
        public User GetUserByLastName(string name)
        {
            //Rechercher dans notre base de donnée
            //simulation d'une base de donnée
            if(name == "abadi")
            {
                return new User() { LastName = "abadi", FirstName = "ihab" };
            }
            else if(name == "toto")
            {
                return new User() { LastName = "toto", FirstName = "tata" };
            }
            else
            {
                return null;
            }
        }
    }
}
