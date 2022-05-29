using UnityEngine;

public class CoinController : MonoBehaviour
{
	[SerializeField] private SpriteRenderer coinSprite;
    [SerializeField] private Rigidbody2D coinCigidbody; 
	private Vector2 newVelocity;

	private int worth = 1;
	public float speed = -3.0f;
	private Vector2 screenBounds;
    
    // Start is called before the first frame update
    void Start()
    {
	    //set the initial speed
	    coinCigidbody.velocity = new Vector2(speed, 0);
	    //?????
	    screenBounds = Camera.main.ScreenToViewportPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    
    
    void FixedUpdate()
    {
	    //set velocity
		coinCigidbody.velocity = new Vector2(speed, 0);
		if (transform.position.x <-10)
		{
			Destroy(this.gameObject);
		}
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
		//destroy on contact with player
        if (other.gameObject.CompareTag("Player"))
        {	
	        publicInformation.CoinManager.addAmount(worth);
			Destroy(this.gameObject);
        }
    }

    
}
