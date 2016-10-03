using UnityEngine;
using System.Collections;

public class Helicopter : MoveObjects {
	// Helicopter profile
	public uint m_HealthPoint;

	public uint m_MoveSpeedMax;
	public uint m_MoveSpeedMin;
	public int m_AccelerometerSpeed;
	public int m_CurrentSpeed;

	public int m_FlyUpSpeed;
	public int m_FlyDownSpeed;

	public float m_SpeedToClinic;

	public int m_Capacity;
	// end profile

	// Use this for initialization
	void Start () {
	
	}

	void FixedUpdate()
	{
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
