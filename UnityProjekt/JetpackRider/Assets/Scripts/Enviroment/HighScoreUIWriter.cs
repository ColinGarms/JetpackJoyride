using UnityEngine;
using UnityEngine.UI;

namespace Enviroment
{
    public class HighScoreUIWriter : MonoBehaviour
    {
        [SerializeField] private Text distanceText;
        private void Update()
        {
            int distance = publicInformation.getHighscore();
            distanceText.text = distance.ToString()+"m";

        }
    }
}