using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGameMyLive
{
    internal class Unit
    {
        public string Name;
        public int MaxHealth;
        public int CurrentHealth;
        public int MaxArmor;
        public int CurrentArmor;
        public int Damage;
        public int Mana;
        public int PositionCursor;
        public char[,] UnitImage;
        public int UnitX = 90;
        public int UnitY = 20;
        public bool FihtigToPlayer1 = false;
        public Unit(string name, int maxHealth, int maxArmor, int mana, int damage, int positionCursor, char[,] unitImage)
        {
            Name = name;
            MaxHealth = maxHealth;
            CurrentHealth = maxHealth;
            MaxArmor = maxArmor;
            CurrentArmor = maxArmor;
            Mana = mana;
            Damage = damage;
            PositionCursor = positionCursor;
            UnitImage = unitImage;

        }
        public void SpawnUnit(char[,] skinUnit, int playerMove)
        {
            if (UnitX != 0)
            {
                Console.SetCursorPosition(UnitX, UnitY);
                for (int i = 0; i < skinUnit.GetLength(0); i++)
                {
                    Console.SetCursorPosition(UnitX, UnitY + i);
                    for (int j = 0; j < skinUnit.GetLength(1); j++)
                    {
                        Console.Write(skinUnit[i, j]);
                    }
                }
                MoveUnit(playerMove);

            }
        }

        public void MoveUnit(int playerMoveDuble)
        {
            

            if (UnitX != playerMoveDuble + 5 && UnitX != playerMoveDuble + 4 && UnitX != playerMoveDuble + 3)

                UnitX--;
            else
                FihtigToPlayer1 = true;
            

        }



    }
}
