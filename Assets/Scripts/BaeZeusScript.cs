using UnityEngine;
using System.Collections;

public class BaeZeusScript : MonoBehaviour {

	GameManager gameManager;
	
	// Use this for initialization
	void Start () {
		gameManager = GameObject.Find("gameManager").GetComponent<GameManager>();
	}

	void Update() {

	}

	void FixedUpdate () {
		//moves up and down as he goes
		//moves to the right at a fixed rate
		float rightMovement = 0.0F;

		float frequency = 4.0f;  // Speed of sine movement
		float height = .1F; //height of sin movement
		float upMovement = height * Mathf.Sin (Time.time * frequency);


		Vector3 newPosition = (transform.position + new Vector3 (rightMovement, upMovement, 0.0F));

		transform.position = newPosition;


	}
}
