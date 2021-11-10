using System;
using System.IO;

//väljer att ladda in eller att skapa ny
System.Console.WriteLine("välkomen, skriv new game för att skappa nytt spel eller load game för att ladda in ett game");

int ii = 0;
Fighter fight = new Fighter();

//väljer om man ladar in ett spel eller skapar nytt
while (ii < 1)
{
    string val = Console.ReadLine();
    if (val == "new game")
    {
        Toolbox.newgame();
    }
    if (val == "load game")
    {
        fight = Toolbox.loodgame();
        ii++;
    }
    if (val != "new game" || val != "load game")
    {
        System.Console.WriteLine("skriv load game eller new game");
    }
}

ii = 0;
while(ii < 1){
    Fiende fiende = Gamebox.skapaFiende(fight);
    
}
