using AnnoncesAspNet.Interface;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnnoncesAspNet.Services
{
    public class FavorisService : IFavoris
    {
        private IHttpContextAccessor _accessor;
        public FavorisService(IHttpContextAccessor accessor)
        {

        }

        public bool AddToFavoris(int id)
        {
            List<int> liste = getFavoris();
            liste.Add(id);
            _accessor.HttpContext.Session.SetString("favoris", JsonConvert.SerializeObject(liste));
            return true;
        }

        public bool RemoveFromFavoris(int id)
        {
            List<int> liste = new List<int>();
            getFavoris().ForEach((e) =>
            {
                if (e != id)
                {
                    liste.Add(e);
                }
            });
            _accessor.HttpContext.Session.SetString("favoris", JsonConvert.SerializeObject(liste));
            return true;
        }

        public List<int> getFavoris()
        {
            List<int> favoris = new List<int>();
            string chaine = _accessor.HttpContext.Session.GetString("favoris");
            if(chaine != null)
            {
                favoris = JsonConvert.DeserializeObject<List<int>>(chaine);
            }
            return favoris;
        }

        public bool IsFavoris(int id)
        {
            return getFavoris().Contains(id);
        }
    }
}
