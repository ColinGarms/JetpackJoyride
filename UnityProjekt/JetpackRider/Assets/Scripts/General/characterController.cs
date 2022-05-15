using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private SpriteRenderer characterSprite;
    [SerializeField] private Rigidbody2D rigidbody; 
    [SerializeField] private LifeTracker lifeTracker;
    private float  upForce = 0.5f;
    private float maxVelocityUp =5f;
    private Vector2 upSpeed; 
    private bool boost;
    

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        //when Jump button (here space) is pressed: remember that
        if (Input.GetButton("Jump"))
        {
            boost = true;
        }
        else
        {
            boost = false;
        }
    }

    void FixedUpdate()
    {
        //when ypu remember that space is pressed, fly up
        flyUp();
    }


    private void flyUp()
    {
        if (boost)
        {
            rigidbody.AddForce(Vector2.up* upForce, ForceMode2D.Impulse);
            if (rigidbody.velocity.y > maxVelocityUp) rigidbody.velocity = new Vector2(rigidbody.velocity.x, maxVelocityUp);
                
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        //when player touches an enemy, reduce lifePoints
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            lifeTracker.changeLifePoints(-1);
        }
    }
}
