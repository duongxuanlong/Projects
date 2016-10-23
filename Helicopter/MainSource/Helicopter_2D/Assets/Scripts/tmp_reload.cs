using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class tmp_reload : MonoBehaviour {


	void Start()
	{
		Button btn = gameObject.GetComponent<Button> ();
		btn.onClick.AddListener (TaskOnClick);

	}
 
	void TaskOnClick()
	{
        SaveDebugValues();
		Application.LoadLevel ("AP");
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
