using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CargoCntrl : MonoBehaviour {

    public Transform startPoint;
    public Transform endPoint;
    public float cargoHealth; 
    public float cargoSpeed;

    // Use this for initialization
    void Start () {
        transform.position = startPoint.transform.position; 
		
	}
	
	// Update is called once per frame
	void Update () {
        float step = cargoSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, endPoint.position, step);

    }
}
