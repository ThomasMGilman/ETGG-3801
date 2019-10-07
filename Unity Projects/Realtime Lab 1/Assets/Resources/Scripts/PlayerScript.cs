using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerScript : GlobalScript
{
    [HideInInspector]
    public int score = 0;

    public float playerMoveSpeed = 5f;
    public float playerRunSpeed = 20f;
    public float jumpHeight = 2f;
    public float camMoveSpeed = 1f;

    public float reticleMaxDistance = 100f; //a multiplier of the forward pos
    private float reticleDistance = 1f;     //current Reticle Distance multiplier

    private int moneyheld = 0;
    private float remainingJump = 0;
    private float runRate;
    private float playerFallSpeed = 0;
    private float moveUpVal;
    private float heightFromCube = 1.000001f;

    private float EnterDebounce = 0f, fireDebounce1 = 0, fireDebounce2 = 0;
    float camOriginY, camOriginZ;

    private bool StructureMode, animateOutOfBuilding, MoveUp, JumpStart, Jumping, Falling = false;

    private Vector3 camOriginPos, camOriginRotation, playerOriginRotation;
    private Vector3 Pos, CamPos, camPivPos, playersLastPos;
    private Animator PlayerAnimation;
    private Camera PlayerCam, tmp;
    private Rigidbody Rigbody;
    private SkinnedMeshRenderer playerImage;
    private Text BuildingText, ScoreText, MoneyText;
    private RawImage HealthBar, ShotHeightView;

    private GameObject buildingTouched;
    private GameObject camPivot;
    private GameObject playerReticle;
    private GameObject arrowDestinationBox;

    CursorLockMode wantMode;    //referenced https://docs.unity3d.com/ScriptReference/Cursor-lockState.html

    void Start()
    {
        //print(this.transform.childCount);
        runRate = playerMoveSpeed;
        PlayerAnimation = GetComponent<Animator>();
        Rigbody = GetComponent<Rigidbody>();
        playerImage = this.transform.GetChild(2).GetComponent<SkinnedMeshRenderer>();       //drawing image of player
        camPivot = this.transform.GetChild(3).gameObject;                                   //Pivot Point for the camera
        PlayerCam = camPivot.transform.GetChild(0).GetComponent<Camera>();
        BuildingText = GameObject.Find("BuildingText").GetComponent<Text>();                //Text that displays when close to building
        ScoreText = GameObject.Find("ScoreText").GetComponent<Text>();                      //Players Score
        MoneyText = GameObject.Find("CashText").GetComponent<Text>();                       //Players Money
        ShotHeightView = GameObject.Find("ShotHeightView").GetComponent<RawImage>();        //get the height minimap
        playerReticle = this.transform.GetChild(5).gameObject;                              //playersReticle while in turret
        arrowDestinationBox = Resources.Load<GameObject>("Prefabs/arrowDestination");
        ShotHeightView.enabled = false;
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
        if (EnterDebounce > 0) EnterDebounce -= .1f * Time.deltaTime;
        checkInput();
    }

    private void FixedUpdate()
    {
        Pos += getPosOffest();
        transform.position = Pos;
        if(animateOutOfBuilding)
        {
            animateOutOfBuilding = false;
            transform.position = playersLastPos;
            transform.rotation = Quaternion.Euler(playerOriginRotation);
            PlayerCam.transform.position = camOriginPos;
            PlayerCam.transform.rotation = Quaternion.Euler(camOriginRotation);
        }
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
            if (posY < -9) gameOver();
        }
        else if (MoveUp) { posY += moveUpVal; MoveUp = false; }
    }

    private float getPosOffset(string dir)
    {
        float dirVal = Input.GetAxis(dir);
        return GreaterOrLess(dirVal, 0) ? dirVal * (runRate * Time.deltaTime) : 0;
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

            float reticleAdjust = getPosOffset("Vertical");
            float newRet = reticleDistance + reticleAdjust;
            if (!(newRet > reticleMaxDistance) && !(newRet < 1) && newRet != reticleDistance)
            {
                reticleDistance = newRet;
                print("ReticleDistance: " + reticleDistance);
            }
                
            Vector3 newRetPos = this.transform.position + PlayerCam.transform.forward * reticleDistance;
            if (newRetPos != playerReticle.transform.position)
            {
                playerReticle.transform.position = newRetPos;
                //print("PlayerPos: " + this.transform.position + " RetPos: " + playerReticle.transform.position);
            }   
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
        print("Entering Structure: " + StructureMode);
        StructureMode = BuildingText.enabled;
        ShotHeightView.enabled = StructureMode;
        playerReticle.GetComponent<MeshRenderer>().enabled = StructureMode;
        //move into building cameraPosition
        if(StructureMode)
        {
            playersLastPos = Pos;
            playerOriginRotation = this.transform.rotation.eulerAngles;
            camOriginPos = PlayerCam.transform.position;
            camOriginRotation = PlayerCam.transform.rotation.eulerAngles;
            playerReticle.transform.position = this.transform.position;
            reticleDistance = 1;

            Vector3 tmp = camOriginPos;
            tmp.x = transform.position.x;
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

    private void checkenterBuilding()
    {
        if ((StructureMode && !BuildingText.enabled) || (!StructureMode && BuildingText.enabled))
            enterBuilding();

        if (StructureMode) BuildingText.enabled = false;
        EnterDebounce = .2f;
        playerImage.enabled = !StructureMode;
        if (buildingTouched != null)
            buildingTouched.SendMessage("enterBuilding", StructureMode);    //update gui display
    }

    private void fireRocket()
    {
        Vector3 tmp = Pos;
        //tmp.y += 2;
        GameObject destinationBox = Instantiate(arrowDestinationBox, playerReticle.transform.position, arrowDestinationBox.transform.rotation);
        print(destinationBox.name+": "+destinationBox.transform.position);
        Vector3 camEuler = PlayerCam.transform.eulerAngles;
        camEuler.x = 0;
        camEuler.y += 90;
        camEuler.z = -camPivPos.x;

        GameObject arrow = Instantiate(Arrow_prefab, tmp, Arrow_prefab.transform.rotation);
        arrow.SendMessage("setDestination", destinationBox);
        print(arrow.name + ": " + arrow.transform.position);
        arrow.transform.eulerAngles = camEuler;
        arrow.transform.forward = PlayerCam.transform.forward;
    }

    /// <summary>
    /// Check Inputs, and whether entering building or not
    /// </summary>
    private void checkInput()
    {
        float fireing2 = Input.GetAxis("Fire2");
        float fireing1 = Input.GetAxis("Fire1");
        if (Input.GetKeyDown(KeyCode.E) && EnterDebounce <= 0)
            checkenterBuilding();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SetCursorState(CursorLockMode.None);
            SceneManager.LoadScene(0, LoadSceneMode.Single);
        }
        if (Input.GetKeyDown(KeyCode.Q))
            SetCursorState(CursorLockMode.None);

        if (Input.GetKeyDown(KeyCode.Mouse0))
            SetCursorState(CursorLockMode.Locked);

        runRate = Input.GetKey(KeyCode.LeftShift) ? playerRunSpeed : playerMoveSpeed;

        if (fireing1 != 0 && StructureMode && buildingTouched.name == Turret && fireDebounce1 <= 0)
        {
            fireDebounce1 = .2f;
            fireRocket();
        }
        else if(fireing2 != 0 && moneyheld > 1)
        {
            fireDebounce2 = .2f;
            if (buildingTouched.name == Turret) autoFire();
            else heal();
            moneyheld -= CurrencyValue;
        }
        if(fireDebounce1 > 0)
            fireDebounce1 -= .1f * Time.deltaTime;
        if (fireDebounce2 > 0)
            fireDebounce2 -= .1f * Time.deltaTime;
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
        removeHealth();
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

    private void gameOver()
    {
        SetCursorState(CursorLockMode.None);
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }

    private void autoFire()
    {

    }

    private void heal()
    {

    }
}
