// See https://aka.ms/new-console-template for more information
namespace app
{
    class Program
    {
        static void Main(string[] args)
        {
            var GameCharacter = new GameCharacter();
            var HeroStats = new GameCharacter(100, 20, 40);
            var BossStats = new GameCharacter(400, 0, 10);

            GameCharacter.Fight(HeroStats, BossStats);

        }
    }
}