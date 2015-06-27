using UnityEngine;
using System.Collections;

public class iPhoneBehaviour : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	void FixedUpdate() {
		if (this.gameObject.transform.position.y < -11) {
			destroyiPhoneOffScreen();
		}
	}

	public void destroyiPhoneOffScreen() {
		Destroy (this.gameObject);
	}
}
