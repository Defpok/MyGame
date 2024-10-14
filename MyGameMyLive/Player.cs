using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace MyGameMyLive
{
    public class Player : Unit
    {
        public Player(string name, float maxHealth, float maxArmor, float maxMana, char[,] image, int posX, int posY, int positionLeftAndRight, int setCurcorShowInfoBattlePosition, float maxDamage, float coofCritDamage)
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
            ColorName = ConsoleColor.Cyan;
        }
        public bool LelelUpNext = false;
        public int PotionHel = 1;
        public int PotionMana = 1;
        public bool ChecSword = false;
        public bool ChecMoergen = false;
        public bool ChecAxe = false;
        public bool Shield = false;
        public bool SearchHomeOne = true;
        public bool SearchHomeTwo = true;

        public void MovePlayer(Write textInfo, Musics soundPoint)
        {

            ConsoleKeyInfo cahrKey = Console.ReadKey();

            switch (cahrKey.Key)
            {
                case ConsoleKey.LeftArrow:
                    if (PosX != 1)
                        PosX--;
                    break;
                case ConsoleKey.RightArrow:
                    if (PosX != 115)
                        PosX++;
                    break;
                case ConsoleKey.UpArrow:
                    if (PosY != 24)
                        PosY--;
                    break;
                case ConsoleKey.DownArrow:
                    if (PosY != 26)
                        PosY++;
                    break;
                case ConsoleKey.R:
                    if (ChecingObj(20 + 3, 24, 2) && SearchHomeOne )
                    {                              
                        SearchBox();
                        SearchHomeOne = false;
                    }
                    else if ( ChecingObj(70 + 3, 24, 2) && SearchHomeTwo)
                    {
                        SearchBox();
                        SearchHomeTwo = false;
                    }
                    break;
                case ConsoleKey.F:
                    if (ChecingEndMap())
                        LelelUpNext = true;
                    break;
                case ConsoleKey.C:
                    if (CurrentHealth < 2000)
                    {
                        if (PotionHel > 0)
                        {
                            PotionHel--;
                            CurrentHealth += 200;
                            soundPoint.PlaySoundEffect("sounds/PointUs.mp3");
                        }
                    }
                    break;
                case ConsoleKey.V:
                    if (CurrentMana < 1200)
                    {
                        if (PotionMana > 0)
                        {
                            PotionMana--;
                            CurrentMana += 90;
                            soundPoint.PlaySoundEffect("sounds/PointUs.mp3");
                        }
                    }
                    break;
                case ConsoleKey.T:
                    ChoiseWeapor();
                    break;

            }

        }
        public void ChoiseWeapor()
        {
            Texturs textur = new Texturs();


            bool choiseWeap = true;
            ConsoleKeyInfo cahrKey = Console.ReadKey();
            while (choiseWeap)
            {

                switch (cahrKey.Key)
                {
                    case ConsoleKey.D1:
                        if (ChecSword)
                        {
                            CurrentDamage += 50;
                            CoofCritDamage += 0.3f;
                            if (!Shield)
                                Image = textur.PlayerImageSword;
                            else
                                Image = textur.PlayerImageShieldAndSword;
                        }

                        break;
                    case ConsoleKey.D2:
                        if (ChecMoergen)
                        {
                            CurrentDamage += 80;
                            CoofCritDamage += 0.2f;
                            if (!Shield)
                                Image = textur.PlayerImageMorgen;
                            else
                                Image = textur.PlayerImageShieldAndMorgen;
                        }

                        break;
                    case ConsoleKey.D3:
                        if (ChecAxe)
                        {
                            CurrentDamage += 40;
                            CoofCritDamage += 0.9f;
                            if (!Shield)
                                Image = textur.PlayerImageAxe;
                            else
                                Image = textur.PlayerImageShieldAndAxe;
                        }


                        break;
                }
                choiseWeap = false;
            }


        }
        public int CharracterBattle()
        {
            ConsoleKeyInfo cahrKey = Console.ReadKey();
            switch (cahrKey.Key)
            {
                case ConsoleKey.D1:
                    return 1;
                case ConsoleKey.D2:
                    return 2;
                case ConsoleKey.D3:
                    return 3;
            }
            return 0;
        }
        public bool ChecingEndMap()
        {
            if (PosX == 114 || PosX == 115 || PosX == 113)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool ChecingObj(int x, int y, int coolision)
        {
            for (int i = 0; i < coolision; i++)
            {
                if (PosX - i == x && PosY == y)
                    return true;

            }
            return false;
        }
        public void SearchObj()
        {

        }

        public bool ExitToLevelUp(Write textInfo)
        {
            textInfo.ShowInfoGG(36, 4, "Вы можете перейти на следующий уровень нажав F", ConsoleColor.Green);
            ConsoleKeyInfo cahrKey = Console.ReadKey();
            switch (cahrKey.Key)
            {
                case ConsoleKey.F:

                    return true;

            }
            return false;
        }
        public void SearchBox()
        {


            Random random = new Random();
            Write write = new Write();
            Texturs texturs = new Texturs();
            int rand = random.Next(0, 9);
            if (SearchHomeOne || SearchHomeTwo)
            {
                switch (rand)
                {
                    case 0:
                        if (PotionHel < 2)
                        {
                            write.ShowInfoGG(36, 1, "Вы нашли зелье здоровья!", ConsoleColor.Green);
                            PotionHel++;
                        }
                        else
                            write.ShowInfoGG(36, 1, "Вы ничего не нашли", ConsoleColor.Red);
                        break;
                    case 1:
                        if (PotionMana < 2)
                        {
                            write.ShowInfoGG(36, 1, "Вы нашли зелье Маны!", ConsoleColor.Green);
                            PotionMana++;
                        }
                        else
                            write.ShowInfoGG(36, 1, "Вы ничего не нашли", ConsoleColor.Red);
                        break;
                    case 2:
                        if (!ChecSword)
                        {
                            write.ShowInfoGG(36, 2, "Вы нашли меч!", ConsoleColor.Green);
                            ChecSword = true;
                        }
                        else
                            write.ShowInfoGG(36, 2, "Вы ничего не нашли", ConsoleColor.Red);
                        break;
                    case 3:
                        if (ChecAxe)
                        {
                            write.ShowInfoGG(36, 2, "Вы нашли топор!", ConsoleColor.Green);
                            ChecAxe = true;
                        }
                        else
                            write.ShowInfoGG(36, 2, "Вы ничего не нашли", ConsoleColor.Red);
                        break;
                    case 4:
                        if (!ChecMoergen)
                        {
                            write.ShowInfoGG(36, 2, "Вы нашли булаву!", ConsoleColor.Green);
                            ChecMoergen = true;
                        }
                        else
                            write.ShowInfoGG(36, 2, "Вы ничего не нашли", ConsoleColor.Red);
                        break;
                    case 5:
                        if (!Shield)
                        {
                            write.ShowInfoGG(36, 1, "Вы нашли щит!", ConsoleColor.Green);
                            Shield = true;
                            CurrentArmor += 200;
                            Image = texturs.PlayerImageShield;

                        }
                        else if (CurrentArmor < 1000)
                        {
                            write.ShowInfoGG(36, 1, "У вас уже есть щит", ConsoleColor.Red);
                            CurrentArmor += 100;
                        }
                        write.ShowInfoGG(36, 1, "Вы нашли щит, но вам не куда его класть", ConsoleColor.Red);
                        break;
                    case 6:
                        write.ShowInfoGG(36, 1, "Вы ничего не нашли", ConsoleColor.Red);
                        break;
                    case 7:
                        write.ShowInfoGG(36, 1, "Вы ничего не нашли", ConsoleColor.Red);
                        break;
                    case 8:
                        write.ShowInfoGG(36, 1, "Вы ничего не нашли", ConsoleColor.Red);
                        break;
                    default:
                        break;
                }

            }

            Console.ReadKey();

        }
    }
}

