using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Hero
{
    internal abstract class CharacterBase
    {
        protected Random random;
        
        public event Action IsDead; // the character is dead

        public string Name { get; private set; }
        public string ClassDescription { get; private set; } // class description
        public string UltimateAbilityDescription { get; private set; } // description of skills

        private int strength;
        public int Strength // power
        {
            get { return strength; }
           set { strength = value; Damage = value * Const.damageMulti; }
        } 

        public int Damage { get; private set; } 
        private int agility;
        public int Agility 
        {
            get { return agility; }
            set { agility = value; DodgeChance = value * Const.dodgeMulti; }
        } 
        public int DodgeChance { get; private set; } 
        private int vitality;
        public int Vitality 
        {
            get { return vitality; }
             set { vitality = value; HP = value * Const.hpMulti; }
        } 
        private int hp;
        public int HP 
        { 
            get { return hp; }
            set {
                hp = value;
                if (hp <= 0) 
                { hp = 0;
                    if(IsDead != null)
                    
                    IsDead(); } }
        }


        protected CharacterBase(string name, string classDescription, string ultimateAbilityDescription, int strength, int agility, int vitality)
        {
            Name = name;
            ClassDescription = classDescription;
            UltimateAbilityDescription = ultimateAbilityDescription;
            Strength = strength;
            Agility = agility;
            Vitality = vitality;
        }

        public int Kick()
        {
            random = new Random();
            int totalDamage = random.Next(Damage - Const.damageVar, Damage + Const.damageVar);
            Console.WriteLine($"{Name} hit and struck {totalDamage} damage");
            return totalDamage;
        }

        public abstract int UseUltimateAbility();

        public virtual void ShowStats()
        {
            Console.WriteLine($"Name: {Name}\nClass: {ClassDescription}\nPower: {Strength}\tAgility: {Agility}\t\tVitality: {Vitality}\nDamage: {Damage}\tDodgeChance: {DodgeChance}%\tHP: {HP}\n:Ultimate {UltimateAbilityDescription}");
        }

      
    }
}
