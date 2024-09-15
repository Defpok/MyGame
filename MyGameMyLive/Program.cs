using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static MyGameMyLive.Map;
using static System.Net.Mime.MediaTypeNames;
using NAudio.Wave;



namespace MyGameMyLive
{
    internal class Program
    {

        static char[,] PlayerImage = {
        {' ', 'о', ' '},
        {'/', '|', '\\' },
        {'/', ' ', '\\' }
    };
        static int playerX = 1;
        static int playerY = 16;


        static void Main(string[] args)
        {
            Console.SetWindowSize(120, 40);
            Console.CursorVisible = false;
            Map map = new Map();

/*            DrawPlayer();*/
                map.RandomSpawnObj();
            while (true)
            {
                /*                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                                HandleInput(keyInfo.Key);*/
               

                Texturs texturs = new Texturs();
                
                map.DisplayMap(0, 15, map.MapsWorld);
                map.MoveSunAndMoon(texturs.Sun, 16, texturs.Moon);

                MovePlayer();

                char[,] icon1 = texturs.Icons;
                char[,] icon2 = texturs.Icons;
                char[,] icon3 = texturs.IconsInfoDiplay;

                int pos = 119 - icon1.GetLength(1);
                map.DisplayMap(0, 0, icon1);
                map.DisplayMap(pos, 0, icon2);
                map.DisplayMap(30, 0, icon3);

                /*Console.SetCursorPosition(0, 7);*/



            }
        }

        static void MovePlayer()
        {
            Console.SetCursorPosition(playerX, playerY);
            for (int i = 0; i < PlayerImage.GetLength(0); i++)
            {
                Console.SetCursorPosition(playerX, playerY + i);
                for (int j = 0; j < PlayerImage.GetLength(1); j++)
                {
                    Console.Write(PlayerImage[i, j]);
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
                case ConsoleKey.UpArrow:
                    playerY--;
                    break;
                case ConsoleKey.DownArrow:
                    playerY++;
                    break;


            }

        }

        


    }
}
