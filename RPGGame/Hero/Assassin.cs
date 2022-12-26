using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Hero
{
    internal class Assassin : CharacterBase
    {
        public Assassin(string name = "the name must be chosen by the player") : base(name, "Assassin", "Sleight of hand - There is a 25% chance of confusing the opponent and imperceptibly hitting with the second hand. Such a blow is considered a critical hit (x3)", 3, 6, 3)
        {

        }
        public override int UseUltimateAbility()
        {
            int chance = random.Next(1, 101);
                if (chance <= 25)
            {
               int ult = Damage * 3;
                Console.WriteLine($"{Name} struck with the second hand, striking {ult} damage ");
                return ult;
            }
            Console.WriteLine($"{Name} he tried to hit with his second hand, but the opponent noticed it and dodged");
                 return 0;
            
        }
    }
}
