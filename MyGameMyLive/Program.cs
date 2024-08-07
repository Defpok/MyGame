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



        static void Main(string[] args)
        {
            ConclusionLoading conclusionLoading = new ConclusionLoading();
            string namePlayer = Console.ReadLine();
            Console.Clear();
            Player player = new Player(namePlayer, 1005, 100, 100, 50, 0);

            Map map = new Map();
            Write write = new Write();
            Texturs texturs = new Texturs();

            Unit unitUpyry = new Unit("Упырь", 700, 50, 100, 50, 20, texturs.UnitImageUpyry);
            Unit unitChort = new Unit("Чорт", 950, 80, 100, 80, 20, texturs.UnitImageChort);
            Unit unitBes = new Unit("Бес", 1500, 150, 150, 150, 20, texturs.UnitImageBes);


            Console.CursorVisible = false;

            int playerXYMove = 0;
            int playerMoveCheck = 0;
            int level = 1;



            while (player.CurrentHealth > 0)
            {
                playerMoveCheck++;
                level = LevelUp(playerMoveCheck);

                /*conclusionLoading.Loading();*/
                write.ShowInfoPlayer(player);
                





                map.DisplayMap(playerXYMove);



                /*unitUpyry.SpawnUnit(texturs.UnitImageUpyry, playerXYMove);*/

                Fihgting(unitUpyry.FihtigToPlayer, unitChort.FihtigToPlayer, unitBes.FihtigToPlayer);
                unitUpyry.FihtigToPlayer = false;
                unitChort.FihtigToPlayer = false;
                unitBes.FihtigToPlayer = false;
                SpawnUnitRand(unitUpyry, unitChort, unitBes, texturs, write, playerXYMove, level);
                player.MovePlayer();









                if (playerXYMove == map.MapsWorld.GetLength(1) - 3)
                    player.MovePlayerNewSpawn();

                playerXYMove = player.XPlayer();

               
            }


        }
        static void Fihgting(bool yp, bool ch, bool be)
        {
            while (yp || ch || be) 
            {
                Console.SetCursorPosition(30, 40);
                Console.WriteLine(1);
            }
        }
        static void SpawnUnitRand(Unit unit1, Unit unit2, Unit unit3, Texturs imageUnitSpawn, Write wr, int mov, int x)
        {
            switch (x)
            {
                case 1:
                    unit1.SpawnUnit(imageUnitSpawn.UnitImageUpyry, mov);
                    wr.ShowInfoUnit(unit1);
                    break;
                case 2:
                    unit1.SpawnUnit(imageUnitSpawn.UnitImageUpyry, mov);
                    wr.ShowInfoUnit(unit1);
                    break;
                case 3:
                    unit1.SpawnUnit(imageUnitSpawn.UnitImageUpyry, mov);
                    wr.ShowInfoUnit(unit1);
                    break;
                case 4:
                    unit2.SpawnUnit(imageUnitSpawn.UnitImageChort, mov);
                    wr.ShowInfoUnit(unit2);
                    break;
                case 5:
                    unit2.SpawnUnit(imageUnitSpawn.UnitImageChort, mov);
                    wr.ShowInfoUnit(unit2);
                    break;
                case 6:
                    unit2.SpawnUnit(imageUnitSpawn.UnitImageChort, mov);
                    wr.ShowInfoUnit(unit2);
                    break;
                case 7:
                    unit2.SpawnUnit(imageUnitSpawn.UnitImageChort, mov);
                    wr.ShowInfoUnit(unit2);
                    break;
                case 8:
                    unit3.SpawnUnit(imageUnitSpawn.UnitImageBes, mov);
                    wr.ShowInfoUnit(unit3);
                    break;
                case 9:
                    unit3.SpawnUnit(imageUnitSpawn.UnitImageBes, mov);
                    wr.ShowInfoUnit(unit3);
                    break;
                case 10:
                    unit3.SpawnUnit(imageUnitSpawn.UnitImageBes, mov);
                    wr.ShowInfoUnit(unit3);
                    break;
            }

        }
        static int LevelUp(int move)
        {
            int up = 1;
            if(move == 100)
            {
                up++;
                
            }else if(move == 200)
            {
                up++;
            }else if(move == 300)
            {
                up++;
            }else if(move == 400)
            {
                up++;
            }else if(move == 500)
            {
                up++;
            }else if(move == 600)
            {
                up++;
            }else if(move == 700)
            {
                up++;
            }else if(move == 800)
            {
                up++;
            }
                return up;
        }
    }
}
