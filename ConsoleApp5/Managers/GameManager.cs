using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    static class GameManager
    {
        public static List<Character> activeCharacters = new List<Character>();
        public static List<Item> activeItems = new List<Item>();
        public static Player player;
        public static Monster activeOpponent { get; private set; }
        public static Item activeItem { get; private set; }
        public static int activeItemListPosition { get; private set; }
        public static Item selectedItem { get; private set; }
        static Random rand = new Random();
        public static int lastPlayerHit { get; private set; }
        public static int lastOpponentHit { get; private set; }
        public static bool isSomeoneAttacked { get; private set; }
        public enum EGameState
        {
            World,
            Fight,
            FightEnd
        }

        public static EGameState gameState = EGameState.World;

        public enum EInventoryState
        {
            Normal,
            Item,
            SelectedItem,
            Monster
        }

        public static EInventoryState inventoryState = EInventoryState.Normal;

        public static void CheckPosition()
        {
            activeItemListPosition = -1;
            activeOpponent = null;
            if(inventoryState != EInventoryState.SelectedItem)
                inventoryState = EInventoryState.Normal;
            foreach (Item item in activeItems)
            {
                if ((player.posX == item.posX) && (player.posY == item.posY))
                {
                    inventoryState = EInventoryState.Item;
                    activeItem = item;
                    activeItemListPosition = activeItems.IndexOf(item);
                }
            }

            foreach (Character character in activeCharacters)
            {
                if ((player.posX == character.posX) && (player.posY == character.posY))
                {
                    if(character is IFightable && !(character is Player))
                    {
                        inventoryState = EInventoryState.Monster;
                        activeOpponent = (Monster)character;
                    }
                }
            }
        }

        public static void Fight()
        {
            isSomeoneAttacked = true;
            int playerWeaponAttack = 0;
            int playerWeaponDefence = 0;
            int playerShieldDefence = 0;
            if (player.activeEquipment.weapon != null)
            {
                playerWeaponAttack = player.activeEquipment.weapon.attackValue;
                playerWeaponDefence = player.activeEquipment.weapon.defenseValue;
            }
            if(player.activeEquipment.shield != null)
            {
                playerShieldDefence = player.activeEquipment.shield.defenseValue;
            }

            int playerTrueDamage = player.baseAttack + playerWeaponAttack;
            int playerTrueDefence = player.baseDefence + playerWeaponDefence + playerShieldDefence;
            int opponentTrueDamage = activeOpponent.baseAttack;
            int opponentTrueDefence = activeOpponent.baseDefence;
            lastPlayerHit = rand.Next(0, playerTrueDamage - opponentTrueDefence);
            player.DealDamage(lastPlayerHit, activeOpponent);
            if(activeOpponent.health > 0)
            {
                lastOpponentHit = rand.Next(0, opponentTrueDamage - playerTrueDefence);
                activeOpponent.DealDamage(lastOpponentHit, player);
            }
            else
            {
                gameState = EGameState.FightEnd;
            }
        }

        public static void SelectInventoryItem(Item item)
        {
            selectedItem = item;
        }
    }
}
