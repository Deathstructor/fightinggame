using System;
using System.IO;
using System.Collections.Generic;
using System.Threading;
using System.Text.Json;
using System.Text.Json.Serialization;


namespace fightinggame
{
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
        static bool welcome = true, run = false;

        static void Main(string[] args)
        {
            Loading();
            Welcome();
        }

        public static void Loading()
        {
            if (welcome)
            {
                Welcome();
            } else if(run)
            {
                Run();
            }
        }

        static void Welcome()
        {
            string propertyData = File.ReadAllText(@"..\properties.json");
            User deserializedPlayer = JsonSerializer.Deserialize<User>(propertyData);
            EnemyTypes deserializedEnemies = JsonSerializer.Deserialize<EnemyTypes>(propertyData);

            Player p = deserializedPlayer.player;
            EnemyCollection ec = deserializedEnemies.enemy;

            //Spelaren väljer sitt namn
            Console.WriteLine("Welcome to Fighting Game 101!");
            Console.WriteLine();
            Console.WriteLine("Choose your name:");
            p.name = Console.ReadLine();
            
            Console.WriteLine($"{p.name} VS {ec.enemy[0].name}");
            Console.WriteLine();
            Console.WriteLine();

            //Laddar in metoden för när spelet är igång
            welcome = false;
            run = true;
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