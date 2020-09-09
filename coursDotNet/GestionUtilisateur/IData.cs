using System;
using System.Collections.Generic;
using System.Text;

namespace GestionUtilisateur
{
    public interface IData
    {
        User GetUserByLastName(string name);
    }
}
