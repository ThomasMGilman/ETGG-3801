using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretScript : GlobalScript
{
    private float offsetHeight;
    private bool setOffset = false;
    private bool falling = true;

    private Vector3 pos;
    private Vector3 rayDir;
    // Start is called before the first frame update
    void Start()
    {
        pos = this.transform.position;
        rayDir = new Vector3(0, 1, 0);
        checkInGround();
        //print("Turret at " + pos);
    }

    // Update is called once per frame
    void Update()
    {
        if(falling)
        {
            pos.y -= gravitationalConstant;
        }
        if(setOffset)
        {
            pos.y = offsetHeight;
            setOffset = false;
        }
        this.transform.position = pos;
    }

    private void checkInGround()
    {
        //raycast for Invaders to know wether or not to fire
        RaycastHit hit;
        int layer_mask = 1 << 8;
        if (Physics.Raycast(pos, rayDir, out hit, 10.0f, layer_mask))
        {
            this.pos = hit.transform.position;
            print("Hitting the ground, my pos: "+this.pos);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject obj = other.gameObject;
        
        if(obj.tag == "ground")
        {
            float diff = pos.y + obj.transform.position.y;
            //print("Trigger enter colliding with " + obj.name + " at" + pos + 
            //    " otherPos: " + obj.transform.position + " diff " + diff);
            offsetHeight = obj.transform.position.y + 1.8f;
            setOffset = true;
            falling = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        //print("TriggerStay colliding at "+pos);
    }
}
