using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGameMyLive
{
    public class Enemy : Unit
    {
        public Enemy(string name, float maxHealth, float maxArmor, float maxMana, char[,] image, int posX, int posY, int positionLeftAndRight, int setCurcorShowInfoBattlePosition, float maxDamage, float coofCritDamage)
        {
            Name = name;
            MaxHealth = maxHealth;
            CurrentHealth = MaxHealth;
            MaxArmor = maxArmor;
            CurrentArmor = MaxArmor;
            MaxMana = maxMana;
            CurrentMana = MaxMana;
            Image = image;
            PosX = posX;
            PosY = posY;
            PositionLeftAndRight = positionLeftAndRight;
            MaxDamage = maxDamage;
            CurrentDamage = MaxDamage;
            CoofCritDamage = coofCritDamage;
            SetCurcorShowInfoBattlePosition = setCurcorShowInfoBattlePosition;
            ColorName = ConsoleColor.Red;

        }
        public int CharracterBattle()
        {
            Random random = new Random();
            int rand = random.Next(1, 3);
            return rand;
        }
    }
}
