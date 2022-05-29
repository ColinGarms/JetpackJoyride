using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class publicInformation
{
    // Start is called before the first frame update
    public static CoinManager CoinManager = new CoinManager();
    //public static SaveGameManager SaveGameManager= new SaveGameManager();
    public static int level;

    public double getAdditionalSpeed()
    {
        //speed at level one is still the same
        return  (publicInformation.level -1) * 0.3;
    }
}
