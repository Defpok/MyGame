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
        public char[,] Gallows = LoadTextureFromFile("texturs/tx_gallows.txt");



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
        public char[,] Maps = LoadTextureFromFile("texturs/display/Maps.txt");
        public char[,] Sun = LoadTextureFromFile("texturs/tx_Sun.txt");
        public char[,] Moon = LoadTextureFromFile("texturs/tx_Moon.txt");
        public char[,] Icons = LoadTextureFromFile("texturs/display/icon_unit.txt");

        public char[,] IconsInfoDiplay = LoadTextureFromFile("texturs/display/icon_displayInfo.txt");
        public char[,] IconsInfoInvent = LoadTextureFromFile("texturs/display/Icon_displayInventory.txt");


        

        public char[,] PlayerImage = LoadTextureFromFile("texturs/PlayerAndUnitImg/tx_playerImg.txt");
        public char[,] PlayerImageShield = LoadTextureFromFile("texturs/PlayerAndUnitImg/tx_playerImg_shield.txt");
        public char[,] PlayerImageSword = LoadTextureFromFile("texturs/PlayerAndUnitImg/tx_playerImg_sword.txt");

        public char[,] PlayerImageShieldAndAxe = LoadTextureFromFile("texturs/PlayerAndUnitImg/tx_playerImg_shieldAndAxe.txt");
        public char[,] PlayerImageShieldAndMorgen = LoadTextureFromFile("texturs/PlayerAndUnitImg/tx_playerImg_shieldAndMorgen.txt");
        public char[,] PlayerImageShieldAndSword = LoadTextureFromFile("texturs/PlayerAndUnitImg/tx_playerImg_shieldAndSword.txt");
        public char[,] PlayerImageAxe = LoadTextureFromFile("texturs/PlayerAndUnitImg/tx_playerImg_axe.txt");
        public char[,] PlayerImageMorgen = LoadTextureFromFile("texturs/PlayerAndUnitImg/tx_playerImg_morgen.txt");








        public char[,] Rustic = LoadTextureFromFile("texturs/PlayerAndUnitImg/tx_playerImg_shieldAndSword.txt");
        public char[,] RusticOld = LoadTextureFromFile("texturs/PlayerAndUnitImg/tx_playerImg_shieldAndSword.txt");

        public char[,] EnemyOne = LoadTextureFromFile("texturs/PlayerAndUnitImg/tx_unitEnemyOne.txt");
        public char[,] EnemyOneSword = LoadTextureFromFile("texturs/PlayerAndUnitImg/tx_unitEnemyOne_sword.txt");
        public char[,] EnemyTwo = LoadTextureFromFile("texturs/PlayerAndUnitImg/tx_unitEnemyTwo.txt");
        public char[,] EnemyTwoSword = LoadTextureFromFile("texturs/PlayerAndUnitImg/tx_unitEnemyTwo_sword.txt");
        public char[,] EnemyThree = LoadTextureFromFile("texturs/PlayerAndUnitImg/tx_unitEnemyThree.txt");
        public char[,] EnemyFo = LoadTextureFromFile("texturs/PlayerAndUnitImg/tx_unitEnemyFo.txt");
        public char[,] EnemyFoSword = LoadTextureFromFile("texturs/PlayerAndUnitImg/tx_unitEnemyFо_sword.txt");
        public char[,] EnemyFive = LoadTextureFromFile("texturs/PlayerAndUnitImg/tx_unitEnemyFive.txt");
        public char[,] EnemySix = LoadTextureFromFile("texturs/PlayerAndUnitImg/tx_unitEnemySix.txt");
        public char[,] EnemySeven = LoadTextureFromFile("texturs/PlayerAndUnitImg/tx_unitEnemySeven.txt");
        public char[,] EnemyBoss = LoadTextureFromFile("texturs/PlayerAndUnitImg/tx_unitEnemyBoss.txt");
        








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

