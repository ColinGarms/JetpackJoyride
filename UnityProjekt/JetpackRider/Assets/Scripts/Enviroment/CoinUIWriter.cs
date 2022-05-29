using System;
using UnityEngine;
using UnityEngine.UI;

namespace Enviroment
{
    public class CoinUIWriter : MonoBehaviour
    {
        [SerializeField] private Text coinText;
        private void Update()
        {
            int money = publicInformation.CoinManager.getMoney();
            coinText.text = money.ToString();

        }
    }
}