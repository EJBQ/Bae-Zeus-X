using UnityEngine;
using System;

public class LightningBehavior : MonoBehaviour {
	
	GameManager gameManager;
	
	// Use this for initialization
	void Start () {
		gameManager = GameObject.Find("gameManager").GetComponent<GameManager>();
	}
	
	public LightningBehavior ()
	{
		
	}
	
	void FixedUpdate() {
		this.GetComponent<Rigidbody2D> ().velocity = new Vector3 (10.0F, 0.0F, 0.0F);
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.CompareTag("Enemy")) {
			Destroy(this.gameObject);
			other.gameObject.GetComponent<MonkeyScript>().loseHealth();
		}
	}
}

