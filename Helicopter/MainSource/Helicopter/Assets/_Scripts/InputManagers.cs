using UnityEngine;
using System.Collections;

public class InputManagers : MonoBehaviour {
	//Implement low pass filter
	float m_AccelerometerUpdateInterval;
	float m_LowPassKernalWidthSeconds;
	float m_LowPassFilterFactor;

	public Vector3 m_LowPassValue;
//	public Vector2 m_TouchPoint;
//	public Vector3 m_Gravity;

	public InputManagers()
	{
		this.m_AccelerometerUpdateInterval = (float)(1.0 / 60.0);
		this.m_LowPassKernalWidthSeconds = 1.0f;
		this.m_LowPassFilterFactor = this.m_AccelerometerUpdateInterval / this.m_LowPassKernalWidthSeconds;

		//this.m_LowPassValue = Vec3 (0.0, 0.0, 0.0);
	}

	public void Start()
	{
		this.m_LowPassValue = Input.acceleration;
	}

	public void UpdateGravity()
	{
		#if UNITY_ANDROID
		this.m_LowPassValue = Vector3.Lerp (this.m_LowPassValue, Input.acceleration, this.m_LowPassFilterFactor);
		#endif
	}

	public bool IsTouching()
	{
		#if UNITY_ANDROID
		if (Input.touchCount > 0)
			return true;
		return false;
		#else
		return false;
		#endif
	}
}
