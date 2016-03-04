using UnityEngine;
using System.Collections;

public class GetOverSpikes : MonoBehaviour {

	public GameObject ground;
	public Transform groundSpawn;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay2D (Collider2D other){
		if (other.gameObject.tag == "banshee" && Input.GetKeyDown(KeyCode.DownArrow)){
			Instantiate (ground, groundSpawn.position, groundSpawn.rotation);
			gameObject.GetComponent<BoxCollider2D> ().enabled = !gameObject.GetComponent<BoxCollider2D> ().enabled;
		}
	}
}
