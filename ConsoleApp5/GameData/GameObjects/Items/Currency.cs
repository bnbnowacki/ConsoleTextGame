using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5.GameData.Game_Objects.Items
{
    class Currency : Item
    {
        public int Amount { get; private set; }

        public Currency(int posX, int posY, char texture, string name, int amount) : base(posX, posY, texture, name)
        {
            Amount = amount;
            this.Name = String.Format("{0}({1})", name, amount);
        }
    }
}
