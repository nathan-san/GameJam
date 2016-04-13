using UnityEngine;
using System.Collections;

public class OutofboundsPlayer : MonoBehaviour {
	void OnBecameInvisible(){
		DestroyPlayer ();
	}

	public void DestroyPlayer(){
		Destroy (gameObject);
        if(GetComponent<PlayerID>() && GameObject.Find("Main Camera") != null)
        {
            GameObject.Find("Main Camera").GetComponent<CameraMovement>().CheckIfSomeoneWon(GetComponent<PlayerID>().ID);
        }
	}

}
