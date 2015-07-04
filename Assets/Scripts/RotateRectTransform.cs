using UnityEngine;
using System.Collections;

public class RotateRectTransform : MonoBehaviour {

	public float speed = 1f;

	private RectTransform rect;

	// Use this for initialization
	void Start () {
		rect = GetComponent<RectTransform>();
	}
	
	// Update is called once per frame
	void Update () {
		rotate();
	}

	public void rotate() {
		rect.Rotate(Vector3.forward * speed * Time.deltaTime);
	}
}
