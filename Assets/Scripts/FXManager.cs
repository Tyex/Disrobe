using UnityEngine;
using System.Collections;

public class FXManager : MonoBehaviour {

	public ParticleSystem burstParticles;

	//Singleton
	static FXManager mInst;
	static public FXManager instance { get { return mInst; } }
	
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
