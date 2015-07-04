using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {

	//Singleton
	static InputManager mInst;
	static public InputManager instance { get { return mInst; } }
	
	void Awake () {
		if(mInst == null) mInst = this;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void processTouches() {
		foreach(Touch t in Input.touches) {

		}
	}
}
