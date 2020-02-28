using ConsoleApp5.GameData;
using ConsoleApp5.Objects;
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


        private int[] baseAttackByLvl = new int[] { 6, 8, 10 };
        private int[] baseDefenceByLvl = new int[] { 2, 3, 4 };
        public List<Item> inventory { get; private set; }
        public EquipmentSet activeEquipment;
        public Player(int posX, int posY) : base(posX, posY)
        {
            inventory = new List<Item>();
            GameManager.player = this;
            InputManager.player = this;
            this.baseAttack = baseAttackByLvl[this.level - 1];
            this.baseDefence = baseDefenceByLvl[this.level - 1];
        }

        public Player(int posX, int posY, byte level, char texture) : base(posX, posY, level, texture)
        {
            inventory = new List<Item>();
            GameManager.player = this;
            InputManager.player = this;
            this.baseAttack = baseAttackByLvl[this.level - 1];
            this.baseDefence = baseDefenceByLvl[this.level - 1];
        }



        public void DealDamage(int value, IFightable opponent)
        {
            opponent.ChangeHealth(-value);
        }

        public void SetInventoryPage(byte page)
        {
            this.inventoryPage = page;
        }

        public void EquipWeapon(Equipment item)
        {
            activeEquipment.weapon = item;
        }

        public void EquipShield(Equipment item)
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

        public void AddExperience(int expAmount)
        {
            this.experience += expAmount;

            if(this.level < ExperienceTable.experienceTable.Length)
            {
                while (this.experience >= ExperienceTable.experienceTable[this.level])
                {
                    this.LevelUp();
                    UpdateBaseStats();

                    if (this.level >= ExperienceTable.experienceTable.Length)
                        break;
                }
            }
        }

        private void UpdateBaseStats()
        {
            this.baseAttack = baseAttackByLvl[this.level - 1];
            this.baseDefence = baseDefenceByLvl[this.level - 1];
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
    struct EquipmentSet
    {
        public Equipment weapon;
        public Equipment shield;
    }
}
