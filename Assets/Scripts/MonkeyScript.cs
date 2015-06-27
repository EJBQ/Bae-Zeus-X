using UnityEngine;
using System.Collections;

public class MonkeyScript : CharacterBehavior {

	public float speed;
	public GameObject player;

	private bool deathFlag = false;

	void FixedUpdate() {
		if (player != null) {
			float z = Mathf.Atan2 ((player.transform.position.y - transform.position.y), (player.transform.position.x - 
				transform.position.x)) *
				Mathf.Rad2Deg - 90;

			transform.eulerAngles = new Vector3 (0, 0, z - 90);

			this.GetComponent<Rigidbody2D> ().AddForce (-1 * gameObject.transform.right * speed);
		}
		if (deathFlag) {
			this.GetComponent<Rigidbody2D>().velocity = new Vector3(0.0F, 10.0F, 0.0F);
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		// I should probably error check this but fuck it
		if (other.gameObject == player) {
			Destroy (other.gameObject);
			deathAnim ();
		}
		// TODO: Make you lose.
	}

	public override void loseHealth() {
		this.health --;
		deathAnim ();
	}

	private void deathAnim() {
		this.gameObject.GetComponent<Rotator> ().rotateSpeed = 10;
		this.deathFlag = true;
	}

	public override void setHealth(int newHealth) {
		this.health = newHealth;
	}
}
