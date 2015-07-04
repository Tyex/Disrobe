using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class PointTapController : MonoBehaviour, IPointerDownHandler {

	public FringueController fringue;

	public string bubbleText;

	// Use this for initialization
	void Start () {
		BubbleManager.instance.pop(bubbleText);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void setFringue(FringueController fringueCtrl) {
		fringue = fringueCtrl;
	}

	public void validatePointAction() {
		fringue.decreaseLife();
	}

	public void OnPointerDown(PointerEventData eventData) {
		validatePointAction();
	}

	public void callNextPoint() {
		fringue.nextPoint();
		Destroy(gameObject);
	}
}
