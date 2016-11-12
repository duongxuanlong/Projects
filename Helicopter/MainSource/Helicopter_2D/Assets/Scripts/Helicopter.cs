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
	public float horizontalAccelerometer;
	public float flyUpSpeedMax;
	public float flyDownSpeedMax;
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
        Debug.Log("helicopterInit");

		rb2d = GetComponent<Rigidbody2D> ();

		//this.m_healthPoint = 1;
		//this.m_moveSpeedMax = 2f;//67f;
		//this.m_moveSpeedMin = 0.5f;//20f;
		//this.m_flyUpSpeedMax = 2f;//250f;//150f;
		//this.m_SpeedUpMin = 0.5f;//150f;//250f;
		//this.m_AccelerometerLow = 0.5f;//1000f;
		//this.m_AccelerometerMedium = 1f;//2000f;
		//this.m_AccelerometerHigh = 2f;//3000f;
		//this.m_AccelerometerLowRange = 0.2f;//3f;
		//this.m_AccelerometerMedium = 0.5f;//6f;
		//this.m_AccelerometerHighRange = 0.5001f;//6.001f;

		//this.m_horizontalAccelerometer = 10f;

		//this.m_capacity = 3;

		this.horizontalSpeedCurrent = this.moveSpeedMin;

//		this.m_SpeedToClinic = 0.3f;
//		this.RangeLeft = 0.3f;
//		this.RangeRight = -0.3f


	}

	public void helicopterUpdate()
	{

		gameManager.inputManager.UpdateAcceleration ();
	}

	public void helicopterFixedUpdate()
	{
		

		HandleFlip ();
		HandleMovement ();
				
	}


	void HandleMovement()
	{
		float xaxis = Mathf.Abs(gameManager.inputManager.acceleration.x);

		//if use in fixed update, use fixedDeltaTime
		//if use in update, use deltaTime
		float accelerometer = 0f;

		//Debug.Log ("Y axis: " + yaxis);


		
		if (xaxis > accelerometerHighRange) {
			accelerometer = this.accelerometerHighMultiple;
		} else if (xaxis > accelerometerMediumRange) {
			accelerometer = this.accelerometerMediumMultiple;
		} else if (xaxis > accelerometerLowRange) {
			accelerometer = this.accelerometerLowMultiple;
		} 

		accelerometer *= Mathf.Sign (gameManager.inputManager.acceleration.x) * horizontalAccelerometer;
		this.horizontalSpeedCurrent += accelerometer * Time.fixedDeltaTime;//this.accelerometerCurrent + accelerometer;
		if (this.horizontalSpeedCurrent >= this.moveSpeedMax) {
			this.horizontalSpeedCurrent = this.moveSpeedMax;
		}

		this.verticalSpeedCurrent += verticalAccelerometer;//this.accelerometerCurrent + accelerometer;
        if (this.verticalSpeedCurrent >= this.flyUpSpeedMax)
            this.verticalSpeedCurrent = this.flyUpSpeedMax;
//		if (!gameManager.inputManager.IsTouching ())
//			this.verticalSpeedCurrent = -this.verticalSpeedCurrent;

		this.accelerometerCurrent = accelerometer;

		Vector2 velocity = this.rb2d.velocity;
		velocity.x = this.horizontalSpeedCurrent;

		velocity.y = this.verticalSpeedCurrent;
			if (!gameManager.inputManager.IsTouching ())
				velocity.y = (0 - this.verticalSpeedCurrent) / 2;
		this.rb2d.velocity = velocity;

		GameObject.Find("DebugCanvas/SpdMove").GetComponent<Text>().text = "velocity.x : " + velocity.x;
		GameObject.Find("DebugCanvas/SpdFly").GetComponent<Text>().text = "velocity.y : " + velocity.y;
	}

	void HandleFlip()
	{
		if (rb2d.velocity.x >= 0 && !this.faceRight) {
			Flip ();
		} else if (rb2d.velocity.x < 0 && this.faceRight) {
			Flip ();
		}
	}

	void Flip()
	{
		this.faceRight = !this.faceRight;
		Vector2 localscale = transform.localScale;
		localscale.x *= -1;
		transform.localScale = localscale;
	}



    public void loadDebugValue()
    {
        Debug.Log("loadDebugValue");
        moveSpeedMax = PlayerPrefs.GetFloat("moveSpeedMax") / gameManager.pixelPerUnit;

        moveSpeedMin = PlayerPrefs.GetFloat("moveSpeedMin") / gameManager.pixelPerUnit;

        flyUpSpeedMax = PlayerPrefs.GetFloat("flyUpSpeedMax") / gameManager.pixelPerUnit;

        flyDownSpeedMax = PlayerPrefs.GetFloat("flyDownSpeedMax") / gameManager.pixelPerUnit;



    }

    public void loadDebugPanel()
    {
        Debug.Log("setDefaultDebugValue");
        GameObject.Find("SpdMoveMaxIF").GetComponent<InputField>().text =  PlayerPrefs.GetFloat("moveSpeedMax").ToString();



    }
    public void setDefaultDebugValue()
    {
        Debug.Log("setDefaultDebugValue");
        PlayerPrefs.SetFloat("moveSpeedMax",200.0f);



    }

}
