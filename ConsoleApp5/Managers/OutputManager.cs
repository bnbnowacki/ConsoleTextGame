using ConsoleApp5.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    /* Class for handling everything that has to be written in console window. */
    static class OutputManager
    {
        public const int screenWidth = 140;
        public const int screenHeight = 40;
        public const int gameWindowWidth = 60;
        public const int gameWindowHeight = 20;

        private static int cameraOffsetX = 0;
        private static int cameraOffsetY = 0;

        public static char[,] gameWindowTiles = new char[gameWindowHeight,gameWindowWidth];

        //main method for drawing text in console window.
        public static void DrawScreen()
        {
            Console.Clear();
            AddCameraOffset();
            CreateGameWindow();
            Console.WriteLine(Strings.TxtGameTitle, GameManager.player.level);
            if(GameManager.gameState == GameManager.EGameState.World)
            DrawLevel();
            if(GameManager.gameState == GameManager.EGameState.Fight || GameManager.gameState == GameManager.EGameState.FightEnd)
            {
                Console.WriteLine("\n\n\n");
                Console.WriteLine("FIGHT!");
                Console.WriteLine("You VS " + GameManager.activeOpponent.name);
                Console.WriteLine("Your HP: " + GameManager.player.health);
                Console.WriteLine("Opponent's HP: " + GameManager.activeOpponent.health);
                Console.WriteLine("--------------------------------------------");
            }
            DrawControlPanel();
            DrawInventory();
        }
        static void CreateGameWindow()
        {
            CreateLevel();
            CreateItems();
            CreateCharacters();
        }
        static void AddCameraOffset()
        {
            if (GameManager.player.posX >= gameWindowWidth - 5 + cameraOffsetX)
                cameraOffsetX++;
            if (GameManager.player.posY >= gameWindowHeight - 5 + cameraOffsetY)
                cameraOffsetY++;
            if (GameManager.player.posX <= cameraOffsetX + 5)
                cameraOffsetX--;
            if (GameManager.player.posY <= cameraOffsetY + 5)
                cameraOffsetY--;
        }

        //method used to create world matrix including bounds.
        static void CreateLevel()
        {
            char[,] level = new char[gameWindowHeight, gameWindowWidth];
            for (int i = 0; i < gameWindowHeight; i++)
            {
                for (int j = 0; j < gameWindowWidth; j++)
                {
                    if ((j == 0 || j == gameWindowWidth - 1) && (i != 0))
                    {
                        level[i, j] = '|';
                    }
                    else if (i == 0 || i == gameWindowHeight - 1)
                    {
                        level[i, j] = '_';
                    }
                    else
                    {
                        level[i, j] = ' ';
                    }
                }
            }

            gameWindowTiles = level;
        }


        //method used to add existing items in game to world matrix.
        static void CreateItems()
        {
            foreach (Item item in GameManager.activeItems)
            {
                for (int i = 0; i < gameWindowTiles.GetLength(0); i++)
                {
                    for (int j = 0; j < gameWindowTiles.GetLength(1); j++)
                    {
                        if (item.posY == i + cameraOffsetY && item.posX == j + cameraOffsetX)
                        {
                            gameWindowTiles[i, j] = item.texture;
                        }
                    }
                }
            }
        }

        //method used to add existing characters in game to world matrix.
        static void CreateCharacters()
        {
            foreach (Character character in GameManager.activeCharacters)
            {
                for (int i = 0; i < gameWindowTiles.GetLength(0); i++)
                {
                    for (int j = 0; j < gameWindowTiles.GetLength(1); j++)
                    {
                        if (character.posY == i + cameraOffsetY && character.posX == j + cameraOffsetX)
                        {
                            gameWindowTiles[i, j] = character.texture;
                        }
                    }
                }
            }
        }


        // WIP ( improvements in refreshing screen)
        public static void DrawPlayerMovement(Player player)
        {
            switch (player.lastMove)
            {
                case Character.ELastMove.Left:
                    Console.SetCursorPosition(player.posX, player.posY + 1);
                    Console.Write("* ");
                    break;

                case Character.ELastMove.Right:
                    Console.SetCursorPosition(player.posX -1, player.posY+1);
                    Console.Write(" *");
                    break;

                case Character.ELastMove.Up:
                    Console.SetCursorPosition(player.posX, player.posY + 2);
                    Console.Write(' ');
                    Console.SetCursorPosition(player.posX, player.posY + 1);
                    Console.Write('*');
                    break;

                case Character.ELastMove.Down:
                    Console.SetCursorPosition(player.posX, player.posY);
                    Console.Write(' ');
                    Console.SetCursorPosition(player.posX, player.posY + 1);
                    Console.Write('*');
                    break;

            }
        }

        static void DrawLevel()
        {
            for (int i = 0; i < gameWindowHeight; i++)
            {
                for (int j = 0; j < gameWindowWidth; j++)
                {
                    Console.Write(gameWindowTiles[i, j]);
                }
                Console.WriteLine();
            }
        }

        static void DrawControlPanel()
        {
            switch (GameManager.gameState)
            {
                case GameManager.EGameState.World:
                    switch (GameManager.inventoryState)
                    {
                        case GameManager.EInventoryState.Normal:
                            Console.WriteLine("[-] Prev Page, [=] Next Page, [1-0] Select Item");
                            break;

                        case GameManager.EInventoryState.Monster:
                            Console.WriteLine("[Y] Yes");
                            Console.WriteLine("Are you sure you want to attack this monster? ({0})", GameManager.activeOpponent.name);
                            break;

                        case GameManager.EInventoryState.Item:
                            Console.WriteLine("[Y] Yes");
                            Console.WriteLine("Do you want to pick up this " + GameManager.activeItem.name + "?");
                            break;

                        case GameManager.EInventoryState.SelectedItem:
                            if(GameManager.selectedItem == GameManager.player.activeEquipment.weapon)
                                Console.WriteLine("[E] Unequip Item, [D] Drop Item");
                            else
                                Console.WriteLine("[E] Equip Item, [D] Drop Item");
                            Console.WriteLine("Item Name: " + GameManager.selectedItem.name);
                            Console.WriteLine("Item Attack Value: " + GameManager.selectedItem.attackValue);
                            Console.WriteLine("Item Defence value: " + GameManager.selectedItem.defenseValue);
                            break;
                    }
                    break;

                case GameManager.EGameState.Fight:
                    Console.WriteLine("[A] Attack");
                    if (GameManager.isSomeoneAttacked)
                    {
                        Console.WriteLine("You Dealed {0} damage to {1}", GameManager.lastPlayerHit, GameManager.activeOpponent.name);
                        if(GameManager.activeOpponent.health > 0)
                        {
                            Console.WriteLine("You lost {0} health points due to {1} attack.", GameManager.lastOpponentHit, GameManager.activeOpponent.name);
                        }
                    }
                    break;

                case GameManager.EGameState.FightEnd:
                    Console.WriteLine("[E] Exit Fight");
                    Console.WriteLine("YOU WON!");
                    break;
            }
        }

        static void DrawInventory()
        {
            int activePage = GameManager.player.inventoryPage * 10;
            List<Item> items = GameManager.player.inventory;
            for(int i = 0; i<10; i++)
            {
                string itemName = "";
                string isEquippedText = "";
                try
                {
                    if (items[i + activePage] != null)
                    {
                        itemName = items[i + activePage].name;
                        if(GameManager.player.activeEquipment.weapon != null && GameManager.player.activeEquipment.weapon == items[i + activePage])
                        {
                            isEquippedText = "(Equipped)";
                        }
                    }
                       
                }
                catch
                {

                }
                Console.WriteLine((i + 1 + activePage) + ". " + itemName + " "+ isEquippedText);
            }
        }

    }
}
