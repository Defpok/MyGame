using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;



namespace MyGameMyLive
{
    internal class Program
    {



        static void Main(string[] args)
        {
            ConclusionLoading conclusionLoading = new ConclusionLoading();
            string namePlayer = Console.ReadLine();
            Console.Clear();
            Player player = new Player(namePlayer, 1000, 100, 100, 0);
            Unit unit = new Unit("ssda", 1000, 100, 100, 30);
            int playerX = 0;
            int playerY = 20;
            Map map = new Map();
            Write write = new Write();
            Texturs texturs = new Texturs();
            Console.CursorVisible = false;







            while (player.CurrentHealth > 0)
            {



                /*conclusionLoading.Loading();*/
                write.ShowInfoPlayer(player);
                write.ShowInfoUnit(unit);




                Console.SetCursorPosition(0, 20);
                map.DisplayMap(playerX);


                Console.SetCursorPosition(playerX, playerY);
                for (int i = 0; i < player.PlayerImage.GetLength(0); i++)
                {
                    Console.SetCursorPosition(playerX, playerY + i);
                    for (int j = 0; j < player.PlayerImage.GetLength(1); j++)
                    {
                        Console.Write(player.PlayerImage[i, j]);
                    }
                }


                ConsoleKeyInfo cahrKey = Console.ReadKey();
                switch (cahrKey.Key)
                {
                    case ConsoleKey.LeftArrow:
                        playerX--;

                        break;
                    case ConsoleKey.RightArrow:
                        playerX++;
                        break;
                }


                if(playerX == map.MapsWorld.GetLength(1) - 2)
                    playerX = 0;

            }


        }
    }
}
