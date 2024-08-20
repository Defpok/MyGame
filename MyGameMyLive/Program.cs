using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static MyGameMyLive.Map;
using static System.Net.Mime.MediaTypeNames;



namespace MyGameMyLive
{
    internal class Program
    {
        static Texturs texturs = new Texturs();
        static List<Unit> units = new List<Unit>
        {
            new Unit("Упырь", 700, 50, 100, 50, 20, texturs.UnitImageUpyry),
            new Unit("Упырь", 750, 50, 100, 50, 20, texturs.UnitImageUpyry),
            new Unit("Упырь", 780, 50, 100, 50, 20, texturs.UnitImageUpyry),
            new Unit("Чорт  ", 950, 80, 100, 80, 20, texturs.UnitImageChort),
            new Unit("Чорт  ", 970, 80, 100, 80, 20, texturs.UnitImageChort),
            new Unit("Чорт  ", 990, 80, 100, 80, 20, texturs.UnitImageChort),
            new Unit("Чорт  ", 1020, 80, 100, 80, 20, texturs.UnitImageChort),
            new Unit("Бес  ", 1500, 150, 150, 150, 20, texturs.UnitImageBes),
            new Unit("Бес  ", 1590, 150, 150, 150, 20, texturs.UnitImageBes),
            new Unit("Бес  ", 1690, 150, 150, 150, 20, texturs.UnitImageBes)
        };

        static int level = 1;
        static int playerMoveCheck = 0;
        static Write write = new Write();
        static int playerXYMove = 0;
        static int playerDamge = 50;
        static int playerArmor = 100;

        static void Main(string[] args)
        {
            string namePlayer = Console.ReadLine();
            Console.Clear();
            Player player = new Player(namePlayer, 999, 100, 100, playerDamge, 0);
            Map map = new Map();

            Console.CursorVisible = false;

            while (player.CurrentHealth > 0)
            {
                // Обновление состояния игры

               



                playerMoveCheck++;
                LevelUp(playerMoveCheck);
                map.DisplayMap(playerXYMove);
                
                write.ShowInfoPlayer(player);
                SpawnUnitRand();
                
                player.MovePlayer();

                // Проверка на столкновение с каждым юнитом
                foreach (var unit in units)
                {
                    if (unit.FihtigToPlayer1)
                    {
                        Fihgting(player, unit);
                        break; // Прерываем цикл, чтобы начать бой
                    }
                }

                if (playerXYMove == map.MapsWorld.GetLength(1) - 3)
                    player.MovePlayerNewSpawn();

                playerXYMove = player.XPlayer();

                Texturs texturs = new Texturs();
                

                    // Проверка, если координаты ГГ равны координатам '*'
                if (map.MapsWorld[2, player.playerX + 1] == '*')
                {
                    InputToPlayerBarell(player);
                }
                else
                {
                    Console.SetCursorPosition(0, 24);
                    Console.WriteLine("                                                                                    ");
                    Console.SetCursorPosition(0, 25);
                    Console.WriteLine("                                                           ");
                    Console.SetCursorPosition(0, 26);
                    Console.WriteLine("                                                           ");
                }
            }
        }
        
        static void InputToPlayerBarell(Player player)
        {
            ConclusionLoading conclusionLoading = new ConclusionLoading();
            Console.SetCursorPosition(0, 24);
            Console.WriteLine("Нажмите F чтобы обыскать");

            ConsoleKeyInfo valueb = Console.ReadKey();
            switch (valueb.Key)
            {
                case ConsoleKey.F:
                    Console.SetCursorPosition(0, 25);
                    conclusionLoading.Loading();
                    RandomPred(player);
                    break;
                default:

                    break;
            }
        }

