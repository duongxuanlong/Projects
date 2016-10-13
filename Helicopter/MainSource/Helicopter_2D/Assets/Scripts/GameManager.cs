using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public float pixelPerUnit;

	public GameObject helicopter;
	public GameObject camera;
	public InputManager inputManager;

	void Awake()
	{
		DontDestroyOnLoad (gameObject);
		helicopter.GetComponent<Helicopter> ().gameManager = this;
		camera.GetComponent<CameraManager> ().gameManager = this;
		inputManager = new InputManager ();
	}

	void Start()
	{
		camera.GetComponent<CameraManager> ().CameraInit ();
		helicopter.GetComponent<Helicopter> ().helicopterInit ();
	}

	void FixedUpdate()
	{
		helicopter.GetComponent<Helicopter> ().helicopterUpdate ();
	}

	void Update()
	{
		
	}


	void LateUpdate()
	{
		camera.GetComponent<CameraManager> ().CameraUpdate ();
	}
}
