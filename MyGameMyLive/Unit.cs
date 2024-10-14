using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace MyGameMyLive
{
    public class Unit
    {
        public string Name;
        public float MaxDamage;
        public float CurrentDamage;
        public float MaxHealth;
        public float CurrentHealth;
        public float MaxArmor;
        public float CurrentArmor;
        public float MaxMana;
        public float CurrentMana;
        public float CoofCritDamage;
        public float FireBall = 200;

        public char[,] Image;
        public int PosX;
        public int PosY;
        public int SetCurcorShowInfoBattlePosition;
        public int PositionLeftAndRight;

        public ConsoleColor ColorName;
        public Unit() 
        {

        }
        public void SpawnPlayer()
        {
            Console.ForegroundColor = ColorName;
            Console.SetCursorPosition(PosX, PosY);
            for (int i = 0; i < Image.GetLength(0); i++)
            {
                Console.SetCursorPosition(PosX, PosY + i);
                for (int j = 0; j < Image.GetLength(1); j++)
                {
                    Console.Write(Image[i, j]);
                }
            }
            Console.ResetColor();
        }
        public bool ChecingArmor()
        {
            if (CurrentArmor > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


    }
}
