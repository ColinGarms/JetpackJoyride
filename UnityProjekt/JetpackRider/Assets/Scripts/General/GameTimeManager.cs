using UnityEngine;

public class GameTimeManager : MonoBehaviour
{
    public void PauseGame ()
    {
        Time.timeScale = 0;
        Debug.Log(Time.timeScale);
    }

    public void ResumeGame ()
    {
        Time.timeScale = 1;
        Debug.Log(Time.timeScale);
    }
}
