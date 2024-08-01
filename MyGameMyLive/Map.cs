using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MyGameMyLive
{
    internal class Map
    {



        Random random = new Random();

        public char[] MapsWorld = { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', };

        public void MapConclusion()
        {
            MapSpawnBiom();

            foreach (char c in MapsWorld)
            {

                Console.Write(c);
            }

        }
        void MapSpawnBiom()
        {

            int randSpawnBiom = random.Next(1, 4);


            int[] biomMapsWorldOne = { 0, 11 }, biomMapsWorldTwo = { 11, 23 }, biomMapsWorldThree = {23, 35};

            

            char forester = '^', road = '-', stone = '*';
             
            switch (randSpawnBiom)
            {

                case 1:
                    MapForHelp(biomMapsWorldOne, forester);
                    MapSpawnBiomTwoСhoice(biomMapsWorldTwo, biomMapsWorldThree, road, stone);

                    break;
                case 2:
                    MapForHelp(biomMapsWorldTwo, forester);
                    MapSpawnBiomTwoСhoice(biomMapsWorldOne, biomMapsWorldThree, road, stone);
                    break;
                case 3:
                    MapForHelp(biomMapsWorldThree, forester);
                    MapSpawnBiomTwoСhoice(biomMapsWorldOne, biomMapsWorldTwo, road, stone);
                    break;
            }

        }

        void MapSpawnBiomTwoСhoice(int[] numbersBiomOne, int[] numbersBiomTwo, char materialOne, char materialTwo)
        {
            
            int randSpawnBiom = random.Next(1, 3);
            switch (randSpawnBiom)
            {
                case 1:
                    MapForHelp(numbersBiomOne, materialOne);
                    MapForHelp(numbersBiomTwo, materialTwo);

                    break;
                case 2:
                    MapForHelp(numbersBiomOne, materialTwo);
                    MapForHelp(numbersBiomTwo, materialOne);
                    break;
            }
        }


        void MapForHelp(int[] numbersBiom, char material)
        {

            for (int i = numbersBiom[0]; i < numbersBiom[1]; i++)
            {
                Console.SetCursorPosition(0, 15);
                MapsWorld[i] = material;
            }
        }
    }
}
