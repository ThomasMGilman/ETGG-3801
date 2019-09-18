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

        if (GreaterOrLess(cfp.x, 0) || GreaterOrLess(cfp.y, 0) || GreaterOrLess(cfp.z, 0))
            print("cam fwrd: " + cfp);

        //float rotateX = Input.GetAxis("Mouse Y");
        float rotateY = Input.GetAxis("Mouse X");

        pos += cfp;
        transform.position = pos;

        Quaternion camPos = transform.rotation; //Get players CameraPos
        //camPos.x += rotateX * (camMoveSpeed * Time.deltaTime); //update forward/backward pos on x axes
        camPos.y += rotateY * (camMoveSpeed * Time.deltaTime); //update left/right pos on z axes

        transform.rotation = camPos;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Rocket")
        {
            playerHealth--;
        }
        else if(other.gameObject.tag == "Currency")
        {
            this.transform.SendMessage("incScore");
            heldCurrency += CurrencyValue;
        }
    }
}
