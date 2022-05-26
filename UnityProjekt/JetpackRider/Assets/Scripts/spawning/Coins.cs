using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    public float speed = -3.0f;
    private Rigidbody2D rb;
    private Vector3 coinPos;
    
    public void OnBecameInvisible()
    {
        Destroy(this.gameObject);
        if (transform.parent != null)
        {
            Destroy(transform.parent.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        coinPos = Camera.main.WorldToScreenPoint(transform.position);
        rb.velocity = new Vector2(speed, 0);
        
    }
}