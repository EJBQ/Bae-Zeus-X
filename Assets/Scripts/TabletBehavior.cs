using UnityEngine;
using System;

public class TabletBehavior : MonoBehaviour {

	GameManager gameManager;

	// Use this for initialization
	void Start () {
		gameManager = GameObject.Find("gameManager").GetComponent<GameManager>();
	}

	public TabletBehavior ()
	{

	}

	void FixedUpdate() {
		if (transform.position.y < -11) {
			gameManager.destroyTabletOffScreen(this);
		}
	}
}

