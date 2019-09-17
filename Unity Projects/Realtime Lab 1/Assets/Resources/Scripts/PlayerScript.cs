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
        pos = this.transform.position;
        playerCam = this.GetComponent<Camera>(); //Get players CameraPos
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        float xDir = Input.GetAxis("Horizontal");
        float dx = -1 * Input.GetAxis("Horizontal");
        float dz = -1 * Input.GetAxis("Vertical");

        //float rotateX = Input.GetAxis("Mouse Y");
        float rotateY = Input.GetAxis("Mouse X");
        //float my = Input.GetAxis("Mouse ScrollWheel");

        Vector3 pos = transform.position;           //players position matrix
        pos.x += dx * (playerMoveSpeed * Time.deltaTime); //update forward/backward pos on x axes
        //pos.y -= gravitationalConstant * Time.deltaTime;  //constant downward Motion
        pos.z += dz * (playerMoveSpeed * Time.deltaTime); //update left/right pos on z axes
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
