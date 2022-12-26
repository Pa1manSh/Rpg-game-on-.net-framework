using System;
using RPG.Hero;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace RPG
{
    public class Game
    {
        private Random random;
        private FightState fightState;
        private CharacterBase player1;
        private CharacterBase player2;

        internal CharacterBase Hero { get; }

        public Game()
        {
            random = new Random();
            fightState = FightState.NextRound;
        }
        public void StartGame()
        {
            Console.Clear();
            Console.WriteLine("player 1 creates a hero\n");
            player1 = CreateCharacter(Hero);
            Console.Clear();
            Console.WriteLine("player 2 creates a hero\n");
            player2 = CreateCharacter(Hero);
            Console.Clear();

            StartFight();
        }

        private CharacterBase CreateCharacter(CharacterBase hero)
        {


            int points = Const.pointsNumber;
            Console.WriteLine("Name your hero :\n ");
            string name = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("If you click something other than the numbers provided, you will close the game.\n");

            Console.WriteLine("\nChoose a hero class :\n1: Warrior\n2: Assassin\n3: Magician ");
            string herotype = Console.ReadLine();

            switch (herotype)
            {
                case "1": hero = new Warrior(name); break;
                case "2": hero = new Assassin(name); break;
                case "3": hero = new Mage(name); break;
                default:
                    Console.WriteLine("Incorrect input, press any key to try again");
                    Console.ReadKey();
                    Console.Clear();
                    CreateCharacter(Hero);

                    break;

            }

            while (points > 0)
            {
                Console.Clear();
                hero.ShowStats();
                Console.WriteLine("Distribute skill points among character characteristics:");
                Console.WriteLine("+1 Power:      +{0} to damage", Const.damageMulti);
                Console.WriteLine("+1 Agility:  +{0}% dodge the attack", Const.dodgeMulti);
                Console.WriteLine("+1 Vitality: +{0} HP", Const.hpMulti);
                Console.WriteLine();
                Console.WriteLine("Skill points left: {0}", points);
                Console.WriteLine("1: +1 Power");
                Console.WriteLine("2: +1 Agility");
                Console.WriteLine("3: +1 Vitality");
                switch (Console.ReadLine())
                {
                    case "1":
                        hero.Strength += 1;
                        break;
                    case "2":
                        hero.Agility += 1;
                        break;
                    default:
                        hero.Vitality += 1;
                        break;
                }
                points -= 1;
            }
            hero.IsDead += () => fightState = FightState.Stopped;


            return hero;
        }
        private void StartFight()
        {
            for (int i = 3; i > 0; i--)
            {
                Console.Clear();
                Console.WriteLine($"{i} ...");
                Console.ReadLine(); // to continue, press any button
            }
            int round = 1;

            while (fightState == FightState.NextRound)
            {
                Console.Clear();
                Console.WriteLine($"Round {round}\n");
                CalculateDamage(player1, player2);
                CalculateDamage(player2, player1);

                Console.WriteLine();
                Console.WriteLine($"Player1 - {player1.Name}");
                player1.ShowStats();

                Console.WriteLine();
                Console.WriteLine($"Player2 - {player2.Name}");
                player2.ShowStats();

                Console.ReadLine();

                round += 1;


            }
            Console.WriteLine("The fight is over");
           

             if (player1.HP == 0 && player2.HP == 0)
            
                {
                    Console.WriteLine("draw");
                }
           else if (player1.HP == 0)
            {
                Console.WriteLine(player1.Name + " is lost ");
            }
            else if (player2.HP == 0)
            {
                Console.WriteLine(player2.Name + " is lost ");
            }


            Console.ReadLine();




            

            void CalculateDamage(CharacterBase agressor, CharacterBase victim)
            {
                if (victim.DodgeChance > random.Next(1, 101))
                {
                    Console.WriteLine($"{agressor.Name} attacked but {victim.Name} was able to dodge");
                }
                else
                {
                    victim.HP -= agressor.Kick();
                    victim.HP -= agressor.UseUltimateAbility();
                }
            }

        }
    }
}
