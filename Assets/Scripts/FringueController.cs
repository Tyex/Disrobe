using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class FringueController : MonoBehaviour {
	
	public int startingLife;
	public int life;
	public List<GameObject> pointsSequence = new List<GameObject>();
	public int currentSequenceIndex;
	
	public GirlPanel girlPanel;

	public Transform pointsRoot;
	public Transform lifePanelPosition;
	public Transform fringueSprite;

	public GameObject defaultLifePanel;

	public float sequenceTotalTime;
	public float currentSequenceTime;

	// Use this for initialization
	void Start () {
		girlPanel = GetComponentInParent<GirlPanel>();

		foreach(GameObject seq in pointsSequence) {
			RuntimeAnimatorController ac = seq.GetComponent<Animator>().runtimeAnimatorController;    //Get Animator controller
			sequenceTotalTime += ac.animationClips[0].length;
		}
	}
	
	// Update is called once per frame
	void Update () {
		currentSequenceTime += Time.deltaTime;
	}
	
	public void init() {
		GameObject lifePanel = Instantiate(defaultLifePanel) as GameObject;
		lifePanel.transform.SetParent(lifePanelPosition, false);
		lifePanel.transform.localPosition = Vector3.zero;
		lifePanel.GetComponent<FringueLifePanel>().fringueCtrl = this;
		
		reset();
	}
	
	public void reset() {
		life = startingLife;
		currentSequenceTime = 0;
	}
	
	public void decreaseLife() {
		life -= FingerManager.instance.fingerPower;
		
		checkStatus();
	}
	
	public void checkStatus() {
		if(life <= 0) {
			destroyFringue();
		}
	}
	
	public void destroyFringue() {
		girlPanel.nextFringue();
		pointsRoot.gameObject.SetActive(false);
		lifePanelPosition.gameObject.SetActive(false);
		fringueSprite.GetComponent<Animator>().SetTrigger("fade");
	}
	
	public void startPointsSequence() {
		currentSequenceIndex = 0;
		initCurrentPoint();
	}
	
	public void nextPoint() {
		currentSequenceIndex++;
		initCurrentPoint();
	}
	
	public void initCurrentPoint() {
		if(currentSequenceIndex < pointsSequence.Count) {
			GameObject newPoint = Instantiate(pointsSequence[currentSequenceIndex]);
			newPoint.transform.SetParent(pointsRoot, false);
			newPoint.transform.localPosition = Vector3.zero;
			newPoint.SendMessage("setFringue", this);
		} else {
			reset();
			startPointsSequence();
		}
	}
}
