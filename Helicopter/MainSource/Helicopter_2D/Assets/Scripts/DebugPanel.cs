using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class DebugPanel : MonoBehaviour {
	public GameObject helicopter;
	public Sprite pauseResumeButton;

	public void Restart()
	{
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
			//load helicopter profile
			PanelLoadProfileValues();
		} else {
			debugPanel.GetComponent<RectTransform> ().localScale = Vector3.zero;
			Time.timeScale = 1;
		}

	}

	public void PanelLoadProfileValues()
	{
		Helicopter _helicopterProfile = helicopter.GetComponent<Helicopter> ();

		GameObject.Find ("DebugCanvas/DebugPanel/moveSpeedMax").GetComponent<InputField> ().text = _helicopterProfile.moveSpeedMax.ToString();
		GameObject.Find ("DebugCanvas/DebugPanel/moveSpeedMin").GetComponent<InputField> ().text = _helicopterProfile.moveSpeedMin.ToString ();
		GameObject.Find("DebugCanvas/DebugPanel/horizontalAccelerometer").GetComponent<InputField>().text = _helicopterProfile.horizontalAccelerometer.ToString ();
		GameObject.Find("DebugCanvas/DebugPanel/flyUpSpeedMax").GetComponent<InputField>().text = _helicopterProfile.flyUpSpeedMax.ToString ();
		GameObject.Find ("DebugCanvas/DebugPanel/flyDownSpeedMax").GetComponent<InputField> ().text = _helicopterProfile.flyDownSpeedMax.ToString ();
		GameObject.Find ("DebugCanvas/DebugPanel/verticalAccelerometer").GetComponent<InputField> ().text = _helicopterProfile.verticalAccelerometer.ToString ();
		GameObject.Find("DebugCanvas/DebugPanel/accelerometerLowMultiple").GetComponent<InputField>().text = _helicopterProfile.accelerometerLowMultiple.ToString();
		GameObject.Find("DebugCanvas/DebugPanel/accelerometerMediumMultiple").GetComponent<InputField>().text = _helicopterProfile.accelerometerMediumMultiple.ToString();
		GameObject.Find("DebugCanvas/DebugPanel/accelerometerHighMultiple").GetComponent<InputField>().text = _helicopterProfile.accelerometerHighMultiple.ToString();
		GameObject.Find("DebugCanvas/DebugPanel/accelerometerLowRange").GetComponent<InputField>().text = _helicopterProfile.accelerometerLowRange.ToString();
		GameObject.Find("DebugCanvas/DebugPanel/accelerometerMediumRange").GetComponent<InputField>().text = _helicopterProfile.accelerometerMediumRange.ToString();
		GameObject.Find("DebugCanvas/DebugPanel/accelerometerHighRange").GetComponent<InputField>().text = _helicopterProfile.accelerometerHighRange.ToString();

	}

	public void SaveDebugValues()
	{
		float value = float.Parse (GameObject.Find ("DebugCanvas/DebugPanel/moveSpeedMax").GetComponent<InputField> ().text);
		PlayerPrefs.SetFloat ("moveSpeedMax", value);
		value = float.Parse (GameObject.Find ("DebugCanvas/DebugPanel/moveSpeedMin").GetComponent<InputField> ().text);
		PlayerPrefs.SetFloat ("moveSpeedMin", value);
		value = float.Parse (GameObject.Find ("DebugCanvas/DebugPanel/horizontalAccelerometer").GetComponent<InputField> ().text);
		PlayerPrefs.SetFloat ("horizontalAccelerometer", value);
		value = float.Parse (GameObject.Find ("DebugCanvas/DebugPanel/flyUpSpeedMax").GetComponent<InputField> ().text);
		PlayerPrefs.SetFloat ("flyUpSpeedMax", value);
		value = float.Parse (GameObject.Find ("DebugCanvas/DebugPanel/flyDownSpeedMax").GetComponent<InputField> ().text);
		PlayerPrefs.SetFloat ("flyDownSpeedMax", value);
		value = float.Parse (GameObject.Find ("DebugCanvas/DebugPanel/verticalAccelerometer").GetComponent<InputField> ().text);
		PlayerPrefs.SetFloat ("verticalAccelerometer", value);
		value = float.Parse (GameObject.Find ("DebugCanvas/DebugPanel/accelerometerLowMultiple").GetComponent<InputField> ().text);
		PlayerPrefs.SetFloat ("accelerometerLowMultiple", value);
		value = float.Parse (GameObject.Find ("DebugCanvas/DebugPanel/accelerometerMediumMultiple").GetComponent<InputField> ().text);
		PlayerPrefs.SetFloat ("accelerometerMediumMultiple", value);
		value = float.Parse (GameObject.Find ("DebugCanvas/DebugPanel/accelerometerHighMultiple").GetComponent<InputField> ().text);
		PlayerPrefs.SetFloat ("accelerometerHighMultiple", value);
		value = float.Parse (GameObject.Find ("DebugCanvas/DebugPanel/accelerometerLowRange").GetComponent<InputField> ().text);
		PlayerPrefs.SetFloat ("accelerometerLowRange", value);
		value = float.Parse (GameObject.Find ("DebugCanvas/DebugPanel/accelerometerMediumRange").GetComponent<InputField> ().text);
		PlayerPrefs.SetFloat ("accelerometerMediumRange", value);
		value = float.Parse (GameObject.Find ("DebugCanvas/DebugPanel/accelerometerHighRange").GetComponent<InputField> ().text);
		PlayerPrefs.SetFloat ("accelerometerHighRange", value);
	}

	public void ApplyDebugValues()
	{	
		Helicopter _helicopterProfile = helicopter.GetComponent<Helicopter> ();

		float value = float.Parse (GameObject.Find ("DebugCanvas/DebugPanel/moveSpeedMax").GetComponent<InputField> ().text);
		_helicopterProfile.moveSpeedMax = value;
		value = float.Parse (GameObject.Find ("DebugCanvas/DebugPanel/moveSpeedMin").GetComponent<InputField> ().text);
		_helicopterProfile.moveSpeedMin = value;
		value = float.Parse (GameObject.Find ("DebugCanvas/DebugPanel/horizontalAccelerometer").GetComponent<InputField> ().text);
		_helicopterProfile.horizontalAccelerometer = value;
		value = float.Parse (GameObject.Find ("DebugCanvas/DebugPanel/flyUpSpeedMax").GetComponent<InputField> ().text);
		_helicopterProfile.flyUpSpeedMax = value;
		value = float.Parse (GameObject.Find ("DebugCanvas/DebugPanel/flyDownSpeedMax").GetComponent<InputField> ().text);
		_helicopterProfile.flyDownSpeedMax = value;
		value = float.Parse (GameObject.Find ("DebugCanvas/DebugPanel/verticalAccelerometer").GetComponent<InputField> ().text);
		_helicopterProfile.verticalAccelerometer = value;
		value = float.Parse (GameObject.Find ("DebugCanvas/DebugPanel/accelerometerLowMultiple").GetComponent<InputField> ().text);
		_helicopterProfile.accelerometerLowMultiple = value;
		value = float.Parse (GameObject.Find ("DebugCanvas/DebugPanel/accelerometerMediumMultiple").GetComponent<InputField> ().text);
		_helicopterProfile.accelerometerMediumMultiple = value;
		value = float.Parse (GameObject.Find ("DebugCanvas/DebugPanel/accelerometerHighMultiple").GetComponent<InputField> ().text);
		_helicopterProfile.accelerometerHighMultiple = value;
		value = float.Parse (GameObject.Find ("DebugCanvas/DebugPanel/accelerometerLowRange").GetComponent<InputField> ().text);
		_helicopterProfile.accelerometerLowRange = value;
		value = float.Parse (GameObject.Find ("DebugCanvas/DebugPanel/accelerometerMediumRange").GetComponent<InputField> ().text);
		_helicopterProfile.accelerometerMediumRange = value;
		value = float.Parse (GameObject.Find ("DebugCanvas/DebugPanel/accelerometerHighRange").GetComponent<InputField> ().text);
		_helicopterProfile.accelerometerHighRange = value;
	}

	public void PanelSetDefault()
	{
		GameObject.Find ("DebugCanvas/DebugPanel/moveSpeedMax").GetComponent<InputField> ().text = "2";
		GameObject.Find ("DebugCanvas/DebugPanel/moveSpeedMin").GetComponent<InputField> ().text =  "0.5";
		GameObject.Find("DebugCanvas/DebugPanel/horizontalAccelerometer").GetComponent<InputField>().text = "4";
		GameObject.Find("DebugCanvas/DebugPanel/flyUpSpeedMax").GetComponent<InputField>().text = "2";
		GameObject.Find ("DebugCanvas/DebugPanel/flyDownSpeedMax").GetComponent<InputField> ().text = "1.5";
		GameObject.Find ("DebugCanvas/DebugPanel/verticalAccelerometer").GetComponent<InputField> ().text = "1";
		GameObject.Find ("DebugCanvas/DebugPanel/accelerometerLowMultiple").GetComponent<InputField> ().text = "0.2";
		GameObject.Find ("DebugCanvas/DebugPanel/accelerometerMediumMultiple").GetComponent<InputField> ().text = "0.7";
		GameObject.Find ("DebugCanvas/DebugPanel/accelerometerHighMultiple").GetComponent<InputField> ().text = "1";
		GameObject.Find ("DebugCanvas/DebugPanel/accelerometerLowRange").GetComponent<InputField> ().text = "0.07";
		GameObject.Find ("DebugCanvas/DebugPanel/accelerometerMediumRange").GetComponent<InputField> ().text = "0.3";
		GameObject.Find ("DebugCanvas/DebugPanel/accelerometerHighRange").GetComponent<InputField> ().text = "0.6";
	}

	public void LoadSavedProfile()
	{
		Helicopter _helicopterProfile = helicopter.GetComponent<Helicopter> ();
		_helicopterProfile.moveSpeedMax = PlayerPrefs.GetFloat("moveSpeedMax");
		_helicopterProfile.moveSpeedMin = PlayerPrefs.GetFloat("moveSpeedMin");
		_helicopterProfile.horizontalAccelerometer = PlayerPrefs.GetFloat("horizontalAccelerometer");
		_helicopterProfile.flyUpSpeedMax = PlayerPrefs.GetFloat("flyUpSpeedMax");
		_helicopterProfile.flyDownSpeedMax = PlayerPrefs.GetFloat("flyDownSpeedMax");
		_helicopterProfile.verticalAccelerometer = PlayerPrefs.GetFloat("verticalAccelerometer");
		_helicopterProfile.accelerometerLowMultiple = PlayerPrefs.GetFloat("accelerometerLowMultiple");
		_helicopterProfile.accelerometerMediumMultiple = PlayerPrefs.GetFloat("accelerometerMediumMultiple");
		_helicopterProfile.accelerometerHighMultiple = PlayerPrefs.GetFloat("accelerometerHighMultiple");
		_helicopterProfile.accelerometerLowRange = PlayerPrefs.GetFloat("accelerometerLowRange");
		_helicopterProfile.accelerometerMediumRange = PlayerPrefs.GetFloat("accelerometerMediumRange");
		_helicopterProfile.accelerometerHighRange = PlayerPrefs.GetFloat("accelerometerHighRange");
	}
	public void SaveDefaultValues()
	{
		Helicopter _helicopterProfile = helicopter.GetComponent<Helicopter> ();
		PlayerPrefs.SetFloat ("moveSpeedMax", _helicopterProfile.moveSpeedMax);
		PlayerPrefs.SetFloat ("moveSpeedMin", _helicopterProfile.moveSpeedMin);
		PlayerPrefs.SetFloat ("horizontalAccelerometer", _helicopterProfile.horizontalAccelerometer);
		PlayerPrefs.SetFloat ("flyUpSpeedMax", _helicopterProfile.flyUpSpeedMax);
		PlayerPrefs.SetFloat ("flyDownSpeedMax", _helicopterProfile.flyDownSpeedMax);
		PlayerPrefs.SetFloat ("verticalAccelerometer", _helicopterProfile.verticalAccelerometer);
		PlayerPrefs.SetFloat ("accelerometerLowMultiple", _helicopterProfile.accelerometerLowMultiple);
		PlayerPrefs.SetFloat ("accelerometerMediumMultiple", _helicopterProfile.accelerometerMediumMultiple);
		PlayerPrefs.SetFloat ("accelerometerHighMultiple", _helicopterProfile.accelerometerHighMultiple);
		PlayerPrefs.SetFloat ("accelerometerLowRange", _helicopterProfile.accelerometerLowRange);
		PlayerPrefs.SetFloat ("accelerometerMediumRange", _helicopterProfile.accelerometerMediumRange);
		PlayerPrefs.SetFloat ("accelerometerHighRange", _helicopterProfile.accelerometerHighRange);

	}
}
