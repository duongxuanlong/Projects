using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Helicopter : MonoBehaviour {
	//Helicopter profile
	public bool faceRight; //handle flip left or right
	public float healthPoint;
	public int capacity;
	public float moveSpeedMax;
	public float moveSpeedMin;
	private float currentMoveSpeed;
	public float horizontalAccelerometer;
	public float flyUpSpeedMax;
	public float flyDownSpeedMax;
	private float currentFlySpeed;
	public float verticalAccelerometer;
	//end helicopter profile

	//Customize accelerometer
	public float accelerometerLowMultiple;
	public float accelerometerMediumMultiple;
	public float accelerometerHighMultiple;

	public float accelerometerLowRange;
	public float accelerometerMediumRange;
	public float accelerometerHighRange;
	//end customize


	public GameManager gameManager { get; set;}
	private Rigidbody2D rb2d;



	//handle horizontal, vertical movement
	private float accelerometerCurrent;
	private float horizontalSpeedCurrent;
	private float verticalSpeedCurrent;
	//end handle horizontal, vertical movement

	public void helicopterInit()
	{
		rb2d = GetComponent<Rigidbody2D> ();
		if (PlayerPrefs.GetInt ("firstLaunch") == 1) {
			gameManager.debugPanel.GetComponent<DebugPanel> ().LoadSavedProfile ();
		} else {
			gameManager.debugPanel.GetComponent<DebugPanel> ().SaveDefaultValues ();
			PlayerPrefs.SetInt ("firstLaunch", 1);
		}
	}

	public void helicopterUpdate()
	{
		// FPS udpate

	}

	public void helicopterFixedUpdate()
	{
		//fixed update 0.02s each
		HandleFlip ();
		HandleMovement ();
				
	}

	void HandleMovement()
	{
		float xaxis = Mathf.Abs(gameManager.inputManager.acceleration.x);

		//if use in fixed update, use fixedDeltaTime
		//if use in update, use deltaTime
		float accelerometer = 1f;
		//accelerometer = this.m_horizontalAccelerometer;

		//Debug.Log ("Y axis: " + yaxis);
		if (xaxis > accelerometerHighRange)
			accelerometer = accelerometerHighMultiple * horizontalAccelerometer;
		else if (xaxis > accelerometerMediumRange)
			accelerometer = accelerometerMediumMultiple * horizontalAccelerometer;
		else if (xaxis > accelerometerLowRange)
			accelerometer = accelerometerLowMultiple * horizontalAccelerometer;
		

		currentMoveSpeed += accelerometer * Time.fixedDeltaTime;//this.m_AccelerometerCurrent + accelerometer;

		if (currentMoveSpeed >= moveSpeedMax)
		{
			currentMoveSpeed = moveSpeedMax;
		}
		if (gameManager.inputManager.IsTouching()) {
			currentFlySpeed += verticalAccelerometer * Time.fixedDeltaTime;
		} else {
			currentFlySpeed -= verticalAccelerometer * Time.fixedDeltaTime;
		}



		Vector2 velocity = this.rb2d.velocity;
		if (gameManager.inputManager.acceleration.x > accelerometerLowRange) {
			velocity.x = currentMoveSpeed;
		} else if (gameManager.inputManager.acceleration.x < -accelerometerLowRange){
			velocity.x = -currentMoveSpeed;
		}
			
		if (currentFlySpeed >= flyUpSpeedMax) {
			currentFlySpeed = flyUpSpeedMax;
		} else if (currentFlySpeed <= -flyDownSpeedMax) {
			currentFlySpeed = -flyDownSpeedMax;
		}
			


		velocity.y = currentFlySpeed;

		rb2d.velocity = velocity;

		GameObject.Find("DebugCanvas/SpdMove").GetComponent<Text>().text = "velocity.x : " + velocity.x;
		GameObject.Find("DebugCanvas/SpdFly").GetComponent<Text>().text = "velocity.y : " + velocity.y;
	}

	void HandleFlip()
	{

		if (gameManager.inputManager.acceleration.x >= accelerometerLowRange && !this.faceRight) {
			Flip ();
			ResetSpeed ();
		} else if (gameManager.inputManager.acceleration.x < -accelerometerLowRange && this.faceRight) {
			Flip ();
			ResetSpeed ();
		}
	}

	void Flip()
	{
		this.faceRight = !this.faceRight;
		Vector2 localscale = transform.localScale;
		localscale.x *= -1;
		transform.localScale = localscale;
	}

	void ResetSpeed()
	{
		currentMoveSpeed = moveSpeedMin;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Victims") {
			Destroy (other);
		}
	}
}
