﻿using UnityEngine;
using System.Collections;

public class GameMaster : MonoBehaviour {

	public static GameMaster gm;

	public static bool currentPlayer = true;
	public static bool currentPlayerSkeleton = false;
	public static bool currentPlayerBrute = false;

	int spawnDelay = 2;

	public Transform playerPrefab;
	public Transform spawnPoint;

	// Use this for initialization
	void Start () {
		gm = GameObject.FindGameObjectWithTag ("GM").GetComponent<GameMaster>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Q) && !currentPlayerSkeleton) {
			// Focus on Skeleton
			currentPlayerSkeleton = true;
			currentPlayer = false;
			currentPlayerBrute = false;
		} else if (Input.GetKeyDown (KeyCode.Q) && currentPlayerSkeleton) {
			// Focus on Player
			currentPlayerSkeleton = false;
			currentPlayerBrute = false;
			currentPlayer = true;
		}
		if (Input.GetKeyDown (KeyCode.W) && !currentPlayerBrute) {
			// Focus on Brute
			currentPlayerSkeleton = false;
			currentPlayerBrute = true;
			currentPlayer = false;
		} else if (Input.GetKeyDown (KeyCode.W) && currentPlayerBrute) {
			// Fucus on Player
			currentPlayerSkeleton = false;
			currentPlayerBrute = false;
			currentPlayer = true;
		}
	}

	public IEnumerator RespawnPlayer () {

		yield return new WaitForSeconds (spawnDelay);
		
		Instantiate (playerPrefab, spawnPoint.position, spawnPoint.rotation);
	}

	public static void KillPlayer (Player player) {
		Destroy (player.gameObject);
		gm.StartCoroutine(gm.RespawnPlayer ());
	}
	public static void KillSkeleton (SkeletonController skeleton) {
		Destroy (skeleton.gameObject);
		GameMaster.currentPlayer = true;
		GameMaster.currentPlayerSkeleton = false;
	}
	public static void KillBrute (BruteController brute){
		Destroy (brute.gameObject);
		GameMaster.currentPlayer = true;
		GameMaster.currentPlayerBrute = false;
	}
}
