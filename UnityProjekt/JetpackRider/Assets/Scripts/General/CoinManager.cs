using UnityEngine;

public class CoinManager : MonoBehaviour

{
    // Start is called before the first frame update
   private int money;
   //[SerializeField] private Text text ; 
   
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

    // change the coin number in the UI
    private void updateUI()
    {
      //TODO: implement change in userinterface, display money
    }
}
