﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    float camOriginY, camOriginZ;

    private bool StructureMode, animateOutOfBuilding, MoveUp, JumpStart, Jumping, Falling = false;

    private Vector3 Pos, camOriginPos, CamPos, camPivPos, playersLastPos;
    private Animator PlayerAnimation;
    private Camera PlayerCam, tmp;
    private Rigidbody Rigbody;
    private SkinnedMeshRenderer playerImage;
    private Text BuildingText, ScoreText, MoneyText;
    private RawImage HealthBar;

    private GameObject buildingTouched;
    private GameObject camPivot;

    CursorLockMode wantMode;    //referenced https://docs.unity3d.com/ScriptReference/Cursor-lockState.html

    void Start()
    {
        //print(this.transform.childCount);
        PlayerAnimation = GetComponent<Animator>();
        PlayerCam = GetComponentInChildren<Camera>();     //Get players Camera
        Rigbody = GetComponent<Rigidbody>();
        playerImage = this.transform.GetChild(2).GetComponent<SkinnedMeshRenderer>();       //drawing image of player
        camPivot = this.transform.GetChild(3).gameObject;                                   //Pivot Point for the camera
        PlayerCam = camPivot.transform.GetChild(0).GetComponent<Camera>();
        BuildingText = GameObject.Find("BuildingText").GetComponent<Text>();                //Text that displays when close to building
        ScoreText = GameObject.Find("ScoreText").GetComponent<Text>();                      //Players Score
        MoneyText = GameObject.Find("CashText").GetComponent<Text>();                       //Players Money
        PlayerAnimation.speed = 2f;
        Falling = true;
        StructureMode = false;
        BuildingText.enabled = false;
        Pos = transform.position;
        CamPos = transform.rotation.eulerAngles;                //Get players CameraPos
        camPivPos = camPivot.transform.rotation.eulerAngles;    //Get CameraPivot Object angle
        camOriginPos = PlayerCam.transform.position;
        camOriginY = camOriginPos.y;
        camOriginZ = camOriginPos.z;

        SetCursorState(CursorLockMode.Locked);
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

    private void adjustToPos(out Vector3 toAdjust, Vector3 other, float yOffset = 0, float zOffset = 0)
    {
        toAdjust.x = 0; toAdjust.y = 0; toAdjust.z = 0;
        if (Pos.x != other.x || Pos.y != other.y + yOffset || Pos.z != other.z + zOffset)
        {
            if (Pos.x != other.x)           toAdjust.x = getDifAmount(other.x, Pos.x);
            if (Pos.y != other.y + yOffset) toAdjust.y = getDifAmount(other.y + yOffset, Pos.y);
            if (Pos.z != other.z + zOffset) toAdjust.z = getDifAmount(other.z + zOffset, Pos.z);
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
                PlayerCam.transform.position = camOriginPos;
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
            if (buildingTouched.name == Base)
                adjustToPos(out newPos, buildPos, 3, -1);
            else
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
            float rotateY   = getPosOffset("Mouse X");
            float pivotCam  = getPosOffset("Mouse Y");
            if (rotateY != 0)
            {
                CamPos.y += rotateY * camMoveSpeed;                 //update left/right pos on z axes
                camPivPos.y = CamPos.y;
                transform.rotation = Quaternion.Euler(CamPos);
            }
            if (pivotCam != 0)
            {
                float newPivX = camPivPos.x + pivotCam;
                if (newPivX < 60 && newPivX > -50)
                    camPivPos.x = newPivX;
                camPivot.transform.rotation = Quaternion.Euler(camPivPos);
            }
        }
    }

    private void enterBuilding()
    {
        //move into building cameraPosition
        if(StructureMode)
        {
            playersLastPos = Pos;
            camOriginPos = PlayerCam.transform.position;
            Vector3 tmp = camOriginPos;
            tmp.y = transform.position.y;
            tmp.z = transform.position.z;
            PlayerCam.transform.position = tmp;
        }
        else //move camerback
        {
            if(Pos != playersLastPos)
            {
                animateOutOfBuilding = true;
            }
        }
    }

    /// <summary>
    /// Check Inputs, and whether entering building or not
    /// </summary>
    private void checkInput()
    {
        float fireing = Input.GetAxis("Fire2");
        if (Input.GetKeyDown(KeyCode.E) && buttonDebounce <= 0)
        {
            if ((StructureMode && !BuildingText.enabled) || (!StructureMode && BuildingText.enabled))
                enterBuilding();

            StructureMode = BuildingText.enabled;
            if (StructureMode) BuildingText.enabled = false;
            buttonDebounce = .2f;
            playerImage.enabled = !StructureMode;
            if(buildingTouched != null)
                buildingTouched.SendMessage("enterBuilding", StructureMode);    //update gui display
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SetCursorState(CursorLockMode.None);
            SceneManager.LoadScene(0, LoadSceneMode.Single);
        }
        if (Input.GetKeyDown(KeyCode.Q))
            SetCursorState(CursorLockMode.None);
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            SetCursorState(CursorLockMode.Locked);
        }
        if (fireing != 0 && StructureMode && buildingTouched.name == Turret)
        {
            GameObject arrow = Instantiate(Arrow_prefab, Pos, this.transform.rotation);
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
