using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour {
	public float multiplier = 1.4f;
	public GameObject pickupEffect;
	public float duration = 4f;

	void OnTriggerEnter (Collider other)
	{
		if (other.CompareTag("Player"))
		{ 
			StartCoroutine ( Pickup(other) );
		 }
	}

	IEnumerator Pickup(Collider Player)
	{
		// Spawn a cool effect
		Instantiate(pickupEffect, transform.position, transform.rotation);
		//Apply effect to the player
		Player.transform.localScale *= multiplier;
		
		playerstat stats = Player.GetComponent<playerstat>();
		stats.health *= multiplier;

		//wait x amount of seconds
		GetComponent<MeshRenderer>().enabled = false;
		GetComponent<Collider>().enabled = false;

		yield return new WaitForSeconds (duration); 
		
		// reverse the effect on our player
		stats.health /= multiplier;

		//remove game obeject
		Destroy(gameObject);
		
	}
	
	}

