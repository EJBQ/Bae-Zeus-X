using UnityEngine;
using System.Collections;

public class iPhoneBehaviour : MonoBehaviour {

	public GameObject blueStars;
	// Use this for initialization
	void Start () {
	
	}
	
	void FixedUpdate() {
		if (this.gameObject.transform.position.y < -11) {
			destroyiPhoneOffScreen();
		}
	}

	void destroyiPhoneOffScreen() {
		Destroy (this.gameObject);
	}

	void OnTriggerEnter2D(Collider2D collider) {

		if (collider.gameObject.CompareTag("Player")) {
			Instantiate(blueStars, this.gameObject.transform.position, Quaternion.identity);
			collider.gameObject.GetComponent<CharacterBehavior>().loseHealth();
			Invoke ("die", 1.2f);
		}

	}

	void die() {
		Destroy (gameObject);
	}
}
