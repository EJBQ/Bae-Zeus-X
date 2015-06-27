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
		print (this.GetComponent<Rigidbody2D> ().velocity);
		this.GetComponent<Rigidbody2D> ().velocity = new Vector3 (10.0F, 0.0F, 0.0F);
		print (this.GetComponent<Rigidbody2D> ().velocity);
	}
}

