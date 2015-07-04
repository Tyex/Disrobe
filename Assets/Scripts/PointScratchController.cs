using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class PointScratchController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler, IDragHandler {

	public FringueController fringue;

	public bool isTouched;
	
	public float scratchStepScreenPercent = .1f;
	private float scratchStep;
	public float currentScratch;
	public float lastScratch;

	// Use this for initialization
	void Start () {
		scratchStep = Screen.width * scratchStepScreenPercent;
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnDestroy() {
		endPoint();
	}

	public void hit() {
		fringue.decreaseLife();
	}

	public void OnPointerDown(PointerEventData eventData) {
		startRecordHits();
	}
	
	public void OnPointerUp(PointerEventData eventData) {
		stopRecordHits();
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
}
