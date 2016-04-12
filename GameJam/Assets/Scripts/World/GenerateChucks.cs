using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GenerateChucks : MonoBehaviour {
    [SerializeField]

    private List<GameObject> _tilesY = new List<GameObject>();

	public List<GameObject> TilesY {
		get { 
			return _tilesY;
		}
	}
    [SerializeField]
	private int _max = 5;
	private int _destroyCount;

	private IChunk _chunk;
	private WallChunk _wall;

	void Start() {
		_wall = GetComponent<WallChunk> ();
		_chunk = _wall;
	}

	void Update () {
		if (_tilesY.Count <= _max) {
            Debug.Log("create");

            _chunk.Create (_tilesY, 5, 5, _destroyCount);	
		}
	}

	public void RemoveTiles (GameObject g) {
		_tilesY.Remove (g);
		Destroy (g.gameObject);
		_destroyCount++;
	}

	public void AddTiles(GameObject g) {
		_tilesY.Add (g);
	}
}
