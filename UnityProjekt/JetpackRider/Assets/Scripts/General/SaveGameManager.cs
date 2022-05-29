using System.IO;
using UnityEngine;

public class SaveGameManager :MonoBehaviour
{

    private  string subPath = "SaveFiles/SaveGameFile";
    public SaveGame saveGame;


    /*public SaveGameManager()
    {
        saveGame =  LoadThisGame(subPath);
    }*/

    void Start()
    { 
        saveGame =  LoadThisGame(subPath);
    }

    private void OnDisable()
    {
        saveGame.coins +=publicInformation.CoinManager.getMoney();
        SaveThisGame();
    }

    public void SaveThisGame()
    {
        SaveThisGame(saveGame, subPath);
    }
    
    
    
    private static void SaveThisGame(SaveGame data, string subPath)
    {
        
        var jsonString = JsonUtility.ToJson(data);
        var fullPath = Path.Combine(Application.dataPath, subPath);
        
        using (var streamWriter = File.CreateText(fullPath)) {
            streamWriter.Write(jsonString);
        }
    }

    private static SaveGame LoadThisGame(string subPath)
    {
        var fullPath = Path.Combine(Application.dataPath, subPath);
        using (var streamReader = File.OpenText(fullPath))
        {
            var jsonString = streamReader.ReadToEnd();
            return JsonUtility.FromJson<SaveGame>(jsonString);
        }
    }


}
