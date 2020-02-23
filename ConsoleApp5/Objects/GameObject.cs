using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    //Basic class for objects in game.
    class GameObject
    {
        public int posX
        {
            get;
            protected set;
        }

        public int posY
        {
            get;
            protected set;
        }

        public int height
        {
            get;
            private set;
        }

        public int width
        {
            get;
            private set;
        }

        public char texture
        {
            get;
            private set;
        }

        public GameObject()
        {
            this.posX = 0;
            this.posY = 0;
            this.height = 1;
            this.width = 1;
            this.texture = ' ';
        }

        public GameObject(int posX, int posY)
        {
            this.posX = posX;
            this.posY = posY;
            this.height = 1;
            this.width = 1;
            this.texture = ' ';
        }

        public GameObject(int posX, int posY, char texture)
        {
            this.posX = posX;
            this.posY = posY;
            this.height = 1;
            this.width = 1;
            this.texture = texture;
        }

        public void SetPosition(int posX = -1, int posY = -1)
        {
            if (posX != -1)
                this.posX = posX;
            if (posY != -1)
                this.posY = posY;
        }
    }


}
