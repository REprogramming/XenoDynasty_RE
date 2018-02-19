using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputCntrl : MonoBehaviour {

    public string playerPrefix = "P1_";
    public float speed;
    public float jumpForce;

    private Rigidbody playerRigidBody;
    private RaycastHit distanceToGround;

    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody>();
        distanceToGround = new RaycastHit();
    }

    void Update()
    {

        // keyboard or joystick via InputManager
        float moveX = Input.GetAxis(playerPrefix + "Horizontal");
        float moveZ = Input.GetAxis(playerPrefix + "Vertical");

        // jump
        if (Input.GetButton(playerPrefix + "Jump") && doGroundCheck())
        {
            playerRigidBody.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
        }

        Vector3 movement = new Vector3(moveX, 0.0f, moveZ);
        playerRigidBody.AddForce(movement * speed);

    }

    bool doGroundCheck()
    {
        return Physics.Raycast(transform.position, Vector3.down, 0.5f);
    }

}


