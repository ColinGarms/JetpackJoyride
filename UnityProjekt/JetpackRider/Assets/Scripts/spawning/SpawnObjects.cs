using System.Collections;
using UnityEngine;

public class SpawnObjects : MonoBehaviour{
    public GameObject dronePrefab;
    public GameObject laserPrefab;
    public GameObject coinPrefab;
    public GameObject coinCirclePrefab;
    public GameObject rocketPrefab;
    public float respawnTime = 1.0f;
    private Vector2 screenBounds;
    
    

    private void SpawnObject()
    {
        
        float chance = Random.Range(0f, 1.0f);
        
        if (chance < 0.3)
        {
            GameObject objectToSpawn = Instantiate(dronePrefab) as GameObject;
            objectToSpawn.transform.position  = new Vector2(screenBounds.x * 10, Random.Range(-screenBounds.y*3, screenBounds.y*3));
        }
        else if (chance <0.5)
        {
            GameObject objectToSpawn = Instantiate(rocketPrefab) as GameObject;
            objectToSpawn.transform.position  = new Vector2(screenBounds.x * 10, Random.Range(-screenBounds.y*3, screenBounds.y*3));
        }
       else if (chance < 0.6)
        {
            GameObject objectToSpawn = Instantiate(coinCirclePrefab) as GameObject;
            objectToSpawn.transform.position = new Vector2(screenBounds.x * 10, Random.Range(-screenBounds.y*1, screenBounds.y*0.8f));
        }
        else if (chance <0.8)
        {
            GameObject objectToSpawn = Instantiate(coinPrefab) as GameObject;
            objectToSpawn.transform.position = new Vector2(screenBounds.x * 10, Random.Range(-screenBounds.y*3, screenBounds.y*3)); 
        }
        else if (chance <= 1)
        {
            GameObject objectToSpawn = Instantiate(laserPrefab) as GameObject;
            objectToSpawn.transform.position = new Vector2(screenBounds.x * 10, Random.Range(-screenBounds.y*3, screenBounds.y*3));
            objectToSpawn.transform.Rotate(new Vector3(0,0,Random.Range(0, 360)));
        }

        
    }

    // Start is called before the first frame update
    void Start()
    {
        Random.InitState(1634);
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
