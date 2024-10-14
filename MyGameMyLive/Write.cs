using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGameMyLive
{
    public enum ActionType
    {
        Attack,
        Defend,
        Heal,
    }
    public class Write
    {

        // Словарь, который связывает значение enum с действиями
        private Dictionary<ActionType, Action<Unit, Unit>> actionMessages;

        // Конструктор, где инициализируется словарь
        public Write()
        {
            actionMessages = new Dictionary<ActionType, Action<Unit, Unit>>
            {
                { ActionType.Attack, (attacker, defender) =>
                    Console.WriteLine($"{attacker.Name} наносит {attacker.CurrentDamage} урона {defender.Name}!")
                },
                { ActionType.Defend, (attacker, defender) =>
                    Console.WriteLine($"{attacker.Name} защищается от атаки {defender.Name}!")
                },
                { ActionType.Heal, (attacker, defender) =>
                    Console.WriteLine($"{attacker.Name} наносит {attacker.FireBall} урона магией {defender.Name}!")
                },
            };
        }

        // Метод для вывода текста с использованием двух объектов класса Unit
        public void ShowMessage(ActionType action, Unit attacker, Unit defender)
        {
            if (actionMessages.ContainsKey(action))
            {
                Console.ForegroundColor = attacker.ColorName;
                Console.SetCursorPosition(32, attacker.SetCurcorShowInfoBattlePosition);
                actionMessages[action](attacker, defender);
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine("Неизвестное действие.");
            }
        }
        public void ShowPlayerSkill()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(35, 1);
            Console.WriteLine("1 - Удар");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.SetCursorPosition(54, 1);
            Console.WriteLine("2 - Защита");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.SetCursorPosition(75, 1);
            Console.WriteLine("3 - Магия");
            Console.ResetColor();
        }


        public void ShoInfoPlayer(Unit unit)
        {

            Console.ForegroundColor = unit.ColorName;
            Console.SetCursorPosition(unit.PositionLeftAndRight, 1);
            Console.WriteLine($"Имя: {unit.Name}");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(unit.PositionLeftAndRight, 3);
            Console.WriteLine($"Здоровье: {unit.CurrentHealth}");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.SetCursorPosition(unit.PositionLeftAndRight, 5);
            Console.WriteLine($"Защита: {unit.CurrentArmor}");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.SetCursorPosition(unit.PositionLeftAndRight, 7);
            Console.WriteLine($"Мана: {unit.CurrentMana}");
            Console.ResetColor();

        }
        public void ShowInfoGG(int posXinfo, int posYinfo, string textInfo, ConsoleColor ColorNextInfo)
        {
            Console.ForegroundColor = ColorNextInfo;
            Console.SetCursorPosition(posXinfo, posYinfo);
            Console.WriteLine(textInfo);
            Console.ResetColor();
        }
    }
}
