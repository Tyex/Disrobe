using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScreenSizePreferred : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width, Screen.height);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
