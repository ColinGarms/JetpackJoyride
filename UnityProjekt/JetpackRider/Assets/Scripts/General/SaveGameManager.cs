using System.IO;
using UnityEngine;

public class SaveGameManager
{

    private  string subPath = "SaveFiles/SaveGameFile";
    public SaveGame saveGame;


    public SaveGameManager()
    {
        saveGame =  LoadThisGame(subPath);
    }





    public void SaveThisGame()
    {
        saveGame.coins +=publicInformation.CoinManager.getMoney();
        if (saveGame.maxDistance < publicInformation.getDistance())
            saveGame.maxDistance = publicInformation.getDistance();
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
