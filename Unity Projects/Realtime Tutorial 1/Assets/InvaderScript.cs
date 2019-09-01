using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InvaderScript : FleetScript
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        Vector3 pos = transform.position;                   //position matrix

        pos.z += direction * (moveSpeed * Time.deltaTime);  //update left/right
        if(movefwrd)
        {
            pos.x       += 1 * (moveSpeed * Time.deltaTime);
            movefwrd    = false;
        }

        transform.position = pos;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
            Destroy(this.gameObject);
        if (other.gameObject.tag == "Bumper")
        {
            print("colliding");
            transform.parent.SendMessage("changeDir");
        }
    }
}
