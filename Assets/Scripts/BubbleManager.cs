using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BubbleManager : MonoBehaviour {

	public Text bubbleText;

	public string[] tooSlowStrings;
	public string[] ohYesStrings;

	private Animator animator;

	//Singleton
	static BubbleManager mInst;
	static public BubbleManager instance { get { return mInst; } }
	
	void Awake () {
		if(mInst == null) mInst = this;
		animator = GetComponent<Animator>();
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void pop(string text) {
		bubbleText.text = text;
		animator.SetTrigger("pop");
	}

	public void sayTooSlow() {
		int random = Random.Range(0, tooSlowStrings.Length);
		pop(tooSlowStrings[random]);
	}

	public  void sayOhYes() {
		int random = Random.Range(0, ohYesStrings.Length);
		pop(ohYesStrings[random]);
	}
}
