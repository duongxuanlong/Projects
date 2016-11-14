using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public float pixelPerUnit;

	public GameObject helicopter;
	public GameObject camera;
	public GameObject tornado;
	public GameObject debugPanel;
	public InputManager inputManager;
	public float tornadoSpeed;
	public Sprite pauseResumeButton;
	private bool firstTouch;

	void Awake()
	{
		helicopter.GetComponent<Helicopter> ().gameManager = this;
		camera.GetComponent<CameraManager> ().gameManager = this;
		tornado.GetComponent<BehindTornado>().gameManager = this;
		inputManager = new InputManager ();
		firstTouch = false;
	}

	void Start()
	{
		camera.GetComponent<CameraManager> ().CameraInit ();
		helicopter.GetComponent<Helicopter> ().helicopterInit ();
		tornado.GetComponent<BehindTornado> ().TornadoInit ();
	}



	void FixedUpdate()
	{
		if (firstTouch) {
			helicopter.GetComponent<Helicopter> ().helicopterFixedUpdate ();
			tornado.GetComponent<BehindTornado> ().tornadoUpdate ();	
		}

	}

	void Update()
	{
		inputManager.UpdateAcceleration ();
		if (!firstTouch) {
			firstTouch = inputManager.IsTouching ();
		}
		helicopter.GetComponent<Helicopter> ().helicopterUpdate ();
	}


	void LateUpdate()
	{
		camera.GetComponent<CameraManager> ().CameraUpdate ();
	}




}
