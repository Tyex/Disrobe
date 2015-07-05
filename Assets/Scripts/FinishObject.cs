using UnityEngine;
using System.Collections;

public class FinishObject : MonoBehaviour {

	public float life;
	public GameObject currentLifePanel;

	public GirlPanel girlPanel;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void decreaseLife() {
		life -= FingerManager.instance.fingerPower;
		FingerManager.instance.increaseSliderValue();
		currentLifePanel.GetComponent<Animator>().SetTrigger("score");
		AudioManager.instance.playSound("Hit");

		if(life <= 0 && this.enabled) {
			girlPanel.endPhase();
			currentLifePanel.SetActive(false);

			GetComponent<Animator>().SetTrigger("fade");
			this.enabled = false;
		}
	}

	public void deactivate() {
		gameObject.SetActive(false);
	}
}
