using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FingerManager : MonoBehaviour {

	public int fingerPower;

	public Text fingerPowerText;
	public Slider fingerPowerSlider;

	public float currentSliderValue;
	public float sliderStep = 100f;
	public float stepMultiplier = 3f;

	public Animator sliderAnimator;
	public Animator textAnimator;

	//Singleton
	static FingerManager mInst;
	static public FingerManager instance { get { return mInst; } }
	
	void Awake () {
		if(mInst == null) mInst = this;
	}

	// Use this for initialization
	void Start () {
		updateSlider();
	}
	
	// Update is called once per frame
	void Update () {
		fingerPowerText.text = "x" + fingerPower;
	}

	public void increaseSliderValue() {
		currentSliderValue += (float) fingerPower;

		updateSlider();

		sliderAnimator.SetTrigger("flash");
	}

	public void updateSlider() {
		fingerPowerSlider.value = currentSliderValue / getNextStepValue();

		if(fingerPowerSlider.value >= 1f) {
			fingerPower++;
			currentSliderValue = 0;
			textAnimator.SetTrigger("bump");
		}
	}

	public float getNextStepValue() {
		return (float) fingerPower * sliderStep * (stepMultiplier * (float) fingerPower - 1f);
	}
}
