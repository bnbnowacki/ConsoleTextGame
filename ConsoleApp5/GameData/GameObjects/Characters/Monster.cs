using ConsoleApp5.GameData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    class Monster : Character, IFightable
    {
        public string name { get; private set; }
        //public int health { get; set; }
        //public int maxHealth { get; set; }
        public int BaseAttack { get; set; }
        public int BaseDefence { get; set; }
        public List<DropItem> PossibleDrop { get; set; }

        public int experienceAward { get; }

        public Monster(string name, int posX, int posY, byte level, int expAward, char texture, List<DropItem> drop) : base(posX, posY, level, texture)
        {
            this.name = name;
            this.BaseAttack = 5;
            this.BaseDefence = 2;
            this.health = 50;
            this.experienceAward = expAward;
            this.PossibleDrop = drop;
        }

        public void DealDamage(int value, IFightable opponent)
        {
            opponent.ChangeHealth(-value);
        }

        public List<Item> GenerateDrop()
        {
            List<Item> actualDrop = new List<Item>();
            Random rand = new Random();
            foreach (DropItem item in PossibleDrop)
            {
                int randResult = rand.Next(101);
                if (randResult <= item.chance)
                    actualDrop.Add(item.item);
            }

            return actualDrop;
        }
    }
}
