using System;
using RPG.Hero;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            PrintMenu();
           
        }

        static void PrintMenu() // main menu
        {
            Console.Clear();
            Console.WriteLine("Rpg in the console \n");
            Console.WriteLine("Start the game");
            Console.WriteLine("Game  ruels");
            Console.WriteLine("Exit");
            string options = Console.ReadLine();

            if(options == "1")
            {
                Game game = new Game();
                game.StartGame();
            }

            if(options == "2")
            {
                Printrules();
            }
            if(options == "3")
            {
               Environment.Exit(0); // exiting 
            }
            PrintMenu(); // recursion



        }

        public static void Printrules() // Game  ruels
        {
            Console.Clear();
            
            new Warrior().ShowStats();
            new Assassin().ShowStats();
            new Mage().ShowStats();
            Console.WriteLine("\nEach fighter has three characteristics - strength, agility and endurance. " +
                             "Strength affects the damage done, dexterity affects the chance to dodge an opponent's blow, endurance affects the number of life points. " +
                             "Also, each fighter has a special skill that he uses in battle. " +
                             string.Format($"Before the start of the battle, the players choose their fighters and distribute {Const.pointsNumber}skill points among the three characteristics, thereby affecting certain indicators of the fighter. ") +
                             string.Format("+1 Power = +{0} damage, +1 agility = +{1}% dodge the blow, +1 vitality = +{2} HP. ", Const.damageMulti, Const.dodgeMulti, Const.hpMulti) +
                             "The fight consists of rounds. In each round, the fighters inflict direct damage to each other and use a special skill once. " +
                             "The number of rounds depends on the life points of the fighters. As soon as one of the fighters runs out of lives the fight stops.");
            Console.ReadLine();
            Console.ReadLine();
        }
    }
}
