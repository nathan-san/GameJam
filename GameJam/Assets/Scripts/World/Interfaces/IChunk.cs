using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public interface IChunk {
	void Create(List<GameObject> total, float tempX, float tempY, int destroyCount);
}
