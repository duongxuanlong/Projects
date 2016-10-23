using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public float pixelPerUnit;

	public GameObject helicopter;
	public GameObject camera;
	public GameObject tornado;
	public InputManager inputManager;
	public float tornadoSpeed;

    public void EnableDebugPanel()
    {
        Canvas debugPanel = GameObject.Find("DebugCanvas").GetComponent<Canvas>();
        debugPanel.enabled = !debugPanel.enabled;
    }
	void Awake()
	{
        Debug.Log("GameManager Awake!!!");
		helicopter.GetComponent<Helicopter> ().gameManager = this;
		camera.GetComponent<CameraManager> ().gameManager = this;
		//tornado.GetComponent<Tornado> ().gameManager = this;
		tornado.GetComponent<BehindTornado>().gameManager = this;
		inputManager = new InputManager ();
	}

	void Start()
	{
        Debug.Log("GameManager Start!!!");
		camera.GetComponent<CameraManager> ().CameraInit ();
		helicopter.GetComponent<Helicopter> ().helicopterInit ();
		tornado.GetComponent<BehindTornado> ().TornadoInit ();
	}

	void FixedUpdate()
	{
		helicopter.GetComponent<Helicopter> ().helicopterUpdate ();
		tornado.GetComponent<BehindTornado> ().tornadoUpdate ();
	}

	void Update()
	{
		
	}


	void LateUpdate()
	{
		camera.GetComponent<CameraManager> ().CameraUpdate ();
	}

}
