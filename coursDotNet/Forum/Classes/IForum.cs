using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.Classes
{
    public interface IForum
    {
        Abonne GetAbonneById(int id);
        Nouvelle GetNouvelleById(int id);

        List<Abonne> Abonnes { get; set; }

        List<Nouvelle> Nouvelles { get; set; }
    }
}
