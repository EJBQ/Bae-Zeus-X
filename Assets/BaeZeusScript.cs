using UnityEngine;
using System.Collections;

public class BaeZeusScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	void FixedUpdate () {
		//moves up and down as he goes
		//moves to the right at a fixed rate
		float rightMovement = 0.1F;

		Vector3 newPosition = (transform.position + new Vector3 (rightMovement, 0.0F, 0.0F));

		transform.position = newPosition;

	}
}
