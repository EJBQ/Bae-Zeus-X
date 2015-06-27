using UnityEngine;
using System.Collections;

public class GestureRecognizer : MonoBehaviour {
	
	public float minSwipeDistY;
	public float minSwipeDistX;
	private Vector2 startPos;
	GameManager gameManager;
	
	// Use this for initialization
	void Start () {
		gameManager = GameObject.Find("gameManager").GetComponent<GameManager>();
	}

	void Update()
	{
		//#if UNITY_ANDROID
		if (Input.touchCount > 0) 
		{
			Touch touch = Input.touches[0];

			switch (touch.phase) 
			{
			case TouchPhase.Began:
				startPos = touch.position;
				break;

			case TouchPhase.Ended:
				
				float swipeDistVertical = (new Vector3(0, touch.position.y, 0) - new Vector3(0, startPos.y, 0)).magnitude;
				float swipeDistHorizontal = (new Vector3(touch.position.x,0, 0) - new Vector3(startPos.x, 0, 0)).magnitude;

				if(swipeDistHorizontal > swipeDistVertical) {
					if (swipeDistHorizontal > minSwipeDistX) 
					{
						float swipeValue = Mathf.Sign(touch.position.x - startPos.x);
							
						if (swipeValue > 0) {//right swipe
						gameManager.shootMana();
						} else if (swipeValue < 0) { //left swipe
								//Shrink ();
						}
					} else {
						gameManager.tap();
					}
				} else {
					if (swipeDistVertical > minSwipeDistY) 
						{
						float swipeValue = Mathf.Sign(touch.position.y - startPos.y);
	
						if (swipeValue > 0) {//right swipe
							//Jump ();
						} else if (swipeValue < 0) { //left swipe
							//Shrink ();
						}
					} else {
						gameManager.tap();
					}
				}
				break;
			}
		}
	}
}