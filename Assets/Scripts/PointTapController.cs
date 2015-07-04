using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class PointTapController : MonoBehaviour, IPointerDownHandler {

	public FringueController fringue;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void validatePointAction() {
		fringue.decreaseLife();
	}

	public void OnPointerDown(PointerEventData eventData) {
		validatePointAction();
	}
}
