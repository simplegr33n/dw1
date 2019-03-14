using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	private GameObject donk;
	public float xMin;
	public float xMax;
	public float yMin;
	public float yMax;

	// Use this for initialization
	void Start () {
		donk = GameObject.FindGameObjectWithTag("Player");
		
	}
	
	// Update is called once per frame
	void LateUpdate () {
		float x = Mathf.Clamp (donk.transform.position.x, xMin, xMax);
		float y = Mathf.Clamp (donk.transform.position.y, yMin, yMax);

		gameObject.transform.position = new Vector3(x, y, gameObject.transform.position.z);


	}
}
