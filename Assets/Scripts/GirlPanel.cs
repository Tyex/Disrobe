using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GirlPanel : MonoBehaviour {

	public List<FringueController> fringues = new List<FringueController>();
	public GameObject finishObject;

	public int currentFringueIndex;

	public Transform overlayRoot;

	public GameObject basePose;
	public GameObject finishPose;

	private Animator animator;

	void Awake() {
		animator = GetComponent<Animator>();
	}

	// Use this for initialization
	void Start () {
		initFringues();
		initCurrentFringue();
		basePose.SetActive(true);
//		finishPose.SetActive(false);
		finishObject.SetActive(false);
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
		} else {
			startFinishPhase();
		}
	}

	public void initCurrentFringue() {
		if(fringues.Count > 0) {
			fringues[currentFringueIndex].startPointsSequence();
		}
	}

	public void startFinishPhase() {
		finishObject.SetActive(true);
		BubbleManager.instance.sayFinish();
	}

	public void endPhase() {
		finishPose.GetComponent<Animator>().SetTrigger("show");
		basePose.GetComponent<Animator>().SetTrigger("hide");

		FXManager.instance.flashParticles.Play();
		AudioManager.instance.playSound("Haan");
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
