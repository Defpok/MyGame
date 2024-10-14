using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGameMyLive
{
    public class BattleAndAction
    {
        public bool Defend = false;
        public bool StartBattle(Unit attacerOne, Unit attacerTwo)
        {
            bool checkingTouch = false;
            if (attacerOne.PosX + 4 == attacerTwo.PosX)
            {
                checkingTouch = true;
                return checkingTouch;
            }
            return checkingTouch;
        }

        public void Battle(Write writeInfoUnit, Player playerAttacer, Enemy unitAttacer, Map Clear, Musics soundBattle)
        {
            /*            Console.SetCursorPosition(30, 3);
                        Console.WriteLine("Введите бой");
                        ConsoleKeyInfo cahrKey = Console.ReadKey();
                            if (cahrKey.Key == ConsoleKey.Enter)
                            {

                            }*/
            Clear.DisplayUI();
            while (playerAttacer.CurrentHealth >= 1 && unitAttacer.CurrentHealth >= 1)
            {
                writeInfoUnit.ShowPlayerSkill();
                writeInfoUnit.ShoInfoPlayer(playerAttacer);

                writeInfoUnit.ShoInfoPlayer(unitAttacer);
                int valuePlayer = playerAttacer.CharracterBattle();
                int valueEnemy = unitAttacer.CharracterBattle();

                Clear.DisplayUI();

                ControlBattle(writeInfoUnit, playerAttacer, unitAttacer, valuePlayer);
                soundBattle.PlaySoundEffect("sounds/HitPlayer.mp3");
                ControlBattle(writeInfoUnit, unitAttacer, playerAttacer, valueEnemy);
            }
            SearchBox(playerAttacer);
        }


        public void ControlBattle(Write writeBattle, Unit attacer, Unit Defender, int vallueActive)
        {

            switch (vallueActive)
            {
                case 1:
                    if (!Defend)
                    {
                        if (Defender.ChecingArmor())
                        {
                            attacer.CurrentDamage = attacer.MaxDamage * attacer.CoofCritDamage;
                            Defender.CurrentHealth -= attacer.CurrentDamage;
                            Defender.CurrentArmor -= 15;

                        }
                        else
                        {
                            attacer.CurrentDamage = attacer.MaxDamage;
                            Defender.CurrentHealth -= attacer.MaxDamage;
                        }
                        writeBattle.ShowMessage(ActionType.Attack, attacer, Defender);

                    }
                    else
                    {

                        Console.SetCursorPosition(32, attacer.SetCurcorShowInfoBattlePosition);
                        Console.WriteLine("Урон не прошел");
                        Defend = false;
                    }

                    break;
                case 2:
                    /*Defender.CurrentHealth -= attacer.Damage;*/
                    writeBattle.ShowMessage(ActionType.Defend, attacer, Defender);
                    Defend = true;
                    break;

                case 3:
                    if (attacer.CurrentMana > 70)
                    {
                        Defender.CurrentHealth -= attacer.FireBall;
                        attacer.CurrentMana -= 70;
                        writeBattle.ShowMessage(ActionType.Heal, attacer, Defender);
                        Defend = false;
                    }
                    break;
            }
        }

        public void SearchBox(Player player)
        {
            if (player.CurrentHealth > 0)
            {
                Random random = new Random();
                Write write = new Write();
                Texturs texturs = new Texturs();
                int rand = random.Next(0, 9);
                switch (rand)
                {
                    case 0:
                        if (player.PotionHel < 5)
                        {
                            write.ShowInfoGG(32, 1, "Вы нашли зелье здоровья!", ConsoleColor.Green);
                            player.PotionHel++;
                        }
                        else
                            write.ShowInfoGG(32, 1, "Вы ничего не нашли", ConsoleColor.Red);
                        break;
                    case 1:
                        if (player.PotionMana < 5)
                        {
                            write.ShowInfoGG(32, 1, "Вы нашли зелье Маны!", ConsoleColor.Green);
                            player.PotionMana++;
                        }
                        else
                            write.ShowInfoGG(32, 1, "Вы ничего не нашли", ConsoleColor.Red);
                        break;
                    case 2:
                        if (!player.ChecSword)
                        {
                            write.ShowInfoGG(32, 1, "Вы нашли меч!", ConsoleColor.Green);
                            player.ChecSword = true;
                        }
                        else
                            write.ShowInfoGG(32, 1, "Вы ничего не нашли", ConsoleColor.Red);
                        break;
                    case 3:
                        if (!player.ChecAxe)
                        {
                            write.ShowInfoGG(32, 1, "Вы нашли топор!", ConsoleColor.Green);
                            player.ChecAxe = true;
                        }
                        else
                            write.ShowInfoGG(32, 1, "Вы ничего не нашли", ConsoleColor.Red);
                        break;
                    case 4:
                        if (!player.ChecMoergen)
                        {
                            write.ShowInfoGG(32, 1, "Вы нашли булаву!", ConsoleColor.Green);
                            player.ChecMoergen = true;
                        }
                        else
                            write.ShowInfoGG(32, 1, "Вы ничего не нашли", ConsoleColor.Red);
                        break;
                    case 5:
                        if (!player.Shield)
                        {
                            write.ShowInfoGG(32, 1, "Вы нашли щит!", ConsoleColor.Green);
                            player.Shield = true;
                            player.CurrentArmor += 200;
                            player.Image = texturs.PlayerImageShield;

                        }
                        else if (player.CurrentArmor < 1000)
                        {
                            write.ShowInfoGG(36, 1, "У вас уже есть щит", ConsoleColor.Red);
                            player.CurrentArmor += 100;
                        }
                        break;
                    case 6:
                        write.ShowInfoGG(32, 1, "Вы ничего не нашли", ConsoleColor.Red);
                        break;
                    case 7:
                        write.ShowInfoGG(32, 1, "Вы ничего не нашли", ConsoleColor.Red);
                        break;
                    case 8:
                        write.ShowInfoGG(32, 1, "Вы ничего не нашли", ConsoleColor.Red);
                        break;
                    default:
                        break;
                }

            }
        }

    }
}
