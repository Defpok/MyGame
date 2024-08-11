using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGameMyLive
{
    internal class Write
    {
        

        public void ShowInfoPlayer(Player player)
        {
            Console.SetCursorPosition(player.PositionCursor, 0);
            Console.Write($"Твое имя: {player.Name}");
            Console.SetCursorPosition(player.PositionCursor, 1);
            Console.WriteLine($"Твое здоровье: {player.CurrentHealth}");
            Console.SetCursorPosition(player.PositionCursor, 2);
            Console.WriteLine($"Твоя защита: {player.CurrentArmor}");
            Console.SetCursorPosition(player.PositionCursor, 3);
            Console.WriteLine($"Твоя мана: {player.Mana}");



            
        }
        public void ShowInfoUnit(Unit unit)
        {
            Console.SetCursorPosition(unit.PositionCursor, 0);
            Console.Write($"Имя врага: {unit.Name}");
            Console.SetCursorPosition(unit.PositionCursor, 1);
            Console.WriteLine($"Его здоровье: {unit.CurrentHealth}");
            Console.SetCursorPosition(unit.PositionCursor, 2);
            Console.WriteLine($"Его защита: {unit.CurrentArmor}");
            Console.SetCursorPosition(unit.PositionCursor, 3);
            Console.WriteLine($"Его мана: {unit.Mana}");
            
        }
    }
}
