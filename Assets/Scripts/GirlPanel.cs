using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GirlPanel : MonoBehaviour {

	public List<FringueController> fringues = new List<FringueController>();
	public int currentFringueIndex;

	public Transform overlayRoot;

	private Animator animator;

	void Awake() {
		animator = GetComponent<Animator>();
	}

	// Use this for initialization
	void Start () {
		initFringues();
		initCurrentFringue();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void initFringues() {
		currentFringueIndex = 0;
//		fringues.AddRange(transform.GetComponentsInChildren<FringueController>());
	}

	public void nextFringue() {
		if(currentFringueIndex < fringues.Count - 1) {
			currentFringueIndex++;
			initCurrentFringue();
		}
	}

	public void initCurrentFringue() {
		if(fringues.Count > 0) {
			fringues[currentFringueIndex].startPointsSequence();
		}
	}

	public void goLeft() {
		animator.SetTrigger("goLeft");
	}

	public void goRight() {
		animator.SetTrigger("goRight");
	}

	public void setRight() {
		animator.SetTrigger("setRight");
	}

	public void comeFromRight() {
		animator.SetTrigger("comeFromRight");
	}

	public void comeFromLeft() {
		animator.SetTrigger("comeFromLeft");
	}

	public void setInactive() {
		gameObject.SetActive(false);
	}
}
