using UnityEngine;
using System.Collections;

public class MonkeyScript : CharacterBehavior {
	
	public float speed;
	public GameObject player;
	private bool deathFlag = false;
	public GameObject iPhone;
	Animator anim;
	
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	void Update() {
		var number = Random.Range (1, 81);
		if (number == 77) {
			Toss();
		}
	}
	
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
			if(transform.position.y > 11) Destroy(this.gameObject);
		}
	}
	
	void OnTriggerEnter2D(Collider2D other) {
		// I should probably error check this but fuck it
		if (other.gameObject.CompareTag("Health")) {
			other.gameObject.GetComponent<CharacterBehavior>().loseHealth();
			deathAnim ();
		}
		// TODO: Make you lose.
	}
	
	public override void loseHealth() {
		this.health --;
		deathAnim ();
	}
	
	private void deathAnim() {
		this.gameObject.GetComponent<Rotator> ().rotateSpeed = 15;
		this.deathFlag = true;
	}
	
	public override void setHealth(int newHealth) {
		this.health = newHealth;
	}
	
	void Toss() {
		GameObject iPhone = (GameObject)Instantiate (this.iPhone, this.gameObject.transform.position, Quaternion.identity);
		Rigidbody2D rb2d = iPhone.GetComponent<Rigidbody2D> ();
		rb2d.velocity = new Vector3 (-10.0f, 6.0f, 0.0f);
	}
}