        static void RandomPred(Player player)
        {
            Random random = new Random();
            int value = random.Next(1, 21);

            switch (value)
            {
                case 1:
                    player.PotionHealing++;
                    Console.SetCursorPosition(0, 26);
                    Console.WriteLine("Вы нашли зелье здоровья");
                    break;
                case 2:
                    player.PotionMana++;
                    Console.SetCursorPosition(0, 26);
                    Console.WriteLine("Вы нашли зелье маны");
                    break;
                case 3:
                    player.ScinsInPlayer(true);
                    playerDamge += 30;
                    Console.SetCursorPosition(0, 26);
                    Console.WriteLine("Вы нашли меч!(+30 к урону)");
                    break;
                case 4:
                    playerArmor += 30;
                    Console.SetCursorPosition(0, 26);
                    Console.WriteLine("Вы нашли шлем!(+30 к броне)");
                    break;
                case 5:
                    if(player.FireBall == 0)
                    {
                        player.FireBall++;
                        Console.SetCursorPosition(0, 26);
                        Console.WriteLine("Вы нашли огненный шар!(100 урона)");
                    }
                    else
                    {
                        Console.SetCursorPosition(0, 26);
                        Console.WriteLine("Вы уже нашли огненный шар.");
                    }
                    break;
                case 6:
                    if (player.ElectroBall == 0)
                    {
                        player.ElectroBall++;
                        Console.SetCursorPosition(0, 26);
                        Console.WriteLine("Вы нашли элекро шар!(150 урона)");
                    }
                    else
                    {
                        Console.SetCursorPosition(0, 26);
                        Console.WriteLine("Вы уже нашли элекро шар.");
                    }
                    break;
                case 7:
                    if (player.VoxduBall == 0)
                    {
                        player.VoxduBall++;
                        Console.SetCursorPosition(0, 26);
                        Console.WriteLine("Вы нашли воздушный шар!(оталкивает противника)");
                    }
                    else
                    {
                        Console.SetCursorPosition(0, 26);
                        Console.WriteLine("Вы уже нашли воздушный шар.");
                    }
                    break;
                case 8:
                    player.PotionHealing++;
                    Console.SetCursorPosition(0, 26);
                    Console.WriteLine("Вы нашли зелье здоровья");
                    break;
                case 9:
                    player.PotionHealing++;
                    Console.SetCursorPosition(0, 26);
                    Console.WriteLine("Вы нашли зелье здоровья");
                    break;
                case 10:
                    player.PotionMana++;
                    Console.SetCursorPosition(0, 26);
                    Console.WriteLine("Вы нашли зелье маны");
                    break;
                case 11:
                    player.PotionMana++;
                    Console.SetCursorPosition(0, 26);
                    Console.WriteLine("Вы нашли зелье маны");
                    break;
                case 12:
                    player.PotionMana++;
                    Console.SetCursorPosition(0, 26);
                    Console.WriteLine("Вы нашли зелье маны");
                    break;
                case 13:
                    player.PotionHealing++;
                    Console.SetCursorPosition(0, 26);
                    Console.WriteLine("Вы нашли зелье здоровья");
                    break;
                case 14:
                    Console.SetCursorPosition(0, 26);
                    Console.WriteLine("Вы ничего не нашли");
                    break;
                case 15:
                    Console.SetCursorPosition(0, 26);
                    Console.WriteLine("Вы ничего не нашли");
                    break;
                case 16:
                    Console.SetCursorPosition(0, 26);
                    Console.WriteLine("Вы ничего не нашли");
                    break;
                case 17:
                    Console.SetCursorPosition(0, 26);
                    Console.WriteLine("Вы ничего не нашли");
                    break;
                case 18:
                    Console.SetCursorPosition(0, 26);
                    Console.WriteLine("Вы ничего не нашли");
                    break;
                case 19:
                    Console.SetCursorPosition(0, 26);
                    Console.WriteLine("Вы ничего не нашли");
                    break;
                case 20:
                    Console.SetCursorPosition(0, 26);
                    Console.WriteLine("Вы ничего не нашли");
                    break;
                default:
                    break;
            }



        }
        static void Fihgting(Player player, Unit unit)
        {
            // Реализация боя
            bool playerWon = Battle(player, unit);

            if (playerWon)
            {
                // Очистка изображения НПС с карты
                ClearUnitFromMap(unit);

                // Удаление НПС из списка
                units.Remove(unit);
            }
        }
        static bool block = false;
        static bool Battle(Player player, Unit unit)
        {
            // Здесь ваша логика боя
            while (player.CurrentHealth > 0 && unit.CurrentHealth > 0)
            {
                // Игрок атакует НПС
                Console.SetCursorPosition(0, 1);
                Console.WriteLine("                                                                                                                       ");
                
                PlayerBattling(player, unit);

                UnitBattling(player, unit);
                /*if (unit.CurrentHealth <= 0) return true; // Игрок выиграл*/
                block = false;
/*                // НПС атакует игрока
                player.CurrentHealth -= unit.Damage;
                if (player.CurrentHealth <= 0) return false; // Игрок проиграл*/
            }
            Console.Clear();
            return true;

        }

