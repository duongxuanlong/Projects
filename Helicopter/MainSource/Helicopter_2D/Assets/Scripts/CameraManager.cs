using UnityEngine;
using System.Collections;

public class CameraManager : MonoBehaviour {


	public GameManager gameManager { get; set; }
	private GameObject helicopter;
	public float lerpSpeed;
	public Vector2 leftZone2;
	public Vector2 leftZone1;
	public Vector2 rightZone1;
	public Vector2 rightZone2;


	// Use this for initialization
	public void CameraInit () {
		helicopter = gameManager.helicopter;

	}
	
	// Update is called once per frame
	public void CameraUpdate() {


		//currently, using this method
		Vector3 offset = new Vector3(0, 0, transform.position.z - helicopter.transform.position.z);
		transform.position = Vector3.Lerp (transform.position, helicopter.transform.position + offset, lerpSpeed);
			

		//end here














		// do it later
		if (helicopter.transform.position.x > rightZone2.x) {
			//change focus to leftzone1.transform.x
		}

		if (helicopter.transform.position.x < leftZone2.x) {
			//change focus to rightZone1.transform.x
		}









		Debug.DrawLine ((Vector2)transform.position + Vector2.up + leftZone2, (Vector2)transform.position + Vector2.down + leftZone2, Color.red);
		Debug.DrawLine ((Vector2)transform.position + Vector2.up + leftZone1, (Vector2)transform.position + Vector2.down + leftZone1, Color.red);
		Debug.DrawLine ((Vector2)transform.position + Vector2.up + rightZone1, (Vector2)transform.position + Vector2.down + rightZone1, Color.red);
		Debug.DrawLine ((Vector2)transform.position + Vector2.up + rightZone2, (Vector2)transform.position + Vector2.down + rightZone2, Color.red);

	}
}
