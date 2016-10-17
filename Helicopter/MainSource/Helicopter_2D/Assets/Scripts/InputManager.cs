using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {

	public Vector3 acceleration { get; set; }

	//Implement low pass filter
	float m_AccelerometerUpdateInterval;
	float m_LowPassKernalWidthSeconds;
	float m_LowPassFilterFactor;

	public InputManager()
	{
		this.m_AccelerometerUpdateInterval = 1f / 60f;
		this.m_LowPassKernalWidthSeconds = 1f;
		this.m_LowPassFilterFactor = this.m_AccelerometerUpdateInterval / this.m_LowPassKernalWidthSeconds;

		this.acceleration = Vector3.zero;
	}

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
		//this.acceleration = Vector3.Lerp(this.acceleration, Input.acceleration, this.m_LowPassFilterFactor);

	}


}
