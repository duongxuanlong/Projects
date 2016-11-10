using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Helicopter : MonoBehaviour {

	//Helicopter profile
	public float m_healthPoint;
	public float m_SpeedMoveMax;
	public float m_SpeedMoveMin;
	public float m_horizontalAccelerometer;

	//Customize accelerometer
	public float m_AccelerometerLow;
	public float m_AccelerometerMedium;
	public float m_AccelerometerHigh;

	public float m_AccelerometerLowRange;
	public float m_AccelerometerMediumRange;
	public float m_AccelerometerHighRange;
	//end customize

	public float m_SpeedUpMax;
	public float m_SpeedUpMin;
	public float m_SpeedDownMax;
	public float m_verticalAccelerometer;
	public int m_capacity;
	//end helicopter profile

	public float m_accelerationRangeMin;

	float healthPoint;
	float moveSpeedMax;
	float moveSpeedMin;
	float horizontalAccelerometer;
	float flyUpSpeedMax;
	float flyDownSpeedMax;
	float verticalAccelerometer;
	int capacity;

	float accelerationRangeMin;


	public GameManager gameManager { get; set;}
	private bool firstTouch;
	private Rigidbody2D rb2d;

	private bool m_FaceRight; //handle flip left or right

	//handle horizontal, vertical movement
	private float m_AccelerometerCurrent;
	private float m_SpeedMoveCurrent;
	private float m_SpeedUpCurrent;
	//end handle horizontal, vertical movement

	public void helicopterInit()
	{
        Debug.Log("helicopterInit");
        
		firstTouch = false;
		rb2d = GetComponent<Rigidbody2D> ();

		this.m_healthPoint = 1;
		this.m_SpeedMoveMax = 2f;//67f;
		this.m_SpeedMoveMin = 0.5f;//20f;
		this.m_SpeedUpMax = 2f;//250f;//150f;
		this.m_SpeedUpMin = 0.5f;//150f;//250f;
		this.m_AccelerometerLow = 0.5f;//1000f;
		this.m_AccelerometerMedium = 1f;//2000f;
		this.m_AccelerometerHigh = 2f;//3000f;
		this.m_AccelerometerLowRange = 0.2f;//3f;
		this.m_AccelerometerMedium = 0.5f;//6f;
		this.m_AccelerometerHighRange = 0.5001f;//6.001f;

		this.m_horizontalAccelerometer = 10f;

		this.m_capacity = 3;

		this.m_AccelerometerCurrent = 0f;
		this.m_FaceRight = true;
		this.m_SpeedMoveCurrent = this.m_SpeedMoveMin;
		this.m_SpeedUpCurrent = this.m_SpeedUpMin;
//		this.m_SpeedToClinic = 0.3f;
//		this.RangeLeft = 0.3f;
//		this.RangeRight = -0.3f
			
		healthPoint = m_healthPoint;
		moveSpeedMax = m_SpeedMoveMax / gameManager.pixelPerUnit;
		moveSpeedMin = moveSpeedMin / gameManager.pixelPerUnit;
		horizontalAccelerometer = m_horizontalAccelerometer / gameManager.pixelPerUnit;
		flyUpSpeedMax = m_SpeedUpMax / gameManager.pixelPerUnit;
		flyDownSpeedMax = m_SpeedDownMax / gameManager.pixelPerUnit;
		verticalAccelerometer = m_verticalAccelerometer / gameManager.pixelPerUnit;
		capacity = m_capacity;
		accelerationRangeMin = m_accelerationRangeMin / gameManager.pixelPerUnit;

        if (!PlayerPrefs.HasKey("firstTime"))
        {
            setDefaultDebugValue();
            PlayerPrefs.SetInt("firstTime", 1);
        }
        loadDebugPanel();
        loadDebugValue();
	}

	public void helicopterUpdate()
	{
		gameManager.inputManager.UpdateAcceleration ();

		HandleFlip ();

		HandleMovement ();

//		if (!firstTouch && gameManager.inputManager.IsTouching()) {
//			firstTouch = true;
//		}
//
//		if (firstTouch) {
//			HandleMovementX ();
//			HandleMovementY ();	
//		}
		
	}

	void HandleMovementX()
	{
		float x = gameManager.inputManager.acceleration.x;
		Vector2 horizontalForce = Vector2.zero;
		//GetKey for editor testing
		if (x >= accelerationRangeMin || Input.GetKey(KeyCode.S)) {
			horizontalForce = Vector2.right * horizontalAccelerometer;
		}
		//GetKey for editor testing
		if (x <= - accelerationRangeMin || Input.GetKey(KeyCode.A)) {
			horizontalForce = Vector2.left * horizontalAccelerometer;

		}

		if (rb2d.velocity.x * Mathf.Sign(horizontalForce.x) <= moveSpeedMax) {
			rb2d.AddForce (horizontalForce, ForceMode2D.Force);
		}
	}

	void HandleMovementY()
	{
		Vector2 verticalForce = Vector2.zero;
		if (gameManager.inputManager.IsTouching()) {
			verticalForce = new Vector2 (0, verticalAccelerometer);
			if (rb2d.velocity.y < flyUpSpeedMax) {
				rb2d.AddForce (verticalForce, ForceMode2D.Force);
			}
		} else {
			verticalForce = new Vector2 (0, -verticalAccelerometer);
			if (rb2d.velocity.y > - flyDownSpeedMax) {
				rb2d.AddForce (verticalForce, ForceMode2D.Force);
			}
		}

	}

	void HandleMovement()
	{
		float xaxis = Mathf.Abs(gameManager.inputManager.acceleration.x);

		//if use in fixed update, use fixedDeltaTime
		//if use in update, use deltaTime
		float accelerometer = 1f;
		//accelerometer = this.m_horizontalAccelerometer;

		//Debug.Log ("Y axis: " + yaxis);
		if (xaxis <= this.m_AccelerometerLowRange)
			accelerometer = this.m_AccelerometerLow;
		else if (xaxis <= this.m_AccelerometerMediumRange)
			accelerometer = this.m_AccelerometerMedium;
		else
			accelerometer = this.m_AccelerometerHigh;
		accelerometer *= Time.fixedDeltaTime;

		this.m_SpeedMoveCurrent += accelerometer;//this.m_AccelerometerCurrent + accelerometer;
        if (this.m_SpeedMoveCurrent >= this.moveSpeedMax)
        {
            this.m_SpeedMoveCurrent = this.moveSpeedMax;
		}
//		if (gameManager.inputManager.acceleration.x < 0)
//			this.m_SpeedMoveCurrent = -this.m_SpeedMoveCurrent;

		this.m_SpeedUpCurrent += accelerometer;//this.m_AccelerometerCurrent + accelerometer;
        if (this.m_SpeedUpCurrent >= this.flyUpSpeedMax)
            this.m_SpeedUpCurrent = this.flyUpSpeedMax;
//		if (!gameManager.inputManager.IsTouching ())
//			this.m_SpeedUpCurrent = -this.m_SpeedUpCurrent;

		this.m_AccelerometerCurrent = accelerometer;

		Vector2 velocity = this.rb2d.velocity;
		velocity.x = this.m_SpeedMoveCurrent;
		if (gameManager.inputManager.acceleration.x < 0)
			velocity.x = 0 - this.m_SpeedMoveCurrent;
		velocity.y = this.m_SpeedUpCurrent;
		if (!gameManager.inputManager.IsTouching ())
			velocity.y = (0 - this.m_SpeedUpCurrent) / 2;
		this.rb2d.velocity = velocity;

		GameObject.Find("DebugCanvas/SpdMove").GetComponent<Text>().text = "velocity.x : " + velocity.x;
		GameObject.Find("DebugCanvas/SpdFly").GetComponent<Text>().text = "velocity.y : " + velocity.y;
	}

	void HandleFlip()
	{
//		if (gameManager.inputManager.acceleration.y >= 0 && !this.m_FaceRight)
//			Flip ();
//		else if (gameManager.inputManager.acceleration.y < 0 && this.m_FaceRight)
//			Flip ();
		if (gameManager.inputManager.acceleration.x >= 0 && !this.m_FaceRight) {
			Flip ();
			ResetSpeed ();
		} else if (gameManager.inputManager.acceleration.x < 0 && this.m_FaceRight) {
			Flip ();
			ResetSpeed ();
		}
	}

	void Flip()
	{
		this.m_FaceRight = !this.m_FaceRight;
		Vector2 localscale = transform.localScale;
		localscale.x *= -1;
		transform.localScale = localscale;
	}

	void ResetSpeed()
	{
		this.m_SpeedMoveCurrent = this.m_SpeedMoveMin;
		this.m_SpeedUpCurrent = this.m_SpeedUpMin;
	}

    public void loadDebugValue()
    {
        Debug.Log("loadDebugValue");
        moveSpeedMax = PlayerPrefs.GetFloat("moveSpeedMax") / gameManager.pixelPerUnit;

        moveSpeedMin = PlayerPrefs.GetFloat("moveSpeedMin") / gameManager.pixelPerUnit;

        flyUpSpeedMax = PlayerPrefs.GetFloat("flyUpSpeedMax") / gameManager.pixelPerUnit;

        flyDownSpeedMax = PlayerPrefs.GetFloat("flyDownSpeedMax") / gameManager.pixelPerUnit;

        horizontalAccelerometer = PlayerPrefs.GetFloat("horizontalAccelerometer") / gameManager.pixelPerUnit;
        verticalAccelerometer = PlayerPrefs.GetFloat("verticalAccelerometer") / gameManager.pixelPerUnit;
        accelerationRangeMin = PlayerPrefs.GetFloat("accelerationRangeMin") / gameManager.pixelPerUnit;
        Debug.Log("moveSpeedMax " + moveSpeedMax);
        Debug.Log("moveSpeedMin " + moveSpeedMin);
        Debug.Log("flyUpSpeedMax " + flyUpSpeedMax);
        Debug.Log("flyDownSpeedMax " + flyDownSpeedMax);
        Debug.Log("horizontalAccelerometer " + horizontalAccelerometer);
        Debug.Log("verticalAccelerometer " + verticalAccelerometer);
        Debug.Log("accelerationRangeMin " + accelerationRangeMin);
    }

    public void loadDebugPanel()
    {
        Debug.Log("setDefaultDebugValue");
        GameObject.Find("SpdMoveMaxIF").GetComponent<InputField>().text =  PlayerPrefs.GetFloat("moveSpeedMax").ToString();
        GameObject.Find("SpdMoveMinIF").GetComponent<InputField>().text = PlayerPrefs.GetFloat("moveSpeedMin").ToString();
        GameObject.Find("FlyUpSpeedMaxIF").GetComponent<InputField>().text = PlayerPrefs.GetFloat("flyUpSpeedMax").ToString();
        GameObject.Find("FlyUpSpeedMinIF").GetComponent<InputField>().text = PlayerPrefs.GetFloat("flyDownSpeedMax").ToString();
        GameObject.Find("horizontalAccelerometerIF").GetComponent<InputField>().text = PlayerPrefs.GetFloat("horizontalAccelerometer").ToString();
        GameObject.Find("verticalAccelerometerIF").GetComponent<InputField>().text = PlayerPrefs.GetFloat("verticalAccelerometer").ToString();
        GameObject.Find("AccelerationRangeMinIF").GetComponent<InputField>().text = PlayerPrefs.GetFloat("accelerationRangeMin").ToString();

    }
    public void setDefaultDebugValue()
    {
        Debug.Log("setDefaultDebugValue");
        PlayerPrefs.SetFloat("moveSpeedMax",200.0f);
        PlayerPrefs.SetFloat("moveSpeedMin", 0.5f);
        PlayerPrefs.SetFloat("flyUpSpeedMax", 200.0f);
        PlayerPrefs.SetFloat("flyDownSpeedMax", 0);
        PlayerPrefs.SetFloat("horizontalAccelerometer", 10.0f);
        PlayerPrefs.SetFloat("verticalAccelerometer", 2200.0f);
        PlayerPrefs.SetFloat("accelerationRangeMin", 0.2f);

    }
    public void setSpdMoveMax(uint value)
    {
        moveSpeedMax = value / gameManager.pixelPerUnit;
    }
    public void setSpdMoveMin(uint value)
    {
        moveSpeedMin = value / gameManager.pixelPerUnit;
    }
    public void setSpdFlyUpMax(uint value)
    {
        flyUpSpeedMax = value / gameManager.pixelPerUnit;
    }
    public void setSpdFlyDownMax(uint value)
    {
        flyDownSpeedMax = value / gameManager.pixelPerUnit;
    }
}
