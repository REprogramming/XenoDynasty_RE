using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCntrl : MonoBehaviour {

    public GameObject cargo;
    public float speed;

    // Use this for initialization
    void Start () {
        speed = 5f; 
        cargo = GameObject.FindGameObjectWithTag("Cargo"); 		
	}
	
	// Update is called once per frame
	void Update () {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, cargo.transform.position, step);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Cargo")
        {
            Destroy(this.gameObject); 
        } 
    }
}
