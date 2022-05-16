using System.Collections;
using UnityEngine;

public class SpawnObjects : MonoBehaviour{
    public GameObject dronePrefab;
    public GameObject coinPrefab;
    public float respawnTime = 25.0f;
    private Vector2 screenBounds;

    private void SpawnObject()
    {
        float chance = Random.Range(0f, 1.0f);
        //spawn drone
        if (chance < 0.6)
        {
            GameObject objectToSpawn = Instantiate(dronePrefab) as GameObject;
            objectToSpawn.transform.position = new Vector2(screenBounds.x * 10, Random.Range(-screenBounds.y*3, screenBounds.y*3));
        }
        //spawn coin
        else
        {
            GameObject objectToSpawn2 = Instantiate(coinPrefab) as GameObject;
            objectToSpawn2.transform.position = new Vector2(screenBounds.x * 10, Random.Range(-screenBounds.y*3, screenBounds.y*3)); 
        }
    }

    // Start is called before the first frame update
    void Start()
    {
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
            yield return new WaitForSeconds(respawnTime* Random.Range(0.5f, 2.0f));
            SpawnObject();
        }
    }
}
