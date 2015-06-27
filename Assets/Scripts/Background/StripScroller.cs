using UnityEngine;
using System.Collections;

public class StripScroller : MonoBehaviour {
	
	public float scrollSpeed;
	public float tileSizeX;
	
	private Vector2 savedOffset;
	private Vector3 startPosition;
	
	void Start ()
	{
		startPosition = transform.position;
		savedOffset = GetComponent<Renderer>().sharedMaterial.GetTextureOffset ("_MainTex");
	}
	
	void Update ()
	{
		float x = Mathf.Repeat (Time.time * scrollSpeed, tileSizeX * 4);
		x = x / tileSizeX;
		x = Mathf.Floor (x);
		x = x / 4;
		Vector2 offset = new Vector2 (x, savedOffset.y);
		GetComponent<Renderer>().sharedMaterial.SetTextureOffset ("_MainTex", offset);
		float newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileSizeX);
		transform.position = startPosition + Vector3.left * newPosition;
	}
	
	void OnDisable () {
		GetComponent<Renderer>().sharedMaterial.SetTextureOffset ("_MainTex", savedOffset);
	}
}