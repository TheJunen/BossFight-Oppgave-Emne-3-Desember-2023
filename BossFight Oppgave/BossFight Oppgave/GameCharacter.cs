using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app
{
    internal class GameCharacter
    {
        private int Health { get; set; }
        private int Strength { get; set; }
        private int Stamina { get; set; }

        bool characterrecharge1 = false;
        bool characterrecharge2 = false;

        public GameCharacter()
        {

        }
        public GameCharacter(int health, int strength, int stamina)
        {
            Health = health;
            Strength = strength;
            Stamina = stamina;
        }

        public void Fight(GameCharacter character1, GameCharacter character2)
        {
            int i = 1;
            {
                while (character1.Health > 0 && character2.Health > 0)
                {
                    Console.WriteLine($"Slåssrunde nr {i}");
                    Recharge(character1, character2);
                    if (characterrecharge2 == false && character2.Health > 0) //Her angriper character2 hvis den har 10 eller mer stamina
                    {
                        Random rand = new Random();
                        character2.Strength = rand.Next(0, 31);
                        int nr1 = character1.Health - character2.Strength;
                        Console.WriteLine($"Boss attacked. Hero's health decreased by {character2.Strength}");
                        character1.Health = nr1;
                        Console.WriteLine($"Hero's health: {character1.Health}");
                        int stamina2 = character2.Stamina - 10;
                        character2.Stamina = stamina2;
                        Console.WriteLine($"Boss's stamina: {character2.Stamina}");
                    }
                    if (characterrecharge1 == false && character1.Health > 0) //Her angriper character1 hvis den har 10 eller mer stamina
                    {
                        int nr2 = character2.Health - character1.Strength;
                        Console.WriteLine($"Hero attacked. Boss's health decreased by {character1.Strength}");
                        character2.Health = nr2;
                        Console.WriteLine($"Boss's health: {character2.Health}");
                        int stamina1 = character1.Stamina - 10;
                        character1.Stamina = stamina1;
                        Console.WriteLine($"Hero's stamina: {character1.Stamina}");
                    }

                    if (character1.Health <= 0 || character2.Health <= 0)
                    {
                        Console.WriteLine($"One died. Health Hero: {character1.Health},Boss: {character2.Health}");
                    }
                    if (character1.Stamina >= 10)
                    {
                        characterrecharge1 = false;
                    }
                    if (character2.Stamina >= 10)
                    {
                        characterrecharge2 = false;
                    }
                    i++;
                }
            }
            
        }
        public void Recharge(GameCharacter character1, GameCharacter character2)
        {
            if (character1.Stamina <= 0)
            {
                character1.Stamina = 40;
                Console.WriteLine("Hero Has now recharged and cannot attack this round");
                characterrecharge1 = true;
            }
            if (character2.Stamina <= 0)
            {
                character2.Stamina = 10;
                Console.WriteLine($"boss has now recharged¨and cannot attack this round");
                characterrecharge2 = true;
            }
        }
    }
}
