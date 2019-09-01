using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InvaderScript : FleetScript  
{
    private float timeSinceReset;
    private bool movefwrd = false;
    private bool mvingFwrd = false;
    private float lastX;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        Vector3 pos = transform.position;                   //position matrix
        //print("moving!! pos: "+pos);
        
        if(movefwrd)                                                    //start moving fwrd fixed distance
        {
            if(!mvingFwrd)                                                  //get position before moving fwrd and offset from wall a bit
            {
                lastX = pos.x;
                mvingFwrd = true;
                pos.z -= Zdirection * (moveSpeed * Time.deltaTime);
            }
            pos.x += 1 * (moveSpeed * Time.deltaTime);
            float newDis = pos.x - lastX;
            if (pos.x - lastX >= fwrdDistance)                              //reached distance to move fwrd, change Zdirection
                transform.parent.SendMessage("changeDir");
        }
        else
        {
            pos.z += Zdirection * (moveSpeed * Time.deltaTime);          //update left/right
            if (movefwrd)
            {
                pos.x += 1 * (moveSpeed * Time.deltaTime);
                movefwrd = false;
            }
        }
        transform.position = pos;
    }
    /*
     * Change Zdirection based off of collision or moving fixed distance forward
     * Makes sure not to update change of Zdirection right away based off of change in time as well
     */
    private void resetMovingFwrd()
    {
        if (!movefwrd)
        {
            movefwrd = true;
            timeSinceReset = Time.time;
        }
        else if(movefwrd && (Time.time - timeSinceReset > 1f))
        {
            Zdirection *= -1;
            movefwrd = false;
            mvingFwrd = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
            Destroy(this.gameObject);
        if (other.gameObject.tag == "Bumper")
        {
            transform.parent.SendMessage("changeDir");
        }
    }
}
