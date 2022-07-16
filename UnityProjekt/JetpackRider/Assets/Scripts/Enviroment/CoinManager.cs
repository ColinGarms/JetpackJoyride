using System;
using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    private int money = 0;
    [SerializeField] private Text[] texts;
    [SerializeField] private PublicInformation gameState;
    
    //adds an amount to money and writes the new amount in the text fields
    public void addAmount(int amount)
    {
        money += amount;
        foreach (var text in texts)
        {
            text.text = $"{money}";
        }
    }

    //return the money value
    public int getMoney()
    {
        return money;
    }
}
