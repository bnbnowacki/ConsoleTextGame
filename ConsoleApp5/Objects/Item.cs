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
        public int attackValue { get; private set; }
        public int defenseValue { get; private set; }

        public Item() : base()
        {
            this.name = "";
            this.attackValue = 0;
            this.defenseValue = 0;
        }

        public Item(string name, int atk, int def)
        {
            this.name = name;
            this.attackValue = atk;
            this.defenseValue = def;
        }

        public Item(int posX, int posY, char texture, string name, int atk, int def) : base(posX, posY, texture)
        {
            this.name = name;
            this.attackValue = atk;
            this.defenseValue = def;
            GameManager.activeItems.Add(this);
        }
    }

    struct Equipment
    {
        public Item weapon;
        public Item shield;
    }
}
