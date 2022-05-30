using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class publicInformation
{
    // Start is called before the first frame update
    public static CoinManager CoinManager = new CoinManager();

    public static SaveGameManager SaveGameManager = new SaveGameManager();

    public SaveGame saveGame;
    //public static SaveGameManager SaveGameManager= new SaveGameManager();
    public static int level;

    public static float getAdditionalSpeed()
    {
        //speed at level one is still the same
        float additionalSpeed = (float) ((level - 1) * 1);
        return  additionalSpeed;
    }
    
    public static int getDistance()
    {
        double timeSinceStart = Time.time;
        double distance = timeSinceStart*3;
        return (int)distance;
    }

    public static int getHighscore()
    {
        return (int)SaveGameManager.saveGame.maxDistance;
    }
}
