using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour
{
    PlayerMovement player;

    private float f_leftStick_X;
    private float f_A;
    private float f_X;

    [SerializeField]
    private int i_joystickNumber;
    private string joystickString;

    void Start() {
        player = GetComponent<PlayerMovement>();
        ControllerToPlayer();
        

    }


    void ControllerToPlayer()
    {
        // Makes it so that the playerTag assigned to an object equals the joystickNumber of the Controller
        switch (player.gameObject.tag)
        {
            case Tags.str_player1:
                i_joystickNumber = 1;
                break;
            case Tags.str_player2:
                i_joystickNumber = 2;
                break;
            case Tags.str_player3:
                i_joystickNumber = 3;
                break;
            case Tags.str_player4:
                i_joystickNumber = 4;
                break;
            default:
                i_joystickNumber = 0;
                break;
        }
        joystickString = i_joystickNumber.ToString();
    }

    // Getters & Setters
    public float LeftStick_X {
        get { return f_leftStick_X; }
        set { f_leftStick_X = value; }
    }

    public float A
    {
        get { return f_A; }
        set { f_A = value; }
    }

    public float X
    {
        get { return f_X; }
        set { f_X = value; }
    }

    void FixedUpdate()
    {
        f_leftStick_X = Input.GetAxis("LeftJoystickX_P" + joystickString);
        f_A = Input.GetAxis("A_P" + joystickString);
        f_X = Input.GetAxis("X_P" + joystickString);
    }
}

