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
    }
}
    
ii = 0;
while(ii < 1){
    
    System.Console.WriteLine("Vad vill du göra");
    System.Console.WriteLine("| Slåss | butiken | Spara | Avsluta |");
    string göra = Console.ReadLine().ToLower();
    
    //för att slåss
    if(göra == "slåss")
    {
    Fiende fiende = Gamebox.skapaFiende(fight);
    fight = Gamebox.slag(fight, fiende);
    }
    //För att gå till butiken
    if (göra == "butiken")
    {

    }
    //för att spara
    if (göra == "spara")
    {
        
    }
    //för att avlsutta 
    if(göra == "avsluta")
    {
        ii++;
    }
}


