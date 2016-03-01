using UnityEngine;
using System.Collections;

public class ActivateCrate : MonoBehaviour {

	GameObject crate;

	// Use this for initialization
	void Start () {
		crate = GameObject.FindGameObjectWithTag ("crate");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay2D(Collider2D other){

		if (other.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.DownArrow)){
			crate.GetComponent<HingeJoint2D>().enabled = !crate.GetComponent<HingeJoint2D>().enabled;
			gameObject.GetComponent<BoxCollider2D>().enabled = !gameObject.GetComponent<BoxCollider2D>().enabled;

		}
	}
}
