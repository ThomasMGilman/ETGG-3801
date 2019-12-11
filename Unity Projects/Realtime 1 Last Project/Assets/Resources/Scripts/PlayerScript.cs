using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float moveSpeed, rotationSpeed, maxPiv, minPiv;

    private Animator PlayerAnimation;
    private Rigidbody rigidBody;
    private Camera PlayerCam;

    private GameObject camPivot;

    private CursorLockMode wantMode;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = this.transform.GetComponent<Rigidbody>();
        PlayerAnimation = GetComponent<Animator>();
        camPivot = this.transform.GetChild(3).gameObject;                                   //Pivot Point for the camera
        PlayerCam = camPivot.transform.GetChild(0).GetComponent<Camera>();                  //Camera is the child of camPivot
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
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SetCursorState(wantMode == CursorLockMode.None ? CursorLockMode.Locked : CursorLockMode.None);
        }
    }

    // Update is called once per frame
    void Update()
    {
        move();
        checkInput();
        updateCamera();
    }

    private void OnTriggerEnter(Collider other)
    {
        print("Colliding with: " + other.gameObject.name);
        if(other.tag == "Door")
        {
            SetCursorState(CursorLockMode.None);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Door")
        {
            SetCursorState(CursorLockMode.Locked);
        }
    }

    private void SetCursorState(CursorLockMode state)
    {
        Cursor.lockState = wantMode = state;
        Cursor.visible = (CursorLockMode.Locked != wantMode);
    }
}