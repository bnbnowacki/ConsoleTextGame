using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5.Objects
{
    class Equipment : Item
    {
        public int attackValue { get; private set; }
        public int defenseValue { get; private set; }

        public Equipment(string name, int atk, int def) : base(name)
        {
            this.attackValue = atk;
            this.defenseValue = def;
        }

        public Equipment(int posX, int posY, char texture, string name, int atk, int def) : base(posX, posY, texture, name)
        {
            this.attackValue = atk;
            this.defenseValue = def;
        }
    }
}
