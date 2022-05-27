
    using System.IO;
    using UnityEngine;

    public class SaveGameManager : MonoBehaviour
    {
        public SaveGame saveGame;
        private string subPath = "Desktop";

        void Start()
        {
            saveGame = LoadThisGame(subPath);
            if (saveGame == null) saveGame = new SaveGame();
            SaveThisGame(saveGame, subPath);
        }

        public void SaveThisGame()
        {
            SaveThisGame(saveGame, subPath);
        }
        
        
        
        private static void SaveThisGame(SaveGame data, string subPath)
        {
            
                var jsonString = JsonUtility.ToJson(data);
               // var fullPath = Path.Combine(Application.persistentDataPath, subPath);
                using (var streamWriter = File.CreateText(subPath))
                {
                    streamWriter.Write(jsonString);
                }
                Debug.Log(1);
        }

        private static SaveGame LoadThisGame(string subPath)
        {
            //var fullPath = Path.Combine(Application.persistentDataPath, subPath);
            using (var streamReader = File.OpenText(subPath))
            {
                var jsonString = streamReader.ReadToEnd();
                return JsonUtility.FromJson<SaveGame>(jsonString);
            }
        }

    
    }
