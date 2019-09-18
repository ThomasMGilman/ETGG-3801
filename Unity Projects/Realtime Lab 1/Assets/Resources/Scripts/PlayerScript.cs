using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : GlobalScript
{
    public int playerHealth = 10;
    public float playerMoveSpeed = 5f;
    public float camMoveSpeed = 1f;

    private float heldCurrency = 0;
    private float gravitationalConstant = 9.8f;

    private Vector3 pos;
    Camera playerCam;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position;
        playerCam = GetComponentInChildren<Camera>(); //Get players CameraPos
        rb = GetComponent<Rigidbody>();
        rb.useGravity = true;
        print("MyChilderenCount: " + this.transform.childCount+" MyParent:"+this.transform.parent);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private float getPosOffset(string dir)
    {
        float dirVal = Input.GetAxis(dir);
        return GreaterOrLess(dirVal, 0) ? dirVal * (playerMoveSpeed * Time.deltaTime) : 0;
    }

    private void FixedUpdate()
    {
        
        Vector3 cfp = new Vector3();
        cfp.x   = getPosOffset("Horizontal");
        cfp.z   = getPosOffset("Vertical");
        cfp     = playerCam.transform.TransformDirection(cfp);
        cfp.y = 0;

        pos += cfp;
        transform.position = pos;

        float rotateY = Input.GetAxis("Mouse X");
        Quaternion camPos = transform.rotation; //Get players CameraPos
        camPos.y += rotateY * (camMoveSpeed * Time.deltaTime); //update left/right pos on z axes

        transform.rotation = camPos;
    }

    private void OnTriggerEnter(Collider other)
    {
        print("colliding with other Tag: " + other.tag+" Other name: "+other.name);
        if (other.gameObject.tag == "ground")
        {
            rb.useGravity = false;
            print("Colliding with ground at: " + this.pos);
        }
        else if (other.gameObject.tag == "Rocket")
        {
            playerHealth--;
        }
        else if(other.gameObject.tag == "Currency")
        {
            this.transform.SendMessage("incScore");
            heldCurrency += CurrencyValue;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "ground")
        {
            rb.useGravity = true;
            print("Exiting Collision at: " + pos);
        }
    }
}
