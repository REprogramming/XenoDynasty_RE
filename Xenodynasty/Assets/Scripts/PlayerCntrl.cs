using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCntrl : MonoBehaviour {

    public float health; 
    public float speed;
    public float power;
    public int weaponEquipped;

    public Transform Slash;
    public Transform Ability1;
    public Transform Ability2;

    public int m_PlayerNumber = 1;              // Used to identify the different players.
    public Rigidbody m_Chick;                   // Prefab of the shell.
    public Transform m_FireTransform;

    public AudioSource m_ShootingAudio;         // Reference to the audio source used to play the shooting audio. NB: different to the movement audio source.

    public AudioClip m_FireClip;                // Audio that plays when each shot is fired.


    private string m_FireButton;                // The input axis that is used for launching shells.
    private float m_CurrentLaunchForce;         // The force that will be given to the shell when the fire button is released.
    private float m_ChargeSpeed;                // How fast the launch force increases, based on the max charge time.
    private bool m_Fired;                       // Whether or not the shell has been launched with this button press.
    //public string shootButton = "Fire1";
    public float shotspeed;
    public float DelayBetweenThrows = 1f;

    float lastThrowDate;
    float lastThrowDate2;


    // Use this for initialization
    void Start () {
        weaponEquipped = 0;
        GetComponent<PlayerCntrl>().Slash.GetComponent<SphereCollider>().enabled = false;
        GetComponent<PlayerCntrl>().Slash.GetComponent<Renderer>().enabled = false;
        lastThrowDate = Time.time;


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
                GetComponent<PlayerCntrl>().Slash.GetComponent<SphereCollider>().enabled = true;
                GetComponent<PlayerCntrl>().Slash.GetComponent<Renderer>().enabled = true;
                break;

            case 1: // Ranged
                break;
        
           

                
        }

        StartCoroutine("sheathWeapon");
    }

    public void doAttack2()
    {
        if ((Time.time - lastThrowDate > DelayBetweenThrows))
        {
           
                    Debug.Log("Melee Attack!");
                    //this.gameObject.GetComponent<SphereCollider>().enabled = true;
                    GetComponent<PlayerCntrl>().Ability1.GetComponent<BoxCollider>().enabled = true;
                    GetComponent<PlayerCntrl>().Ability1.GetComponent<Renderer>().enabled = true;
                    

                    lastThrowDate = Time.time;

               
            StartCoroutine("sheathWeapon");
        }
    }

    public void doAttack3()
    {
                     
                           
                
                  
                    if ((Time.time - lastThrowDate2 > DelayBetweenThrows))
                    {
                        //Stuff

                        Rigidbody shellInstance =
                        Instantiate(m_Chick, m_FireTransform.position, m_FireTransform.rotation) as Rigidbody;
                        shellInstance.velocity = shotspeed * m_FireTransform.forward;
                        lastThrowDate2 = Time.time;
                    }
                

        StartCoroutine("sheathWeapon");
    }

    IEnumerator sheathWeapon()
    {
        yield return new WaitForSeconds(0.2f);
        switch (weaponEquipped)
        {
            case 0: // Melee
                GetComponent<PlayerCntrl>().Slash.GetComponent<SphereCollider>().enabled = false;
                GetComponent<PlayerCntrl>().Slash.GetComponent<Renderer>().enabled = false;
                GetComponent<PlayerCntrl>().Ability1.GetComponent<BoxCollider>().enabled = false;
                GetComponent<PlayerCntrl>().Ability1.GetComponent<Renderer>().enabled = false;
                break;

            case 1: // Ranged
                break;
        }

     
    }

    void OnTriggerEnter (Collider other)
    {
        if(other.gameObject.tag == "Enemy" && GetComponent<PlayerCntrl>().Slash.GetComponent<SphereCollider>().enabled == true)
        {
            Debug.Log("Enemy Hit!"); 
            Destroy(other.gameObject); 
        }

        if (other.gameObject.tag == "Enemy" && GetComponent<PlayerCntrl>().Ability1.GetComponent<BoxCollider>().enabled == true)
        {
            Debug.Log("Enemy Hit!");
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "Enemy" && GetComponent<PlayerCntrl>().Ability2.GetComponent<BoxCollider>().enabled == true)
        {
            Debug.Log("Enemy Hit!");
            Destroy(other.gameObject);
        }

    }
}
