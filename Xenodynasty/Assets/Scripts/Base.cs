using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Base : MonoBehaviour
{

    public GameObject cargo;
    public float speed;
    public int Damage = 0;
    public Text Text1;
    public Text losetext;


    // Use this for initialization
    void Start()
    {
        speed = 5f;
        cargo = GameObject.FindGameObjectWithTag("Cargo");
    }

    // Update is called once per frame
    void Update()
    {
       

        Text1.text = "Base Damage: " + Damage.ToString();

        if (Damage >= 5)
        {
            losetext.text = "Your base has been destroyed. You Lose";
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            GetComponent<Base>().Damage += 1;
            Destroy(other.gameObject);
        }
    }
}
