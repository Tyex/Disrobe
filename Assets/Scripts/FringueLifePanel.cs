using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FringueLifePanel : MonoBehaviour {

	public FringueController fringueCtrl;
	public FinishObject finishObject;

	public float displayLife;

	public Image timerImage;
	public Text lifeText;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(fringueCtrl != null) {
			lifeText.text = fringueCtrl.life.ToString();
			timerImage.fillAmount = 1f - (fringueCtrl.currentSequenceTime / fringueCtrl.sequenceTotalTime);
		} else {
			lifeText.text = finishObject.life.ToString();
			timerImage.fillAmount = 1f;
		}
	}
}
