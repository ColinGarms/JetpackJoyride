using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Handle_Pause_Menu : MonoBehaviour
{   
    [SerializeField]
    private GameObject startScreen;

    public void HidePauseScreen() {
        startScreen.SetActive(false);
    }
    
    public void ShowPauseScreen() {
        startScreen.SetActive(true);
    }
}
