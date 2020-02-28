using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    class Item : GameObject
    {
        public string Name { get; protected set; }

        public Item() : base()
        {
            this.Name = "";
        }

        public Item(string name) : base()
        {
            this.Name = name;
        }

        public Item(int posX, int posY, char texture, string name) : base(posX, posY, texture)
        {
            this.Name = name;
            GameManager.activeItems.Add(this);
        }
    }
}
