using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MyGameMyLive
{
    internal class Map
    {


        
        public char[,] MapsWorld =
            {
        { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
        { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
        { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '}
            };

        public char[,] foresterSpruce = {
        { ' ', ' ', '^', ' ', ' ' },
        { ' ', '/', ' ', '\\', ' ' },
        { '/', ' ', '|', ' ', '\\' }
    };

        public char[,] foresterOak = {
        { '\\', ' ', '|', ' ', '/' },
        { ' ', '\\', '|', '/', ' ' },
        { ' ', ' ', '|', ' ', ' ' }
    };
        

        public void MapSpawnObject(int startRow, int startCol, char[,] obj)
        {
            
            
            int objRows = obj.GetLength(0);
            int objCols = obj.GetLength(1);

            for (int i = 0; i < objRows; i++)
            {
                for (int j = 0; j < objCols; j++)
                {
                    // Проверяем, чтобы не выйти за границы массива MapsWorld
                    if (startRow + i < MapsWorld.GetLength(0) && startCol + j < MapsWorld.GetLength(1))
                    {
                        MapsWorld[startRow + i, startCol + j] = obj[i, j];
                    }
                }
            }
        }

        public void DisplayMap()
        {
            int rows = MapsWorld.GetLength(0);
            int cols = MapsWorld.GetLength(1);

            

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(MapsWorld[i, j]);
                }
                Console.WriteLine();
            }
        }

    }
}
