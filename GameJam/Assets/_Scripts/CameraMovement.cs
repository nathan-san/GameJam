using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
public class CameraMovement : MonoBehaviour {
	float currentTime = 0;
    [SerializeField]
	float speed = 0.005f;
    [SerializeField]
    float aceleration = 0.001f;
    [SerializeField]
    private List<GameObject> players;
    [SerializeField]
    private Text winText;
	void FixedUpdate(){
		currentTime += Time.deltaTime;

        speed += aceleration;
		transform.Translate (Vector2.up * speed);
        foreach(GameObject player in players)
        {
            if(player != null)
            {
                if (player.transform.position.y > transform.position.y + 4f)
                {
                    transform.position = new Vector3(transform.position.x, player.transform.position.y - 4f, transform.position.z);
                }
            }
        }
	}
    public void CheckIfSomeoneWon(int id)
    {
        players.RemoveAt(id);
        if (players.Count < 2)
        {
            winText.text = players[0].gameObject.tag+" has won!";
        }
        StartCoroutine(GoBackToMenu());
    }
    IEnumerator GoBackToMenu()
    {
        yield return new WaitForSeconds(2f);
        players.RemoveAt(0);
        Application.LoadLevel("Menu");
    }
}
