using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundScript : GlobalScript
{
    private int health;

    // Start is called before the first frame update
    void Start()
    {
        health = 100;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        print("colliding");
        if(other.tag == "Rocket")
        {
            print("im hit!!");
        }
    }
}
