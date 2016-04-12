using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    [SerializeField]
    private float gravity = 10f;
    [SerializeField]
    private float maxspeed = 100f;
    [SerializeField]
    private float maxGravity = 100f;
    [SerializeField]
    private float jumpForce = 100f;
    [SerializeField]
    private bool stopsWithJumpWhenPressingUp = false;
    
    private float aceleration = 5f;
    
    private float Xspeed = 0;
    private float Yspeed = 0;
    private bool grounded = false;
    private bool walled = false;
    private bool left = false;
    private bool right = true;
    private int jumpCounter = 1;
    private bool sliding = false;

    private Animator animator;
    void Start () {
       //animator = GetComponent<Animator>();
    }

    
    void Update()
    {
       
        GravityHandler();
        JumpPlayer();
        MovePlayer();
        if(sliding && !walled)
        {
            Yspeed = 0;
            if(left)
            {
                Xspeed = -maxspeed;
            }
            else
            {
                Xspeed = maxspeed;
            }
        }
    }
    IEnumerator Slide()
    {
        sliding = true;
        yield return new WaitForSeconds(0.3f);
        sliding = false;
    }
    void GravityHandler()
    {
        if (grounded)
        {
            Yspeed = 0;
            jumpCounter = 0;
        }
        else if (walled)
        {
            if (Yspeed > -maxGravity / 4)
            {
                Yspeed -= gravity;
            }
            else
            {
                //Yspeed -= gravity / 2;
            }
        }
        else
        {
            //gravity will kick in if the player is in the air.
            if (Yspeed >= -maxGravity)
            {
                Yspeed -= gravity;
            }
        }

    }
    void JumpPlayer()
    {
        //if the player stop pressing the up button, the player will make small jumps.
        if (Input.GetKey("up"))
        {
            if (grounded)
            {
                //jump
                Yspeed = jumpForce;
                jumpCounter++;
            }
            else if (Input.GetKeyDown("up"))
            {
                if (walled)
                {
                    //walljump
                    Yspeed = jumpForce;
                    jumpCounter = 1;

                    if (left)
                    {
                        Xspeed = maxspeed / 1f;
                        ChangeDirection(true);
                    }
                    else if (right)
                    {
                        Xspeed = -maxspeed / 1f;
                        ChangeDirection(false);
                    }
                    
                }
                else if (jumpCounter < 2)
                {
                    Debug.Log(jumpCounter);
                    jumpCounter++;
                    Yspeed = maxGravity;
                }

            }
        }
        else if (!grounded && Yspeed > 0)
        {
            //stops with jumping
            if (!walled && stopsWithJumpWhenPressingUp)
            {
                Yspeed = 0;
            }


        }
    }
    void MovePlayer()
    {

        //slide event
        if (Input.GetKeyDown("space")&& !sliding)
        {
            StartCoroutine(Slide());
        }
        //moves the player
        if (Input.GetKey("left") && Xspeed > -maxspeed && !sliding)
        {
            //animator.SetBool("movesHorizontal",true);
            ChangeDirection(false);
            if (Xspeed > maxspeed / 2f)
            {
                Xspeed -= aceleration;
            }
            Xspeed -= aceleration;
        }
        else if (Input.GetKey("right") && Xspeed < maxspeed && !sliding)
        {
            //animator.SetBool("movesHorizontal", true);

            ChangeDirection(true);
            if (Xspeed < -maxspeed / 2f)
            {
                Xspeed += aceleration;
            }
            Xspeed += aceleration;
        }
        else 
        {
            float friction = aceleration;
            if (!grounded)
            {
                friction = 0f;
            }
            
            //stops the player
            if (Xspeed < -friction)
            {
                Xspeed += friction;
            }
            else if (Xspeed > friction)
            {
                Xspeed -= friction;
            }
            else
            {
                //to makes sure the player doesnt move after being stopped to move.
                Xspeed = 0;
            }

        }

        if(Input.GetKey("left") == false && Input.GetKey("right") == false)
        {
            //animator.SetBool("movesHorizontal", false);
        }
    }
    void FixedUpdate () {
        //translates the player with the x and y speed that is declared in the update function.
        transform.Translate(Xspeed/1000f,Yspeed/1000f,0f);
	}
    void ChangeDirection(bool faceRight)
    {
        if(faceRight)
        {
            left = false;
            right = true;
            transform.localScale = new Vector3(1, 1, 1);
            if(Xspeed == 0)
            {
                Xspeed = 3;
            }
        }
        else
        {
            left = true;
            right = false;
            transform.localScale = new Vector3(-1, 1, 1);
            if (Xspeed == 0)
            {
                Xspeed = -3;
            }
        }

    }
    void OnCollisionEnter2D(Collision2D other)
    {
        //you know what this does! ;) 
        if (other.gameObject.tag == "ground")
        {
            grounded = true;
            
        }
        else if (other.gameObject.tag == "wall")
        {
            walled = true;
            Xspeed = 0;
            Yspeed = 0;
            
        }


    }
    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "ground")
        {
            grounded = false;
        }
        else if (other.gameObject.tag == "wall")
        {
            walled = false;
        }
    }
}
