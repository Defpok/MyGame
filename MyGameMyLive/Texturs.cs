using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MyGameMyLive
{
    internal class Texturs
    {
       


        public char[,] ForesterSpruce = {
        { ' ', ' ', '^', ' ', ' ' },
        { ' ', '/', ' ', '\\', ' ' },
        { '/', ' ', '|', ' ', '\\' }
    };
        public char[,] ForesterOak = {
        { '\\', ' ', '|', ' ', '/' },
        { ' ', '\\', '|', '/', ' ' },
        { ' ', ' ', '|', ' ', ' ' }
    };
        public char[,] ForesterApple = {
        { '/', '~', '~', '~', '\\' },
        { '\\', '~', '|', '~', '/' },
        { ' ', ' ', '|', ' ', ' ' }
    };

        public char[,] FlowersOne = {
        { ' '},
        { '0'},
        { '|'},
    };
        public char[,] FlowersTwo = {
        { ' '},
        { '@'},
        { '|'},
    };
        public char[,] Road = {
        { ' '},
        { ' '},
        { '_'},
    };
        public char[,] FlowersThree = {
        { ' ', ' ', ' ', ' ', ' ' },
        { 'о', ' ', 'о', ' ', 'о' },
        { ' ', '\\', '|', '/', ' ' }
    };
        public char[,] FlowersFo = {
        { ' ', ' ', ' '},
        { '{', 'о', '}'},
        { ' ', '|', ' '},
    }; 
        public char[,] Barrel = {
        { ' ',' ',' '},
        { ' ','_',' '},
        { '[','*',']'},
    }; 
        public char[,] BarrelNone = {
        { ' ',' ',' '},
        { ' ','_',' '},
        { '[',' ',']'},
    };
        public char[,] HomeOne = {
        {' ', ' ', '|','^','^','^','^','^','^','^','^','|', ' ', ' '},
        {' ', ' ', '|',' ','[',']',' ','|',',','|',' ','|', ' ', ' '},
        {'_', '_', '|','_','_','_','_','|','_','|','_','|', '_', '_'}
    };
        public char[,] HomeTwo = {
        {' ', ' ', '/','~','~','~','~','~','~','\\', ' ', ' '},
        {' ', ' ', '|','[',']',' ',' ','[',']','|', ' ', ' '},
        {'_', '_', '|','_','_','_','_','_','_','|', '_', '_'}
    };
        public char[,] HomeThreeNone = {
        {' ', ' ', '=','=','=','=','=','=','=','=','=','=','=','=','=','=','=','=','=', ' ', ' '},
        {' ', ' ', '|','(',' ',')','(',' ',')',' ',' ',' ',' ','|','_','_','_','_','|', ' ', ' '},
        {'_', '_', '|','(',' ',')','(',' ',')','_','_','_','_','|','(',')','(',')','|', '_', '_'}
    };
        public char[,] HomeThree = {
        {' ', ' ', '=','=','=','=','=','=','=','=','=','=','=','=','=','=','=','=','=', ' ', ' '},
        {' ', ' ', '|','(',' ',')','(',' ',')',' ',' ',' ',' ','|','_','_','_','_','|', ' ', ' '},
        {'_', '_', '|','(','*',')','(',' ',')','_','_','_','_','|','(',')','(',')','|', '_', '_'}
    };
        public char[,] HomeThree1 = {
        {' ', ' ', '=','=','=','=','=','=','=','=','=','=','=','=','=','=','=','=','=', ' ', ' '},
        {' ', ' ', '|','(',' ',')','(',' ',')',' ',' ',' ',' ','|','_','_','_','_','|', ' ', ' '},
        {'_', '_', '|','(',' ',')','(','*',')','_','_','_','_','|','(',')','(',')','|', '_', '_'}
    };
        public char[,] HomeThree2 = {
        {' ', ' ', '=','=','=','=','=','=','=','=','=','=','=','=','=','=','=','=','=','=','=', ' ', ' '},
        {' ', ' ', '|','(',' ',')','(',' ',')',' ',' ',' ',' ','|','_','_','_','_','_','_','|', ' ', ' '},
        {'_', '_', '|','(',' ',')','(',' ',')','_','_','_','_','|','(','*',')','(',' ',')','|', '_', '_'}
    };
        public char[,] HomeThree3 = {
        {' ', ' ', '=','=','=','=','=','=','=','=','=','=','=','=','=','=','=','=','=','=','=', ' ', ' '},
        {' ', ' ', '|','(',' ',')','(',' ',')',' ',' ',' ',' ','|','_','_','_','_','_','_','|', ' ', ' '},
        {'_', '_', '|','(',' ',')','(',' ',')','_','_','_','_','|','(',' ',')','(','*',')','|', '_', '_'}
    };
        public char[,] Cat = {
        { ' ', ' ', ' ', ' ', ' '},
        { ' ', ',', '_', 'о', ' '},
        { ' ', '`', ' ', '`', ' '},
    };
        public char[,] UnitImageUpyry = {
        {' ', 'о', ' '},
        {'/', '|', '\\'},
        {'/', ' ', '\\'}
    };
        public char[,] UnitImageChort = {
        {' ', 'О',' ', ' '},
        {'/', '(', ')', '\\'},
        {'/', ' ', ' ', '\\'}
    };
        public char[,] UnitImageBes = {
        {' ', ' ', '_','О', '_', ' ', ' '},
        {'/', '(', '_','_','_',')', '\\'},
        {' ', '/', ' ', ' ',' ', '\\',' ',}
    };





        public Dictionary<char, ConsoleColor> TreeColors = new Dictionary<char, ConsoleColor>
{
    { '^', ConsoleColor.Green },
    { 'о', ConsoleColor.Red },
    { '~', ConsoleColor.Red },
    { '/', ConsoleColor.Green },
    { '\\', ConsoleColor.Green },
    { '|', ConsoleColor.DarkYellow } // Коричневый цвет для ствола
};        
        public Dictionary<char, ConsoleColor> FlofersColors = new Dictionary<char, ConsoleColor>
{
    { 'о', ConsoleColor.Red },
    { '@', ConsoleColor.Red },
    { '/', ConsoleColor.Green },
    { '{', ConsoleColor.Green },
    { '}', ConsoleColor.Green },
    { '\\', ConsoleColor.Green },
    { '|', ConsoleColor.Green } // Коричневый цвет для ствола
};

        public Dictionary<char, ConsoleColor> PlayerColors = new Dictionary<char, ConsoleColor>
{
    { 'о', ConsoleColor.DarkYellow },
    { '|', ConsoleColor.DarkCyan }, // Коричневый цвет для туловища
    { '/', ConsoleColor.DarkCyan },
    { '\\', ConsoleColor.DarkCyan }
};        
        public Dictionary<char, ConsoleColor> RoadColors = new Dictionary<char, ConsoleColor>
{
    { '_', ConsoleColor.Green },
};
        public Dictionary<char, ConsoleColor> UnitColors = new Dictionary<char, ConsoleColor>
{
    { 'о', ConsoleColor.Red },
    { '|', ConsoleColor.Yellow }, // Коричневый цвет для туловища
    { '/', ConsoleColor.Yellow },
    { '(', ConsoleColor.DarkYellow }, // Коричневый цвет для туловища
    { ')', ConsoleColor.DarkYellow },
    { '\\', ConsoleColor.Yellow },
    { '[', ConsoleColor.Yellow },
    { ']', ConsoleColor.Yellow },
    { '_', ConsoleColor.Yellow },

};
        public Dictionary<char, ConsoleColor> HomeColors = new Dictionary<char, ConsoleColor>
{
    { '|', ConsoleColor.DarkYellow },
    { '(', ConsoleColor.DarkYellow }, // Коричневый цвет для туловища
    { ')', ConsoleColor.DarkYellow },
    { '/', ConsoleColor.DarkYellow },
    { '\\', ConsoleColor.DarkYellow },
    { '[', ConsoleColor.Blue },
    { ']', ConsoleColor.Blue }
};




        

    }

}
