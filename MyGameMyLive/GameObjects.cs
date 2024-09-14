using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace MyGameMyLive
{
    internal class GameObjects
    {
        public char[,] ImageObj;
        public int X, Y;
        public string NameObject;

        public bool CheckUserPlaceToGameObj(int coordUser)
        {
            if (X  == coordUser - 5)
            {
                return true;
            }
            return false;
        }
    }


    internal class Flora : GameObjects
    {
        public Flora(char[,] imageObj)
        {
            ImageObj = imageObj;
            Y = 9;
        }

    }
    internal class Road : GameObjects
    {
        public Road(char[,] imageObj, string nameObject)
        {
            ImageObj = imageObj;
            NameObject = nameObject;
        }

    }
    internal class Home : GameObjects
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
