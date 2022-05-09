using UnityEngine;
using UnityEngine.SceneManagement; 

public class Load_Scene : MonoBehaviour
{   
    public void loadSelectedScene(string sceneName) {
        SceneManager.LoadScene(sceneName); 

        Debug.Log("Test");
    }
}
