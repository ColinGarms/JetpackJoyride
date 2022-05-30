using UnityEngine;
using UnityEngine.UI;

public class CoinManager 

{
    // Start is called before the first frame update

    private int money = 0;
   //[SerializeField] private Text text ; 
   


    // Update is called once per frame
    
    public void addAmount(int amount)
    {
        money += amount;
        
    }

    public int getMoney()
    {
        return money;
    }
}
