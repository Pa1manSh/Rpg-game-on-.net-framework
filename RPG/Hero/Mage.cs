using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Hero
{
    internal class Mage : CharacterBase
    {
        public Mage(string name = "the name must be chosen by the player") : base(name, "Mage", "Concentration - Nothing can throw a magician off balance. The magician concentrates for a second and launches a fireball at the enemy for a 1-60 damage", 2, 3, 5)
        {

        }
        public override int UseUltimateAbility()
        {
            int ult = random.Next(1, 61);
            Console.WriteLine($"{Name} concentrates and releases a fireball, causing {ult} damage ");
            return ult;
        }
    }
}
