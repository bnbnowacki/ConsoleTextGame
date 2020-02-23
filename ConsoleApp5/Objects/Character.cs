using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    //Object of this class can be controlled by player.
    class Character : GameObject
    {
        public byte level
        {
            get;
            private set;
        }
        public enum ELastMove
        {
            Left,
            Right,
            Up,
            Down
        };

        public ELastMove lastMove { get; private set; }

        public int experience
        {
            get;
            protected set;
        }

        public int maxHealth
        {
            get;
            set;
        }

        public int health
        {
            get;
            set;
        }
        public void ChangeHealth(int value)
        {
            this.health += value;
        }

        public void LevelUp()
        {
            this.level++;
        }
        public Character() : base()
        {
            this.level = 1;
            this.experience = 0;
            this.maxHealth = 100;
            this.health = 100;
        }

        public void SetLastMove(ELastMove move)
        {
            this.lastMove = move;
        }

        public Character(int posX, int posY) : base(posX, posY)
        {
            this.level = 1;
            this.experience = 0;
            this.maxHealth = 100;
            this.health = 100;
            GameManager.activeCharacters.Add(this);
        }

        public Character(int posX, int posY, byte level, char texture) : base(posX, posY, texture)
        {
            this.level = level;
            this.experience = 0;
            this.maxHealth = 100;
            this.health = 100;
            GameManager.activeCharacters.Add(this);
        }
    }
}
