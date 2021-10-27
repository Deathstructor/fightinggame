using System;
using System.Threading;

string name1 = "", name2 = "";
int p1HP = 100, p2HP = 100;
bool menu = true, run = false;

if(menu == true)
{
    Menu();
}

if(run == true)
{
     Run();
}

void Menu()
{
    //Spelaren väljer sitt namn
    Console.WriteLine("Welcome to Fighting Game 101!");
    Console.WriteLine();
    Console.WriteLine("PLAYER 1");
    Console.WriteLine("Choose your name:");
    name1 = Console.ReadLine();
    
    Console.WriteLine();
    Console.WriteLine();
    Console.WriteLine("PLAYER 2");
    Console.WriteLine("Choose your name:");
    name2 = Console.ReadLine();
    Console.Clear();
    
    Console.WriteLine($"{name1} VS {name2}");
    Console.WriteLine();
    Console.WriteLine();

    //Laddar in metoden för när spelet är igång
    menu = false;
    run = true;
}


void Run()
{
    Console.WriteLine("Ready...");
    Thread.Sleep(TimeSpan.FromSeconds(1));
    Console.WriteLine("Set...");
    Thread.Sleep(TimeSpan.FromSeconds(1));
    Console.WriteLine("FIGHT!");
    Console.WriteLine();
    Console.WriteLine();

    //Vad som händer så länge en spelare är vid liv
    while (p1HP > 0 && p2HP > 0)
    {
        Random rdm = new Random();

        //Slumpar skada som spelarna gör på varandra, visar sedan hur mycket skade de gjorde på varandra samt hur mycket hp de har kvar.
        int p1dmg = rdm.Next(1, 41), p2dmg = rdm.Next(1, 41);
        p1HP -= p2dmg;
        p2HP -= p1dmg;

        Console.WriteLine($"{name1} dealt {p1dmg} damage to {name2}!");
        Console.WriteLine($"{name2} dealt {p2dmg} damage to {name1}!");
        Console.WriteLine();

        if (p1HP < 0)
        {
            p1HP = 0;
        } else if (p2HP < 0)
        {
            p2HP = 0;
        }

        Console.WriteLine($"{name1}'s health: {p1HP}");
        Console.WriteLine($"{name2}'s health: {p2HP}");
        Console.WriteLine();
        Console.WriteLine();
        Thread.Sleep(TimeSpan.FromSeconds(3));
    }

    //Vad som händer beroende på vem det är som vinner.
    if (p1HP > 0)
    {
        Console.WriteLine($"{name1} won with {p1HP} left!");
    } else if (p2HP > 0)
    {
        Console.WriteLine($"{name2} won with {p2HP} left!");
    } else if (p1HP <= 0 && p2HP <= 0)
    {
        Console.WriteLine($"{name1} and {name2} killed each other, it's a draw!");
    }


    Console.ReadLine();
}