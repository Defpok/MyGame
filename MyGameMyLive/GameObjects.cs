using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace MyGameMyLive
{
    public class GameObjects
    {
        public char[,] ImageObj;
        public int X, Y;
        public string NameObject;

        public bool CheckUserPlaceToGameObj(int coordUser)
        {
            if (X == coordUser - 5)
            {
                return true;
            }
            return false;
        }
    }
    public class Box : GameObjects
    {
        public bool Empty;
        public char[,] ImageObjEmp;
        public Box(char[,] imageObj, char[,] imageObjTwo, int x, int y, bool empty)
        {
            Empty = empty;
            if (Empty)
                ImageObj = imageObj;
            else
                ImageObj = imageObjTwo;

            ImageObjEmp = imageObjTwo;
            X = x;
            Y = y;
        }
        public void SearchBox(Player player)
        {
            if (Empty)
            {
                Random random = new Random();
                Write write = new Write();
                Texturs texturs = new Texturs();
                int rand = random.Next(0, 9);
                switch (rand)
                {
                    case 0:
                        if (player.PotionHel < 5)
                        {
                            write.ShowInfoGG(36, 2, "Вы нашли зелье здоровья!", ConsoleColor.Green);
                            player.PotionHel++;
                        }
                        else
                            write.ShowInfoGG(36, 2, "Вы ничего не нашли", ConsoleColor.Red);
                        break;
                    case 1:
                        if (player.PotionMana < 5)
                        {
                            write.ShowInfoGG(36, 2, "Вы нашли зелье Маны!", ConsoleColor.Green);
                            player.PotionMana++;
                        }
                        else
                            write.ShowInfoGG(36, 2, "Вы ничего не нашли", ConsoleColor.Red);
                        break;
                    case 2:
                        if (!player.ChecSword)
                        {
                            write.ShowInfoGG(36, 2, "Вы нашли меч!", ConsoleColor.Green);
                            player.ChecSword = true;
                        }
                        else
                            write.ShowInfoGG(36, 2, "Вы ничего не нашли", ConsoleColor.Red);
                        break;
                    case 3:
                        if (!player.ChecAxe)
                        {
                            write.ShowInfoGG(36, 2, "Вы нашли топор!", ConsoleColor.Green);
                            player.ChecAxe = true;
                        }
                        else
                            write.ShowInfoGG(36, 2, "Вы ничего не нашли", ConsoleColor.Red);
                        break;
                    case 4:
                        if (!player.ChecMoergen)
                        {
                            write.ShowInfoGG(36, 2, "Вы нашли булаву!", ConsoleColor.Green);
                            player.ChecMoergen = true;
                        }
                        else
                            write.ShowInfoGG(36, 2, "Вы ничего не нашли", ConsoleColor.Red);
                        break;
                    case 5:
                        if (!player.Shield)
                        {
                            write.ShowInfoGG(36, 2, "Вы нашли щит!", ConsoleColor.Green);
                            player.Shield = true;
                            player.CurrentArmor += 200;
                            player.Image = texturs.PlayerImageShield;

                        }
                        else if (player.CurrentArmor < 1000)
                        {
                            write.ShowInfoGG(36, 1, "У вас уже есть щит", ConsoleColor.Red);
                            player.CurrentArmor += 100;
                        }
                        break;
                    case 6:
                        write.ShowInfoGG(36, 2, "Вы ничего не нашли", ConsoleColor.Red);
                        break;
                    case 7:
                        write.ShowInfoGG(36, 2, "Вы ничего не нашли", ConsoleColor.Red);
                        break;
                    case 8:
                        write.ShowInfoGG(36, 2, "Вы ничего не нашли", ConsoleColor.Red);
                        break;
                    default:
                        break;
                }

                Empty = false;
                ImageObj = ImageObjEmp;

            }
        }
        public void SpawnBox()
        {
            Console.SetCursorPosition(X, Y);
            for (int i = 0; i < ImageObj.GetLength(0); i++)
            {
                Console.SetCursorPosition(X, Y + i);
                for (int j = 0; j < ImageObj.GetLength(1); j++)
                {
                    Console.Write(ImageObj[i, j]);
                }
            }
            Console.ResetColor();

        }
        public bool CheckUserPlaceToBox(int coordUsX, int coordUsY, Write write, Map map, Musics soundOpen)
        {
            if (Empty)
            {
                
                if (X == coordUsX + 1 && Y == coordUsY + 1)
                {
                    write.ShowInfoGG(36, 2, "Вы нашли сундук, нажмите E чтобы обыскать его", ConsoleColor.Green);
                    ConsoleKeyInfo cahrKey = Console.ReadKey();
                    write.ShowInfoGG(36, 2, "                                                 ", ConsoleColor.Green);
                    map.DisplayUIClear();
                    switch (cahrKey.Key)
                    {
                        case ConsoleKey.E:
                            soundOpen.PlaySoundEffect("sounds/BoxOpen.mp3");
                            return true;
                    }
                }

            }
            return false;
        }



    }

    public class Flora : GameObjects
    {
        public Flora(char[,] imageObj)
        {
            ImageObj = imageObj;
            Y = 9;
        }

    }
    public class Road : GameObjects
    {
        public Road(char[,] imageObj, string nameObject)
        {
            ImageObj = imageObj;
            NameObject = nameObject;
        }

    }
    public class Home : GameObjects
    {
        public int CoordDoor;
        public Home(char[,] imageObj, string nameObject)
        {
            ImageObj = imageObj;
            NameObject = nameObject;
            Y = 2;

        }

    }

}
