using System;
using System.IO;



int ii = 0;
Fighter fight = new Fighter();

//väljer om man ladar in ett spel eller skapar nytt
while (ii < 1)
{
    System.Console.WriteLine("välkomen, skriv new game för att skappa nytt spel eller load game för att ladda in ett game");
    string val = Console.ReadLine();
    if (val == "new game")
    {
        Toolbox.newgame();
    }
    if (val == "load game")
    {
        fight = Toolbox.loodgame();
        ii++;
        Console.Clear();
    }
}

ii = 0;
while (ii < 1)
{

    //kollar om du är död 
    if (fight.hp > 0)
    {
        Console.Clear();
        //skriver information 
        System.Console.WriteLine("Vad vill du göra");
        System.Console.WriteLine("| Slåss | butiken | Spara | Avsluta |");
        string göra = Console.ReadLine().ToLower();

        //för att slåss
        if (göra == "slåss")
        {
            Fiende fiende = Gamebox.skapaFiende(fight);
            fight = Gamebox.slag(fight, fiende);
        }
        //För att gå till butiken
        if (göra == "butiken")
        {
            fight = Gamebox.butiken(fight);
        }
        //för att spara
        if (göra == "spara")
        {
            Toolbox.savegame(fight);
            System.Console.WriteLine("Sparat");
        }
        //för att avlsutta 
        if (göra == "avsluta")
        {
            while (ii < 1)
            {
                System.Console.WriteLine("Vill du sparade? Ja eller nej");
                göra = Console.ReadLine().ToLower();
                if (göra == "nej") { ii++; }
                if (göra == "ja")
                {
                    fight = Gamebox.butiken(fight);
                    ii++;
                }
            }


        }
    } else {ii++;}
}


