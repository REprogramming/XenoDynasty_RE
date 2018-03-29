using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputCntrl : MonoBehaviour {

    public string playerPrefix;

    private Vector3 moveVector;
    [SerializeField] private float moveSpeed = 10.0f;

    private Vector3 lookVector;
    private float m_LookAngleInDegrees;
    public float m_damping = 10.0f;

    private Rigidbody playerRigidBody;
    private RaycastHit distanceToGround;
    public Color defaultMaterial;

    public Camera Camera; 

    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody>();
        distanceToGround = new RaycastHit();
        defaultMaterial = this.gameObject.GetComponent<Renderer>().material.color;

        //var camera = Camera;
        //var forward = camera.transform.forward;
        //var right = camera.transform.right;
        //forward.y = 0f;
        //right.y = 0f;
        //forward.Normalize();
        //right.Normalize();

    }

    void GetInput()
    {
        moveVector.x = Input.GetAxis(playerPrefix + "Horizontal");
        moveVector.z = Input.GetAxis(playerPrefix + "Vertical");

        lookVector.x = Input.GetAxis(playerPrefix + "RHorizontal");
        lookVector.y = Input.GetAxis(playerPrefix + "RVertical");
    }

    void ProcessInput()
    {

        Vector3 direction = Camera.main.transform.forward;
        direction.y = 0;

        transform.position += moveVector * moveSpeed * Time.deltaTime;

        //transform.Translate(moveVector * Time.deltaTime * moveSpeed); //moving the player
        

        if (lookVector.x != 0.0f || lookVector.y != 0.0f)
        {
            m_LookAngleInDegrees = Mathf.Atan2(lookVector.x, lookVector.y) * Mathf.Rad2Deg;
            Quaternion eulerAngle = Quaternion.Euler(0.0f, m_LookAngleInDegrees, 0.0f);
            transform.rotation = Quaternion.Lerp(transform.rotation, eulerAngle, Time.deltaTime * m_damping);
        }
    }

    void Update()
    {
        GetInput();
        ProcessInput();

        if (Input.GetButtonDown(playerPrefix + "Fire1"))
        {
            Debug.Log(playerPrefix + "Fire1 has been pressed");         
            this.gameObject.GetComponent<PlayerCntrl>().doAttack();           
        }

        if (Input.GetButtonDown(playerPrefix + "Fire2"))
        {
            Debug.Log(playerPrefix + "Fire1 has been pressed");
            this.gameObject.GetComponent<PlayerCntrl>().doAttack2();
        }

        if (Input.GetButtonDown(playerPrefix + "Fire3"))
        {
            Debug.Log(playerPrefix + "Fire1 has been pressed");
            this.gameObject.GetComponent<PlayerCntrl>().doAttack3();
        }
    }
}


