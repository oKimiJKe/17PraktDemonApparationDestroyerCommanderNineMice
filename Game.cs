using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace _17PraktDemonApparationDestroyerCommanderNineMice
{
    internal class Game
    {
        private Monster _monster;
        private Player _player;
        private bool _isGameStart;

        public Monster Monster { get { return _monster; } set { _monster = value; } }
        public Player Player { get { return _player; } set { _player = value; } }
        public bool IsGameStart { get { return _isGameStart; } set { _isGameStart = value; } }
        
        public Game(Monster monster, Player player) 
        { 
            _monster = monster;
            _player = player;
            _isGameStart = false;
        }

        public void StartGame()
        {
            IsGameStart = true;

            Player.DisplayStatus();
            Console.WriteLine();
            Monster.DisplayStatus();

            Console.WriteLine($"\nПутешествуя по миру вы наткулись на монстра:{Monster.Name}." +
                $"\n\nБитва начинается!");
        }
        
        public void EndGame()
        {
            if (!Player.IsAlive && !Monster.IsAlive)
            {
                Console.WriteLine("\nНичья");
                IsGameStart = false;
            }
            else if (Player.IsAlive == false)
            {
                Console.WriteLine("\nПоражение");
                IsGameStart = false;
            }
            else if (Monster.IsAlive == false)
            {
                Console.WriteLine("\nПобеда");
                IsGameStart = false;
            }
            else
            {
                Console.WriteLine("\nСледующий ход.");
            }
        }
        
        public void MonsterTurn()
        {
            int damage = Monster.GetAttackDamage();
            Player.TakeDamage(damage);
            Console.WriteLine($"\n{Monster.Name} думает над своим ходом.");
            Console.WriteLine($"{Monster.Name} атакует и наносит {damage} урона!");
        }
       
        public void PlayerTurn()
       
        {
            Console.WriteLine($"\n{Player.Name} выбирает действие." +
                $"\n1:Атака" +
                $"\n2.Лечение." +
                $"\n3.Специальная атака." +
                $"\n4.Сдаться.");
            
            Console.Write("Выберите действие: ");

            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                switch (choice)
                {
                    case 1:
                        int damage = Player.GetAttackDamage();
                        Monster.TakeDamage(damage);
                        Console.WriteLine($"\nВы атакуете и наносите {damage} урона!");
                        if (Player.SpecialAttack)
                        {
                            Player.SpecialAttack = false;
                            Console.WriteLine("\nВаша специальная атака перезарядилась!");
                        }
                        break;

                    case 2:
                        Player.Healing(Player.Heal);
                        Console.WriteLine($"\nВы лечитесь и восстанавливаете {Player.Heal} здоровья!");
                        Console.WriteLine($"Теперь у вас {Player.HP}/{Player.MaxHP} здоровья.");
                        if (Player.SpecialAttack)
                        {
                            Player.SpecialAttack = false;
                            Console.WriteLine("\nВаша специальная атака перезарядилась!");
                        }
                        break;

                    case 3:
                        if (Player.SpecialAttack == false)
                        {
                            int specialDamage = Player.SpecialAttackDamage();
                            Monster.TakeDamage(specialDamage);
                            Console.WriteLine($"\nВы используете специальную атаку и наносите {specialDamage} урона!");
                            Console.WriteLine($"У монстра осталось {Monster.HP}/{Monster.MaxHP}");
                            Player.SpecialAttack = true;
                        }
                        else
                        {
                            Console.WriteLine("\nСпециальная атака уже использована!");
                            PlayerTurn();
                            return;
                        }
                        break;
                    case 4:
                        Console.WriteLine("\nВы сдались...");
                        Player.HP = 0;
                        IsGameStart = false;
                        Console.WriteLine("\nПоражение...");
                        break;

                }
            }
        }
        public void RunGame()
        {
            StartGame();
            int turn = 0;
            while (IsGameStart)
            {
                Console.WriteLine($"\nХод {turn += 1}");
                PlayerTurn();
                Console.WriteLine($"\nХод {turn += 1}");
                MonsterTurn();
                Monster.DisplayStatus();
                Player.DisplayStatus();
                EndGame();
            }
        }
    }
}
