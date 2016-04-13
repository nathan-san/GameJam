using UnityEngine;
using System.Collections;

public class PlayerID : MonoBehaviour {
    [SerializeField]
    private int id;
    public int ID
    {
        get { return id; }
        set { ID = value; }
    }
}
