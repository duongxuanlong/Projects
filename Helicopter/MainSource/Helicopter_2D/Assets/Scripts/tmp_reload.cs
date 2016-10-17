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
		Application.LoadLevel ("AP");
	}
}
