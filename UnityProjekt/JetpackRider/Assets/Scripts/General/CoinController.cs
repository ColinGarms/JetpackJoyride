using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
	private int worth = 1;
	[SerializeField] private CoinManager coinManager;
    [SerializeField] private SpriteRenderer coinSprite;
    [SerializeField] private Rigidbody2D rigidbody; 
	private Vector2 newVelocity;
    
    // Start is called before the first frame update
    void Start()
    {
		newVelocity = new Vector2(-1f,0);
    }

    // Update is called once per frame
    void Update()
    {
    }

    void FixedUpdate()
    {
		//set stardard velocity
        rigidbody.velocity = newVelocity;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
		//destroy on contact with player
        if (other.gameObject.CompareTag("Player"))
        {
	        coinManager.addAmount(worth);
			Destroy(this.gameObject);
        }
    }
}
