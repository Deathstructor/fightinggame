using System.Text.RegularExpressions;
using System.Collections.Generic;
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

        //  ########       ########     ####################    ########       #####    #####          #####
        //  #########     #########     ####################    #########      #####    #####          #####
        //  ##########   ##########     #####                   ##########     #####    #####          #####
        //  ##### ##### ##### #####     #####                   ##### #####    #####    #####          #####
        //  #####  #########  #####     ###############         #####  #####   #####    #####          #####
        //  #####   #######   #####     ###############         #####   #####  #####    #####          #####
        //  #####    #####    #####     #####                   #####    ##### #####    #####          #####
        //  #####             #####     #####                   #####     ##########    #####          #####
        //  #####             #####     ####################    #####      #########    ####################
        //  #####             #####     ####################    #####       ########    ####################

        // Metod för allt som händer i "Main Menu"
        static void Menu()
        {
            Console.Clear();

            //Ett lite "fancy" system för att navigera i menyn
            int selected = 1;
            var kp = ConsoleKey.Insert;
            do
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Welcome to Fighting Game 101!");
                Console.ForegroundColor = ConsoleColor.White;
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
                    Console.WriteLine("> Tutorial");
                }
                else
                {
                    Console.WriteLine("Tutorial");
                }

                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("Use the arrow keys to navigate and press enter to select.");
                Console.ForegroundColor = ConsoleColor.White;

                kp = Console.ReadKey(true).Key;

                switch (kp)
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
                                selectNewSave();
                                break;

                            case 2:
                                loadSaveGame();
                                break;

                            case 3:
                                tutorial();
                                break;
                        }
                        break;
                }
                Console.Clear();
            } while (true);
        }

        //  ####################     ####################   #####              #####     ####################
        //  ####################     ####################    #####            #####      ####################
        //  #####          #####     #####          #####     #####          #####       #####
        //  #####                    #####          #####      #####        #####        #####
        //  ####################     #####          #####       #####      #####         ###############
        //  ####################     ####################        #####    #####          ###############
        //                 #####     ####################         #####  #####           #####
        //  #####          #####     #####          #####          ##########            #####
        //  ####################     #####          #####           ########             ####################
        //  ####################     #####          #####            ######              ####################

        static bool saveTo1 = false, saveTo2 = false, saveTo3 = false;
        static bool overwrite1 = false, overwrite2 = false, overwrite3 = false;
        // Meny för savegames som fungerar på samma sätt som huvud menyn-
        static void selectNewSave()
        {
            Console.Clear();

            int selected = 1;
            var kp = ConsoleKey.B;
            bool done = false;
            do
            {
                Console.WriteLine("Select savegame slot:");
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

                kp = Console.ReadKey(true).Key;

                switch (kp)
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
                        kp = ConsoleKey.Insert;
                        switch (selected)
                        {
                            case 1:
                                while (kp != ConsoleKey.Y || kp != ConsoleKey.N && overwrite1 == false)
                                {
                                    Console.WriteLine();
                                    Console.WriteLine();
                                    Console.WriteLine("Are you sure that you want to overwrite this save? (y/n)");
                                    Console.WriteLine();
                                    kp = Console.ReadKey(true).Key;
                                    if (kp == ConsoleKey.Y)
                                    {
                                        Console.WriteLine();
                                        Console.WriteLine();
                                        Console.WriteLine("Successfully Created Savefile");
                                        saveTo1 = true;
                                        saveTo2 = false;
                                        saveTo3 = false;
                                        Thread.Sleep(TimeSpan.FromSeconds(2));
                                        newGame();
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
                                while (kp != ConsoleKey.Y || kp != ConsoleKey.N && overwrite2 == false)
                                {
                                    Console.WriteLine();
                                    Console.WriteLine();
                                    Console.WriteLine("Are you sure that you want to overwrite this save? (y/n)");
                                    Console.WriteLine();
                                    kp = Console.ReadKey(true).Key;
                                    if (kp == ConsoleKey.Y)
                                    {
                                        Console.WriteLine();
                                        Console.WriteLine();
                                        Console.WriteLine("Successfully Created Savefile");
                                        saveTo1 = false;
                                        saveTo2 = true;
                                        saveTo3 = false;
                                        Thread.Sleep(TimeSpan.FromSeconds(2));
                                        newGame();
                                        overwrite2 = true;
                                        done = true;
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        Menu();
                                    }
                                }
                                break;

                            case 3:
                                while (kp != ConsoleKey.Y || kp != ConsoleKey.N && overwrite3 == false)
                                {
                                    Console.WriteLine();
                                    Console.WriteLine();
                                    Console.WriteLine("Are you sure that you want to overwrite this save? (y/n)");
                                    Console.WriteLine();
                                    kp = Console.ReadKey(true).Key;
                                    if (kp == ConsoleKey.Y)
                                    {
                                        Console.WriteLine();
                                        Console.WriteLine("Successfully Created Savefile");
                                        saveTo1 = false;
                                        saveTo2 = false;
                                        saveTo3 = true;
                                        Thread.Sleep(TimeSpan.FromSeconds(2));
                                        newGame();
                                        overwrite3 = true;
                                        done = true;
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

        // #####                ####################        ####################        ###############
        // #####                ####################        ####################        ###################
        // #####                #####          #####        #####          #####        #####          #####
        // #####                #####          #####        #####          #####        #####           #####
        // #####                #####          #####        #####          #####        #####           #####
        // #####                #####          #####        ####################        #####           #####
        // #####                #####          #####        ####################        #####           #####
        // #####                #####          #####        #####          #####        #####          #####
        // ###############      ####################        #####          #####        ###################
        // ###############      ####################        #####          #####        ###############


        // Metod för att ladda in en sparfil
        static void loadSaveGame()
        {
            Console.Clear();

            int selected = 1;
            var kp = ConsoleKey.Insert;
            do
            {
                Console.WriteLine("Select the savegame that you want to load:");

                // Kollar vilken rad man är på och lägger till pilen framför texten på raden man är på.
                if (selected == 1)
                {
                    Console.WriteLine("> Save 1");
                }
                else
                {
                    Console.WriteLine("Save 1");

                }
                if (selected == 2)
                {
                    Console.WriteLine("> Save 2");
                }
                else
                {
                    Console.WriteLine("Save 2");

                }
                if (selected == 3)
                {
                    Console.WriteLine("> Save 3");
                }
                else
                {
                    Console.WriteLine("Save 3");
                }

                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("Use the arrow keys to navigate and press enter to select.");
                Console.ForegroundColor = ConsoleColor.White;

                kp = Console.ReadKey(true).Key;

                switch (kp)
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

                    // Laddar in sparfilen som man har valt när man trycker på ENTER
                    case ConsoleKey.Enter:
                        switch (selected)
                        {
                            case 1:
                                saveTo1 = true;
                                saveTo2 = false;
                                saveTo3 = false;
                                level();
                                break;

                            case 2:
                                saveTo1 = true;
                                saveTo2 = false;
                                saveTo3 = false;
                                level();
                                break;

                            case 3:
                                saveTo1 = true;
                                saveTo2 = false;
                                saveTo3 = false;
                                level();
                                break;
                        }
                        break;
                }
                Console.Clear();
            } while (true);
        }



        //  ########       #####    ####################    #####             #####
        //  #########      #####    ####################    #####             #####
        //  ##########     #####    #####                   #####             #####
        //  ##### #####    #####    #####                   #####    #####    #####
        //  #####  #####   #####    ###############         #####   #######   #####
        //  #####   #####  #####    ###############         #####  #########  #####
        //  #####    ##### #####    #####                   ##### ##### ##### #####
        //  #####     ##########    #####                   ##########   ##########
        //  #####      #########    ####################    #########     #########
        //  #####       ########    ####################    ########       ########



        static void newGame()
        {
            Console.Clear();

            string propertyData = File.ReadAllText(@"..\properties.json");

            if (saveTo1)
            {
                propertyData = File.ReadAllText(@"..\Savegames\Save1.json");
            }
            else if (saveTo2)
            {
                propertyData = File.ReadAllText(@"..\Savegames\Save2.json");
            }
            else if (saveTo3)
            {
                propertyData = File.ReadAllText(@"..\Savegames\Save3.json");
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

                while (p.name == "undefined" || p.name == "" || p.name.Length > 16)
                {
                    p.name = Console.ReadLine();

                    if (p.name == "")
                    {
                        Console.WriteLine();
                        Console.WriteLine("Your name can't be blank!");
                    }
                    else if (p.name.Length > 16)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Your name cannot contain more that 16 characters!");
                    }
                }
                goto ReplaceName;
            }

            if (saveTo1)
            {
                File.WriteAllText(@"..\Savegames\Save1.json", allData);
            }
            else if (saveTo2)
            {
                File.WriteAllText(@"..\Savegames\Save2.json", allData);
            }
            else if (saveTo3)
            {
                File.WriteAllText(@"..\Savegames\Save3.json", allData);
            }

            Console.WriteLine($"Welcome {p.name}! You will now be redirected to the main menu.");
            Thread.Sleep(TimeSpan.FromSeconds(5));
            Menu();
        }



        //  ###############     #####          #####    ###############     ####################    ############          ###############     ####################    #####
        //  ###############     #####          #####    ###############     ####################    ###############       ###############     ####################    #####
        //       #####          #####          #####         #####          #####          #####    #####       #####          #####          #####          #####    #####
        //       #####          #####          #####         #####          #####          #####    #####       #####          #####          #####          #####    #####
        //       #####          #####          #####         #####          #####          #####    ###############            #####          #####          #####    #####
        //       #####          #####          #####         #####          #####          #####    #############              #####          ####################    #####
        //       #####          #####          #####         #####          #####          #####    #####    #####             #####          ####################    #####
        //       #####          #####          #####         #####          #####          #####    #####     #####            #####          #####          #####    #####
        //       #####          ####################         #####          ####################    #####       #####     ###############     #####          #####    ###############
        //       #####          ####################         #####          ####################    #####        #####    ###############     #####          #####    ###############



        // En tutorial som förklarar hur spelet funkar.
        static void tutorial()
        {
            Console.Clear();

            // Inledning
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Welcome to the tutorial!");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Thread.Sleep(TimeSpan.FromSeconds(3));
            Console.WriteLine("Here you will get a brief introduction to how the game");
            Console.WriteLine("works, but don't worry, it won't take a lot of time!");
            Thread.Sleep(TimeSpan.FromSeconds(5));
            Console.Clear();

            // Del 1 av tutorialen: värden
            Console.WriteLine("To begin with, let's talk about you and the enemies.");
            Thread.Sleep(TimeSpan.FromSeconds(3));
            Console.WriteLine();
            Console.WriteLine("There are a few important values that you need to know:");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Health, Max Damage, Min Damage, Type, Gold and Accuracy.");
            Console.ForegroundColor = ConsoleColor.White;
            Thread.Sleep(TimeSpan.FromSeconds(5));
            Console.WriteLine();
            Console.WriteLine("Health is pretty self explanatory. Maximum and Minimum");
            Console.WriteLine("damage is the max/min damage that the player or the");
            Console.WriteLine("enemy can cause, because the damage is randomized. The");
            Console.WriteLine("enemies damage will vary depending on the enemy type.");
            Thread.Sleep(TimeSpan.FromSeconds(5));
            Console.WriteLine();
            Console.WriteLine("Accuracy is very important part of the game, because");
            Console.WriteLine("there's actually a chance that you or the enemy miss");
            Console.WriteLine("an attack! The accuracy is a number between 0 and 1");
            Console.WriteLine("where 1 is 100% a hit. The enemy accuracy will depend");
            Console.WriteLine("on the enemy type. The player will be able to buy items");
            Console.WriteLine("in the game later on that can change the standard value");
            Console.WriteLine("(0.8), standard damage (10 - 40) and standard health (100).");
            Thread.Sleep(TimeSpan.FromSeconds(5));
            Console.WriteLine();
            Console.WriteLine("Then we have Gold. Gold can be earned from killing enemies.");
            Console.WriteLine("Different amounts of gold will be awarded depending on the enemy");
            Console.WriteLine("type. Gold can then be used in the shop to buy different items.");
            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("Press ENTER to continue.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadLine();
            Console.Clear();



            // Del 2 av tutorialen: enemy types
            Console.WriteLine("Now let's go through the different enemy types!");
            Console.WriteLine("The different enemy types are:");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Thread.Sleep(TimeSpan.FromSeconds(0.5));
            Console.WriteLine();
            Console.WriteLine("Undead - A very basic enemy, average HP, damage and accuracy");

            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Thread.Sleep(TimeSpan.FromSeconds(0.5));
            Console.WriteLine();
            Console.WriteLine("Magic - High damage and accuracy but very low HP | Has a chance to heal itself!");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Thread.Sleep(TimeSpan.FromSeconds(0.5));
            Console.WriteLine();
            Console.WriteLine("Tank - Very high HP, low damage and average accuracy | ");

            Console.ForegroundColor = ConsoleColor.Green;
            Thread.Sleep(TimeSpan.FromSeconds(0.5));
            Console.WriteLine();
            Console.WriteLine("Goblin - average HP, damage and accuracy | Has a chance to steal gold from you!");

            Console.ForegroundColor = ConsoleColor.Red;
            Thread.Sleep(TimeSpan.FromSeconds(0.5));
            Console.WriteLine();
            Console.WriteLine("Demon - Average HP, Insanely high damage but really bad accuracy | Immune to spells!");

            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Thread.Sleep(TimeSpan.FromSeconds(0.5));
            Console.WriteLine();
            Console.WriteLine("Astral - Average HP, low damage and 100% accuracy | ");
            Console.WriteLine();
            Console.WriteLine();

            Thread.Sleep(TimeSpan.FromSeconds(5));

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("Press ENTER to continue.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadLine();
            Console.Clear();



            // Del 3 av tutorialen: butik och föremål
            Console.WriteLine("Work in progress...");

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("Press ENTER to continue.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadLine();
            Console.Clear();
        }



        // #####                ####################    #####             #####     ####################    #####
        // #####                ####################     #####           #####      ####################    #####
        // #####                #####                     #####         #####       #####                   #####
        // #####                #####                      #####       #####        #####                   #####
        // #####                ###############             #####     #####         ###############         #####
        // #####                ###############              #####   #####          ###############         #####
        // #####                #####                         ##### #####           #####                   #####
        // #####                #####                          #########            #####                   #####
        // ###############      ####################            #######             ####################    ###############
        // ###############      ####################             #####              ####################    ###############



        static void level()
        {
            Console.Clear();

            // Laddar in data från sparfilen
            string saveData;
            if (saveTo1)
            {
                saveData = File.ReadAllText(@"..\Savegames\Save1.json");
            }
            else if (saveTo2)
            {
                saveData = File.ReadAllText(@"..\Savegames\Save2.json");
            }
            else
            {
                saveData = File.ReadAllText(@"..\Savegames\Save3.json");
            }


            User deserializedPlayer = JsonSerializer.Deserialize<User>(saveData);
            EnemyTypes deserializedEnemies = JsonSerializer.Deserialize<EnemyTypes>(saveData);

            Player p = deserializedPlayer.player;
            EnemyCollection ec = deserializedEnemies.enemy;

            Enemy[] opponents = generateEnemies(ec, p);

            Console.WriteLine($"Level {p.level}");
            Thread.Sleep(TimeSpan.FromSeconds(1));
            Console.WriteLine();
            Console.WriteLine();

            int newGold = 0;

            // Själva slagsmålet
            foreach (Enemy e in opponents)
            {
                // Antal rundor
                int rounds = opponents.Length;
                int currentRound = 1;

                if (p.health > 0 && e.health > 0)
                {
                    // Visar statistik för fienden man ska möta
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine($"{e.name}");
                    Thread.Sleep(TimeSpan.FromSeconds(1));
                    Console.WriteLine($"Health: {e.health}");
                    Thread.Sleep(TimeSpan.FromSeconds(0.1));
                    Console.WriteLine($"Max/Min Damage: {e.max_damage} / {e.min_damage}");
                    Thread.Sleep(TimeSpan.FromSeconds(0.1));
                    Console.WriteLine($"Accuracy: {e.accuracy}");
                    Thread.Sleep(TimeSpan.FromSeconds(0.1));
                    Console.WriteLine($"Type: {e.type}");
                    Console.WriteLine();
                    Console.WriteLine();
                    Thread.Sleep(TimeSpan.FromSeconds(1));
                    Console.ForegroundColor = ConsoleColor.White;
                }

                while (p.health > 0 && e.health > 0)
                {
                    // RNG GENERATOR
                    Random rdm = new Random();

                    // Slumpar skadan man gör
                    int playerDamage = rdm.Next(p.min_damage, p.max_damage);
                    int enemyDamage = rdm.Next(e.min_damage, e.max_damage);
                    // Slumpar träffsäkerheten (gör att man träffar eller missar)
                    double playerAccuracy = rdm.NextDouble();
                    double enemyAccuracy = rdm.NextDouble();
                    // Slumpar hur mycket "gold" man får från varje enemy
                    int goldDrop = rdm.Next(e.min_gold_drop, e.max_gold_drop);


                    // Åsamkar skada beroende på ifall man har tur med träffsäkerheten eller inte
                    if (playerAccuracy <= p.accuracy)
                    {
                        e.health -= playerDamage;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"{p.name} dealt {playerDamage} damage to the {e.name}!");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("You missed!");
                        Console.ForegroundColor = ConsoleColor.White;
                    }

                    if (enemyAccuracy <= e.accuracy)
                    {
                        p.health -= enemyDamage;
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine($"{e.name} dealt {enemyDamage} damage to {p.name}!");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine($"The {e.name} missed!");
                    }
                    Thread.Sleep(TimeSpan.FromSeconds(0.5));
                    Console.WriteLine();


                    // Gör så att man inte hamnar på negativt HP om man dör
                    if (p.health < 0)
                    {
                        p.health = 0;
                    }
                    else if (e.health < 0)
                    {
                        e.health = 0;
                    }

                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine($"{p.name}'s health: {p.health} HP");
                    Console.WriteLine($"The {e.name}'s health: {e.health} HP");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine();
                    Console.WriteLine();
                    Thread.Sleep(TimeSpan.FromSeconds(1));

                    // Om fienden är död skriver programmet att man har vunnit rundan och man får 20 HP
                    if (e.health == 0)
                    {
                        p.health += 20;
                        newGold += goldDrop;
                        currentRound++;
                        Console.WriteLine("You won the round!");
                        Console.WriteLine("+20 HP");
                        Console.WriteLine($"+{goldDrop} gold");
                        Console.WriteLine();
                        Console.WriteLine($"You now have {p.gold + newGold} gold");
                        Console.WriteLine();
                        Console.WriteLine();
                    }
                }

                // Vad som händer beroende på om spelaren överlever eller dör
                if (p.health == 0 && currentRound >= rounds)
                {
                    Console.WriteLine("You died!");
                    Console.WriteLine();
                    Console.WriteLine();
                }
                else if (e.health == 0 && currentRound >= rounds)
                {
                    Console.WriteLine("You won!");
                    Console.WriteLine();
                    Console.WriteLine();
                }
            }

                string theData = File.ReadAllText(@"..\Savegames\Save1.json");
                // yEs (i dare ya to question it...)

                // theData = theData.Replace(p.gold, p.gold + newGold);

                User tempU = JsonSerializer.Deserialize<User>(saveData);
                EnemyTypes tempE = JsonSerializer.Deserialize<EnemyTypes>(saveData);

                Player tempP = deserializedPlayer.player;
                EnemyCollection tempEC = deserializedEnemies.enemy;

                tempP.gold = 3;

                string ujson = JsonSerializer.Serialize<User>(tempU);
                string ejson = JsonSerializer.Serialize<EnemyTypes>(tempE);

                (User, EnemyTypes) something;
                something.Item1 = tempU;
                something.Item2 = tempE;

                // tObject unitedJson = new tObject();
                // unitedJson.us = tempU;
                // unitedJson.et = tempE;
                //ujson + "," + ejson;
                // string something = JsonSerializer.Serialize<tObject>(unitedJson);

                File.WriteAllText(@"test.json", something);



            if (saveTo1)
            {
                Console.WriteLine(@"\" + '\u0022' + @"gold\" + '\u0022' + ": " + p.gold);
                Console.WriteLine(@"\" + '\u0022' + @"gold\" + '\u0022' + ": " + (p.gold + newGold));
                File.WriteAllText(@"..\Savegames\Save1.json", theData);
            }
            else if (saveTo2)
            {
                // File.WriteAllText(@"..\Savegames\Save2.json", allData);
            }
            else if (saveTo3)
            {
                // File.WriteAllText(@"..\Savegames\Save3.json", allData);
            }



            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("Press ENTER to go back to the main menu.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadLine();
            Menu();
        }

        // "Genererar" fiender baserat på spelarens level
        static Enemy[] generateEnemies(EnemyCollection ec, Player p)
        {
            List<Enemy> generatedEnemies = new List<Enemy>();
            Random rdm = new Random();
            int amount = rdm.Next(1, p.level);

            for (var i = 0; i < amount; i++)
            {
                generatedEnemies.Add(ec.enemy[rdm.Next(0, ec.enemy.Count)]);
            }

            return generatedEnemies.ToArray();
        }
    }
}