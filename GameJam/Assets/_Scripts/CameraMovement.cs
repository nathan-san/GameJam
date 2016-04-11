using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CameraMovement : MonoBehaviour {
	public Text timeRunning;
	float currentTime = 0;
	float speed = 0.005f;
	void Update(){
		currentTime += Time.deltaTime;
		if (currentTime >= 10f) {
			speed = 0.01f;
		}
		if (currentTime >= 20f) {
			speed = 0.015f;
		}
		transform.Translate (Vector2.up * speed);
		timeRunning.text = "Time running: " + Mathf.Floor(currentTime) + " Seconds";
	}
}
