using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundScript : GlobalScript
{
    private int health;
    private Vector3 groundPos;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        health = 100;
        rb = GetComponent<Rigidbody>();
        rb.isKinematic  = true;
        rb.useGravity   = true;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        //print(this.name+": colliding with other Tag: " + other.tag + " Other name: " + other.name + 
        //    " at WorldPos: "+this.transform.position + "\nlocalPos: "+this.transform.localPosition);
        if(other.tag == "Rocket")
        {
            print("im hit!!");

        }
    }
}
