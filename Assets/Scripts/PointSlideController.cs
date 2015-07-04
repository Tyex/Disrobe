using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class PointSlideController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler {

	public FringueController fringue;

	public bool isTouched;

	public float maxTimeCount;
	public float currentTimeTouched;

	public float hitsInterval = .25f;
	public float lastHitTime = 0;
	public float hitTimeThreshold = 1f;

	public float hitTime = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(isTouched) {
			hitTime += Time.deltaTime;
			currentTimeTouched += Time.deltaTime;

			while(hitTime - lastHitTime >= hitsInterval) {
				hit();
				lastHitTime += hitsInterval;
			}
		}

		maxTimeCount += Time.deltaTime;
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
		hitTime = -hitTimeThreshold;
		lastHitTime = 0;
	}

	public void stopRecordHits() {
		isTouched = false;
	}

	public void endPoint() {

	}
}
