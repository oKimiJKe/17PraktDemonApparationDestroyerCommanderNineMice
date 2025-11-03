using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _17PraktDemonApparationDestroyerCommanderNineMice
{
    internal class Player : Character
    {
        private int _heal;
        private double _XDamage;
        private bool _SpecialAttack;

        public int Heal { get { return _heal; } set { _heal = value; } }
        public double XDamage { get { return _XDamage; } set { _XDamage = value; } }
        public bool SpecialAttack { get { return _SpecialAttack; } set { _SpecialAttack = value; } }

        public Player(int maxhp, int hp, string name, int mindmg,int maxdmg,int heal,double xDamage,bool specialAttack) : base(maxhp,hp,name, mindmg,maxdmg)
        {
            MaxHP = maxhp;
            HP = hp;
            Name = name;
            MinDamage = mindmg;
            MaxDamage = maxdmg;
            Heal = heal;
            SpecialAttack = specialAttack;
            XDamage = xDamage;
        }

        public int SpecialAttackDamage()
        {
            Random rnd = new Random();
            return (int)(XDamage * rnd.Next(MinDamage, MaxDamage+1));
        }


        public override void DisplayStatus()
        {
            Console.WriteLine($"\nГерой:\nHP { HP}/{ MaxHP}" +
                $"\nУрон: от {MinDamage} до {MaxDamage} " +
                $"\nЛечение: {Heal}");
        }
    }
}
