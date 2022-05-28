using UnityEngine;

public class RocketController : MonoBehaviour
{
    [SerializeField] private SpriteRenderer rocketSprite;
    [SerializeField] private Rigidbody2D rigidbody; 
    [SerializeField] private GameObject warningPrefab;
    private GameObject objectToSpawn; 
    private Vector2 newVelocity;
    private float time ;
    
	
    public float speed = -3.0f;
    private Vector2 screenBounds;

    private bool move=false;
    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToViewportPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        showWarning();
        time =  Time.time;
        Debug.Log(time + 100);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (time + 2 < Time.time )
        {
            move = true;
        }
    }

    private void FixedUpdate()
    {

        if (move)
        {
            Destroy(objectToSpawn.gameObject);
            rigidbody.velocity = new Vector2(speed, 0);
            //?????
            screenBounds =
                Camera.main.ScreenToViewportPoint(new Vector3(Screen.width, Screen.height,
                    Camera.main.transform.position.z));
            
        }
        
        if (transform.position.x <-10)
        {
            Destroy(this.gameObject);
        }
        
        
        
    }

    private void showWarning()
    {
        float yPosition = rigidbody.position.y;
        float xPosition = Screen.width;
        
        objectToSpawn = Instantiate(warningPrefab) as GameObject;
        objectToSpawn.transform.position = new Vector2(screenBounds.x * 8, this.transform.position.y);
        //objectToSpawn.GetComponent<Rigidbody2D>().position = new Vector2(screenBounds.x * 9, this.rigidbody.position.y);
    }
}
