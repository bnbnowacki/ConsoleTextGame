using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5.GameData.Game_Objects.Items
{
    class Currency : Item
    {
        private string _name;
        new public string Name
        {
            get { return _name + string.Format("({0})", Amount); }
            set { _name = value; }
        }
        public int Amount { get; private set; }

        public Currency(string name, int minAmount, int maxAmount) : base (name)
        {
            Random random = new Random();
            Amount = random.Next(minAmount, maxAmount);

            this.Name = name;
        }

        public Currency(int posX, int posY, char texture, string name, int amount) : base(posX, posY, texture, name)
        {
            Amount = amount;
            this.Name = name;
        }

        public Currency(int posX, int posY, char texture, string name, int minAmount, int maxAmount) : base(posX, posY, texture, name)
        {
            Random random = new Random();
            Amount = random.Next(minAmount, maxAmount);

            this.Name = name;
        }
    }
}
