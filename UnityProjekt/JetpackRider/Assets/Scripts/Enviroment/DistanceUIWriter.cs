using UnityEngine;
using UnityEngine.UI;

namespace Enviroment
{
    public class DistanceUIWriter : MonoBehaviour
    {
        [SerializeField] private Text distanceText;
        private void Update()
        {
            int distance = publicInformation.getDistance();
            distanceText.text = distance.ToString()+"m";

        }
    }
}