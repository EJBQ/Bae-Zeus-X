using UnityEngine;
using System.Collections;

public class BaeZeusScript : CharacterBehavior {

	GameManager gameManager;

	private bool deathFlag;

	// Use this for initialization
	void Start () {
		gameManager = GameObject.Find("gameManager").GetComponent<GameManager>();
	}

	void Update() {

	}

	void FixedUpdate () {
		if(!deathFlag) {
			//moves up and down as he goes
			//moves to the right at a fixed rate
			float rightMovement = 0.0F;
	
			float frequency = 4.0f;  // Speed of sine movement
			float height = .1F; //height of sin movement
			float upMovement = height * Mathf.Sin (Time.time * frequency);
	
	
			Vector3 newPosition = (transform.position + new Vector3 (rightMovement, upMovement, 0.0F));
	
			transform.position = newPosition;
		}else {
			//this.GetComponent<Rigidbody2D>().velocity = new Vector3(0.0F, 10.0F, 0.0F);
		}
	}

	public override void loseHealth() {
		this.health --;
		if (health < 1) {
			deathAnim();
		}
	}

	public override void setHealth(int newHealth) {
		this.health = newHealth;
	}

	public int getHealth() {
		return health;
	}
	
	private void deathAnim() {
		this.gameObject.GetComponent<Rotator> ().rotateSpeed = 10;
		this.deathFlag = true;
		gameManager.endGame ();
	}
}
