using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingScript : GlobalScript
{
    private float offsetHeight;
    private bool setOffset = false;
    private bool falling = true;

    private Vector3 pos;
    // Start is called before the first frame update
    void Start()
    {
        pos = this.transform.position;
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

    private void OnTriggerEnter(Collider other)
    {
        GameObject obj = other.gameObject;
        
        if(obj.tag == "ground")
        {
            float diff = pos.y + obj.transform.position.y;
            //print("This: "+ transform.name +"\nTrigger enter colliding with " + obj.name + " at" + pos + 
            //    " otherPos: " + obj.transform.position + " diff " + diff);
            offsetHeight = obj.transform.position.y + (transform.name == Base ? 1.1f : 1.8f);
            setOffset = true;
            falling = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        //print("TriggerStay colliding at "+pos);
    }

    private void enterBuilding(bool state)
    {
        print("Entering: " + this.name + " state: " + state);
    }
}
