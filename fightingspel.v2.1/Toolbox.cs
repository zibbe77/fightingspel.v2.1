using System;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;

public class Fighter
{
    public int hp { get; set; }
    public int dmg { get; set; }
    public int lvl { get; set; }
    public int lvlmulti { get; set; }
    public int xp { get; set; }
}
public class Toolbox
{
    public static void newgame()
    {
        string fileName = "";
        int ii = 0;
        while (ii < 1)
        {
            //skriver namnet på saven
            string namn = "";
            System.Console.WriteLine("skriv namnet på din save");
            namn = Console.ReadLine();
            fileName = $"{namn}.json";

            //sparar namnet på saven 
            string[] line = File.ReadAllLines(@"saves.txt");
            string[] line2 = File.ReadAllLines(@"orgin.txt");
            for (int i = 0; i < line2.Length; i++)
            {
                if (namn == line2[i])
                {
                    ii = -1;
                }
            }
            if (ii > -1)
            {
                File.AppendAllText(@"saves.txt", $"\n{namn}.json");
                File.AppendAllText(@"orgin.txt", $"\n{namn}");
            }
            ii++;
        }
        //skriver in saker i json filen 
        var fighter = new Fighter
        {
            hp = 100,
            dmg = 10,
            lvl = 1,
            lvlmulti = 2,
            xp = 0
        };

        string jsonString = JsonSerializer.Serialize(fighter);
        File.WriteAllText(fileName, jsonString);
    }

    public static Fighter loodgame()
    {
        string[] line = File.ReadAllLines(@"saves.txt");
        int ii = 0;
        string save = "";
        while (ii < 1)
        {
            for (int i = 0; i < line.Length; i++) { System.Console.WriteLine(line[i]); }
            System.Console.WriteLine("skriv viken save du vill ha");
            save = Console.ReadLine();
            for (int i = 0; i < line.Length; i++)
            {
                if (save == line[i]) {  ii++;  }
            }
        }

        //(Deserialize) data
        string jsonString = File.ReadAllText(save);
        Fighter fighter = JsonSerializer.Deserialize<Fighter>(jsonString);
        return fighter;
    }
}