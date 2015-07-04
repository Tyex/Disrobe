using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GirlsUI : MonoBehaviour {

	public int currentGirlIndex;

	public GameObject girlsContainer;
	public List<GirlPanel> girlPanels = new List<GirlPanel>();

	public GameObject nextButton;
	public GameObject previousButton;

	// Use this for initialization
	void Start () {
		initGirlsPanel();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void initGirlsPanel() {
		currentGirlIndex = 0;
		girlPanels.AddRange(girlsContainer.GetComponentsInChildren<GirlPanel>());
		for(int i = 1; i < girlPanels.Count; i++) {
			girlPanels[i].setRight();
//			girlPanels[i].gameObject.SetActive(false);
		}

		refreshButtonsState();
	}

	public void nextGirl() {
		switchGirl(1);
	}

	public void previousGirl() {
		switchGirl(-1);
	}

	public void switchGirl(int val) {
		if(val > 0) {
			girlPanels[currentGirlIndex].goLeft();
			currentGirlIndex += val;
//			girlPanels[currentGirlIndex].gameObject.SetActive(true);
			girlPanels[currentGirlIndex].comeFromRight();
		} else {
			girlPanels[currentGirlIndex].goRight();
			currentGirlIndex += val;
//			girlPanels[currentGirlIndex].gameObject.SetActive(true);
			girlPanels[currentGirlIndex].comeFromLeft();
		}

		refreshButtonsState();
	}

	public void refreshButtonsState() {
		nextButton.SetActive(currentGirlIndex < girlPanels.Count - 1);
		previousButton.SetActive(currentGirlIndex > 0);
	}
}
