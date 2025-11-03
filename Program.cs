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
                mindmg: 15,
                maxdmg: 25,
                heal: 20,
                xDamage: 2.5,
                specialAttack: false
            );

            Monster monster = new Monster(
                name: "Древний Дракон",
                maxhp: 150,
                hp:150,
                mindamage: 10,
                maxdmg: 35
            );

            Game game = new Game( monster,player);
            game.RunGame();

        }
    }
}
