using UnityEngine;
using System.Collections;

public class CameraManager : MonoBehaviour {


	public float m_cameraMoveSpeed;
	private float cameraMoveSpeed;
	public GameManager gameManager { get; set; }


	// Use this for initialization
	public void CameraInit () {
		cameraMoveSpeed = m_cameraMoveSpeed / gameManager.pixelPerUnit;
	}
	
	// Update is called once per frame
	public void CameraUpdate() {
		transform.position = transform.position + Vector3.right * cameraMoveSpeed * Time.deltaTime;

	}
}
