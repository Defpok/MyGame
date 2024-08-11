using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace MyGameMyLive
{
    internal class Player
    {
        public string Name;
        public int MaxHealth;
        public int CurrentHealth;
        public int MaxArmor;
        public int CurrentArmor;
        public int Mana;
        public int Damage;

        public int PositionCursor;
        public char[,] PlayerImage = {
        {' ', 'о', ' '},
        {'/', '|', '\\' },
        {'/', ' ', '\\' }
    };
        public int playerX = 0;
        public int playerY = 20;

        public Player()
        {

        }

        public Player(string name, int maxHealth, int maxArmor, int mana, int damage, int positionCursor)
        {
            Name = name;
            MaxHealth = maxHealth;
            CurrentHealth = maxHealth;
            MaxArmor = maxArmor;
            CurrentArmor = maxArmor;
            Mana = mana;
            Damage = damage;
            PositionCursor = positionCursor;
        }
        public void MovePlayer()
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
                    if (playerX != -0)
                        playerX--;

                    break;
                case ConsoleKey.RightArrow:
                    playerX++;
                    break;
            }

        }
        public int XPlayer()
        {
            return playerX;
        }
        public void MovePlayerNewSpawn()
        {
            playerX = 0;
        }
    }
}
