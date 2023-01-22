using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main()
        {
            List<Trainer> listTrainers = new List<Trainer>();
            while (true)
            {
                string[] command = Console.ReadLine().Split();
                if (command[0] == "Tournament")
                {
                    break;
                }
                string trainerName = command[0];
                string pokemonName = command[1];
                string element = command[2];
                int health = int.Parse(command[3]);
                Pokemon currentPokemon = new Pokemon(pokemonName, element, health);
                Trainer currentTrainer = new Trainer();
                bool checkTrainer = listTrainers.Any(n => n.Name == trainerName);
                if (!checkTrainer)
                {
                    currentTrainer.Name = trainerName;
                    currentTrainer.collectionPokemon.Add(currentPokemon);
                    listTrainers.Add(currentTrainer);
                }
                else
                {
                    foreach (var trainer in listTrainers)
                    {
                        if (trainer.Name == trainerName)
                        {
                            trainer.collectionPokemon.Add(currentPokemon);
                        }
                    }
                }
            }
            string input = Console.ReadLine();
            while (input!="End")
            {

                switch (input)
                {
                    case "Fire":
                        atacking(listTrainers, input);

                        break;



                    case "Water":
                        atacking(listTrainers, input);
                        break;



                    case "Electricity":
                        atacking(listTrainers, input);
                        break;
                }
               input = Console.ReadLine();

            }
            foreach (var trainer in listTrainers.OrderByDescending(a => a.NumberOfBadges))
            {
                Console.WriteLine($"{trainer.Name} {trainer.NumberOfBadges} {trainer.collectionPokemon.Count}");
            }
        }
        private static void atacking(List<Trainer> listTrainers, string command)
        {
            foreach (var trainer in listTrainers)
            {
                bool isTranerHasThatElement = false;
                foreach (var pokemon in trainer.collectionPokemon)
                {
                    if (command == pokemon.Element)
                    {
                        trainer.NumberOfBadges++;
                        isTranerHasThatElement = true;
                        break;
                    }

                }
                if (isTranerHasThatElement == false)
                {
                    trainer.collectionPokemon.ForEach(pokemon => pokemon.Health -= 10);
                    trainer.collectionPokemon.RemoveAll(pokemon => pokemon.Health <= 0);
                }
            }
        }
    }
}
