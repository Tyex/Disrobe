using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour {

	public string clipToPlay;
	public bool playNow;

	//Singleton
	static AudioManager mInst;
	static public AudioManager instance { get { return mInst; } }
	
	void Awake () {
		if(mInst == null) mInst = this;
		DontDestroyOnLoad(this.gameObject);
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(playNow) {
			playSound(clipToPlay);
			playNow = false;
		}

		if(Input.GetKeyDown(KeyCode.P)) {
			playSound(clipToPlay);
		}
	}

	public void playSound(string name) {
		transform.Find(name).GetComponent<AudioSource>().Play();
	}
}
