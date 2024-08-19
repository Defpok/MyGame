using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace MyGameMyLive
{
    internal class Map
    {

        public struct ColorChar
        {
            public char Symbol;
            public ConsoleColor Color;

            public ColorChar(char symbol, ConsoleColor color)
            {
                Symbol = symbol;
                Color = color;
            }
        }

        public ColorChar[,] ColorMap;
        public char[,] MapsWorld =
            {
        { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
        { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
        { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '}
            };
        
        public bool TestSpawn = true;

        public Map()
        {
            ColorMap = new ColorChar[MapsWorld.GetLength(0), MapsWorld.GetLength(1)];
            for (int i = 0; i < ColorMap.GetLength(0); i++)
            {
                for (int j = 0; j < ColorMap.GetLength(1); j++)
                {
                    ColorMap[i, j] = new ColorChar(' ', ConsoleColor.White);
                }
            }
            
        }

        public void MapSpawnObject(int startRow, int startCol, char[,] obj, ConsoleColor defaultColor, Dictionary<char, ConsoleColor> colorMapping = null)
        {
            int objRows = obj.GetLength(0);
            int objCols = obj.GetLength(1);

            for (int i = 0; i < objRows; i++)
            {
                for (int j = 0; j < objCols; j++)
                {
                    if (startRow + i < MapsWorld.GetLength(0) && startCol + j < MapsWorld.GetLength(1))
                    {
                        MapsWorld[startRow + i, startCol + j] = obj[i, j];
                        ConsoleColor color = defaultColor;

                        if (colorMapping != null && colorMapping.ContainsKey(obj[i, j]))
                        {
                            color = colorMapping[obj[i, j]];
                        }

                        ColorMap[startRow + i, startCol + j] = new ColorChar(obj[i, j], color);
                    }
                }
            }
        }  
        

        public void MapSpawnPlayer(int starRow, int starCol, char[,] ob, ConsoleColor defaultColor, Dictionary<char, ConsoleColor> colorMapping = null)
        {
            
            int objRows = ob.GetLength(0);
            int objCols = ob.GetLength(1);
            for (int i = 0; i < objRows; i++)
            {
                for (int j = 0; j < objCols; j++)
                {
                    if (starRow + i < MapsWorld.GetLength(0) && starCol + j < MapsWorld.GetLength(1))
                    {
                        MapsWorld[starRow + i, starCol + j] = ob[i, j];
                        ConsoleColor color = defaultColor;

                        if (colorMapping != null && colorMapping.ContainsKey(ob[i, j]))
                        {
                            color = colorMapping[ob[i, j]];
                        }

                        ColorMap[starRow + i, starCol + j] = new ColorChar(ob[i, j], color);
                    }
                }
            }



            
        }




        public void DisplayMap(int NumbersVovePlayer)
        {
            
            if(TestSpawn == true || NumbersVovePlayer == MapsWorld.GetLength(1) - 3)
                SpawnRandom();

            Console.SetCursorPosition(0, 20);
            int rows = MapsWorld.GetLength(0);
            int cols = MapsWorld.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.ForegroundColor = ColorMap[i, j].Color;
                    Console.Write(ColorMap[i, j].Symbol);
                }
                Console.WriteLine();
            }
            Console.ResetColor();
            

        }


        public int[] vorot;

        public void SpawnRandom()
        {
            TestSpawn = false;
            Texturs texturs = new Texturs();
            Random random = new Random();

            int[] randObject = new int[texturs.ListTexturs.Count];
            int longObjTextur = 0;

            for (int i = 0; i < randObject.Length; i++)
                randObject[i] = random.Next(0, texturs.ListTexturs.Count);
            vorot = randObject;
            for (int i = 0; i < randObject.Length; i++)
            {
                char[,] texture = texturs.ListTexturs[randObject[i]];
                Dictionary<char, ConsoleColor> colorMapping = null;

                // Определение типа текстуры и соответствующего словаря цветов
                if (texture == texturs.ForesterSpruce || texture == texturs.ForesterOak || texture == texturs.ForesterApple)
                {
                    colorMapping = texturs.TreeColors;
                }
                else if (texture == texturs.FlowersOne || texture == texturs.FlowersTwo || texture == texturs.FlowersThree || texture == texturs.FlowersFo)
                {
                    colorMapping = texturs.FlofersColors;
                }
                else if (texture == texturs.Road)
                {
                    colorMapping = texturs.RoadColors;
                }
                else if (texture == texturs.HomeOne || texture == texturs.HomeTwo || texture == texturs.HomeThree)
                {
                    colorMapping = texturs.HomeColors;
                }
                else if (texture == texturs.Cat || texture == texturs.Barrel)
                {
                    colorMapping = texturs.UnitColors;
                }

                MapSpawnObject(0, longObjTextur, texture, ConsoleColor.Green, colorMapping);
                longObjTextur += texture.GetLength(1);
            }
        }

    }
}
