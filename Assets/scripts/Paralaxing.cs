using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paralaxing : MonoBehaviour {

	public Transform[] backgrounds; // backgrounds/foregrounds
	private float[] parallaxScales; // proportion of camera movement to move background by
	public float smoothing = 1f; // how smooth paralax will be. must be > 0

	private Transform cam; // reference to main camera's transform
	private Vector3 previousCamPos; // store camera's position in previous frame

	public float scaleVar = -1;


	void Awake () {
		cam = Camera.main.transform;
	}
	
	void Start () {
		previousCamPos = cam.position;

		parallaxScales = new float[backgrounds.Length];
		for (int i = 0; i < backgrounds.Length; i++) {
			parallaxScales[i] = backgrounds[i].position.z * scaleVar;
		}
	}

	// Update is called once per frame
	void Update () {
		for (int i = 0; i < backgrounds.Length; i++) {
			float parallax = (previousCamPos.x - cam.position.x) * parallaxScales[i];

			// set target position as current position + parallax
			float backgroundTargetPosX = backgrounds[i].position.x + parallax;

			// create target position
			Vector3 backgroundTargetPos = new Vector3 (backgroundTargetPosX, backgrounds[i].position.y, backgrounds[i].position.z);

			backgrounds[i].position = Vector3.Lerp (backgrounds[i].position, backgroundTargetPos, smoothing * Time.deltaTime);
		}

		// set previousCamPos to camera's new position at end of frame
		previousCamPos = cam.position;
	}
}
