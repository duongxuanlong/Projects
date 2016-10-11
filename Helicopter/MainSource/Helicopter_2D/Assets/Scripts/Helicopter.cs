using UnityEngine;
using System.Collections;

public class Helicopter : MonoBehaviour {

	public float m_healthPoint;
	public float m_moveSpeedMax;
	public float m_moveSpeedMin;
	public float m_horizontalAccelerometer;
	public float m_flyUpSpeedMax;
	public float m_flyDownSpeedMax;
	public float m_verticalAccelerometer;
	public int m_capacity;

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

	public void helicopterInit()
	{
		firstTouch = false;
		rb2d = GetComponent<Rigidbody2D> ();

		healthPoint = m_healthPoint;
		moveSpeedMax = m_moveSpeedMax / gameManager.pixelPerUnit;
		moveSpeedMin = moveSpeedMin / gameManager.pixelPerUnit;
		horizontalAccelerometer = m_horizontalAccelerometer / gameManager.pixelPerUnit;
		flyUpSpeedMax = m_flyUpSpeedMax / gameManager.pixelPerUnit;
		flyDownSpeedMax = m_flyDownSpeedMax / gameManager.pixelPerUnit;
		verticalAccelerometer = m_verticalAccelerometer / gameManager.pixelPerUnit;
		capacity = m_capacity;
		accelerationRangeMin = m_accelerationRangeMin / gameManager.pixelPerUnit;	


	}

	public void helicopterUpdate()
	{
		gameManager.inputManager.UpdateAcceleration ();


		if (!firstTouch && gameManager.inputManager.IsTouching()) {
			firstTouch = true;
		}

		if (firstTouch) {
			HandleMovementX ();
			HandleMovementY ();	
		}
		
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
}
