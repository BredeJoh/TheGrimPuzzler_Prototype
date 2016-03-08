using UnityEngine;
using System.Collections;

public class ActivateableDoor : MonoBehaviour {

	GameObject door;

	void Start (){
		door = GameObject.FindGameObjectWithTag ("door");
	}

	void OnTriggerEnter2D (Collider2D other){
		if (other.gameObject.tag == "brute"){
			//Destroy (door);
			door.GetComponent<SpriteRenderer>().enabled = !enabled;
			door.GetComponent<BoxCollider2D>().enabled = !enabled;
			//gameObject.GetComponent<BoxCollider2D> ().enabled = !gameObject.GetComponent<BoxCollider2D> ().enabled;
		}
	}


}
