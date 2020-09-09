using System;
using System.Collections.Generic;
using System.Text;

namespace GestionCompteBancaire.Classes
{
    public interface ISauvegarde
    {
        bool addOperation(Operation operation);
    }
}
