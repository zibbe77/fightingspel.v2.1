using System;
using System.IO;

//väljer att ladda in eller att skapa ny
System.Console.WriteLine("välkomen, skriv new game för att skappa nytt spel eller load game för att ladda in ett game");
int ii = 0;
while (ii < 1)
{
    string val = Console.ReadLine();
    if (val == "new game") 
    {
        Toolbox.newgame();
    }
    if (val == "load game") 
    {   
        fighter f = Toolbox.loodgame();
        ii++;
    }
}

