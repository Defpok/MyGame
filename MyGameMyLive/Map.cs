using NAudio.Gui;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;


namespace MyGameMyLive
{
    public class Map
    {
        public char[,] MapsWorld;
        private List<GameObjects> placedObjects = new List<GameObjects>();
        private Random random = new Random();
        public char[,] Icon1;
        public char[,] Icon2;
        public char[,] Icon3;
        public int posUI;
        public int poscolor;
        public int poscolor1;
        public int poscolor2;
        public int poscolor3;
        public int poscolor4;
        public int poscolor5;
        public Map()
        {
           Texturs texturs = new Texturs();
            MapsWorld = texturs.Maps;
            Icon1 = texturs.Icons;
            Icon2 = texturs.Icons;
            Icon3 = texturs.IconsInfoDiplay;
            posUI = 119 - Icon1.GetLength(1);
        }

        public void RandomSpawnObj()
        {
            Texturs texturs = new Texturs();

            List<Flora> flora = new List<Flora>();

            

            Map map = new Map();

            Flora forestOak = new Flora(texturs.ForesterOak);
            Flora forestOakMini = new Flora(texturs.ForesterOakMini);
            Flora forestSpruce = new Flora(texturs.ForesterSpruce);
            Flora forestSpruceMini = new Flora(texturs.ForesterSpruceMini);
            Flora forestApple = new Flora(texturs.ForesterApple);
            Flora forestAppleMini = new Flora(texturs.ForesterAppleMini);
            Flora gallows = new Flora(texturs.Gallows);

            Flora flowersOne = new Flora(texturs.FlowersOne);
            Flora flowersTwo = new Flora(texturs.FlowersTwo);
            Flora flowersThree = new Flora(texturs.FlowersThree);
            Flora flowersFo = new Flora(texturs.FlowersFo);
            Flora flowersFive = new Flora(texturs.FlowersFive);
            Flora flowersSix = new Flora(texturs.FlowersSix);
            Flora noneObject = new Flora(texturs.NoneObj);

            flora.Add(forestOak);
            flora.Add(forestOakMini);
            flora.Add(forestSpruce);
            flora.Add(forestSpruceMini);
            flora.Add(forestApple);
            flora.Add(forestAppleMini);

            flora.Add(gallows);

            flora.Add(flowersOne);
            flora.Add(flowersTwo);
            flora.Add(flowersThree);
            flora.Add(flowersFo);
            flora.Add(flowersFive);
            flora.Add(flowersSix);
            flora.Add(flowersSix);
            flora.Add(noneObject);
            flora.Add(noneObject);
            flora.Add(noneObject);
            flora.Add(noneObject);
            flora.Add(noneObject);
            flora.Add(noneObject);
            flora.Add(noneObject);

            List<Home> home = new List<Home>();

            Home homeOne = new Home(texturs.HomeOne, "Жилой многаквартирный дом");
            Home homeTwo = new Home(texturs.HomeTwo, "Жилой фермерский дом");
            Home homeThree = new Home(texturs.HomeThree, "Амбар");


            home.Add(homeOne);
            home.Add(homeTwo);
            home.Add(homeThree);

            List<Home> homeBroken = new List<Home>();

            Home homeOneBroken = new Home(texturs.HomeOneBroken, "Разрушеный многаквартирный дом");
            Home homeTwoBroken = new Home(texturs.HomeTwoBroken, "Разрушеный фермерский дом");
            Home homeThreeBroken = new Home(texturs.HomeThreeBroken, "Разрушеный амбар");


            homeBroken.Add(homeOneBroken);
            homeBroken.Add(homeTwoBroken);
            homeBroken.Add(homeThreeBroken);
            Random random = new Random();

            int valueHome = 2;
            int coordHom = 20;

            int coordHomRandSpawnPlusOne = 0;
            int coordHomRandSpawnPlusTwo = 0;


            /*обернуть в вайл */









            /* int heightArrayFlovers = 120;
             int heightArrayChecingFlovers = 0;
             int bottomPositionFlovers = 1;
             int positionToXFlovers = 0;

             int startSpawnFlovers = 6;
             int warrningSpawnFlovers = 12;
             spawnFlora(flora, heightArrayFlovers, heightArrayChecingFlovers, bottomPositionFlovers, positionToXFlovers, startSpawnFlovers, warrningSpawnFlovers);
 */


            for (int i = 0; i < valueHome; i++)
            {
                int randChoiseHome = random.Next(0, 3);

                switch(random.Next(1, 3))
                {
                    case 1:
                        SpawnObjToMapWord(homeBroken[randChoiseHome].ImageObj, 6, coordHom,MapsWorld);
                        if (coordHomRandSpawnPlusOne == 0)
                        {
                            coordHomRandSpawnPlusOne += homeBroken[randChoiseHome].ImageObj.GetLength(1);
                        }
                        else if(coordHomRandSpawnPlusOne > 10)
                        {
                            coordHomRandSpawnPlusTwo += homeBroken[randChoiseHome].ImageObj.GetLength(1);
                        }
                        break;
                    case 2:

                        SpawnObjToMapWord(home[randChoiseHome].ImageObj, 6, coordHom, MapsWorld);

                        

                        if (coordHomRandSpawnPlusOne == 0)
                        {
                            coordHomRandSpawnPlusOne += homeBroken[randChoiseHome].ImageObj.GetLength(1);
                        }
                        else if (coordHomRandSpawnPlusOne > 10)
                        {
                            coordHomRandSpawnPlusTwo += homeBroken[randChoiseHome].ImageObj.GetLength(1);
                        }
                        break;
                }
                coordHom += 50;
            }






            

            int heightArray = 20;
            int heightArrayChecing = 0;
            int bottomPosition = 6;
            int positionToX = 1;
            int startSpawn = 0;
            int warrningSpawn = 15;
            spawnFlora(flora, heightArray, heightArrayChecing, bottomPosition, positionToX, startSpawn, warrningSpawn);





            int heightArrayTwo = 70 - (heightArray + coordHomRandSpawnPlusOne);
            int heightArrayChecingTwo = 0;
            int bottomPositionTwo = 6;
            int positionToXTwo = heightArray + coordHomRandSpawnPlusOne;
            spawnFlora(flora, heightArrayTwo, heightArrayChecingTwo, bottomPositionTwo, positionToXTwo, startSpawn, warrningSpawn);






            int heightArrayThree = 118 - (heightArray + coordHomRandSpawnPlusOne + heightArrayTwo + coordHomRandSpawnPlusTwo);
            int heightArrayChecingThree = 0;
            int bottomPositionThree = 6;
            int positionToXThree = heightArray + coordHomRandSpawnPlusOne + heightArrayTwo + coordHomRandSpawnPlusTwo;
            spawnFlora(flora, heightArrayThree - 1, heightArrayChecingThree, bottomPositionThree, positionToXThree, startSpawn, warrningSpawn);

            poscolor = heightArray;
            poscolor1 = heightArrayTwo;
            poscolor2 = heightArrayThree;
            poscolor3 = coordHomRandSpawnPlusOne;
            poscolor4 = coordHomRandSpawnPlusTwo;
           




            /*            spawnFlora(flora, heightArray, heightArrayChecing, bottobPosition);

                        spawnFlora(flora, heightArray, heightArrayChecing, bottobPosition);*/









            /*            for (int i = 0; i < heightArray; i += heightArrayChecing)
                        {
                            int rand = random.Next(0, 6);
                            if(heightArray - heightArrayChecing >= flora[rand].ImageObj.GetLength(1))
                            {
                                SpawnObjToMapWord(flora[rand].ImageObj, 0, heightArrayChecing, MapsWorld);

                                heightArrayChecing += flora[rand].ImageObj.GetLength(1);

                            }
                            else
                            {
                                return;
                            }

                        }*/


        }

