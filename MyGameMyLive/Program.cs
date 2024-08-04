using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;



namespace MyGameMyLive
{
    internal class Program
    {


        static void Main(string[] args)
        {
            ConclusionLoading conclusionLoading = new ConclusionLoading();
            string namePlayer = Console.ReadLine(); 
            Console.Clear();
            Player player = new Player(namePlayer, 1005, 100, 100, 0);
            Unit unit = new Unit("ssda", 1000, 100, 100, 30);
            Map map = new Map();
            Write write = new Write();

            int userXY = 0;
            while (player.CurrentHealth > 0)
            {
                /*conclusionLoading.Loading();*/
                write.ShowInfoPlayer(player);
                write.ShowInfoUnit(unit);


                map.MapSpawnObject(0, 0, map.foresterSpruce);
                map.MapSpawnObject(0, 5, map.foresterOak);

                map.MapSpawnObject(0, 10, map.foresterOak);
                map.MapSpawnObject(0, 15, map.foresterOak);

                map.MapSpawnObject(0, userXY, player.PlayerImage);

                Console.SetCursorPosition(0, 20);

                map.DisplayMap();

                Console.SetCursorPosition(0, 15);

                ConsoleKeyInfo cahrKey = Console.ReadKey();
                switch(cahrKey.Key)
                {
                    case ConsoleKey.A:
                        userXY--;

                        break;
                    case ConsoleKey.D:
                        userXY++;
                        break;
                }





                // Отображаем карту



                
                Console.Clear();


            }
        }
    }
}
