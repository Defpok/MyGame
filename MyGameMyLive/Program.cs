using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static MyGameMyLive.Map;
using static System.Net.Mime.MediaTypeNames;
using NAudio.Wave;

using System.Threading;


namespace MyGameMyLive
{
    internal class Program
    {





        static void Main(string[] args)
        {


            bool StartGame = true;
            while (StartGame)
            {
                Console.CursorVisible = false;
                Console.SetCursorPosition(55, 20);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("1 - Новая игра! ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(55, 22);
                Console.WriteLine("2 - Выход!");

                bool chekStartGame = true;
                while (chekStartGame)
                {
                ConsoleKeyInfo cahrKey = Console.ReadKey();
                    switch (cahrKey.Key)
                    {
                        case ConsoleKey.D1:
                            StartGame = true;
                            chekStartGame = false;
                            break;
                        case ConsoleKey.D2:
                            StartGame = false;
                            chekStartGame = false;
                            return;
                        default:

                            break;
                    }

                }



                Console.ResetColor();
                Console.Clear();






                Map map = new Map();




                Musics sound = new Musics();


                string musicFileNameMove = "sounds/MovePlayerVerTwo.mp3";
                string musicFileGameOver = "sounds/GameOver.mp3";
                string levelUpSound = "sounds/LevelUp.mp3";
                string winGame = "sounds/Win.mp3";


                Texturs texturs = new Texturs();

                string namePlayer;
                Console.SetCursorPosition(53, 20);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Добро пожаловать в игру! ");
                Console.SetCursorPosition(55, 22);
                Console.WriteLine("Вечер в глубинке!");
                Console.SetCursorPosition(50, 24);
                Console.Write("Дорогой игрок, введи свое имя: ");
                Console.ResetColor();
                namePlayer = Console.ReadLine();
                Console.SetCursorPosition(42, 26);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ПОМНИ! Никогда не зажимай клавишу перед врагом!");
                Console.ReadLine();
                Console.Clear();
                Console.SetCursorPosition(42, 18);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("На вашу деревню напали, вам нужно спасти ее!");
                Console.ResetColor();
                Console.ReadLine();

                Player player = new Player(namePlayer, 1000, 100, 200, texturs.PlayerImage, 2, 25, 1, 4, 100, 0.2f);





                /*Unit unit = new Unit("Nagibator228", 1000, 100, 200, texturs.PlayerImage, 2, 25, 1);*/
                BattleAndAction battle = new BattleAndAction();



                sound.AddMusicFile("sounds/MusicBack.mp3");
                sound.AddMusicFile("sounds/MusicBack1.mp3");
                sound.AddMusicFile("sounds/MusicBack2.mp3");
                sound.AddMusicFile("sounds/MusicBack3.mp3");
                sound.AddMusicFile("sounds/MusicBack4.mp3");
                sound.AddMusicFile("sounds/MusicBack5.mp3");

                sound.PlayBackgroundMusic();

                bool movingLevel = false;


                Write write = new Write();

                List<char[,]> imageEnemy = new List<char[,]>
            {
                texturs.EnemyOne,
                texturs.EnemyOneSword,
                texturs.EnemyTwo,
                texturs.EnemyTwoSword,
                texturs.EnemyThree,
                texturs.EnemyFo,
                texturs.EnemyFoSword,
                texturs.EnemyFive,
                texturs.EnemySix,
                texturs.EnemySeven,
                texturs.EnemyBoss
            };

                int[] posYEnemy = { 25, 25, 26, 24, 25, 24, 24, 23, 23, 22, 21 };
                int[] healthEnemy = { 500, 650, 600, 750, 800, 850, 1000, 1200, 1300, 1400, 1600 };
                int[] armorEnemy = { 30, 50, 60, 80, 100, 110, 130, 140, 160, 180, 220 };
                int[] manaEnemy = { 40, 50, 90, 120, 150, 200, 250, 300, 350, 400, 500 };
                int[] damageEnemy = { 60, 100, 110, 115, 120, 150, 200, 300, 350, 400, 500 };
                string[] nameEnemy = { "Упырь", "Упырь", "Черт", "Черт", "Длинорук", "Длинорук", "Длинорук", "Демон", "Жирдяй", "Суккуб", "Пожиратель" };

                int i = 0;
                bool win = false;
                Random rand = new Random();




                while (player.CurrentHealth > 0 && !win)
                {

                    Enemy enemy = new Enemy(nameEnemy[i], healthEnemy[i], armorEnemy[i], manaEnemy[i], imageEnemy[i], 100, posYEnemy[i], 101, 6, damageEnemy[i], 0.5f);
                    Box box1 = new Box(texturs.Box, texturs.BoxEmpty, rand.Next(10, 100), rand.Next(26, 28), RandomEmpty());
                    Box box2 = new Box(texturs.Box, texturs.BoxEmpty, rand.Next(10, 100), rand.Next(26, 28), RandomEmpty());
                    map.RandomSpawnObj();


                    while (player.CurrentHealth > 0 && !movingLevel && !win)
                    {

                        map.DisplayMap(0, 15, map.MapsWorld);
                        player.SpawnPlayer();
                        if (enemy.CurrentHealth > 0)
                            enemy.SpawnPlayer();



                        map.DisplayUI();
                        map.DisplayMapUI(30, 31, texturs.IconsInfoInvent);

                        write.ShowInfoGG(53, 32, "Инвентарь(T)", ConsoleColor.Magenta);
                        write.ShowInfoGG(65, 34, $"Зелье здоровья(C) - {player.PotionHel}", ConsoleColor.Green);
                        write.ShowInfoGG(33, 34, $"Зелье Маны(V) - {player.PotionMana}", ConsoleColor.Blue);
                        write.ShowInfoGG(53, 13, $"Уровень {i+1}", ConsoleColor.Blue);

                        if (player.ChecSword)
                            write.ShowInfoGG(33, 36, $"Меч 50 урона, шанс пробития брони +30% (1)", ConsoleColor.Red);
                        if (player.ChecMoergen)
                            write.ShowInfoGG(33, 38, $"Булова 80 урона, шанс пробития брони +20% (2)", ConsoleColor.Red);
                        if (player.ChecAxe)
                            write.ShowInfoGG(33, 40, $"Топор 40 урона, шанс пробития брони +90% (3)", ConsoleColor.Red);


                        box1.SpawnBox();
                        box2.SpawnBox();

                        write.ShoInfoPlayer(player);

                        if (battle.StartBattle(player, enemy))
                            battle.Battle(write, player, enemy, map, sound);


                        map.MoveSunAndMoon(texturs.Sun, 16, texturs.Moon);

                        if (box1.CheckUserPlaceToBox(player.PosX, player.PosY, write, map, sound))
                            box1.SearchBox(player);
                        if (box2.CheckUserPlaceToBox(player.PosX, player.PosY, write, map, sound))
                            box2.SearchBox(player);

                        if (player.ChecingObj(20 + 3, 24, 2))
                            write.ShowInfoGG(36, 2, "Вы можете обыскать это нажав R", ConsoleColor.Green);

                        if (player.ChecingObj(70 + 3, 24, 2))
                            write.ShowInfoGG(36, 2, "Вы можете обыскать это нажав R", ConsoleColor.Green);

                        if (player.ChecingEndMap())
                            write.ShowInfoGG(36, 4, "Вы можете перейти на следующий уровень нажав F", ConsoleColor.Green);

                        player.MovePlayer(write, sound);

                        sound.PlaySoundEffect(musicFileNameMove);
                        movingLevel = player.LelelUpNext;




                    }
                    i++;
                    if (player.CurrentHealth > 0 && i == 11)
                        win = true;

                    player.SearchHomeOne = true;
                    player.SearchHomeTwo = true;
                    if (i <= 11)
                        sound.PlaySoundEffect(levelUpSound);

                    player.LelelUpNext = false;
                    player.CurrentDamage += 15;
                    player.CurrentHealth += 30;
                    player.CurrentArmor += 30;
                    movingLevel = false;
                    player.PosX = 2;
                    map.ClearArrayUI(map.MapsWorld);

                }

                if (player.CurrentHealth <= 0)
                {
                    sound.StopBackgroundMusic();

                    Console.Clear();
                    Console.SetCursorPosition(60, 20);
                    sound.PlaySoundEffect(musicFileGameOver);
                    Console.WriteLine("ВЫ ПРОИГРАЛИ!");
                    Console.ReadKey();
                    Console.ReadKey();

                }
                else if (player.CurrentHealth >= 0 && win)
                {
                    sound.StopBackgroundMusic();

                    Console.Clear();
                    Console.SetCursorPosition(60, 20);
                    sound.PlaySoundEffect(winGame);
                    Console.WriteLine("ВЫ ВЫЙГРАЛИ!");
                    Console.ReadKey();
                    Console.ReadKey();
                }
            }

        }

        static bool RandomEmpty()
        {

            Random random = new Random();
            switch (random.Next(1, 3))
            {
                case 1:

                    return true;
                case 2:
                    return false;
            }
            return false;
        }




    }
}

