using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _17PraktDemonApparationDestroyerCommanderNineMice
{
    internal class Monster : Character
    {
        public Monster(int maxhp, int hp, string name, int mindamage, int maxdmg) : base(maxhp, hp, name, mindamage, maxdmg)
        {
            MaxHP = maxhp;
            HP = hp;
            Name = name;
            MinDamage = mindamage;
            MaxDamage = maxdmg;
        }

        public override void DisplayStatus()
        {
            Console.WriteLine($"\n{Name}:" +
                $"HP {HP}/{MaxHP}" +
                $"\nУрон: от {MinDamage} до {MaxDamage}");
        }
    }
}
