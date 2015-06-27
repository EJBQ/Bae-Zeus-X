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
		
	}
}

