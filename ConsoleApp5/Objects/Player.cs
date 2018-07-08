using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    class Player : Character, IFightable
    {
        public byte inventoryPage { get; private set; }
        public int baseAttack { get; set; }
        public int baseDefence { get; set; }
        public List<Item> inventory { get; private set; }
        public Equipment activeEquipment;
        public Player(int posX, int posY) : base(posX, posY)
        {
            inventory = new List<Item>();
            GameManager.player = this;
            InputManager.player = this;
        }

        public Player(int posX, int posY, byte level, char texture) : base(posX, posY, level, texture)
        {
            inventory = new List<Item>();
            GameManager.player = this;
            InputManager.player = this;
            this.baseAttack = 10;
            this.baseDefence = 2;
        }

        public void setPosition(int posX = -1, int posY = -1)
        {
            if (posX != -1)
                this.posX = posX;
            if (posY != -1)
                this.posY = posY;
        }

        public void ChangeHealth(int value)
        {
            this.health += value;
        }
        public void DealDamage(int value, IFightable opponent)
        {
            opponent.ChangeHealth(-value);
        }

        public void SetInventoryPage(byte page)
        {
            this.inventoryPage = page;
        }

        public void EquipWeapon(Item item)
        {
            activeEquipment.weapon = item;
        }

        public void EquipShield(Item item)
        {
            activeEquipment.shield = item;
        }

        public void UnequipWeapon()
        {
            activeEquipment.weapon = null;
        }

        public void UnequipShield()
        {
            activeEquipment.shield = null;
        }
        /*
        private List<Position2D> updatePositions()
        {
            List<Position2D> updatedPositions = new List<Position2D>(this.positions);
            Position2D actualPos;
            actualPos.posX = this.posX;
            actualPos.posY = this.posY;
            for (int i = 0; i < positions.Count; i++)
            {
                if (i == 0)
                {
                    updatedPositions[i] = actualPos;
                }
                else
                {
                    updatedPositions[i] = this.positions[i - 1];
                }
            }
            return updatedPositions;
        }*/
    }
}
