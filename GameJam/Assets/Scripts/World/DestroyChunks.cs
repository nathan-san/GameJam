using UnityEngine;
using System.Collections;

public class DestroyChunks : MonoBehaviour {

	private GenerateChucks _generate;
	// Use this for initialization
	void Start () {
		_generate = GetComponent<GenerateChucks> ();

	}
	
	// Update is called once per frame
	void Update () {
		CheckIfAtBoundrey ();
	}

	private void CheckIfAtBoundrey () {
		for (int i = 0; i < _generate.TilesY.Count; i++) {
			if (_generate.TilesY [i].transform.position.y + 16 < Camera.main.transform.position.y - GetCameraSize ().y) {
				_generate.RemoveTiles (_generate.TilesY [i].gameObject);
			}
		}
			
	}

	Vector2 GetCameraSize() {
		float height = 2 * Camera.main.orthographicSize;
		float width = height * Camera.main.aspect;
	
		return new Vector2 (width, height);
	}
}
