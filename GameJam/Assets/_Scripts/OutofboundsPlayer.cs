using UnityEngine;
using System.Collections;

public class OutofboundsPlayer : MonoBehaviour {
	void OnBecameInvisible(){
		DestroyPlayer ();
	}

	public void DestroyPlayer(){
		Destroy (gameObject);
	}
}
