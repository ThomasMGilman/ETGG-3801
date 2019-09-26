using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundScript : GlobalScript
{
    private Vector3 pos, groundOriginPos;
    Rigidbody rb;
    bool falling = false;

    // Start is called before the first frame update
    void Start()
    {
        pos = this.transform.position;
        groundOriginPos = pos;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(falling)
        {
            pos.y -= gravitationalConstant;
            this.transform.position = pos;
            if (pos.y < -10)
            {
                this.GetComponent<MeshRenderer>().enabled = false;
                falling = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //print(this.name+": colliding with other Tag: " + other.tag + " Other name: " + other.name + 
        //    " at WorldPos: "+this.transform.position + "\nlocalPos: "+this.transform.localPosition);
        if(other.tag == "rocket")
        {
            falling = true;
        }
    }
}
