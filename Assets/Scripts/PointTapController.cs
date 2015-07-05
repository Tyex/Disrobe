using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class PointTapController : MonoBehaviour, IPointerDownHandler {

	public GameObject fringue;

	public string bubbleText;
	public bool silent;

	// Use this for initialization
	void Start () {
		if(!silent) {
			BubbleManager.instance.pop(bubbleText);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void setFringue(GameObject fringueCtrl) {
		fringue = fringueCtrl;
	}

	public void validatePointAction() {
		fringue.SendMessage("decreaseLife");
	}

	public void OnPointerDown(PointerEventData eventData) {
		validatePointAction();
	}

	public void callNextPoint() {
		fringue.SendMessage("nextPoint");
		Destroy(gameObject);
	}
}
