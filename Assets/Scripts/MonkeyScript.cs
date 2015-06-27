using UnityEngine;
using System.Collections;

public class MonkeyScript : MonoBehaviour {

	public float speed;
	public Transform player;

	void FixedUpdate() {
		float z = Mathf.Atan2 ((player.transform.position.y - transform.position.y), (player.transform.position.x - 
			transform.position.x)) *
			Mathf.Rad2Deg - 90;

		transform.eulerAngles = new Vector3 (0, 0, z);

		this.GetComponent<Rigidbody2D>().AddForce(gameObject.transform.up * speed);
	}

	void OnTriggerEnter2D(Collider2D other) {
		// I should probably error check this but fuck it
		Destroy (other.gameObject);
		// TODO: Make you lose.
	}
}
