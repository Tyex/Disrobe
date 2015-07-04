using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FringueController : MonoBehaviour {

	public int life;

	public GirlPanel girlPanel;

	public Transform lifePanelPosition;
	public GameObject defaultLifePanel;

	public GameObject[] defaultPoints;

	// Use this for initialization
	void Start () {
		girlPanel = GetComponentInParent<GirlPanel>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void init() {
		GameObject lifePanel = Instantiate(defaultLifePanel) as GameObject;
		lifePanel.transform.SetParent(lifePanelPosition, false);
		lifePanel.GetComponent<RectTransform>().localPosition = Vector3.zero;
		lifePanel.GetComponent<FringueLifePanel>().fringueCtrl = this;
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
		Destroy(gameObject);
	}

	public void startPointsGeneration() {

	}
}
