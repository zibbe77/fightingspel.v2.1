using System;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;

public class Fiende
{
    public int hp = 0;
    public int dmg = 0;
    public int givexp = 100;
}
public class Gamebox
{

    public static Fiende skapaFiende(Fighter fighter)
    {
        Random generator = new Random();
        int r = generator.Next(1, 8);

        Fiende fiende = new Fiende
        {
            hp = fighter.lvlmulti * 20 * r,
            dmg = fighter.lvlmulti * r
        };
        return fiende;
    }
    public static Fighter slag(Fighter fighter, Fiende fiende)
    {
        int ii = 0;
        Random generator = new Random();
        while (ii < 1)
        {
            //skriver information till spelaren
            System.Console.WriteLine($"Finden har{fiende.hp} och gör max {fiende.dmg} dmg");
            System.Console.WriteLine($"Du har {fighter.hp} och gör max {fighter.dmg}");
            System.Console.WriteLine("Vad vill du göra?");
            System.Console.WriteLine("| Springa | Hårt slag | Lätt slag |");


            //slumpar tal 
            int RP = generator.Next(fighter.dmg / 2, fighter.dmg);
            int RF = generator.Next(fiende.dmg / 2, fiende.dmg);
            int chance = generator.Next(0, 100);

            //tar spelarens val
            string göra = Console.ReadLine();
            göra = Console.ReadLine().ToLower();

            //kollar val och räknar ut dmg och hp
            if (göra == "springa")
            {
                if (chance > 65)
                {
                    System.Console.WriteLine("Du sprang ifrån finden");
                    ii++;
                }
                if (chance < 65)
                {
                    System.Console.WriteLine("Du mislyckade");
                    //här ska man ta dmg
                }
            }
            if (göra == "hårt slag")
            {
                if (chance > 30)
                {
                    fiende.hp = -RP * 2;
                }
                if (chance < 30) { System.Console.WriteLine("du missade ditt slag"); }
            }
            if (göra == "lätt slag")
            {
                fiende.hp = -RP;
            }
            if (fiende.hp < 0)
            {
                fighter.hp = -RF;
            }
        }

        return fighter;
    }
}