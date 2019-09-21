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

    private bool moveUp, falling = false;

    private Vector3 pos, camPos;
    Animator playerAnimation;
    Camera playerCam;
    Rigidbody rb;

    CursorLockMode wantMode;    //referenced https://docs.unity3d.com/ScriptReference/Cursor-lockState.html

    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position;
        camPos = transform.rotation.eulerAngles;        //Get players CameraPos
        playerAnimation = GetComponent<Animator>();
        playerCam = GetComponentInChildren<Camera>();   //Get players Camera
        rb = GetComponent<Rigidbody>();
        playerAnimation.speed = 2f;  
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

    /// <summary>
    /// Return Vector3 of movement change
    /// </summary>
    /// <returns></returns>
    private Vector3 getPosOffest()
    {
        Vector3 newPos = new Vector3();
        newPos.x = getPosOffset("Horizontal");
        newPos.z = getPosOffset("Vertical");
        newPos = playerCam.transform.TransformDirection(newPos);
        newPos.y = 0;

        if (falling)  newPos.y -= gravitationalConstant * Time.deltaTime;
        if (moveUp) { newPos.y += moveUpVal; moveUp = false; }
        playerAnimation.SetBool("moving", (newPos.x != 0 || newPos.z != 0)); //if either x or z movement not 0 moving animation is true

        return newPos;
    }

    /// <summary>
    /// Update Camera Position of Player
    /// </summary>
    private void updateCamera()
    {
        if(wantMode == CursorLockMode.Locked)
        {
            float rotateY = getPosOffset("Mouse X");
            if (rotateY != 0)
            {
                camPos.y += rotateY * camMoveSpeed;                 //update left/right pos on z axes
                transform.rotation = Quaternion.Euler(camPos);
            }
        }
    }

    /// <summary>
    /// Check Inputs
    /// </summary>
    private void checkInput()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = wantMode = CursorLockMode.None;
            SetCursorState();
        }
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Cursor.lockState = wantMode = CursorLockMode.Locked;
            SetCursorState();
        }
    }

    private void FixedUpdate()
    {
        checkInput();
        pos += getPosOffest();
        transform.position = pos;
        updateCamera();
    }

    private void groundCollision(GameObject obj, bool colliding)
    {
        if(colliding)
        {
            falling = false;
            float diff = pos.y - obj.transform.position.y;
            if (diff < heightFromCube)
            {
                moveUp = true;
                moveUpVal = heightFromCube - diff;
            }
        }
        else
            falling = true;
    }

    private void moneyCollision(GameObject obj)
    {
        Destroy(obj);
        heldCurrency += CurrencyValue;
        score += 100;
    }

    private void rocketCollision(GameObject obj)
    {
        playerHealth--;
        //possible knockback
    }

    private void structureCollision(GameObject obj)
    {
        //adjust camera and window view
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject obj = other.gameObject;
        //print("colliding with other Tag: " + obj.tag+" Other name: "+ obj.name+ "\notherPos: "+obj.transform.position + " OtherLocalPos: "+obj.transform.localPosition);
        switch (obj.tag)
        {
            case "ground":
                groundCollision(obj, true);
                break;
            case "money":
                moneyCollision(obj);
                break;
            case "rocket":
                rocketCollision(obj);
                break;
            case "structure":
                structureCollision(obj);
                break;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        GameObject obj = other.gameObject;
        switch (obj.tag)
        {
            case "ground":
                if(falling)
                    groundCollision(obj, true);
                break;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        GameObject obj = other.gameObject;
        switch (obj.tag)
        {
            case "ground":
                groundCollision(obj, false);
                break;
        }
    }

    void SetCursorState()
    {
        Cursor.lockState = wantMode;
        Cursor.visible = (CursorLockMode.Locked != wantMode);
    }
}
