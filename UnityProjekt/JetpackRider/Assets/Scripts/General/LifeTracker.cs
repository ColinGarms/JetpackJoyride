using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// adds lifepoints to the game and calls methods of WinLoose to crate a win and loose screen
public class LifeTracker : MonoBehaviour
{
    //images that show the healthpoints for the player, each one for 1 health point

    private int maxLifePoitns = 7;
    // life points with valid range
    [SerializeField][Range(0, 2)] private int lifePoints;


    //turn off all lifepoint images that are not needed 
    public void Start()
    {
        lifePoints = 1;
    }
        
    //return the current lifePoints
    public int getLifePoints()
    {
        return lifePoints;

    }


    // called when there is a change to the lifepoints of the player
    public void changeLifePoints(int change)
    {
        
        //change the actual LifePoints
        lifePoints += change;

        //check for game over condition
        if (lifePoints <= 0)
        {
            //winLoose.loose();
        }
            
            
    }
}
