﻿using System;
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
        public char[,] WeaponScins;
        public int Weapon;
        public string WeaponName;
        public int PositionCursor;
        public int PotionHealing = 1;
        public int PotionMana = 0;
        public int FireBall = 0;
        public int ElectroBall = 0;
        public int VoxduBall = 0;

        public char[,] PlayerImage = {
        {' ', 'о', ' '},
        {'/', '|', '\\' },
        {'/', ' ', '\\' }
    };public char[,] PlayerImageIron = {
        {' ', 'о', ' ', ' '},
        {'/', '|', '\\','/'},
        {'/', ' ', '\\',' '}
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
            WeaponName = "Рукой";
        }
        public void ScinsInPlayer(bool checkin)
        {
            if (checkin)
            {
                PlayerImage = PlayerImageIron;
            }
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
                case ConsoleKey.UpArrow:

                    if(PotionHealing > 0)
                    {
                        CurrentHealth += 50;
                        PotionHealing--;
                    }

                    break;
                case ConsoleKey.DownArrow:
                    if (PotionMana > 0)
                    {
                        Mana += 15;
                        PotionMana--;
                    }
                    break;
            }

        }
        //бой, при вызове которого также отображаються способности в бою, у юнита также. 
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
