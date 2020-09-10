using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.Classes
{
    public interface IModerateur
    {
        int Id { get; }
        Abonne AjouterAbonne(IForum forum, string nom, string prenom, int age);
        bool SupprimerNouvelle(IForum forum, Nouvelle nouvelle);
        bool BannirAbonne(Abonne abonne);
    }
}
