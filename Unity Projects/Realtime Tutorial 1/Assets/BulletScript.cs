using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float moveSpeed = 25.0f;
    public int direction;
    // Start is called before the first frame update
    void Start()
    {
        if (transform.parent.name == "Ship")
            direction = 1;
        else
            direction = -1;
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody rb = GetComponent<Rigidbody>();

        Vector3 pos = transform.position;           //ships position matrix
        pos.x -= direction * (moveSpeed * Time.deltaTime); //update left/right position on z plane
        transform.position = pos;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Invader")
        {
            //Change Score
            GameObject gui_text = GameObject.Find("Ship");
            GameObject Fleet = GameObject.Find("Fleet");
            Fleet.SendMessage("checkInFront");
            gui_text.SendMessage("getPoints", other.gameObject.GetComponent<InvaderScript>().score);
        }
        else if (other.gameObject.tag == "Ship")
        {
            GameObject Ship = GameObject.Find("Ship");
            Ship.SendMessage("removeHealth", gameObject.GetComponent<InvaderScript>().dmg);
        }
        else if (transform.parent.tag == "Invader")
        {
            SendMessage("ResetFire");
        }
        //Destroy Bullet
        Destroy(this.gameObject);
    }
}
