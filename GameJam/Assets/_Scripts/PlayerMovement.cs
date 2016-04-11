using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour {

    Controller controller;
    
    void Start () {
        controller = GetComponent<Controller>();
    }


    void FixedUpdate()
    {
        if(controller.A != 0)
        {
        }
    }

}


        
    
