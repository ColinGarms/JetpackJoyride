using UnityEngine;

namespace General
{
    public class LevelSelection :MonoBehaviour
    {
        public void setLevel(int level)
        {
            publicInformation.level = level;
        }
        public void setLevel1()
        {
            setLevel(1);
        }
        public void setLevel2()
        {
            setLevel(2);
        }
        public void setLevel3()
        {
            setLevel(3);
        }
    }
}