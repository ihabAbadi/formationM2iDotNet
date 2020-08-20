using System;
using System.Collections.Generic;
using System.Text;

namespace coursDotNet.Classes
{
    abstract class Figure
    {
        private int posX;
        private int posY;

        public int PosX { get => posX; set => posX = value; }
        public int PosY { get => posY; set => posY = value; }

        protected Figure(int posX, int posY)
        {
            PosX = posX;
            PosY = posY;
        }

        public abstract void Afficher();
    }
}
