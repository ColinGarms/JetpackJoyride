using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.UIElements;
using UnityEngine;

public class Drones : MonoBehaviour{

   
    public float speed = -3.0f;
    private Rigidbody2D rb;
    private Vector3 dronePos;
    
    public void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(speed, 2 * Mathf.Sin(Time.time * 3));

        dronePos = Camera.main.WorldToScreenPoint(transform.position);
    }
}