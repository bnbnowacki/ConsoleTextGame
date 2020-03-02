using ConsoleApp5.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5.GameData
{
    struct DropItem
    {
        public Item item;
        public int chance;

        public DropItem(Item item, int chance)
        {
            this.item = item;
            this.chance = chance;
        }
    }
}
