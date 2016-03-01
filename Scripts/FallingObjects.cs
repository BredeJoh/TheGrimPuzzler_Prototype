using UnityEngine;
using System.Collections;

public class FallingObjects : MonoBehaviour {

	public GameObject bruteSpawn;
	public GameObject skeleSpawn;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D other){
		
		if (other.gameObject.tag == "brute"){
			Destroy (other.gameObject);
			Instantiate(bruteSpawn, transform.position, transform.rotation);
		}
		if (other.gameObject.tag == "skeleton"){
			Destroy (other.gameObject);
			Instantiate(skeleSpawn, transform.position, transform.rotation);
		}
			Destroy (this.gameObject);

	}
}
