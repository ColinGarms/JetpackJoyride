using System.Collections;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;

public class SpawnObjects : MonoBehaviour
{
    [SerializeField] private publicInformation gameState;
    [SerializeField] private GameObject dronePrefab;
    [SerializeField] private GameObject laserPrefab;
    [SerializeField] private GameObject coinPrefab;
    [SerializeField] private GameObject coinCirclePrefab;
    [SerializeField] private GameObject laserHurdlePrefab;
    [SerializeField] private GameObject laserHolePrefab;
    [SerializeField] private GameObject laserGroupTopPrefab;
    [SerializeField] private GameObject laserGroupBottomPrefab;
    [SerializeField] private GameObject rocketPrefab;
    public float respawnTime = 5.0f;
    private Vector2 screenBounds;
    [SerializeField] private Text seedInput;



    public void GetSeed()
    {
        //Random.InitState(1634);
        Random.InitState(int.Parse(seedInput.text));
        //Debug.Log("Seed: " + int.Parse(seedInput.text));
        
    }

    private float SpawnObject()
    {
        
        float chance = Random.Range(0f, 1.0f);
        
        
        if (chance < 0.05)
        {
            GameObject objectToSpawn = Instantiate(laserHurdlePrefab) as GameObject;
            foreach (var laser in  objectToSpawn.GetComponentsInChildren<Laser>())
            {
                laser.gameState=gameState;
            }
            objectToSpawn.transform.position  = new Vector2(screenBounds.x * 15,objectToSpawn.transform.position.y);
            return respawnTime * Random.Range(1.0f, 2.0f) * 5.0f;

        }
        if (chance < 0.1)
        {
            GameObject objectToSpawn = Instantiate(laserGroupTopPrefab) as GameObject;
            foreach (var laser in  objectToSpawn.GetComponentsInChildren<Laser>())
            {
                laser.gameState=gameState;
            }
            objectToSpawn.transform.position  = new Vector2(screenBounds.x * 15,objectToSpawn.transform.position.y);
            return respawnTime * Random.Range(1.0f, 2.0f) * 1.5f;

        }
        if (chance < 0.15)
        {
            GameObject objectToSpawn = Instantiate(laserGroupBottomPrefab) as GameObject;
            foreach (var laser in  objectToSpawn.GetComponentsInChildren<Laser>())
            {
                laser.gameState=gameState;
            }
            objectToSpawn.transform.position  = new Vector2(screenBounds.x * 15,objectToSpawn.transform.position.y);
            return respawnTime * Random.Range(1.0f, 2.0f) * 1.5f;

        }
        else if (chance <0.2)
        {
            GameObject objectToSpawn = Instantiate(laserHolePrefab) as GameObject;
            foreach (var laser in  objectToSpawn.GetComponentsInChildren<Laser>())
            {
                laser.gameState=gameState;
            }
            objectToSpawn.transform.position  = new Vector2(screenBounds.x * 10, objectToSpawn.transform.position.y);
            Debug.Log(screenBounds.x);
            return respawnTime* Random.Range(1.00f, 2.0f) * 1.5f;
        }
        else if (chance <0.3)
        {
            GameObject objectToSpawn = Instantiate(dronePrefab) as GameObject;
            objectToSpawn.GetComponent<Drones>().gameState=gameState;
            objectToSpawn.transform.position  = new Vector2(screenBounds.x * 10, Random.Range(-screenBounds.y*3, screenBounds.y*3));
            return respawnTime* Random.Range(1.0f, 2.0f);
        }
        else if (chance <0.5)
        {
            GameObject objectToSpawn = Instantiate(rocketPrefab) as GameObject;
            objectToSpawn.GetComponent<RocketController>().gameState=gameState;
            objectToSpawn.transform.position  = new Vector2(screenBounds.x * 10, Random.Range(-screenBounds.y*3, screenBounds.y*3));
            return respawnTime* Random.Range(1.0f, 2.0f);
        }
        else if (chance < 0.6)
        {
            GameObject objectToSpawn = Instantiate(coinCirclePrefab) as GameObject;
           
            foreach (var coinController in  objectToSpawn.GetComponentsInChildren<CoinController>())
            {
                coinController.gameState=gameState;
            }
            objectToSpawn.transform.position = new Vector2(screenBounds.x * 10, Random.Range(-screenBounds.y*1, screenBounds.y*0.8f));
            return respawnTime* Random.Range(1.0f, 2.0f);
        }
        else if (chance <0.8)
        {
            GameObject objectToSpawn = Instantiate(coinPrefab) as GameObject;
            objectToSpawn.GetComponent<CoinController>().gameState=gameState;
            objectToSpawn.transform.position = new Vector2(screenBounds.x * 10, Random.Range(-screenBounds.y*3, screenBounds.y*3));
            return respawnTime* Random.Range(1.0f, 2.0f);
        }
        else if (chance <= 1)
        {
            GameObject objectToSpawn = Instantiate(laserPrefab) as GameObject;
            objectToSpawn.GetComponent<Laser>().gameState=gameState;
            objectToSpawn.transform.position = new Vector2(screenBounds.x * 11, Random.Range(-screenBounds.y*3, screenBounds.y*3));
            objectToSpawn.transform.Rotate(new Vector3(0,0,Random.Range(0, 360)));
            return respawnTime * Random.Range(1.0f, 2.0f);
        }
        return respawnTime* Random.Range(1.0f, 2.0f);
        
    }

    // Start is called before the first frame update
    public void StartSpawning()
    {
        GetSeed();
        screenBounds = Camera.main.ScreenToViewportPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(SpawnWave());
    }

    IEnumerator SpawnWave()
    {
        var waitTime = 30.0f;
        
        while (true)
        {
            yield return null;
            waitTime = SpawnObject();
            Debug.Log("waitTime: " + waitTime);
            yield return new WaitForSeconds(waitTime);
            //yield return new WaitForSeconds(respawnTime* Random.Range(0.6f, 1.0f));
            SpawnObject();
        }
    }
}
