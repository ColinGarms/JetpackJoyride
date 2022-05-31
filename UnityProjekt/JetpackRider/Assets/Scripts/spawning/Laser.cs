using UnityEngine;

public class Laser : MonoBehaviour
{
    public publicInformation gameState;
    public float speed = -3.0f ;
    private Rigidbody2D rb;
    private Vector3 laserPos;
   
    
    public void OnBecameInvisible()
    {
        Destroy(this.gameObject);
        if (transform.parent != null && transform.parent.childCount == 1)
        {
            Destroy(transform.parent.gameObject);
        }
    }
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(speed , 0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        laserPos = Camera.main.WorldToScreenPoint(transform.position);
        rb.velocity = new Vector2(speed-(float)(gameState.getAdditionalSpeed()*0.5) , 0);
        
    }
}