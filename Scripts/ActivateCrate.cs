using UnityEngine;
using System.Collections;

public class ActivateCrate : MonoBehaviour {

	public GameObject crate;
	Transform crateSpawn;
	public GameObject currentCrate;

	// Use this for initialization
	void Start () {
		//crate = GameObject.FindGameObjectWithTag ("crate");
		crateSpawn = GameObject.Find ("CrateSpawn").transform;
		Instantiate (crate, crateSpawn.position, crateSpawn.rotation);
		currentCrate = GameObject.Find ("Crate");
	}
	
	// Update is called once per frame
	void Update () {
		if (currentCrate == null) {
			Instantiate (crate, crateSpawn.position, crateSpawn.rotation);
			currentCrate = GameObject.FindGameObjectWithTag ("crate");
		}
	}

	void OnTriggerStay2D(Collider2D other){

		if (other.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.DownArrow)){
			currentCrate.GetComponent<Rigidbody2D> ().gravityScale = 1;
			//gameObject.GetComponent<BoxCollider2D>().enabled = !gameObject.GetComponent<BoxCollider2D>().enabled;

			//StartCoroutine (RespawnCrate());
		} else if (other.gameObject.tag == "banshee" && Input.GetKeyDown(KeyCode.DownArrow)){
			
		}
	}

	/*IEnumerator RespawnCrate (){

		yield return new WaitForSeconds (4);
		Instantiate (crate, crateSpawn.position, crateSpawn.rotation);
		gameObject.GetComponent<BoxCollider2D> ().enabled = enabled;
	}*/
}
