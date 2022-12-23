using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Hero
{
    internal class Warrior: CharacterBase
    {
        public Warrior(string name = "the name must be chosen by the player") : base(name, " Warrior", "Rage - Pain only makes a warrior stronger. After the blow, the warrior becomes enraged and thrice hits the opponent with a shield. The damage of each hit is equal to the strength indicator", 4, 2, 4)
        {

        }

        public override int UseUltimateAbility()
        {
            int ult = Strength * 3;
            Console.WriteLine($"{Name} gets into a rage and hits 3 times with a shield, causing {ult} damage");
            return ult;
        }

    }
}
