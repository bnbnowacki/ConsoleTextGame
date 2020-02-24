using ConsoleApp5.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    //Class for managing all inputs made by user in game.
    static class InputManager
    {
        public static ConsoleKey activeKey { get; private set; }
        public static Player player;
        
        public static void CheckInput()
        {
            activeKey = Console.ReadKey(false).Key;
            switch (GameManager.gameState)
            {
                case GameManager.EGameState.World:
                    switch (activeKey)
                    {
                        case ConsoleKey.UpArrow:
                            player.SetLastMove(Character.ELastMove.Up);
                            player.SetPosition(posY: player.posY - 1);
                            break;
                        case ConsoleKey.DownArrow:
                            player.SetLastMove(Character.ELastMove.Down);
                            player.SetPosition(posY: player.posY + 1);
                            break;
                        case ConsoleKey.RightArrow:
                            player.SetLastMove(Character.ELastMove.Right);
                            player.SetPosition(posX: player.posX + 1);
                            break;
                        case ConsoleKey.LeftArrow:
                            player.SetLastMove(Character.ELastMove.Left);
                            player.SetPosition(posX: player.posX - 1);
                            break;
                    }
                    switch (GameManager.inventoryState)
                    {
                        case GameManager.EInventoryState.Normal:
                            switch (activeKey)
                            {
                                case ConsoleKey.OemMinus:
                                    if (player.inventoryPage > 0)
                                        player.SetInventoryPage((byte)(player.inventoryPage - 1));
                                    break;

                                case ConsoleKey.OemPlus:
                                    player.SetInventoryPage((byte)(player.inventoryPage + 1));
                                    break;

                                case ConsoleKey.D1:
                                    SelectItem(0 + (player.inventoryPage * 10));
                                    break;

                                case ConsoleKey.D2:
                                    SelectItem(1 + (player.inventoryPage * 10));
                                    break;

                                case ConsoleKey.D3:
                                    SelectItem(2 + (player.inventoryPage * 10));
                                    break;

                                case ConsoleKey.D4:
                                    SelectItem(3 + (player.inventoryPage * 10));
                                    break;

                                case ConsoleKey.D5:
                                    SelectItem(4 + (player.inventoryPage * 10));
                                    break;

                                case ConsoleKey.D6:
                                    SelectItem(5 + (player.inventoryPage * 10));
                                    break;

                                case ConsoleKey.D7:
                                    SelectItem(6 + (player.inventoryPage * 10));
                                    break;

                                case ConsoleKey.D8:
                                    SelectItem(7 + (player.inventoryPage * 10));
                                    break;

                                case ConsoleKey.D9:
                                    SelectItem(8 + (player.inventoryPage * 10));
                                    break;

                                case ConsoleKey.D0:
                                    SelectItem(9 + (player.inventoryPage * 10));
                                    break;
                            }
                            break;

                        case GameManager.EInventoryState.Monster:
                            switch (activeKey)
                            {
                                case ConsoleKey.A:
                                    GameManager.gameState = GameManager.EGameState.Fight;
                                    break;
                            }
                            break;

                        case GameManager.EInventoryState.Item:
                            switch (activeKey)
                            {
                                case ConsoleKey.A:
                                    player.inventory.Add(GameManager.activeItems[GameManager.activeItemListPosition]);
                                    GameManager.activeItems.Remove(GameManager.activeItems[GameManager.activeItemListPosition]);
                                    break;
                            }
                            break;

                        case GameManager.EInventoryState.SelectedItem:
                            switch (activeKey)
                            {
                                case ConsoleKey.D:
                                    if(GameManager.selectedItem == player.activeEquipment.weapon)
                                    {
                                        player.EquipWeapon(null);
                                    }
                                    GameManager.selectedItem.SetPosition(player.posX, player.posY);
                                    GameManager.activeItems.Add(GameManager.selectedItem);
                                    player.inventory.Remove(GameManager.selectedItem);
                                    GameManager.SelectInventoryItem(null);
                                    GameManager.inventoryState = GameManager.EInventoryState.Normal;
                                    break;

                                case ConsoleKey.E:
                                    if(player.activeEquipment.weapon == GameManager.selectedItem)
                                    {
                                        player.EquipWeapon(null);
                                        GameManager.SelectInventoryItem(null);
                                        GameManager.inventoryState = GameManager.EInventoryState.Normal;
                                    }
                                    else
                                    {
                                        if(GameManager.selectedItem is Equipment)
                                        player.EquipWeapon(GameManager.selectedItem as Equipment);
                                        GameManager.SelectInventoryItem(null);
                                        GameManager.inventoryState = GameManager.EInventoryState.Normal;
                                    }
                                    break;
                            }
                            break;
                    }
                    break;

                case GameManager.EGameState.Fight:
                    switch (activeKey)
                    {
                        case ConsoleKey.A:
                            GameManager.Fight();
                            break;
                    }
                    break;

                case GameManager.EGameState.FightEnd:
                    switch (activeKey)
                    {
                        case ConsoleKey.E:
                            GameManager.gameState = GameManager.EGameState.World;
                            GameManager.activeCharacters.Remove(GameManager.activeOpponent);
                            break;
                    }
                    break;
            }
        }

        public static void SelectItem(int itemNumber)
        {
            if(itemNumber < player.inventory.Count)
            {
                GameManager.SelectInventoryItem(player.inventory[itemNumber]);
                GameManager.inventoryState = GameManager.EInventoryState.SelectedItem;
            }
        }
    }
}
