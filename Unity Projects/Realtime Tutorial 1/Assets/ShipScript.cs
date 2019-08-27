using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipScript : MonoBehaviour
{
    public float moveSpeed = 50.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float dz = Input.GetAxis("Horizontal");
        Vector3 pos = transform.position;           //ships position matrix
        pos.z += dz * (moveSpeed * Time.deltaTime); //update left/right position on z plane

        if(Input.GetButtonDown("Jump"))             //ships firing code
        {
            print("pewpew");
        }
        
        transform.position = pos;
    }
}
