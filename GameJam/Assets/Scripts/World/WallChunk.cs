using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WallChunk : MonoBehaviour, IChunk {
	[SerializeField]private GameObject _parent;
	[SerializeField]private GameObject _tile;
	private GenerateChucks _generate;
    [SerializeField]
    private float chunkHeigth = 9f;
	void Awake () {
		_generate = GetComponent<GenerateChucks> ();
	}

	public void Create(List<GameObject> total, float tempX, float tempY, int destroyCount) {
		for (int y = 0; y < tempY; y++) {
            Debug.Log("create");
			//GameObject gplus = Instantiate (_tile, new Vector3(tempX, (1 * total.Count / 2) + destroyCount / 2, 0), Quaternion.identity) as GameObject;
			GameObject gmin = Instantiate (_tile, new Vector3(_tile.transform.position.x,( chunkHeigth* total.Count) + destroyCount * chunkHeigth, _tile.transform.position.z), Quaternion.identity) as GameObject;
			//_generate.AddTiles (gplus);
			_generate.AddTiles (gmin);
		}
	}
}
