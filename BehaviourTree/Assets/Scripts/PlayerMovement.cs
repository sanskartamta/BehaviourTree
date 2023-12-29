using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController playercontroller;

    private float movespeed = 10f;

    public float runspeed = 10f;
    public float walkspeed = 5f;

    public float g;

    public Vector3 velocity;

    public LayerMask ground;

    public bool onGround;
    public Transform checkSpherePosition;

    public float checkRadius;
    public float jumpHeight;
    public bool isWalking;
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            movespeed = runspeed;
            isWalking = false;
        }
        else
        {
            movespeed = walkspeed;
            isWalking = true;
        }
        onGround = Physics.CheckSphere(checkSpherePosition.position, checkRadius, ground );
        if(onGround == true)
        {
            velocity.y = -1f;
        }
        else
        {
            velocity.y -= g * Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.Space) && onGround==true)
        {
            velocity.y = jumpHeight;
        }

        playercontroller.Move(velocity);

        float x = Input.GetAxis("Horizontal") * movespeed * Time.deltaTime;
        float y = Input.GetAxis("Vertical") * movespeed * Time.deltaTime;

        playercontroller.Move(transform.forward * y);
        playercontroller.Move(transform.right * x);

    }
}
