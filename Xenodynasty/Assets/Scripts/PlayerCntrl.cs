using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCntrl : MonoBehaviour {

    public float health; 
    public float speed;
    public float power;
    public int weaponEquipped;  
    


	// Use this for initialization
	void Start () {
        weaponEquipped = 0;
        this.gameObject.GetComponent<SphereCollider>().enabled = false;

    }
	
	// Update is called once per frame
	void Update () {     
		
	}

    public void doAttack()
    {
        switch (weaponEquipped)
        {
            case 0: // Melee
                Debug.Log("Melee Attack!");
                this.gameObject.GetComponent<SphereCollider>().enabled = true;            
                break;

            case 1: // Ranged
                break;
        }

        StartCoroutine("sheathWeapon");
    }

    IEnumerator sheathWeapon()
    {
        yield return new WaitForSeconds(0.2f);
        switch (weaponEquipped)
        {
            case 0: // Melee
                this.gameObject.GetComponent<SphereCollider>().enabled = false;
                break;

            case 1: // Ranged
                break;
        }       
    }

    void OnTriggerEnter (Collider other)
    {
        if(other.gameObject.tag == "Enemy" && this.gameObject.GetComponent<SphereCollider>().enabled == true)
        {
            Debug.Log("Enemy Hit!"); 
            Destroy(other.gameObject); 
        }
    }
}
