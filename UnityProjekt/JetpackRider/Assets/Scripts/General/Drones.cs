using UnityEngine;

public class Drones : MonoBehaviour{
    public float speed = -3.0f;
    private Rigidbody2D rb;
    private Vector2 screenBounds;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(speed, 0);
        screenBounds = Camera.main.ScreenToViewportPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(speed, 2 * Mathf.Sin(Time.time * 3));
        if (transform.position.x <-10)
        {
            Destroy(this.gameObject);
        }
    }
}