        public void spawnFlora(List<Flora> floras, int height, int heightCheking, int bottomPos, int x, int start, int warning)
        {
            int check;
            for (int i = 0; i < height; i += check)
            {
                check = 0;
                int rand = random.Next(start, warning);
                if (height - heightCheking >= floras[rand].ImageObj.GetLength(1))
                {
                    SpawnObjToMapWord(floras[rand].ImageObj, bottomPos + random.Next(0, 3), x, MapsWorld);


                    heightCheking += floras[rand].ImageObj.GetLength(1);
                    floras[rand].X = x;
                    x += floras[rand].ImageObj.GetLength(1);
                    check += floras[rand].ImageObj.GetLength(1);
                }
                else
                {
                    return;
                }

            }
        }
        public void DisplayUI()
        {
            DisplayMapUI(0, 0, Icon1);
            DisplayMapUI(posUI, 0, Icon2);
            DisplayMapUI(30, 0, Icon3);
        }
        public void DisplayUIClear()
        {

            ClearArrayUI(Icon1);
            ClearArrayUI(Icon2);
            ClearArrayUI(Icon3);

        }
        public void ClearArrayUI(char[,] obj)
        {
            int rows = obj.GetLength(0);  // Количество строк
            int cols = obj.GetLength(1);  // Количество столбцов

            // Проходим по каждой строке, начиная со второй и заканчивая предпоследней
            for (int i = 1; i < rows - 1; i++)
            {
                // Проходим по каждому столбцу, начиная со второго и заканчивая предпоследним
                for (int j = 1; j < cols - 1; j++)
                {
                    obj[i, j] = ' ';  // Заменяем символ на пробел
                }
            }
        }

