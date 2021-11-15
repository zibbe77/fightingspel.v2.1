using System;
using System.IO;

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
        int r = generator.Next(fighter.lvlmulti, fighter.lvlmulti + 6);

        Fiende fiende = new Fiende
        {
            hp = fighter.lvlmulti * r + 60,
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
            System.Console.WriteLine($"Finden har {fiende.hp} och gör max {fiende.dmg} dmg");
            System.Console.WriteLine($"Du har {fighter.hp} och gör max {fighter.dmg}");
            System.Console.WriteLine("Vad vill du göra?");
            System.Console.WriteLine("| Springa | Hårt slag | Lätt slag |");


            //slumpar tal 
            int RP = generator.Next(fighter.dmg / 2, fighter.dmg);
            int RF = generator.Next(fiende.dmg / 2, fiende.dmg);
            int chance = generator.Next(0, 100);

            //tar spelarens val
            string göra = Console.ReadLine().ToLower();

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
                if (chance > 40)
                {
                    fiende.hp -= RP * 2;
                }
                if (chance < 40) { System.Console.WriteLine("du missade ditt slag"); }
            }
            if (göra == "lätt slag")
            {
                fiende.hp -= RP;
            }
            //fiende atakcerar
            if (fiende.hp > 0)
            {
                fighter.hp -= RF;
            }
            // avslutar loopen
            if (fiende.hp < 0)
            {
                ii++;
                fighter.pengar += 50 * fighter.lvlmulti;
                fighter.xp += 100 / fighter.lvlmulti;

                System.Console.WriteLine($"Du fick {50 * fighter.lvlmulti} pengar och {100 / fighter.lvlmulti} xp (Det krävs hundra xp för att lvl up)");

                //kollar om du ska lvl up
                if (fighter.xp > 100)
                {
                    fighter.lvl += 1;
                    fighter.lvlmulti += 2;
                    fighter.dmg += 2;
                    fighter.hp += 5;
                    System.Console.WriteLine($"du lvl up från {fighter.lvl - 1} till {fighter.lvl}");
                }

                System.Console.WriteLine($"Du har nu {fighter.pengar} pengar och {fighter.xp} xp");
                System.Console.WriteLine($"Du är lvl {fighter.lvl}");
                Console.ReadLine();
            }
            if(fighter.hp < 0)
            {
                while(ii < 1){
                System.Console.WriteLine("Du dog");
                System.Console.WriteLine("Vill du spara innan spelets avslutas?");
                System.Console.WriteLine("| Ja | Nej |");
                göra = Console.ReadLine().ToLower();
                
                if (göra == "ja"){
                    Toolbox.savegame(fighter);
                    ii++;
                }
                if( göra == "nej"){
                    ii++;
                }
                }             
                
            }
        }

        return fighter;
    }
    //Butiken där man kan köpa sakar
    public static Fighter butiken(Fighter fighter)
    {
        int ii = 0;
        while (ii < 1)
        {
            System.Console.WriteLine("Det som fins att köpa är hp flaskor som healar 50 hp kostar 100 pengar och 2 skada som kostar 300");
            System.Console.WriteLine("| HP | Skada | Tillbaka |");

            string göra = Console.ReadLine().ToLower();
            if (göra == "hp")
            {
                if (fighter.pengar > 100)
                {
                    fighter.hp += 50;
                    if (fighter.hp > fighter.lvl * 5 + 95)
                    {
                        fighter.hp = fighter.lvl * 5 + 95;
                        System.Console.WriteLine("Du har fult");
                    }
                }
            }
            if (göra == "skada")
            {
                if (fighter.pengar > 300)
                {
                    fighter.dmg += 2;
                }
            }
            if (göra == "tillbaka")
            {
                ii++;
            }

        }

        return fighter;
    }
}