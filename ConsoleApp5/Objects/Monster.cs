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
        public int baseAttack { get; set; }
        public int baseDefence { get; set; }

        public int experienceAward { get; }

        public Monster(string name, int posX, int posY, byte level, int expAward, char texture) : base(posX, posY, level, texture)
        {
            this.name = name;
            this.baseAttack = 5;
            this.baseDefence = 2;
            this.health = 50;
            this.experienceAward = expAward;
        }

        public void DealDamage(int value, IFightable opponent)
        {
            opponent.ChangeHealth(-value);
        }
    }
}
