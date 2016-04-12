using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CameraMovement : MonoBehaviour {
    [SerializeField]
	private Text timeRunning;
	float currentTime = 0;
	float speed = 0.005f;
    private float extraSpeed = 0;
    [SerializeField]
    private GameObject[] players;
    private bool cathingUpWithPlayers = false;
	void FixedUpdate(){
		currentTime += Time.deltaTime;
		if (currentTime >= 10f) {
			speed = 0.01f;
		}
		if (currentTime >= 20f) {
			speed = 0.015f;
		}
		transform.Translate (Vector2.up * (speed + extraSpeed));
		timeRunning.text = "Time running: " + Mathf.Floor(currentTime) + " Seconds";
        foreach(GameObject player in players)
        {
            if(player != null && !cathingUpWithPlayers)
            {
                if (player.transform.position.y > transform.position.y + 4f)
                {
                    StartCoroutine(CatchIUpWithFirstPlayer(player.transform.position.y));
                }
            }
        }
	}
    IEnumerator CatchIUpWithFirstPlayer(float playerPosY)
    {
        cathingUpWithPlayers = true;
        extraSpeed = 0.1f;
        while (transform.position.y+4f < playerPosY)
        {
            yield return new WaitForFixedUpdate();
        }
        extraSpeed = 0;
        cathingUpWithPlayers = false;
    }
}
