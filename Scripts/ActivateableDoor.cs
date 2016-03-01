using UnityEngine;
using System.Collections;

public class ActivateableDoor : MonoBehaviour {

	GameObject door;

	void Start (){
		door = GameObject.FindGameObjectWithTag ("door");
	}

	void OnTriggerEnter2D (Collider2D other){
		if (other.gameObject.tag == "Player"){
			Destroy (door);
			gameObject.GetComponent<BoxCollider2D> ().enabled = !gameObject.GetComponent<BoxCollider2D> ().enabled;
		}
	}
}
