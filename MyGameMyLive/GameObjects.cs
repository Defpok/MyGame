using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGameMyLive
{
    internal class GameObjects
    {
        public char[,] ImageObj;
        public int X, Y;
        public string NameObject;


    }

    internal class Forest : GameObjects
    {
        public Forest(char[,] imageObj, int x, int y, string nameObject) 
        { 
            ImageObj = imageObj;
            X = x;
            Y = y;
            NameObject = nameObject;
        }
        

    }
    internal class Flowers : GameObjects
    {
        public Flowers(char[,] imageObj, int x, int y, string nameObject)
        {
            ImageObj = imageObj;
            X = x;
            Y = y;
            NameObject = nameObject;
        }

    }
    internal class Road : GameObjects
    {
        public Road(char[,] imageObj, int x, int y, string nameObject)
        {
            ImageObj = imageObj;
            X = x;
            Y = y;
            NameObject = nameObject;
        }

    }
    internal class Home : GameObjects
    {
        public Home(char[,] imageObj, int x, int y, string nameObject)
        {
            ImageObj = imageObj;
            X = x;
            Y = y;
            NameObject = nameObject;
        }

    }

}
