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
            Player player = new Player(5, 5, 1, '*');
            Monster monster1 = new Monster("Skeleton", 10, 10, 1, '#');
            Monster monster2 = new Monster("Skeleton", 10, 12, 1, '#');
            Monster monster3 = new Monster("Skeleton", 5, 15, 1, '#');
            Monster monster4 = new Monster("Skeleton", 1, 18, 1, '#');
            Item sword = new Item(10, 12, '/', "Sword", 10, 1);
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
