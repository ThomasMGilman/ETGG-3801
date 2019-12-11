using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private Vector3 getMoveOffset()
    {
        Vector3 offset = Vector3.zero;
        offset.x = Input.GetAxis("Horizontal");
        offset.z = Input.GetAxis("Vertical");
        print("moving: " + offset);
        return offset;
    }

    private void move()
    {
        Vector3 tmpPos = this.transform.position;
        tmpPos += getMoveOffset();
        this.transform.position = tmpPos;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
