using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class DebugPanel : MonoBehaviour {
	public Sprite pauseResumeButton;

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
