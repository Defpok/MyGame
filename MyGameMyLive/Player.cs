using System;
using System.Collections.Generic;
using System.Linq;
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
        public int PositionCursor;
        public char[,] PlayerImage = {
        {' ', 'о', ' '},
        {'/', '|', '\\'},
        {'/', ' ', '\\' }
    };

        public Player()
        {

        }

        public Player(string name, int maxHealth, int maxArmor, int mana, int positionCursor)
        {
            Name = name;
            MaxHealth = maxHealth;
            CurrentHealth = maxHealth;
            MaxArmor = maxArmor;
            CurrentArmor = maxArmor;
            Mana = mana;
            PositionCursor = positionCursor;
        }



    }
}
