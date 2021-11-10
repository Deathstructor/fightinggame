using System;
using System.IO;
using System.Threading;
using System.Text.Json;


namespace fightinggame
{
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
            var ch = ConsoleKey.Insert;
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
                                SelectNewSave();
                                break;

                            case 2:
                                LoadSaveGame();
                                break;

                            case 3:
                                // LevelSelector();
                                break;
                        }
                        break;
                }
                Console.Clear();
            } while (true);
        }


        static bool saveTo1 = false, saveTo2 = false, saveTo3 = false;
        static bool overwrite1 = false, overwrite2 = false, overwrite3 = false;
        // Meny för savegames som fungerar på samma sätt som huvud menyn-
        static void SelectNewSave()
        {
            Console.Clear();

            int selected = 1;
            var ch = ConsoleKey.B;
            bool done = false;
            do
            {
                Console.WriteLine("Select savegame slot");
                Console.WriteLine();
                Console.WriteLine();

                // Kollar vilken rad man är på och lägger till pilen framför texten på raden man är på.
                if (selected == 1)
                {
                    Console.WriteLine("> Savegame 1");
                }
                else
                {
                    Console.WriteLine("Savegame 1");

                }
                if (selected == 2)
                {
                    Console.WriteLine("> Savegame 2");
                }
                else
                {
                    Console.WriteLine("Savegame 2");

                }
                if (selected == 3)
                {
                    Console.WriteLine("> Savegame 3");
                }
                else
                {
                    Console.WriteLine("Savegame 3");
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


                    // Väljer en sparfil där man ska spara all "progress" man har gjort i spelet.
                    case ConsoleKey.Enter:
                        ch = ConsoleKey.Insert;
                        switch (selected)
                        {
                            case 1:
                                while (ch != ConsoleKey.Y || ch != ConsoleKey.N && overwrite1 == false)
                                {
                                    Console.WriteLine("Are you sure that you want to overwrite this save? (y/n)");
                                    Console.WriteLine();
                                    ch = Console.ReadKey(true).Key;
                                    if (ch == ConsoleKey.Y)
                                    {
                                        File.WriteAllText(@"..\Savegames\Save1", "Successfully Created Savefile");
                                        Console.WriteLine();
                                        Console.WriteLine();
                                        Console.WriteLine("Successfully Created Savefile");
                                        saveTo1 = true;
                                        saveTo2 = false;
                                        saveTo3 = false;
                                        Thread.Sleep(TimeSpan.FromSeconds(2));
                                        NewGame();
                                        overwrite1 = true;
                                        done = true;
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        Menu();
                                    }
                                }
                                break;

                            case 2:
                                while (ch != ConsoleKey.Y || ch != ConsoleKey.N && overwrite2 == false)
                                {
                                    Console.WriteLine("Are you sure that you want to overwrite this save? (y/n)");
                                    Console.WriteLine();
                                    ch = Console.ReadKey(true).Key;
                                    if (ch == ConsoleKey.Y)
                                    {
                                        File.WriteAllText(@"..\Savegames\Save2", "Successfully Created Savefile");
                                        Console.WriteLine();
                                        Console.WriteLine();
                                        Console.WriteLine("Successfully Created Savefile");
                                        saveTo1 = false;
                                        saveTo2 = true;
                                        saveTo3 = false;
                                        Thread.Sleep(TimeSpan.FromSeconds(2));
                                        NewGame();
                                        overwrite2 = true;
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        Menu();
                                    }
                                }
                                break;

                            case 3:
                                while (ch != ConsoleKey.Y || ch != ConsoleKey.N && overwrite3 == false)
                                {
                                    Console.WriteLine("Are you sure that you want to overwrite this save? (y/n)");
                                    Console.WriteLine();
                                    ch = Console.ReadKey(true).Key;
                                    if (ch == ConsoleKey.Y)
                                    {
                                        File.WriteAllText(@"..\Savegames\Save3", "Successfully Created Savefile");
                                        Console.WriteLine();
                                        Console.WriteLine();
                                        Console.WriteLine("Successfully Created Savefile");
                                        saveTo1 = false;
                                        saveTo2 = false;
                                        saveTo3 = true;
                                        Thread.Sleep(TimeSpan.FromSeconds(2));
                                        NewGame();
                                        overwrite3 = true;
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        Menu();
                                    }
                                }
                                break;
                        }
                        break;
                }
                Console.Clear();
            } while (!done);
        }



        static void LoadSaveGame() {
            
        }



        static void NewGame()
        {
            Console.Clear();

            string propertyData = File.ReadAllText(@"..\properties.json");

            if (saveTo1)
            {
                propertyData = File.ReadAllText(@"..\Savegames\Save1Settings.json");
            }
            else if (saveTo2)
            {
                propertyData = File.ReadAllText(@"..\Savegames\Save2Settings.json");
            }
            else if (saveTo3)
            {
                propertyData = File.ReadAllText(@"..\Savegames\Save3Settings.json");
            }



            User deserializedPlayer = JsonSerializer.Deserialize<User>(propertyData);
            EnemyTypes deserializedEnemies = JsonSerializer.Deserialize<EnemyTypes>(propertyData);

            Player p = deserializedPlayer.player;
            EnemyCollection ec = deserializedEnemies.enemy;

            p.name = "undefined";
            
            ReplaceName:
            string allData = File.ReadAllText(@"..\properties.json");
            allData = allData.Replace("undefined", p.name);

            // Spelaren väljer sitt namn
            if (p.name == "undefined")
            {
                Console.WriteLine("To begin with, what would you like to be called?");
                Console.WriteLine("Enter your name below:");

                while (p.name == "undefined" || p.name == "" || p.name.Length > 16 )
                {
                    p.name = Console.ReadLine();
                }

                goto ReplaceName;
            }

            if (saveTo1)
            {
                File.WriteAllText(@"..\Savegames\Save1Settings.json", allData);
            }
            else if (saveTo2)
            {
                File.WriteAllText(@"..\Savegames\Save2Settings.json", allData);
            }
            else if (saveTo3)
            {
                File.WriteAllText(@"..\Savegames\Save3Settings.json", allData);
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