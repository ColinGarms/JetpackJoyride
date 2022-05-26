using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjects : MonoBehaviour{
    public GameObject dronePrefab;
    public GameObject laserPrefab;
    public GameObject coinPrefab;
    public GameObject coinCirclePrefab;
    public float respawnTime = 1.0f;
    private Vector2 screenBounds;
    
    

    private void SpawnObject()
    {
        
        float chance = Random.Range(0f, 1.0f);
        
        if (chance < 0.4)
        {
            GameObject objectToSpawn = Instantiate(dronePrefab) as GameObject;
            objectToSpawn.transform.position = new Vector2(screenBounds.x * 10, Random.Range(-screenBounds.y*3, screenBounds.y*3));
        }
        if (chance > 0.8)
        {
            GameObject objectToSpawn = Instantiate(coinCirclePrefab) as GameObject;
            objectToSpawn.transform.position = new Vector2(screenBounds.x * 10, Random.Range(-screenBounds.y*1, screenBounds.y*0.8f));
        }
        if (chance < 0.8 && chance > 0.6)
        {
            GameObject objectToSpawn2 = Instantiate(coinPrefab) as GameObject;
            objectToSpawn2.transform.position = new Vector2(screenBounds.x * 10, Random.Range(-screenBounds.y*3, screenBounds.y*3)); 
        }
        if (chance < 0.6 && chance > 0.4)
        {
            GameObject objectToSpawn2 = Instantiate(laserPrefab) as GameObject;
            objectToSpawn2.transform.position = new Vector2(screenBounds.x * 10, Random.Range(-screenBounds.y*3, screenBounds.y*3));
            objectToSpawn2.transform.Rotate(new Vector3(0,0,Random.Range(0, 360)));
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
