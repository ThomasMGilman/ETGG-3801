using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyScript : GlobalScript
{
    public float rotationRate = 2f;

    private float heightFromCube = 1.000001f;
    private float moveUpVal;
    private bool moveUp, falling = true;
    private Vector3 pos, rotationPos;

    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position;
        rotationPos = transform.rotation.eulerAngles;        //Get players CameraPos
        falling = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!falling)
        {
            if (moveUp)
            {
                moveUp = false;
                pos.y += moveUpVal;
            }
            //Rotate coin
            rotationPos.y += rotationRate * Time.deltaTime;
            transform.rotation = Quaternion.Euler(rotationPos);
        }
        else
            pos.y -= gravitationalConstant * Time.deltaTime;

        transform.position = pos;
    }

    private void groundCollision(GameObject obj, bool colliding)
    {
        if (colliding)
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "ground")
            groundCollision(other.gameObject, true);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "ground")
            groundCollision(other.gameObject, false);
    }
}
