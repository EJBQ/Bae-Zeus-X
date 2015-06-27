using UnityEngine;
using System.Collections;

public class HouseBehaviour : MonoBehaviour {

	public Texture success1, success2, success3;
	Texture[] texArr;
	public int speed = 3;
	private Rigidbody2D rb;
	private BoxCollider2D boxCollider;
	private bool displayMessage;
	private float displayTime;
	private Texture currentTexture;
	GameManager gameManager;

	// Use this for initialization
	void Start () {
		displayMessage = false;
		displayTime = 1.0f;
		gameManager = GameObject.Find("gameManager").GetComponent<GameManager>();
		rb = GetComponent<Rigidbody2D> ();
		texArr = new[] {success1, success2, success3};
	}

	void Update() {
		transform.position = transform.position + speed * new Vector3 (-1 * Time.deltaTime, 0f, 0f);
	}

	IEnumerator OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.CompareTag ("Tablet")) {
			gameManager.tabletsDelivered++;
			Debug.Log (gameManager.tabletsDelivered);
			displayMessage = true;
			currentTexture = texArr[Random.Range (0, texArr.Length)];
			Destroy (other.gameObject);
			yield return new WaitForSeconds(displayTime);
			displayMessage = false;
		}
	}

	void OnGUI() {
		if (displayMessage) {
			Vector3 pos = transform.position;
			GUI.DrawTexture(new Rect(pos.x , pos.y - Screen.height/20, 60, 60), currentTexture, ScaleMode.ScaleToFit, true, 0f);
		}
	}

}
