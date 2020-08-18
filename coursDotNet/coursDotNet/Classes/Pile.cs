using System;
using System.Collections.Generic;
using System.Text;

namespace coursDotNet.Classes
{
    class Pile<T>
    {
        private T[] elements;
        private int taille;
        private int index;

        public Pile(int t)
        {
            taille = t;
            elements = new T[taille];
            index = 0;
        }

        public void Empiler(T element)
        {
            if(index < taille)
            {
                elements[index] = element;
                index++;
            }
            else
            {
                Console.WriteLine("Pile pleine");
            }
        }
        public void Depiler()
        {
            if(index > 0)
            {
                elements[index - 1] = default(T);
                index--;
            }
            else
            {
                Console.WriteLine("Pile vide");
            }
        }

        public T GetElement(int i)
        {
            if(i >= 0 && i < index)
            {
                return elements[i];
            }
            else
            {
                return default(T);
            }
        }
    }
}
