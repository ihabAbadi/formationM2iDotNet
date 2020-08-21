using System;
using System.Collections.Generic;
using System.Text;

namespace coursDotNet.Classes
{
    class AgeException : Exception
    {
        public AgeException() : base("Vous êtes un peu vieux ou jeune")
        {

        }
    }
}
