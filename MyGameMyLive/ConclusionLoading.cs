using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace MyGameMyLive
{
    internal class ConclusionLoading
    {
        private static int counter = 0;
        private static Timer timer;

        public void Loading()
        {
            int counter = 0;
            Timer timer = new Timer(650); // Интервал таймера 1000 миллисекунд (1 секунда)

            timer.Elapsed += (sender, e) =>
            {
                counter++;
                Console.Write(".");

                if (counter >= 3)
                {
                    timer.Stop(); // Остановка таймера после 3 секунд
                    timer.Dispose(); // Освобождение ресурсов таймера
                    Console.WriteLine("\nПродолжить...");
                }
            };

            
            timer.Enabled = true; // Включение таймера

            
            Console.ReadLine();
        }
    }
}
