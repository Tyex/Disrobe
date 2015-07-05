using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class PointScratchController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler, IDragHandler {
	
	public GameObject fringue;

	public bool isTouched;
	
	public float scratchStepScreenPercent = .1f;
	private float scratchStep;
	public float currentScratch;
	public float lastScratch;

	public string bubbleText;
	public bool silent;
	
	// Use this for initialization
	void Start () {
		scratchStep = Screen.width * scratchStepScreenPercent;

		if(!silent) {
			BubbleManager.instance.pop(bubbleText);
		}
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnDestroy() {
		endPoint();
	}

	public void setFringue(GameObject fringueCtrl) {
		fringue = fringueCtrl;
	}

	public void hit() {
		fringue.SendMessage("decreaseLife");
	}

	public void OnPointerDown(PointerEventData eventData) {
		startRecordHits();
	}
	
	public void OnPointerUp(PointerEventData eventData) {
		stopRecordHits();
	}

	public void OnPointerEnter(PointerEventData eventData) {
		startRecordHits();
	}
	
	public void OnPointerExit(PointerEventData eventData) {
		stopRecordHits();
	}
	
	public void startRecordHits() {
		isTouched = true;
		currentScratch = 0;
		lastScratch = 0;
	}
	
	public void stopRecordHits() {
		isTouched = false;
	}

	public void OnDrag(PointerEventData eventData) {
		if(isTouched) {
			currentScratch += eventData.delta.magnitude;

			while(currentScratch >= lastScratch + scratchStep) {
				hit();
				lastScratch += scratchStep;
			}
		}
	}

	public void endPoint() {

	}

	public void callNextPoint() {
		fringue.SendMessage("nextPoint");
		Destroy(gameObject);
	}
}
