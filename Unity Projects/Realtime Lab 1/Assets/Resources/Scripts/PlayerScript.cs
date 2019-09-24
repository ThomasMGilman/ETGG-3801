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

    private float buttonDebounce = 0f;

    private bool StructureMode, animateOutOfBuilding, MoveUp, JumpStart, Jumping, Falling = false;

    private Vector3 Pos, CamPos, playersLastPos;
    private Animator PlayerAnimation;
    private Camera PlayerCam, tmp;
    private Rigidbody Rigbody;
    private SkinnedMeshRenderer playerImage;
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
        playerImage     = GameObject.Find("PlayerImage").GetComponent<SkinnedMeshRenderer>();
        BuildingText    = GameObject.Find("BuildingText").GetComponent<Text>();
        ScoreText       = GameObject.Find("ScoreText").GetComponent<Text>();
        MoneyText       = GameObject.Find("CashText").GetComponent<Text>();
        PlayerAnimation.speed = 2f;
        Falling = true;
        StructureMode = false;
        BuildingText.enabled = false;
    }

    void Update()
    {
        if (buttonDebounce > 0) buttonDebounce -= .1f * Time.deltaTime;
        checkInput();
    }

    private void FixedUpdate()
    {
        Pos += getPosOffest();
        transform.position = Pos;
        updateCamera();
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

    float getDifAmount(float posX, float otherX)
    {
        return (posX - otherX);
    }

    private void adjustToPos(out Vector3 toAdjust, Vector3 other, float yOffset = 0)
    {
        toAdjust.x = 0; toAdjust.y = 0; toAdjust.z = 0;
        if (Pos.x != other.x || Pos.y != other.y + 2 || Pos.z != other.z)
        {
            if (Pos.x != other.x)           toAdjust.x = getDifAmount(other.x, Pos.x);
            if (Pos.y != other.y + yOffset) toAdjust.y = getDifAmount(other.y + yOffset, Pos.y);
            if (Pos.z != other.z)           toAdjust.z = getDifAmount(other.z, Pos.z);
        }
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
            if(animateOutOfBuilding)
            {
                adjustToPos(out newPos, playersLastPos);
                if (Pos == playersLastPos) animateOutOfBuilding = false;
            }
            else
            {
                newPos.x = getPosOffset("Horizontal");
                newPos.z = getPosOffset("Vertical");
                newPos = PlayerCam.transform.TransformDirection(newPos);
                getPosYOffset(out newPos.y);

                PlayerAnimation.SetBool("moving", (newPos.x != 0 || newPos.z != 0)); //if either x or z movement not 0 moving animation is true
            }
        }
        else
        {
            Vector3 buildPos = buildingTouched.transform.position;
            adjustToPos(out newPos, buildPos, 2);
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

    private void enterBuilding()
    {
        //move into building cameraPosition
        if(StructureMode)
        {
            playersLastPos = Pos;
            if (buildingTouched.name == Base)
            {

            }
            else if (buildingTouched.name == Turret)
            {

            }
            else
                print("Cannot enter a nonStructure object!!! what are you trying to enter?! : " + buildingTouched.name);
        }
        else //move camerback
        {
            if(Pos != playersLastPos)
                animateOutOfBuilding = true;
        }
    }

    /// <summary>
    /// Check Inputs
    /// </summary>
    private void checkInput()
    {
        if (Input.GetKeyDown(KeyCode.E) && buttonDebounce <= 0) ////WORK ON THIS HERE
        {
            StructureMode = BuildingText.enabled;
            if (StructureMode) BuildingText.enabled = false;
            else BuildingText.enabled = true;
            buttonDebounce = .2f;

            playerImage.enabled = !StructureMode;
            buildingTouched.SendMessage("enterBuilding", StructureMode);    //update gui display
            enterBuilding();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SetCursorState(CursorLockMode.None);
        }
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            SetCursorState(CursorLockMode.Locked);
        }
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
            buildingTouched = obj;
        BuildingText.enabled = colliding;
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

    private void SetCursorState(CursorLockMode state)
    {
        Cursor.lockState = wantMode = state;
        Cursor.visible = (CursorLockMode.Locked != wantMode);
    }
}
