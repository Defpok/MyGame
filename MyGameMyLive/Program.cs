using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;



namespace MyGameMyLive
{
    internal class Program
    {


        static void Main(string[] args)
        {
            ConclusionLoading conclusionLoading = new ConclusionLoading();
            string namePlayer = Console.ReadLine(); 
            Console.Clear();
            Player player = new Player(namePlayer, 1000, 100, 100, 0);
            Unit unit = new Unit("ssda", 1000, 100, 100, 30);
            Map map = new Map();
            Write write = new Write();  

            while (player.CurrentHealth > 0)
            {
                /*conclusionLoading.Loading();*/
                write.ShowInfoPlayer(player);
                
                map.MapConclusion();

                Console.ReadLine();
                Console.Clear();


            }
        }
    }
}
