using UnityEngine;
using System.Collections;

public class RandomizeAnimPlayback : MonoBehaviour {
	
	public Animator anim;
	
	void Awake() {
		anim = GetComponent<Animator>();
	}
	
	// Use this for initialization
	void Start () {
		anim.Play("Anim", 0, Random.value);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
