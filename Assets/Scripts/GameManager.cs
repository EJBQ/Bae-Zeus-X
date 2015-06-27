using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	
	public GameObject tablet;

	// These are set in the Unity Editor

	// Mana
	public Slider manaSlider;
	public int manaDownAmount;
	public int manaRechargeAmount;
	private int shots;
	public int tabletsDelivered;

	public GameObject player;
	public GameObject lightning;
	public GameObject monkey;
	public GameObject house;
	public GameObject mainCamera;
	
	private int tabletLives;
	private int healthLives;

	private float monkeySpawnRate;
	private float houseSpawnRate;
	private long monkeySpawnTime;
	private long houseSpawnTime;

	// Use this for initialization
	void Start () {
		tabletsDelivered = 0;
		monkeySpawnTime = 400;
		houseSpawnTime = 200;
		monkeySpawnRate = 1;
		houseSpawnRate = 1;
	}

	
	void Update() {
	}
	
	void FixedUpdate () {

		manaSlider.value += manaRechargeAmount * Time.fixedDeltaTime * 3;
		monkeySpawnRate *= .9999999F;
		houseSpawnRate *= 1.0000001F;

		monkeySpawnTime --;
		if (monkeySpawnTime <= 0) {
			spawnMonkey ();
			monkeySpawnTime = (long) (Random.value * monkeySpawnRate * 800F);
		}

		houseSpawnTime --;
		if (houseSpawnTime <= 0) {
			spawnHouse ();
			houseSpawnTime = (long) (Random.value * houseSpawnRate * 400F);
		}

	}

	void gameStart() {
		tabletLives = 10;
		healthLives = 3;
		shots = 0;
		monkeySpawnRate = 1;
		houseSpawnRate = 1;
		monkeySpawnTime = 1000;
		houseSpawnTime = 500;
		tabletsDelivered = 0;
	}

	public GameObject getTablet() {
		return tablet;
	}

	// Catch all for everything that happens when Bae is hurt :(
	public void takeDamage(){

	}

	void OnGUI() {
		GUI.Label(new Rect(10,10,40,40), "Score: " + tabletsDelivered); 
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
		GameObject lighting = (GameObject) Instantiate(this.lightning, player.transform.position, Quaternion.identity);
		//Rigidbody2D rb2d = lightning.GetComponent<Rigidbody2D> ();
		//rb2d.velocity = new Vector3(0.0F, -5.0F, 0.0F);
	}

	void spawnMonkey() {
		GameObject monkey = (GameObject) Instantiate(this.monkey, mainCamera.transform.position + new Vector3 (15.0F, 4.0F, 10.0F), Quaternion.identity);
	
	}

	void spawnHouse() {
		GameObject house = (GameObject) Instantiate(this.house, mainCamera.transform.position + new Vector3 (15.0F, -5.0F, 10.0F), Quaternion.identity);

	}
}


