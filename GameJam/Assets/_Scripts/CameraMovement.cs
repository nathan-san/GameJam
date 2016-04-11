using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {
	float currentTime;
	float speed;
	void update(){
		currentTime += Time.deltaTime;
		if (currentTime == 10f) {
			speed = 0.1f;
		}
		if (currentTime == 20f) {
			speed = 0.15f;
		}
		transform.Translate (Vector2.up * speed);
	}
}
