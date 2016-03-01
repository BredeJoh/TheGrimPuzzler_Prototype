using UnityEngine;
using System.Collections;

public class CameraFollow2D : MonoBehaviour {

// VARIABLES
	float dampTime = 0.3f;
	Vector3 velocity = Vector3.zero;
	public Transform target;
	public static Transform player;
	public static Transform skeleton;
	public static Transform brute;
	float nextTimeToSearch = 0;

	void Start (){
		player = GameObject.FindGameObjectWithTag ("Player").transform;
	}
	
// Update is called once per frame
	void FixedUpdate () {



		// Switching targets acording to the active player
		if(GameMaster.currentPlayer){
			target = player;
		}
		if(GameMaster.currentPlayerSkeleton){

			if(skeleton==null){
				FindSkeleton();
				if (skeleton != null){
					target = skeleton;
				}
			}

		}
		if(GameMaster.currentPlayerBrute){

			if(brute==null){
				FindBrute();
				if (brute != null){
				target = brute;
				}
			}
			target = brute;
		}

		// Searching for player until he spawnes
		if (target == null) {
			FindPlayer ();
			return;
		} 



		// Define Target of the follow
			if (target) {
			// Define space that camera shall occupy
				Vector3 point = GetComponent<Camera>().WorldToViewportPoint(target.position);
				Vector3 delta = target.position - GetComponent<Camera>().ViewportToWorldPoint
					(new Vector3(0.5f, 0.5f, point.z)); //(new Vector3(0.5, 0.5, point.z));
			// Follow the player w. smoothing
				Vector3 destination = transform.position + delta;
				transform.position = Vector3.SmoothDamp
					(transform.position, destination, ref velocity, dampTime);
			}
	}

	void FindPlayer () {
		if (nextTimeToSearch <= Time.time) {
			GameObject searchResult = GameObject.FindGameObjectWithTag ("Player");	
			if (searchResult != null)
				player = searchResult.transform;
			nextTimeToSearch = Time.time + 0.5f;
			
		}
	}

	void FindSkeleton () {
		if (nextTimeToSearch <= Time.time) {
			GameObject searchResult = GameObject.FindGameObjectWithTag ("skeleton");	
			if (searchResult != null)
				skeleton = searchResult.transform;
			nextTimeToSearch = Time.time + 0.5f;
		}
	}

	void FindBrute () {
		if (nextTimeToSearch <= Time.time) {
			GameObject searchResult = GameObject.FindGameObjectWithTag ("brute");	
			if (searchResult != null)
				brute = searchResult.transform;
			nextTimeToSearch = Time.time + 0.5f;
		}
	}
}