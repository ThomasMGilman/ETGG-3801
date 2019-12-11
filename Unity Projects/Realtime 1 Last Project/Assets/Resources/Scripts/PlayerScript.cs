using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float moveSpeed;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        this.rb = this.transform.GetComponent<Rigidbody>();
    }

    private Vector3 getMoveOffset()
    {
        Vector3 offset = Vector3.zero;
        offset.x = Input.GetAxis("Horizontal");
        offset.z = Input.GetAxis("Vertical");
        offset = this.transform.TransformDirection(offset);
        return offset * Time.deltaTime * moveSpeed;
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
        move();
    }
}
