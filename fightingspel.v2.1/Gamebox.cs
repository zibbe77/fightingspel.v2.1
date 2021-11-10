using System;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;

public class Fiende
{
    public int hp = 0;
    public int dmg = 0;

}
public class Gamebox
{

    public static Fiende skapaFiende(Fighter fighter)
    {
        Random generator = new Random();
        int r = generator.Next(1, 5);

        Fiende fiende = new Fiende
        {
            hp = fighter.lvlmulti * 10 * r,
            dmg = fighter.lvlmulti * r
        };
        return fiende;
    }
    public static Fiende slag(Fighter fighter, Fiende fiende)
    {


        return fiende;

    }
}