using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : GlobalScript
{
    [HideInInspector]
    public int score = 0;

    public int playerHealth = 10;
    public float playerMoveSpeed = 5f;
    public float jumpHeight = 2f;
    public float camMoveSpeed = 1f;

    private float remainingJump = 0;
    private float playerFallSpeed = 0;
    private float moneyheld = 0;
    private float moveUpVal;
    private float heightFromCube = 1.000001f;

    private bool StructureMode, MoveUp, JumpStart, Jumping, Falling = false;

    private Vector3 Pos, CamPos;
    private Animator PlayerAnimation;
    private Camera PlayerCam, tmp;
    private Rigidbody Rigbody;
    private Text BuildingText, ScoreText, MoneyText;
    private RawImage HealthBar;

    private GameObject buildingTouched;

    CursorLockMode wantMode;    //referenced https://docs.unity3d.com/ScriptReference/Cursor-lockState.html

    void Start()
    {
        Pos = transform.position;
        CamPos = transform.rotation.eulerAngles;                //Get players CameraPos
        PlayerAnimation = GetComponent<Animator>();
        PlayerCam       = GetComponentInChildren<Camera>();     //Get players Camera
        Rigbody         = GetComponent<Rigidbody>();
        BuildingText    = GameObject.Find("BuildingText").GetComponent<Text>();
        ScoreText       = GameObject.Find("ScoreText").GetComponent<Text>();
        MoneyText       = GameObject.Find("CashText").GetComponent<Text>();
        PlayerAnimation.speed = 2f;
        Falling = true;
        StructureMode = false;
    }

    void Update()
    {

    }

    private void getPosYOffset(out float posY)
    {
        posY = 0;
        float jumpAmount = getPosOffset("Jump");
        if(!Falling && !Jumping && jumpAmount > 0)
        {
            Jumping = true;
            remainingJump = jumpHeight;
        }
        if (Jumping)
        {
            if (remainingJump <= 0) { Jumping = false; Falling = true; }
            else
            {
                if (jumpAmount <= 0)
                {
                    Jumping = false;
                    Falling = true;
                    remainingJump = 0;
                }
                else
                {
                    remainingJump -= jumpAmount;
                    posY += jumpAmount;
                }
            }
        }
        else if (Falling)
        {
            playerFallSpeed += gravitationalConstant * Time.deltaTime;
            //print("FallSpeed: " + playerFallSpeed);
            posY -= playerFallSpeed;
        }
        else if (MoveUp) { posY += moveUpVal; MoveUp = false; }
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
        if (!StructureMode)
        {
            newPos.x = getPosOffset("Horizontal");
            newPos.z = getPosOffset("Vertical");
            newPos = PlayerCam.transform.TransformDirection(newPos);
            getPosYOffset(out newPos.y);

            PlayerAnimation.SetBool("moving", (newPos.x != 0 || newPos.z != 0)); //if either x or z movement not 0 moving animation is true
        }
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
                CamPos.y += rotateY * camMoveSpeed;                 //update left/right pos on z axes
                transform.rotation = Quaternion.Euler(CamPos);
            }
        }
    }

    /// <summary>
    /// Check Inputs
    /// </summary>
    private void checkInput()
    {
        if (Input.GetAxis("Submit") != 0)
        {
            if(BuildingText.enabled && !StructureMode)
            {
                StructureMode = true;
                buildingTouched.SendMessage("enterBuilding");
            }
        }
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
        Pos += getPosOffest();
        transform.position = Pos;
        updateCamera();
    }

    private void groundCollision(GameObject obj, bool colliding)
    {
        if(colliding)
        {
            Falling = false;
            Jumping = false;
            playerFallSpeed = 0;
            float diff = Pos.y - obj.transform.position.y;
            if (diff < heightFromCube)
            {
                MoveUp = true;
                moveUpVal = heightFromCube - diff;
            }
        }
        else
            Falling = true;
    }

    private void moneyCollision(GameObject obj)
    {
        Destroy(obj);
        moneyheld += CurrencyValue;
        score += 100;
        ScoreText.text = "Score: " + score;
        MoneyText.text = "Money: " + moneyheld;
    }

    private void rocketCollision(GameObject obj)
    {
        playerHealth--;
        //possible knockback
    }

    private void structureCollision(GameObject obj, bool colliding)
    {
        if(colliding)
        {
            BuildingText.enabled = true;
            buildingTouched = obj;
        } 
        else
            BuildingText.enabled = false;
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
                structureCollision(obj, true);
                break;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        GameObject obj = other.gameObject;
        switch (obj.tag)
        {
            case "ground":
                if(Falling)
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
            case "structure":
                structureCollision(obj, false);
                break;
        }
    }

    void SetCursorState()
    {
        Cursor.lockState = wantMode;
        Cursor.visible = (CursorLockMode.Locked != wantMode);
    }
}
