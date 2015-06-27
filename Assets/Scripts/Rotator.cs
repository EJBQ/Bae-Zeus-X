
using System;
using UnityEngine;
public class Rotator : MonoBehaviour
{
	public float rotateSpeed;

	public Rotator ()
	{

	}

	void FixedUpdate() {
		transform.Rotate (Vector3.back * rotateSpeed);
	}
}
