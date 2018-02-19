using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCntrl : MonoBehaviour {

    public GameObject p1;
    public GameObject p2;
    public float cameraSpeed; 


    private float distanceBtwnPlayers;
    private Vector3 zoomOutTarget;
    private Vector3 zoomInTarget;
    private Vector3 midFocalPoint;
    private float cameraX;
    private float cameraZ; 
   
    

	// Use this for initialization
	void Start () {       
            
    }
	
	// Update is called once per frame
	void Update () {

        distanceBtwnPlayers = Vector3.Distance(p1.transform.position, p2.transform.position);
        Debug.Log("Dist. btwn players: " + distanceBtwnPlayers);

        midFocalPoint = (p1.transform.position + p2.transform.position) / 2f;     
  
        zoomOutTarget = new Vector3(this.transform.position.x, this.transform.position.y + 5f, this.transform.position.z);
        zoomInTarget = new Vector3(this.transform.position.x, this.transform.position.y - 5f, this.transform.position.z);

        if (distanceBtwnPlayers > 8f)
        {         
            zoomOut(); 
        }

        if (distanceBtwnPlayers < 8f)
        {
            zoomIn(); 
        }

        this.transform.position = new Vector3(midFocalPoint.x, this.transform.position.y, midFocalPoint.z); 

    }

    void zoomOut()
    {
        if (this.transform.position.y < 30f)
        {
            // ZoomOut              
            float step = cameraSpeed * Time.deltaTime;
            this.transform.position = Vector3.MoveTowards(transform.position, zoomOutTarget, step);
        }
    }

    void zoomIn()
    {
        if (this.transform.position.y > 15f)
        {
            // ZoomOut              
            float step = cameraSpeed * Time.deltaTime;
            this.transform.position = Vector3.MoveTowards(transform.position, zoomInTarget, step);
        }
    }

}
