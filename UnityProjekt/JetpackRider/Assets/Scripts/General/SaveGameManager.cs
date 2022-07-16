using System.IO;
using UnityEngine;

//hold a saveGame and is responsible for loading and saving i
//can be used to get the data out of the saveGame
public class SaveGameManager 
{
    private PublicInformation gameState;
    private  string subPath = "SaveGameFile";
    public SaveGame saveGame;
 
    public SaveGameManager( PublicInformation gameState)
    {
        saveGame =  LoadThisGame(subPath);
        this.gameState = gameState;
    }

    //stores gamedata in the saveGame and saves it
    public void SaveThisGame()
    {
        saveGame.coins +=gameState.CoinManager.getMoney();
        if (saveGame.maxDistance < gameState.getDistance())
        {
            saveGame.maxDistance = gameState.getDistance();
        }
            
        SaveThisGame(saveGame, subPath);
    }
    
    //saves the given saveGame in a json file
    private static void SaveThisGame(SaveGame data, string subPath)
    {
        
        var jsonString = JsonUtility.ToJson(data);
        var fullPath = Path.Combine(Application.dataPath, subPath);
        
        using (var streamWriter = File.CreateText(fullPath)) {
            streamWriter.Write(jsonString);
        }
    }

    //loads a saveGame from a saveFile with the given subPath
    private static SaveGame LoadThisGame(string subPath)
    {

        var fullPath = Path.Combine(Application.dataPath, subPath);
        if (File.Exists(fullPath))
        {
            using (var streamReader = File.OpenText(fullPath))
            {
                var jsonString = streamReader.ReadToEnd();
                return JsonUtility.FromJson<SaveGame>(jsonString);
            }
        }
        else return new SaveGame();
    }

    //returns the highscore (maxDistance) as an int
    public int getHighScore()
    {
        return (int) saveGame.maxDistance;
    }

}
