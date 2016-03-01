﻿using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public Transform spawnpoint;

	float speed = 7.0f; 
	float jumpSpeed = 14.0f;
	bool isGrounded = false;
    bool stunned = false;
    private bool climb = false;
	Rigidbody2D body2D;


	// Use this for initialization
	void Start () {
		transform.position = spawnpoint.position;
		body2D = GetComponent<Rigidbody2D> ();
        
	}

	// Update is called once per frame
	void Update () {
		if (GameMaster.currentPlayer == true && stunned == false) {
			// Movement
			if (Input.GetKey (KeyCode.LeftArrow)) {
				body2D.velocity = new Vector2 (-speed, body2D.velocity.y);
				transform.localScale = new Vector2 (1f, 1f);
			} else if (Input.GetKey (KeyCode.RightArrow)) {
				body2D.velocity = new Vector2 (speed, body2D.velocity.y);
				transform.localScale = new Vector2 (-1f, 1f);
			} else {
				body2D.velocity = new Vector2 (0f, body2D.velocity.y);
			}

            // Jumping
            if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded == true && climb == false) {
				body2D.velocity = new Vector2 (body2D.velocity.x, jumpSpeed);
				isGrounded = false;
			}
            //climbing
            else if (Input.GetKey(KeyCode.UpArrow) && climb == true)
            {
                body2D.velocity = new Vector2(body2D.velocity.x, speed);
                isGrounded = false;
            }
		} else {
			//gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2 (0,0);
		}
        if (isGrounded)
        {
            stunned = false;
        }
	}
    void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "skeleton")
        {
            stunned = true;
            Vector2 knockBack = other.gameObject.transform.position - gameObject.transform.position;
            if (knockBack.x > 0)
            {
                body2D.velocity = new Vector2(-speed, speed);
                print("hei");
            }
            else
            {
                body2D.velocity = new Vector2(speed, speed);
                print("hade");
            }
        }
        if (other.gameObject.tag == "brute")
        {
            stunned = true;
            Vector2 knockBack = other.gameObject.transform.position - gameObject.transform.position;
            if (knockBack.x > 0)
            {
                body2D.velocity = new Vector2(-speed, speed);
                print("hei");
            }
            else
            {
                body2D.velocity = new Vector2(speed, speed);
                print("hade");
            }
        }
    }

	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.tag == "ground")
        {
			isGrounded = true;
		}     
       /* if (other.gameObject.tag == "skeleton")
        {
            stunned = true;
            Vector2 knockBack = other.gameObject.transform.position - gameObject.transform.position;
            if (knockBack.x > 0)
            {
                body2D.velocity = new Vector2(-speed, speed);
                print("hei");
            }
            else
            {
                body2D.velocity = new Vector2(speed, speed);
                print("hade");          
            }
        }
        if(other.gameObject.tag == "brute")
        {
            stunned = true;
            Vector2 knockBack = other.gameObject.transform.position - gameObject.transform.position;
            if (knockBack.x > 0)
            {
                body2D.velocity = new Vector2(-speed, speed);
                print("hei");
            }
            else
            {
                body2D.velocity = new Vector2(speed, speed);
                print("hade");
            }
        }*/
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "ground")
        {
            isGrounded = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
		/*if (other.gameObject.tag == "ground")
		{
			isGrounded = true;
		}   
*/
        if (other.gameObject.tag == "ladder")
        {
            climb = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag == "ladder")
        {
            climb = false;
        }
    }

}