using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    public float moveSpeed, rotationSpeed, maxPiv, minPiv, maxInputSize, timeReductionAmount;

    private Animator PlayerAnimation;
    private Rigidbody rigidBody;
    private Camera PlayerCam;
    private GameObject camPivot, codeInput;
    private InputField codeInputField;

    private CursorLockMode wantMode;

    private Text codeText, timer;

    //Timing
    private float maxTime = 60 * 5;         //60 seconds = 1 minute * 5 = 5 minutes
    private float timeLeft;

    private int codeToMatch;
    private bool collidingWithDoor = false;
    private string codeStartString = "Code: ";
    private string inputCode = "";
    // Start is called before the first frame update
    void Start()
    {
        timer = GameObject.FindGameObjectWithTag("Timer").GetComponent<Text>();
        timeLeft = maxTime;

        //Get UI Elements for editing later
        codeText = GameObject.FindGameObjectWithTag("Code").GetComponent<Text>();
        codeInput = GameObject.FindGameObjectWithTag("InputField");
        codeInputField = codeInput.GetComponent<InputField>();
        codeInput.SetActive(false);

        //Get and set player variables to interact with later
        rigidBody = this.transform.GetComponent<Rigidbody>();
        PlayerAnimation = GetComponent<Animator>();
        camPivot = this.transform.GetChild(3).gameObject;                                   //Pivot Point for the camera
        PlayerCam = camPivot.transform.GetChild(0).GetComponent<Camera>();                  //Camera is the child of camPivot

        //Lock the mouse cursor to the screen
        SetCursorState(CursorLockMode.Locked);
    }

    private Vector3 getMoveOffset()
    {
        Vector3 offset = Vector3.zero;
        offset.x = -Input.GetAxis("Horizontal");
        offset.z = -Input.GetAxis("Vertical");
        offset = this.transform.TransformDirection(offset);
        PlayerAnimation.SetBool("moving", (offset.x != 0 || offset.z != 0));                //if either x or z movement not 0 moving animation is true
        return offset * Time.deltaTime * moveSpeed;
    }

    /// <summary>
    /// Update Camera Position of Player
    /// </summary>
    private void updateCamera()
    {
        if (wantMode == CursorLockMode.Locked)
        {
            float rotateY = Input.GetAxis("Mouse X") * rotationSpeed;
            float pivotCam = Input.GetAxis("Mouse Y") * rotationSpeed;
            //print("Angles recieved rotate: " + rotateY + " piv: " + pivotCam);
            if (rotateY != 0)
            {
                Vector3 playerDir = this.transform.rotation.eulerAngles;
                playerDir.y += rotateY;                 //update left/right pos on z axes
                transform.rotation = Quaternion.Euler(playerDir);
            }
            if (pivotCam != 0)
            {
                Vector3 camAngle = camPivot.transform.rotation.eulerAngles;
                float angleVal = camAngle.x + pivotCam;
                if (angleVal <= maxPiv || angleVal >= minPiv)
                    camAngle.x = angleVal;
                camPivot.transform.rotation = Quaternion.Euler(camAngle);
            }
        }
    }

    private void move()
    {
        Vector3 tmpPos = this.transform.position;
        tmpPos += getMoveOffset();
        this.transform.position = tmpPos;
    }

    private void checkInput()
    {
        //if (Input.GetKeyDown(KeyCode.Escape))
        //    SetCursorState(wantMode == CursorLockMode.None ? CursorLockMode.Locked : CursorLockMode.None);
        if (Input.GetAxis("Fire1") != 0 || Input.GetKeyDown(KeyCode.KeypadEnter))
            handleInputField(true);
    }

    private void handleInputField(bool spacePressed = false)
    {
        if(codeInputField.text.Length >= maxInputSize || (spacePressed && codeInputField.text.Length > 0))
        {
            string inCode = codeInputField.text;
            if(inCode == codeToMatch.ToString())
            {
                win();
            }
            else
            {
                timeLeft -= timeReductionAmount;
            }
            codeInputField.text = "";
        }
    }

    private void updateTimer()
    {
        timeLeft -= Time.deltaTime;
        timer.text = Math.Round(timeLeft / 60, 2).ToString();
        if (timeLeft <= 0)
            lose();
    }

    // Update is called once per frame
    void Update()
    {
        move();
        checkInput();
        updateCamera();
        if(collidingWithDoor)   //Display Code Input
        {
            handleInputField();
            codeText.text = codeStartString + inputCode;
        }
        updateTimer();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Door")                             //If Colliding with Door, show UI elements
        {
            SetCursorState(CursorLockMode.None);
            collidingWithDoor = true;
            codeInput.SetActive(true);
            codeText.enabled = true;
            codeText.text = codeStartString + inputCode;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Door")                            //If Exit collision with Door, Hide UI elements
        {
            SetCursorState(CursorLockMode.Locked);
            collidingWithDoor = false;
            codeInput.SetActive(false);
            codeText.enabled = false;
        }
    }

    private void SetCursorState(CursorLockMode state)
    {
        Cursor.lockState = wantMode = state;
        Cursor.visible = (CursorLockMode.Locked != wantMode);
    }

    private void win()
    {
        SceneManager.LoadScene(2);
    }

    void lose()
    {
        SceneManager.LoadScene(3);
    }

    private void setCode(int code)
    {
        codeToMatch = code;
    }
}