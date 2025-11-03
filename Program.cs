namespace _17PraktDemonApparationDestroyerCommanderNineMice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Добро пожаловать в игру 'Битва с монстром'!");


            Player player = new Player(
                name: "Герой",
                maxhp: 100,
                hp: 100,
                mindmg: 30,
                maxdmg: 50,
                heal: 3,
                xDamage: 2.5,
                specialAttack: false
            );


            Monster monster = new Monster(
                name: "Админ",
                maxhp: 1000,
                hp:1000,
                mindamage: 1,
                maxdmg: 5
            );

            Game game = new Game( monster,player);
            game.RunGame();

        }
    }
}
