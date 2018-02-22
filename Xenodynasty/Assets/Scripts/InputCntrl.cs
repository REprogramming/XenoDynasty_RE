using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputCntrl : MonoBehaviour {

    public string playerPrefix;
    public float speed;  

    private Rigidbody playerRigidBody;
    private RaycastHit distanceToGround;
    public Color defaultMaterial; 

    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody>();
        distanceToGround = new RaycastHit();
        defaultMaterial = this.gameObject.GetComponent<Renderer>().material.color; 
    }

    void Update()
    {
        // keyboard or joystick via InputManager
        float moveX = Input.GetAxis(playerPrefix + "Horizontal");
        float moveZ = Input.GetAxis(playerPrefix + "Vertical");

        Vector3 movement = new Vector3(moveX, 0.0f, moveZ);
        playerRigidBody.AddForce(movement * speed);

        if (Input.GetButtonUp(playerPrefix + "Fire1"))
        {
            Debug.Log(playerPrefix + "Fire1 has been pressed");         
            this.gameObject.GetComponent<PlayerCntrl>().doAttack();           
        }

    }

    bool doGroundCheck()
    {
        return Physics.Raycast(transform.position, Vector3.down, 0.5f);
    }

   
   

}


