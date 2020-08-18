using System;
using System.Collections.Generic;
using System.Text;

namespace coursDotNet.Classes
{
    class Salle<T>
    {
        private T element;

        public T Element { get => element; set => element = value; }
    }
}
