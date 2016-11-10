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
	public Sprite pauseResumeButton;
	private bool firstTouch;

	void Awake()
	{
        Debug.Log("GameManager Awake!!!");
		helicopter.GetComponent<Helicopter> ().gameManager = this;
		camera.GetComponent<CameraManager> ().gameManager = this;
		tornado.GetComponent<BehindTornado>().gameManager = this;
		inputManager = new InputManager ();
		firstTouch = false;
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
		if (firstTouch) {
			helicopter.GetComponent<Helicopter> ().helicopterUpdate ();
			tornado.GetComponent<BehindTornado> ().tornadoUpdate ();	
		}

	}

	void Update()
	{
		if (!firstTouch) {
			firstTouch = inputManager.IsTouching ();
		}
	}


	void LateUpdate()
	{
		camera.GetComponent<CameraManager> ().CameraUpdate ();
	}




	public void Restart()
	{
		SaveDebugValues();
		Application.LoadLevel ("AP");
	}
	public void PauseResume()
	{
		GameObject debugPanel = GameObject.Find ("DebugCanvas/DebugPanel").gameObject;
		GameObject pauseResumeGameObject = GameObject.Find ("DebugCanvas/PauseResume").gameObject;
		Sprite tmpPauseResumeSprite = pauseResumeGameObject.GetComponent<Image> ().sprite;
		pauseResumeGameObject.GetComponent<Image> ().sprite = pauseResumeButton;
		pauseResumeButton = tmpPauseResumeSprite;
		if (debugPanel.GetComponent<RectTransform> ().localScale == Vector3.zero) {
			debugPanel.GetComponent<RectTransform> ().localScale = Vector3.one;

			Time.timeScale = 0;
		} else {
			debugPanel.GetComponent<RectTransform> ().localScale = Vector3.zero;
			Time.timeScale = 1;
		}

	}

	void SaveDebugValues()
	{
		float value = float.Parse(GameObject.Find("SpdMoveMaxIF").GetComponent<InputField>().text);
		PlayerPrefs.SetFloat("moveSpeedMax", value);
		value = float.Parse(GameObject.Find("SpdMoveMinIF").GetComponent<InputField>().text);
		PlayerPrefs.SetFloat("moveSpeedMin", value);
		value = float.Parse(GameObject.Find("FlyUpSpeedMaxIF").GetComponent<InputField>().text);
		PlayerPrefs.SetFloat("flyUpSpeedMax", value);
		value = float.Parse(GameObject.Find("FlyUpSpeedMinIF").GetComponent<InputField>().text);
		PlayerPrefs.SetFloat("flyDownSpeedMax", value);

		value = float.Parse(GameObject.Find("horizontalAccelerometerIF").GetComponent<InputField>().text);
		PlayerPrefs.SetFloat("horizontalAccelerometer", value);
		value = float.Parse(GameObject.Find("verticalAccelerometerIF").GetComponent<InputField>().text);
		PlayerPrefs.SetFloat("verticalAccelerometer", value);
		value = float.Parse(GameObject.Find("AccelerationRangeMinIF").GetComponent<InputField>().text);
		PlayerPrefs.SetFloat("accelerationRangeMin", value);

	}
}
