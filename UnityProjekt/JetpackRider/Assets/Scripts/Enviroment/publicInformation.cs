using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class publicInformation : MonoBehaviour//change to gamestate
{
    // Start is called before the first frame update
    //public static CoinManager CoinManager = new CoinManager();

    public  SaveGameManager SaveGameManager;
    public CoinManager CoinManager;

     private void Start()
     {
         SaveGameManager = new SaveGameManager(this);
         
     }

     //public static SaveGameManager SaveGameManager= new SaveGameManager();
    public  int level;

    public  float getAdditionalSpeed()
    {
        //speed at level one is still the same
        float additionalSpeed = (float) ((level - 1) * 1);
        return  additionalSpeed;
    }
    
    public  int getDistance()
    {
        double timeSinceStart = Time.time;
        double distance = timeSinceStart*3;
        return (int)distance;
    }
}
