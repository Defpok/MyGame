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


        public char[,] MapsWorld = new char[7, 120];



        public Map()
        {
            for (int i = 0; i < MapsWorld.GetLength(0); i++)
            {
                for (int j = 0; j < MapsWorld.GetLength(1); j++)
                {
                    MapsWorld[i, j] = '1';
                }
            }
            
        }

        public void InicialisehionClassTextur()
        {

        }

        

    }
}
