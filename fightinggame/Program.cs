using System;
using System.IO;
using System.Collections.Generic;
using System.Threading;
using System.Text.Json;
using System.Text.Json.Serialization;


namespace fightinggame
{
    // Klasser som beskriverk objekt för att serialisera och deserialisera "properties.json".
    public class User
    {
        public Player player { get; set; }
    }
    public class Player
    {
        public string name { get; set; }
        public int health { get; set; }
        public int max_damage { get; set; }
        public int min_damage { get; set; }
    }

    public class EnemyTypes
    {
        [JsonPropertyName("enemies")]
        public EnemyCollection enemy { get; set; }
    }
    public class EnemyCollection
    {
        public List<Enemy> enemy { get; set; }
    }
    public class Enemy
    {
        public string name { get; set; }
        public int health { get; set; }
        public int max_damage { get; set; }
        public int min_damage { get; set; }
        public int id { get; set; }
    }



    public class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }

        // Metod för allt som händer i "Main Menu"
        static void Menu()
        {
            //Ett lite "fancy" system för att navigera i menyn
            int selected = 1;
            var ch = ConsoleKey.B;
            do
            {
                Console.WriteLine("Welcome to Fighting Game 101!");
                Console.WriteLine();
                Console.WriteLine("What would you like to do?");
                Console.WriteLine();
                Console.WriteLine();


                // Kollar vilken rad man är på och lägger till pilen framför texten på raden man är på.
                if (selected == 1)
                {
                    Console.WriteLine("> New Game");
                }
                else
                {
                    Console.WriteLine("New Game");

                }
                if (selected == 2)
                {
                    Console.WriteLine("> Load Saved Game");
                }
                else
                {
                    Console.WriteLine("Load Saved Game");

                }
                if (selected == 3)
                {
                    Console.WriteLine("> Level Selector");
                }
                else
                {
                    Console.WriteLine("Level Selector");
                }

                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("Use the arrow keys to navigate and press enter to select.");
                Console.ForegroundColor = ConsoleColor.White;

                ch = Console.ReadKey(true).Key;

                switch (ch)
                {
                    // Flyttar ner pilen om man trycker på "Down Arrow" och flyttar den högst upp
                    // om pilen är längst ner.
                    case ConsoleKey.DownArrow:
                        if (selected == 3)
                        {
                            selected = 1;
                        }
                        else
                        {
                            selected++;
                        }
                        break;

                    // Samma som ovan, fast med "Up Arrow" istället.
                    case ConsoleKey.UpArrow:
                        if (selected == 1)
                        {
                            selected = 3;
                        }
                        else
                        {
                            selected--;
                        }
                        break;

                    // Laddar in metod när man trycker på ENTER beroende på vilken sak i
                    // menyn man har valt.
                    case ConsoleKey.Enter:
                        switch (selected)
                        {
                            case 1:
                                NewGame();
                                Console.Clear();
                                break;

                            case 2:
                                // LoadSaveGame();
                                Console.Clear();
                                break;

                            case 3:
                                // LevelSelector();
                                Console.Clear();
                                break;
                        }
                        break;
                }
            Console.Clear();
            } while (true);
        }

        static void NewGame()
        {
            string propertyData = File.ReadAllText(@"..\properties.json");
            User deserializedPlayer = JsonSerializer.Deserialize<User>(propertyData);
            EnemyTypes deserializedEnemies = JsonSerializer.Deserialize<EnemyTypes>(propertyData);

            Player p = deserializedPlayer.player;
            EnemyCollection ec = deserializedEnemies.enemy;

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("If you want to go back to the man menu press \"Left Arrow\".");
            Console.ForegroundColor = ConsoleColor.White;

            

            if (p.name == "undefined")
            {
                Console.WriteLine("To begin with, what would you like to be called?");
                Console.WriteLine("Enter your name below:");
                p.name = Console.ReadLine();

                Player playerSerialize = new Player()
                {
                    name = p.name
                };

                string serializePlayer = JsonSerializer.Serialize<Player>(playerSerialize);
                File.WriteAllText("test.json", serializePlayer);
            }
        }



        static void Run()
        {
            Console.WriteLine("Ready...");
            Thread.Sleep(TimeSpan.FromSeconds(1));
            Console.WriteLine("Set...");
            Thread.Sleep(TimeSpan.FromSeconds(1));
            Console.WriteLine("FIGHT!");
            Console.WriteLine();
            Console.WriteLine();

            // Vad som händer så länge en spelare är vid liv
            // while (Player.health > 0 && Enemy > 0)
            // {
            //     Random rdm = new Random();

            //     //Slumpar skada som spelarna gör på varandra, visar sedan hur mycket skade de gjorde på varandra samt hur mycket hp de har kvar.
            //     int p1dmg = rdm.Next(1, 41), p2dmg = rdm.Next(1, 41);
            //     p1HP -= p2dmg;
            //     p2HP -= p1dmg;

            //     Console.WriteLine($"{name1} dealt {p1dmg} damage to {name2}!");
            //     Console.WriteLine($"{name2} dealt {p2dmg} damage to {name1}!");
            //     Console.WriteLine();

            //     if (p1HP < 0)
            //     {
            //         p1HP = 0;
            //     }
            //     else if (p2HP < 0)
            //     {
            //         p2HP = 0;
            //     }

            //     Console.WriteLine($"{name1}'s health: {p1HP}");
            //     Console.WriteLine($"{name2}'s health: {p2HP}");
            //     Console.WriteLine();
            //     Console.WriteLine();
            //     Thread.Sleep(TimeSpan.FromSeconds(3));
            // }

            // //Vad som händer beroende på vem det är som vinner.
            // if (p1HP > 0)
            // {
            //     Console.WriteLine($"{name1} won with {p1HP} HP left!");
            // }
            // else if (p2HP > 0)
            // {
            //     Console.WriteLine($"{name2} won with {p2HP} HP left!");
            // }
            // else if (p1HP <= 0 && p2HP <= 0)
            // {
            //     Console.WriteLine($"{name1} and {name2} killed each other, it's a draw!");
            // }


            Console.ReadLine();
        }
    }
}