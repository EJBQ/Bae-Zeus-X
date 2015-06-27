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

	// Use this for initialization
	void Start () {
		shots = 0;
	}

	
	void Update() {
	}
	
	void FixedUpdate () {

		manaSlider.value += manaRechargeAmount * Time.fixedDeltaTime * 3;
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
			Debug.Log(++shots);
		} else {
			Debug.Log ("No Mana left");
			shots = 0;
		}

	}
}


