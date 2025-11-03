using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _17PraktDemonApparationDestroyerCommanderNineMice
{
    internal abstract class Character
    {
        private int _maxHP;
        private int _hp;
        private string _name;
        private int _minDamage;
        private int _maxDamage;

        public bool IsAlive { get { return _hp > 0; } }
       
        public int HP { get { return _hp; } set { _hp = value; } }
        public string Name { get { return _name; } set { _name = value; } }
        public int MinDamage { get { return _minDamage; } set { _minDamage = value; } }
        public int MaxDamage { get { return _maxDamage; } set { _maxDamage = value; } }
        public int MaxHP { get { return _maxHP; } set { _maxHP = value; } }

        public virtual int GetAttackDamage()
        {
            Random rnd = new Random();
            return rnd.Next(MinDamage, MaxDamage);
        }

        public virtual int TakeDamage(int damage)
        {
            return HP -= damage;
        }

        public virtual int Healing(int heal)
        {
            return HP += heal;
        }

        public Character(int maxHP, int hp, string name, int minDamage, int maxDamage)
        {
            MaxHP = maxHP;
            _hp = hp;
            Name = name;
            MinDamage = minDamage;
            MaxDamage = maxDamage;
        }

        public abstract void DisplayStatus();
    }
}
