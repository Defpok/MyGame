using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MyGameMyLive
{
    internal class Texturs
    {



        public char[,] ForesterSpruce = LoadTextureFromFile("texturs/tx_forester_spruce.txt");
        public char[,] ForesterSpruceMini = LoadTextureFromFile("texturs/tx_forester_spruce_mini.txt");
        public char[,] ForesterOak = LoadTextureFromFile("texturs/tx_forester_oak.txt");
        public char[,] ForesterOakMini = LoadTextureFromFile("texturs/tx_forester_oak_mini.txt");
        public char[,] ForesterApple = LoadTextureFromFile("texturs/tx_forester_apple.txt");
        public char[,] ForesterAppleMini = LoadTextureFromFile("texturs/tx_forester_apple_mini.txt");



        public char[,] FlowersOne = LoadTextureFromFile("texturs/tx_flowers_one.txt");
        public char[,] FlowersTwo = LoadTextureFromFile("texturs/tx_flowers_two.txt");
        public char[,] FlowersThree = LoadTextureFromFile("texturs/tx_flowers_three.txt");
        public char[,] FlowersFo = LoadTextureFromFile("texturs/tx_flowers_fo.txt");
        public char[,] FlowersFive = LoadTextureFromFile("texturs/tx_flowers_five.txt");
        public char[,] FlowersSix = LoadTextureFromFile("texturs/tx_flowers_six.txt");

        public char[,] Box = LoadTextureFromFile("texturs/tx_box.txt");
        public char[,] BoxEmpty = LoadTextureFromFile("texturs/tx_box_empty.txt");

        public char[,] HomeOne = LoadTextureFromFile("texturs/tx_home_one.txt");
        public char[,] HomeTwo = LoadTextureFromFile("texturs/tx_home_two.txt");
        public char[,] HomeThree = LoadTextureFromFile("texturs/tx_home_three.txt");

        public char[,] HomeOneBroken = LoadTextureFromFile("texturs/tx_home_one_broken.txt");
        public char[,] HomeTwoBroken = LoadTextureFromFile("texturs/tx_home_two_broken.txt");
        public char[,] HomeThreeBroken = LoadTextureFromFile("texturs/tx_home_three_broken.txt");

        public char[,] Castle = LoadTextureFromFile("texturs/tx_castle.txt");

        public char[,] NoneObj = LoadTextureFromFile("texturs/tx_none.txt");





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


        public static char[,] LoadTextureFromFile(string filePath)
        {
            // Чтение текстуры из файла
            string[] textureLines = File.ReadAllLines(filePath);

            // Создаем двумерный массив, размеры которого соответствуют строкам и символам в текстуре
            char[,] textureArray = new char[textureLines.Length, textureLines[0].Length];

            // Заполняем двумерный массив символами из текстуры
            for (int i = 0; i < textureLines.Length; i++)
            {
                for (int j = 0; j < textureLines[i].Length; j++)
                {
                    textureArray[i, j] = textureLines[i][j];
                }
            }

            // Возвращаем готовый двумерный массив
            return textureArray;
        }
    }


}

