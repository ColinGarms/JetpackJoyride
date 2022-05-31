using UnityEngine;
using UnityEngine.UI;

namespace Enviroment
{
    public class DistanceUIWriter : MonoBehaviour
    {
        [SerializeField] private Text distanceText;
        [SerializeField] private publicInformation gameState;
        private void Update()
        {
            int distance = gameState.getDistance();
            distanceText.text = distance.ToString()+"m";

        }
    }
}