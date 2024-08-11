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
            bool FightingToplayers = false;
            ConclusionLoading conclusionLoading = new ConclusionLoading();
            string namePlayer = Console.ReadLine();
            Console.Clear();


            Player player = new Player(namePlayer, 1005, 100, 100, 50, 0);

            Map map = new Map();



            Console.CursorVisible = false;

            



            while (player.CurrentHealth > 0)
            {
                playerMoveCheck++;
                LevelUp(playerMoveCheck);

                /*conclusionLoading.Loading();*/
                write.ShowInfoPlayer(player);


                map.DisplayMap(playerXYMove);


                SpawnUnitRand();


                FightingToplayers = BoolChecking();






                if (FightingToplayers)
                {
                    Fihgting();
                }
                


                player.MovePlayer();







                if (playerXYMove == map.MapsWorld.GetLength(1) - 3)
                    player.MovePlayerNewSpawn();

                playerXYMove = player.XPlayer();

                
            }


        }
        static void Fihgting()
        {


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
        static bool BoolChecking()
        {
            return units.Any(unit => unit.FihtigToPlayer1);
        }
        static void LevelUp(int move)
        {
            level = move / 100 + 1;
        }
    }
}
