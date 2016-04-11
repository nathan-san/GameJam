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
            Debug.Log("Jump");
        }
        if(controller.LeftStick_X < 0)
        {
            Debug.Log("left");
        }
        else if (controller.LeftStick_X >0)
        {
            Debug.Log("Right");
        }
        if(controller.X != 0)
        {
            Debug.Log("Dash!");
        }
    }

}


        
    
