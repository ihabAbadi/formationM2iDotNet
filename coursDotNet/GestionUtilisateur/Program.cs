using System;

namespace GestionUtilisateur
{
    class Program
    {
        static void Main(string[] args)
        {
            UserController controller = new UserController(new Data());
        }
    }
}
