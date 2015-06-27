using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	
	public GameObject tablet;

	// These are set in the Unity Editor

	// Bae
	public GameObject baeZeus;

	// Mana
	public Slider manaSlider;
	public int manaDownAmount;
	public int manaRechargeAmount;
	private int shots;

	public GameObject player;
	public GameObject lightning;
	
	private int tabletLives;
	private int healthLives;

	// Use this for initialization
	void Start () {
	}

	
	void Update() {
	}
	
	void FixedUpdate () {

		manaSlider.value += manaRechargeAmount * Time.fixedDeltaTime * 3;
	}

	void gameStart() {
		tabletLives = 10;
		healthLives = 3;
		shots = 0;
	}

	public GameObject getTablet() {
		return tablet;
	}

	// Catch all for everything that happens when Bae is hurt :(
	public void takeDamage(){

	}

	// Right now activated when TestButton is clicked!!
	public void shootMana(){
		if (manaSlider.value > manaDownAmount) {
			manaSlider.value -= manaDownAmount;
			Debug.Log (++shots);
			throwLightning ();
		} else {
			Debug.Log ("No Mana left");
			shots = 0;
		}
	}

	public void destroyTabletOffScreen(TabletBehavior tb) {
		Destroy (tb.gameObject);
	}

	public void tap() {
		dropTablet ();
	}

	void dropTablet() {
		GameObject tablet = (GameObject) Instantiate(getTablet(), player.transform.position, Quaternion.identity);
		Rigidbody2D rb2d = tablet.GetComponent<Rigidbody2D> ();
		rb2d.velocity = new Vector3(0.0F, -5.0F, 0.0F);
	}

	void throwLightning() {
		GameObject lighting = (GameObject) Instantiate(lightning, player.transform.position, Quaternion.identity);
		Rigidbody2D rb2d = lightning.GetComponent<Rigidbody2D> ();
		rb2d.AddForce(new Vector2(10.0F, 0.0F));
	}
}


