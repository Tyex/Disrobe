using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class FringueController : MonoBehaviour {
	
	public int startingLife;
	public int life;
	public List<GameObject> pointsSequence = new List<GameObject>();
	public List<AnimatorOverrideController> pointsAnimations = new List<AnimatorOverrideController>();
	public int currentSequenceIndex;
	
	public GirlPanel girlPanel;

	public Transform pointsRoot;
	public Transform lifePanelPosition;
	public Transform fringueSprite;

	public GameObject defaultLifePanel;

	public float sequenceTotalTime;
	public float currentSequenceTime;

	public float delayTime = 1f;

	private GameObject currentLifePanel;

	void Awake() {
		girlPanel = GetComponentInParent<GirlPanel>();
	}

	// Use this for initialization
	void Start () {
		foreach(AnimatorOverrideController animOveride in pointsAnimations) {
			sequenceTotalTime += animOveride.animationClips[0].length;
		}

		sequenceTotalTime += (pointsSequence.Count - 1) * delayTime;
	}
	
	// Update is called once per frame
	void Update () {
		currentSequenceTime += Time.deltaTime;
	}
	
	public void init() {
		if(pointsSequence.Count > 0) {
			currentSequenceTime = 0;
			life = startingLife;

			if(currentLifePanel == null) {
				currentLifePanel = Instantiate(defaultLifePanel) as GameObject;
			}
			currentLifePanel.transform.SetParent(lifePanelPosition, false);
			currentLifePanel.GetComponent<FringueLifePanel>().fringueCtrl = this;

			lifePanelPosition.SetParent(girlPanel.overlayRoot, false);
			pointsRoot.SetParent(girlPanel.overlayRoot, false);
		}
	}
	
	public void decreaseLife() {
		life -= FingerManager.instance.fingerPower;
		FingerManager.instance.increaseSliderValue();
		currentLifePanel.GetComponent<Animator>().SetTrigger("score");
		AudioManager.instance.playSound("Hit");
		
		checkStatus();
	}
	
	public void checkStatus() {
		if(life <= 0) {
			destroyFringue();
		}
	}
	
	public void destroyFringue() {
		BubbleManager.instance.sayOhYes();
		FXManager.instance.burstParticles.Play();
		AudioManager.instance.playSound("Clothes");

		girlPanel.nextFringue();
		pointsRoot.gameObject.SetActive(false);
		lifePanelPosition.gameObject.SetActive(false);
		fringueSprite.GetComponent<Animator>().SetTrigger("fade");
		Destroy(currentLifePanel);
	}
	
	public void startPointsSequence() {
		Invoke("init", delayTime);
		currentSequenceIndex = 0;
		initCurrentPoint();
	}
	
	public void nextPoint() {
		currentSequenceIndex++;
		initCurrentPoint();
	}
	
	public void initCurrentPoint() {
		if(pointsSequence.Count > 0) {
			if(currentSequenceIndex < pointsSequence.Count) {
				Invoke("instantiateNextPoint", delayTime);
			} else {
				Invoke("restartSequence", delayTime);
			}
		}
	}

	public void instantiateNextPoint() {
		GameObject newPoint = Instantiate(pointsSequence[currentSequenceIndex]);
		newPoint.transform.SetParent(pointsRoot, false);
		newPoint.SendMessage("setFringue", this.gameObject);
		newPoint.GetComponent<Animator>().runtimeAnimatorController = pointsAnimations[currentSequenceIndex];
	}

	public void restartSequence() {
		BubbleManager.instance.sayTooSlow();
		AudioManager.instance.playSound("Fail");
		startPointsSequence();
	}
}
