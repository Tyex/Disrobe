using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FringueLifePanel : MonoBehaviour {

	public FringueController fringueCtrl;

	public Text lifeText;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		lifeText.text = fringueCtrl.life.ToString();
	}
}
