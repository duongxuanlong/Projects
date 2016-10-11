using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {

	public Vector3 acceleration { get; set; }

	public bool IsTouching()
	{
		if (Input.GetMouseButton(0)) {
			return true;
		}
		//On device
		if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) {
			return true;
		}
		return false;
	}

	public void UpdateAcceleration()
	{
		this.acceleration = Input.acceleration;
	}


}
