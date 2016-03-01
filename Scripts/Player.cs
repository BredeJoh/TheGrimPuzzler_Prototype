﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    Text healthText;
    Rigidbody2D body2D;
	[System.Serializable]
	public class PlayerStats{
		public int PlayerHealth = 3;
	}

	public PlayerStats playerStats = new PlayerStats ();

	// Use this for initialization
	void Start () {
        body2D = GetComponent<Rigidbody2D>();
        healthText = GameObject.Find("Health").GetComponent<Text>();
        healthText.text = "Health: " + playerStats.PlayerHealth;

	}
	
	// Update is called once per frame
	void Update () {
        healthText.text = "Health: " + playerStats.PlayerHealth;
    }

	public void DamagePlayer(int damage){
		playerStats.PlayerHealth -= damage;
		if (playerStats.PlayerHealth <= 0) {
			GameMaster.KillPlayer(this);
		}
	}
	void OnCollisionEnter2D (Collision2D other){
		
		if(other.gameObject.tag == "spikes")
        {			
			DamagePlayer (3);		
		}
        if (other.gameObject.tag == "skeleton")
        {
            DamagePlayer(1);
        }
        if (other.gameObject.tag == "brute")
        {
            DamagePlayer(1);
        }
		if (other.gameObject.tag == "banshee")
		{
			DamagePlayer(1);
		}
    }

	IEnumerator OnTriggerEnter2D (Collider2D other){
		if (other.gameObject.name == "Goal"){
			float fadeTime = GameObject.Find("Goal").GetComponent<Fading> ().BeginFade(1);
			yield return new WaitForSeconds (fadeTime);
			Application.LoadLevel (Application.loadedLevel + 1);
		}
	}
}
