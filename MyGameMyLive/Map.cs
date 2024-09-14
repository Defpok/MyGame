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
    internal class Map
    {
        public char[,] MapsWorld = new char[9, 120];
        private List<GameObjects> placedObjects = new List<GameObjects>();
        private Random random = new Random();

        public Map()
        {
            for (int i = 0; i < MapsWorld.GetLength(0); i++)
            {
                for (int j = 0; j < MapsWorld.GetLength(1); j++)
                {
                    MapsWorld[i, j] = ' ';
                }
            }
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
                        SpawnObjToMapWord(homeBroken[randChoiseHome].ImageObj, 2, coordHom,MapsWorld);
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
                        SpawnObjToMapWord(home[randChoiseHome].ImageObj, 2, coordHom, MapsWorld);
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
            int bottomPosition = 0;
            int positionToX = 0;
            int startSpawn = 0;
            int warrningSpawn = 20; 
            spawnFlora(flora, heightArray, heightArrayChecing, bottomPosition, positionToX, startSpawn, warrningSpawn);





            int heightArrayTwo = 70 - (heightArray + coordHomRandSpawnPlusOne);
            int heightArrayChecingTwo = 0;
            int bottomPositionTwo = 0;
            int positionToXTwo = heightArray + coordHomRandSpawnPlusOne;
            spawnFlora(flora, heightArrayTwo, heightArrayChecingTwo, bottomPositionTwo, positionToXTwo, startSpawn, warrningSpawn);






            int heightArrayThree = 120 - (heightArray + coordHomRandSpawnPlusOne + heightArrayTwo + coordHomRandSpawnPlusTwo);
            int heightArrayChecingThree = 0;
            int bottomPositionThree = 0;
            int positionToXThree = heightArray + coordHomRandSpawnPlusOne + heightArrayTwo + coordHomRandSpawnPlusTwo;
            spawnFlora(flora, heightArrayThree, heightArrayChecingThree, bottomPositionThree, positionToXThree, startSpawn, warrningSpawn);



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
                    SpawnObjToMapWord(floras[rand].ImageObj, random.Next(0, 2), x, MapsWorld);


                    heightCheking += floras[rand].ImageObj.GetLength(1);
                    x += floras[rand].ImageObj.GetLength(1);

                    check += floras[rand].ImageObj.GetLength(1);
                }
                else
                {
                    return;
                }

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
        public void DisplayMap()
        {
            for (int i = 0; i < MapsWorld.GetLength(0); i++)
            {
                for (int j = 0; j < MapsWorld.GetLength(1); j++)
                {
                    Console.Write(MapsWorld[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
