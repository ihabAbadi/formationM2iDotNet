using AnnoncesAspNet.Interface;
using AnnoncesAspNet.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnnoncesAspNet.Services
{
    public class LoginService : ILogin
    {
        private IHttpContextAccessor _accessor;

        public LoginService(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }
        public Utilisateur GetUserInfo()
        {
            string stringUtilisateur = _accessor.HttpContext.Session.GetString("utilisateur");
            if(stringUtilisateur != null)
            {
                return JsonConvert.DeserializeObject<Utilisateur>(stringUtilisateur);
            }
            return null;
        }

        public void SaveUser(Utilisateur utilisateur)
        {
            utilisateur.Password = null;
            _accessor.HttpContext.Session.SetString("utilisateur", JsonConvert.SerializeObject(utilisateur));
        }
    }
}
