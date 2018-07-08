using System.Collections.Generic;

namespace ConsoleApp5
{
    public struct Level
    {
        public char[,] Tilemap;
        public byte size;
    }

    public struct Position2D
    {
        public int posX;
        public int posY;

        public Position2D(int posX, int posY)
        {
            this.posX = posX;
            this.posY = posY;
        }
    }
}