using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    private float length;
    private float startPosition;
    public float scrollSpeed;
    private Vector3 backgroundPos;
    
    public void OnBecameInvisible()
    {
        startPosition = startPosition + length*2;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
        
    }

    // Update is called once per frame
    void Update()
    {
        float temp = Camera.main.transform.position.x * (1 - scrollSpeed);
        float distance =Time.time * 5.0f * -scrollSpeed;
        
        backgroundPos = Camera.main.WorldToScreenPoint(transform.position);
        
        transform.position = new Vector3(startPosition + distance, transform.position.y, transform.position.z);

        
        Debug.Log(temp);
        
        if (backgroundPos.x > 0)
        {
          
        }
        else if (backgroundPos.x + length  < 0 )
        {
           
        }
        


    }
}