using ConsoleApp5.GameData;
using ConsoleApp5.GameData.Game_Objects.Items;
using ConsoleApp5.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    class Program
    {
        static void Main(string[] args)
        {
            //entry config
            Console.SetWindowSize(OutputManager.screenWidth, OutputManager.screenHeight);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.CursorVisible = false;
            Player player = new Player(15, 15, 1, '*');
            Equipment sword = new Equipment(10, 12, '/', "Sword", 10, 1);
            Currency money = new Currency(10, 10, '+', "Gold", 1, 10);

            List<DropItem> skeletonDrop = new List<DropItem>() { new DropItem(new Equipment("Mace", 2, 1), 30), new DropItem(new Currency("Gold", 1, 10), 100) };
            List<Monster> monsters = new List<Monster>() { new Monster("Skeleton", 10, 10, 1, 50, '#', skeletonDrop), new Monster("Skeleton", 10, 12, 1, 50, '#', skeletonDrop), new Monster("Skeleton", 5, 15, 1, 50, '#', skeletonDrop), new Monster("Skeleton", 1, 18, 1, 50, '#', skeletonDrop),  };


            ConsoleKey actualKey = ConsoleKey.F12;
            OutputManager.DrawScreen();

            //main game loop
            while (InputManager.activeKey != ConsoleKey.Q)
            {
                InputManager.CheckInput();
                GameManager.CheckPosition();
                OutputManager.DrawScreen();
            }
            
            Console.ReadKey();
        }
    }
}
