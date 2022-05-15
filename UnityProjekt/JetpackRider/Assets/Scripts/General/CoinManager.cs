using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour



{
    //[SerialiseField] private int money; 
    // Start is called before the first frame update
   private int money;
   [SerializeField] private Text text ; 
    void Start()
    {
        money = 0;
    }

    // Update is called once per frame
    
    public void addAmount(int amount)
    {
        money += amount;
        updateUI();
    }

    private void updateUI()
    {
        text.text = money.ToString();
    }
}
