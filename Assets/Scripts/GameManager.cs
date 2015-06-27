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
	public GameObject house2;
	public GameObject house3;
	public GameObject house4;
	public GameObject mainCamera;
	
	private int tabletLives;

	private float monkeySpawnRate;
	private float houseSpawnRate;
	private long monkeySpawnTime;
	private long houseSpawnTime;

	private bool gameRunning = false;

	// Use this for initialization
	void Start () {

		// GameCircle
		AGSClient.ServiceReadyEvent += serviceReadyHandler;
		AGSClient.ServiceNotReadyEvent += serviceNotReadyHandler;
		bool usesLeaderboards = true;
		bool usesAchievements = true;
		bool usesWhispersync = false;
		
		AGSClient.Init (usesLeaderboards, usesAchievements, usesWhispersync);




			
			AGSAchievementsClient.UpdateAchievementSucceededEvent += updateAchievementSucceeded;
			AGSAchievementsClient.UpdateAchievementFailedEvent += updateAchievementFailed;
		Debug.Log("GG");
			AGSAchievementsClient.UpdateAchievementProgress("enter_game_achievment",50.0f);


	}

	
	void Update() {
	}
	
	void FixedUpdate () {

		if (!gameRunning)
			return;

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
		shots = 0;

		tabletsDelivered = 0;
		monkeySpawnTime = 400;
		houseSpawnTime = 200;
		monkeySpawnRate = 1;
		houseSpawnRate = 1;

		gameRunning = true;
	}

	public GameObject getTablet() {
		return tablet;
	}

	// Catch all for everything that happens when Bae is hurt :(
	public void takeDamage(){

	}

	void OnGUI() {
		GUI.Label(new Rect(Screen.width /16, Screen.height/16, Screen.width/16, Screen.height/16), "Score: " + tabletsDelivered); 
		if (!gameRunning) {
			if(GUI.Button(new Rect(Screen.width /2, Screen.height/2, Screen.width/8, Screen.height/8), "Start")) {
				gameStart();
			}
		}
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
		tabletLives --;
		if (tabletLives == 0) {
			endGame();
		}
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
		int houseChoose = (int)Random.Range (1, 4);
		
		switch(houseChoose) {
		case 1 :
			GameObject house = (GameObject) Instantiate(this.house, mainCamera.transform.position + new Vector3 (20.0F, -5.0F, 10.0F), Quaternion.identity);
			break;
		case 2:
			GameObject house2 = (GameObject) Instantiate(this.house2, mainCamera.transform.position + new Vector3 (20.0F, -5.0F, 10.0F), Quaternion.identity);
			break;
		case 3:
			GameObject house3 = (GameObject) Instantiate(this.house3, mainCamera.transform.position + new Vector3 (20.0F, -5.0F, 10.0F), Quaternion.identity);
			break;
		case 4:
			GameObject house4 = (GameObject) Instantiate(this.house4, mainCamera.transform.position + new Vector3 (20.0F, -5.0F, 10.0F), Quaternion.identity);
			break;
		}
	}

	//Game Circle
	private void serviceNotReadyHandler (string error)    {
		Debug.Log("Service is not ready");
	}

	//Game Circle
	private void serviceReadyHandler ()    {
		Debug.Log("Service is ready");
	}

	private void updateAchievementSucceeded(string achievementId) {
		Debug.Log ("Ya Achievement!!!");
	}
	
	private void updateAchievementFailed(string achievementId, string error) {
		Debug.Log ("Sad no achievement");
	}
	
	public void endGame() {
		gameRunning = false;
	}
}


