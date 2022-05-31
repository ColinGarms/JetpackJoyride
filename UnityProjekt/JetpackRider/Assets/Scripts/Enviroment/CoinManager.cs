using System;
using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour

{
    // Start is called before the first frame update

    private int money = 0;
   [SerializeField] private Text[] texts ;
   [SerializeField] private publicInformation gameState;

   private void Start()
   {
       
   }


   // Update is called once per frame
    
    public void addAmount(int amount)
    {
        money += amount;
        foreach (var text in texts)
        {
            text.text = $"{money}";
        }
    }

    public int getMoney()
    {
        return money;
    }
}
