using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//saves information about the game state
public class PublicInformation : MonoBehaviour
{
    public  SaveGameManager SaveGameManager;
    public CoinManager CoinManager;

     private void Start()
     {
         SaveGameManager = new SaveGameManager(this);
         
     }

     //saves the selected level
    public  int level;

    //returns the additional speed that is added to the horizontally moving objects
    public  float getAdditionalSpeed()
    {
        //speed at level one is still the same
        float additionalSpeed = (float) ((level - 1) * 1);
        return  additionalSpeed;
    }
    
    //returns the distance the character has crossed
    public  int getDistance()
    {
        //distance depends on the time since that start of the game
        double timeSinceStart = Time.time;
        double distance = timeSinceStart*3;
        return (int)distance;
    }
}
