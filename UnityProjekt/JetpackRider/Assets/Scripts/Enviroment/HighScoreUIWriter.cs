using UnityEngine;
using UnityEngine.UI;

namespace Enviroment
{
    //writes the high score in the text field
    public class HighScoreUIWriter : MonoBehaviour
    {
        [SerializeField] private Text distanceText;
        [SerializeField] private PublicInformation gameState;
        private void Update()
        {
            int distance = gameState.SaveGameManager.getHighScore();
            distanceText.text = distance.ToString()+"m";

        }
    }
}