using UnityEngine;
using System.Collections;

public class BehindTornado : MonoBehaviour {

	public GameManager gameManager { get; set; }
	private Rigidbody2D rb2d;
	private float tornadoSpeed;
	// Use this for initialization
	public void TornadoInit()
	{
		rb2d = GetComponent<Rigidbody2D> ();
		tornadoSpeed = gameManager.tornadoSpeed / gameManager.pixelPerUnit;

	}

	// Update is called once per frame
	public void tornadoUpdate() {
		if (rb2d.velocity.x < tornadoSpeed) {
			rb2d.velocity = new Vector2 (tornadoSpeed, 0);
		}
	}
}
