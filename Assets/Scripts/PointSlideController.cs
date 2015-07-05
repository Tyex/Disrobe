using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class PointSlideController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler {

	public GameObject fringue;

	public bool isTouched;

	public float maxTimeCount;
	public float currentTimeTouched;

	public float hitsInterval = .25f;
	public float lastHitTime = 0;
	public float hitTimeThreshold = 1f;

	public float hitTime = 0;

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

	public void setFringue(GameObject fringueCtrl) {
		fringue = fringueCtrl;
	}

	public void hit() {
		fringue.SendMessage("decreaseLife");
	}

	public void OnPointerDown(PointerEventData eventData) {
//		startRecordHits();
	}

	public void OnPointerUp(PointerEventData eventData) {
//		stopRecordHits();
	}

	public void OnPointerEnter(PointerEventData eventData) {
		startRecordHits();
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

	public void callNextPoint() {
		fringue.SendMessage("nextPoint");
		Destroy(gameObject);
	}
}
