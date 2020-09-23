using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnnoncesAspNet.Interface
{
    public interface IFavoris
    {
        bool AddToFavoris(int id);
        bool RemoveFromFavoris(int id);
        List<int> getFavoris();

        bool IsFavoris(int id);
    }
}
