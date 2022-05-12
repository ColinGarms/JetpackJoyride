using UnityEngine;

public class Handle_Pause_Menu : MonoBehaviour
{   
    [SerializeField]
    private GameObject startScreen;

    public void HidePauseScreen() {
        startScreen.SetActive(false);
        Time.timeScale = 1f;
    }
    
    public void ShowPauseScreen() {
        startScreen.SetActive(true);
        Time.timeScale = 0f;
    }
}
