using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
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

        static void Main(string[] args)
        {
            ConclusionLoading conclusionLoading = new ConclusionLoading();
            string namePlayer = Console.ReadLine();
            Console.Clear();

            Player player = new Player(namePlayer, 1005, 100, 100, 50, 0);
            Map map = new Map();

            Console.CursorVisible = false;

            while (player.CurrentHealth > 0)
            {
                // Обновление состояния игры
                playerMoveCheck++;
                LevelUp(playerMoveCheck);
                write.ShowInfoPlayer(player);
                map.DisplayMap(playerXYMove);
                SpawnUnitRand();

                // Проверка на столкновение с каждым юнитом
                foreach (var unit in units)
                {
                    if (unit.FihtigToPlayer1)
                    {
                        Fihgting(player, unit);
                        break; // Прерываем цикл, чтобы начать бой
                    }
                }

                player.MovePlayer();
                if (playerXYMove == map.MapsWorld.GetLength(1) - 3)
                    player.MovePlayerNewSpawn();

                playerXYMove = player.XPlayer();
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

        static bool Battle(Player player, Unit unit)
        {
            // Здесь ваша логика боя
            while (player.CurrentHealth > 0 && unit.CurrentHealth > 0)
            {
                // Игрок атакует НПС
                unit.CurrentHealth -= player.Damage;
                if (unit.CurrentHealth <= 0) return true; // Игрок выиграл

                // НПС атакует игрока
                player.CurrentHealth -= unit.Damage;
                if (player.CurrentHealth <= 0) return false; // Игрок проиграл
            }
            return false;
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
                    write.ShowInfoUnit(unit);
                }
            }
        }

        static void LevelUp(int move)
        {
            level = move / 100 + 1;
        }
    }
}
