using UnityEngine;
using System.Collections;

public class FingerManager : MonoBehaviour {

	public int fingerPower;

	//Singleton
	static FingerManager mInst;
	static public FingerManager instance { get { return mInst; } }
	
	void Awake () {
		if(mInst == null) mInst = this;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