        public int X = 110;
        public int visableMoonSun = 2;


        public void MoveSunAndMoon(char[,] oj, int Y, char[,] obj)
        {

            char[,] chars = oj;

            if(visableMoonSun % 2 == 0)
            {
                chars = oj;
            }
            else
            {
                chars = obj;
            }

            Console.SetCursorPosition(X, Y);
            for (int i = 0; i < chars.GetLength(0); i++)
            {
                Console.SetCursorPosition(X, Y + i);
                for (int j = 0; j < chars.GetLength(1); j++)
                {
                    Console.Write(chars[i, j]);
                }
            }
            X--;
            if (X == 5) 
            {
                X = 110;
                visableMoonSun++;
            }
        }

        public void SpawnObjToMapWord(char[,] obj, int y, int x, char[,] objSpawn)
        {

            for (int i = 0; i < obj.GetLength(0); i++)
            {
                for (int j = 0; j < obj.GetLength(1); j++)
                {
                    objSpawn[y+ i, x +j] = obj[i, j];
                }
            }
            
        }
        public void DisplayMapUI(int startX, int startY, char[,] obj)
        {
            for (int i = 0; i < obj.GetLength(0); i++)
            {
                for (int j = 0; j < obj.GetLength(1); j++)
                {
                    // Устанавливаем курсор на позицию перед выводом каждого символа
                    Console.SetCursorPosition(startX + j, startY + i);
                    Console.Write(obj[i, j]);
                }
                // Не нужно Console.WriteLine(), так как позиция курсора уже установлена
            }

        }
        public void DisplayMap(int startX, int startY, char[,] obj)
        {
            // Установка цветов для окрашивания
            ConsoleColor color1 = ConsoleColor.Green;
            ConsoleColor color2 = ConsoleColor.DarkYellow;

            for (int i = 0; i < obj.GetLength(0); i++)
            {
                for (int j = 0; j < obj.GetLength(1); j++)
                {
                    // Устанавливаем курсор на позицию перед выводом каждого символа
                    Console.SetCursorPosition(startX + j, startY + i);

                    // Проверяем, является ли символ решеткой
                    if (obj[i, j] == '#')
                    {
                        Console.Write(obj[i, j]); // Просто выводим решетку
                    }
                    else
                    {
                        // Определяем цвет для текущей позиции
                        if (j < poscolor)
                        {
                            Console.ForegroundColor = color1; // Зелёный до 20
                        }
                        else if (j >= poscolor && j < poscolor3 + poscolor)
                        {
                            Console.ForegroundColor = color2; // Жёлтый от 20 до 40
                        }
                        else if (j >= poscolor3 + poscolor && j < poscolor3 + poscolor + poscolor1)
                        {
                            Console.ForegroundColor = color1; // Жёлтый от 20 до 40
                        }
                        else if (j >= poscolor3 + poscolor + poscolor1 && j < poscolor3 + poscolor + poscolor1 + poscolor4)
                        {
                            Console.ForegroundColor = color2; // Жёлтый от 20 до 40
                        }
                        else if (j >= poscolor3 + poscolor + poscolor1 + poscolor4 && j < poscolor3 + poscolor + poscolor1 + poscolor4 + poscolor2 -1)
                        {
                            Console.ForegroundColor = color1; // Жёлтый от 20 до 40
                        }
                        else 
                        {
                            Console.ResetColor(); 
                        }

                        Console.Write(obj[i, j]); // Выводим символ
                    }
                }
                // Сброс цвета после строки
                Console.ResetColor();
            }

            // Сброс цвета в консоли
            Console.ResetColor();
        }

    }
}
/*poscolor = heightArray;
poscolor1 = heightArrayTwo;
poscolor2 = heightArrayThree;
poscolor3 = coordHomRandSpawnPlusOne;
poscolor4 = coordHomRandSpawnPlusTwo;*/