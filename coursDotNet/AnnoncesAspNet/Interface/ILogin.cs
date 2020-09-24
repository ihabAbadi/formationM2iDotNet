using AnnoncesAspNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnnoncesAspNet.Interface
{
    public interface ILogin
    {
        void SaveUser(Utilisateur utilisateur);

        Utilisateur GetUserInfo();
    }
}
