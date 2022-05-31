using System.Collections;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;

public class SpawnObjects : MonoBehaviour
{
    [SerializeField] private publicInformation gameState;
    public GameObject dronePrefab;
    public GameObject laserPrefab;
    public GameObject coinPrefab;
    public GameObject coinCirclePrefab;
    public GameObject laserHurdlePrefab;
    public GameObject laserHolePrefab;
    public GameObject rocketPrefab;
    public float respawnTime = 1.0f;
    private Vector2 screenBounds;
    [SerializeField] private Text seedInput;



    public void GetSeed()
    {
        //Random.InitState(1634);
        Random.InitState(int.Parse(seedInput.text));
        //Debug.Log("Seed: " + int.Parse(seedInput.text));
        
    }

    private void SpawnObject()
    {
        
        float chance = Random.Range(0f, 1.0f);
        
        
        if (chance < 0.1)
        {
            GameObject objectToSpawn = Instantiate(laserHurdlePrefab) as GameObject;
            foreach (var laser in  objectToSpawn.GetComponentsInChildren<Laser>())
            {
                laser.gameState=gameState;
            }
            objectToSpawn.transform.position  = new Vector2(screenBounds.x * 15,objectToSpawn.transform.position.y);
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
        }
        else if (chance <0.3)
        {
            GameObject objectToSpawn = Instantiate(dronePrefab) as GameObject;
            objectToSpawn.GetComponent<Drones>().gameState=gameState;
            objectToSpawn.transform.position  = new Vector2(screenBounds.x * 10, Random.Range(-screenBounds.y*3, screenBounds.y*3));
        }
        else if (chance <0.5)
        {
            GameObject objectToSpawn = Instantiate(rocketPrefab) as GameObject;
            objectToSpawn.GetComponent<RocketController>().gameState=gameState;
            objectToSpawn.transform.position  = new Vector2(screenBounds.x * 10, Random.Range(-screenBounds.y*3, screenBounds.y*3));
        }
        else if (chance < 0.6)
        {
            GameObject objectToSpawn = Instantiate(coinCirclePrefab) as GameObject;
           
            foreach (var coinController in  objectToSpawn.GetComponentsInChildren<CoinController>())
            {
                coinController.gameState=gameState;
            }
            objectToSpawn.transform.position = new Vector2(screenBounds.x * 10, Random.Range(-screenBounds.y*1, screenBounds.y*0.8f));
        }
        else if (chance <0.8)
        {
            GameObject objectToSpawn = Instantiate(coinPrefab) as GameObject;
            objectToSpawn.GetComponent<CoinController>().gameState=gameState;
            objectToSpawn.transform.position = new Vector2(screenBounds.x * 10, Random.Range(-screenBounds.y*3, screenBounds.y*3)); 
        }
        else if (chance <= 1)
        {
            GameObject objectToSpawn = Instantiate(laserPrefab) as GameObject;
            objectToSpawn.GetComponent<Laser>().gameState=gameState;
            objectToSpawn.transform.position = new Vector2(screenBounds.x * 11, Random.Range(-screenBounds.y*3, screenBounds.y*3));
            objectToSpawn.transform.Rotate(new Vector3(0,0,Random.Range(0, 360)));
        }

        
    }

    // Start is called before the first frame update
    void Start()
    {
        GetSeed();
        screenBounds = Camera.main.ScreenToViewportPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(SpawnWave());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime* Random.Range(0.6f, 1.0f));
            SpawnObject();
        }
    }
}
