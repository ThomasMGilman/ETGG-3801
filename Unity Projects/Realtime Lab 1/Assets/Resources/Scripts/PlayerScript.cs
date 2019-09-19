using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : GlobalScript
{
    public int playerHealth = 10;
    public float playerMoveSpeed = 5f;
    public float camMoveSpeed = 1f;

    private float heldCurrency = 0;
    private float moveUpVal;
    private float heightFromCube = 1.000001f;

    private bool moving = false;
    private bool falling = false;
    private bool moveUp;

    private Vector3 pos;
    Animator playerAnimation;
    Camera playerCam;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position;
        playerAnimation = GetComponent<Animator>();
        playerCam = GetComponentInChildren<Camera>(); //Get players CameraPos
        rb = GetComponent<Rigidbody>();
        falling = true;
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
        rb = GetComponent<Rigidbody>();

        Vector3 cfp = new Vector3();
        cfp.x   = getPosOffset("Horizontal");
        cfp.z   = getPosOffset("Vertical");
        cfp     = playerCam.transform.TransformDirection(cfp);
        cfp.y = 0;

        if(falling)
        {
            cfp.y -= gravitationalConstant;
        }

        if(moveUp)
        {
            cfp.y += moveUpVal;
            moveUp = false;
        }

        if( cfp.x != 0 || cfp.z != 0)
        {
            moving = true;
            playerAnimation.SetBool("moving", moving);
        }
        else
        {
            moving = false;
            playerAnimation.SetBool("moving", moving);
        }
        

        pos += cfp;
        transform.position = pos;

        float rotateY = Input.GetAxis("Mouse X");
        Quaternion camPos = transform.rotation; //Get players CameraPos
        camPos.y += rotateY * (camMoveSpeed * Time.deltaTime); //update left/right pos on z axes

        transform.rotation = camPos;
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject obj = other.gameObject;
        //print("colliding with other Tag: " + obj.tag+" Other name: "+ obj.name+ "\notherPos: "+obj.transform.position + " OtherLocalPos: "+obj.transform.localPosition);
        if (obj.tag == "ground")
        {
            falling = false;
            //float diff2 = pos.y - obj.transform.localPosition.y;
            float diff = pos.y - obj.transform.position.y;
            //print("colliding with ground, gPosLocalY: " + obj.transform.localPosition.y + " myPos: " + pos.y + " diff: "+diff2);
            //print("colliding with ground, gPosWorldY: " + obj.transform.position.y + " myPos: " + pos.y + " diff: " + diff);
            if (diff < heightFromCube)
            {
                moveUp = true;
                moveUpVal = heightFromCube - diff;
                //print("moving up: " + moveUpVal + " my pos: " + pos);
            }
        }
        else if (obj.tag == "Rocket")
        {
            playerHealth--;
        }
        else if(obj.tag == "Currency")
        {
            this.transform.SendMessage("incScore");
            heldCurrency += CurrencyValue;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        GameObject obj = other.gameObject;
        if(obj.tag == "ground")
        {
            falling = false;
        }
    }


    private void OnTriggerExit(Collider other)
    {
        GameObject obj = other.gameObject;
        if (obj.tag == "ground")
        {
            falling = true;
            //print("Exiting Collision at: " + pos);
        }
    }
}