        static void ClearUnitFromMap(Unit unit)
        {
            Console.SetCursorPosition(unit.UnitX, unit.UnitY);
            for (int i = 0; i < unit.UnitImage.GetLength(0); i++)
            {
                Console.SetCursorPosition(unit.UnitX, unit.UnitY + i);
                for (int j = 0; j < unit.UnitImage.GetLength(1); j++)
                {
                    Console.Write(' '); // Отрисовка пустого пространства на месте НПС
                }
            }
        }

        static void SpawnUnitRand()
        {
            for (int i = 0; i < level && i < units.Count; i++)
            {
                Unit unit = units[i];
                if (unit.CurrentHealth > 0)
                {
                    unit.SpawnUnit(unit.UnitImage, playerXYMove);
                }
            }
        }

        static void LevelUp(int move)
        {
            level = move / 100 + 1;
        }


        static void PlayerBattling(Player player, Unit unit)
        {
            Write write = new Write();
            write.ShowInfoUnit(unit);
            write.ShowInfoPlayer(player);
            write.ShowInfoPlayerBattle(player);
            ConsoleKeyInfo valuebo = Console.ReadKey();
            
            switch (valuebo.Key)
            {
                case ConsoleKey.D1:
                    unit.CurrentHealth -= player.Damage;
                    Console.SetCursorPosition(0, 10);
                    Console.WriteLine($"Вы нанесли {unit.Name} урон в размере {player.Damage}                                  ");
                    
                    break;
                case ConsoleKey.D2:
                    Console.SetCursorPosition(0, 10);
                    Console.WriteLine($"Вы поставили блок, следующая атака врага не нанесет урона.                              ");
                    block = true;

                    break;
                case ConsoleKey.D3:

                    /*                    unit.CurrentHealth -= player.Damage;
                                        Console.SetCursorPosition(0, 11);
                                        Console.WriteLine($"Вы нанесли {unit.Name} урон в размере {player.Damage}");*/

                    break;
                default:
                    break;
            }
            
        }
        static void UnitBattling(Player player, Unit unit)
        {
            Random randoms = new Random();   

            int valuerand = randoms.Next(0, 4);

            switch (valuerand)
            {
                case 1:
                    if (!block)
                    {
                    player.CurrentHealth -= unit.Damage;
                    Console.SetCursorPosition(0, 11);
                    Console.WriteLine($"По Вам нанес {unit.Name} урон в размере {unit.Damage}                                                            ");
                    }
                    else
                    {
                        player.CurrentHealth -= 10;
                        Console.SetCursorPosition(0, 11);
                        Console.WriteLine($"Из-за блока, по Вам нанесли 10 урона                                                                  ");
                    }
                    
                    break;
                case 2:
                    unit.CurrentHealth += 20;
                    Console.SetCursorPosition(0, 11);
                    Console.WriteLine($"Враг востановил здоровье на 20 единиц                                                                ");
                    

                    break;
                case 3:

                    player.CurrentHealth -= unit.Damage;
                    Console.SetCursorPosition(0, 11);
                    Console.WriteLine($"Вы нанесли {unit.Name} урон в ра2222змере {player.Damage}                                             ");

                    break;
                default:
                    break;
            }
            
        }


    }
}
