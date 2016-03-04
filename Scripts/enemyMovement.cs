using UnityEngine;
using System.Collections;

public class enemyMovement : MonoBehaviour {

    Rigidbody2D body2D;
    float speed = 7.0f;
    private bool moveRight = true;

	// Use this for initialization
	void Start () {
        body2D = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        if (moveRight)
        {
            body2D.velocity = new Vector2(speed, body2D.velocity.y);
            transform.localScale = new Vector2(-1f, 1f);
            
        }
        else if (moveRight == false)
        {
            body2D.velocity = new Vector2(-speed, body2D.velocity.y);
            transform.localScale = new Vector2(1f, 1f);
        }
}
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "movementTrigger")
        {
            if (moveRight) {
                moveRight = false;
            }
            else
            {
                moveRight = true;
            }
        }
    }
}
