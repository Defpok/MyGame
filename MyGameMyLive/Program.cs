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
        static int playerRow = 0; // Начальная строка игрока
        static int playerCol = 0; // Начальный столбец игрока

        static char[,] playerImage = {
            {' ', 'о', ' '},
            {'/', '|', '\\'},
            {'/', ' ', '\\'}
        };



        static void Main(string[] args)
        {
            Console.SetWindowSize(140, 40);
            
            Map map = new Map();

            DrawPlayer();
            while (true)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                HandleInput(keyInfo.Key);

                map.RandomSpawnObj();
                map.DisplayMap();

            }
        }

        static void DrawPlayer()
        {
            for (int i = 0; i < playerImage.GetLength(0); i++)
            {
                Console.SetCursorPosition(playerCol, playerRow + i);
                for (int j = 0; j < playerImage.GetLength(1); j++)
                {
                    Console.Write(playerImage[i, j]);
                }
            }
        }

        static void ClearPlayer()
        {
            for (int i = 0; i < playerImage.GetLength(0); i++)
            {
                Console.SetCursorPosition(playerCol, playerRow + i);
                Console.Write("   "); // Очистка позиции персонажа (замена на пробелы)
            }
        }

        static void HandleInput(ConsoleKey key)
        {
            ClearPlayer(); // Удаляем старую позицию игрока

            switch (key)
            {
                case ConsoleKey.A: // Влево
                    if (playerCol > 0) playerCol--;
                    break;
                case ConsoleKey.D: // Вправо
                    if (playerCol < Console.WindowWidth - playerImage.GetLength(1)) playerCol++;
                    break;
                case ConsoleKey.W: // Вверх
                    if (playerRow > 0) playerRow--;
                    break;
                case ConsoleKey.S: // Вниз
                    if (playerRow < Console.WindowHeight - playerImage.GetLength(0)) playerRow++;
                    break;
            }

            DrawPlayer(); // Рисуем игрока на новой позиции
        }


    }
}
