using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    class Item : GameObject
    {
        public string name { get; private set; }

        public Item() : base()
        {
            this.name = "";
        }

        public Item(string name)
        {
            this.name = name;
        }

        public Item(int posX, int posY, char texture, string name) : base(posX, posY, texture)
        {
            this.name = name;
            GameManager.activeItems.Add(this);
        }
    }
}
