using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float moveSpeed = 1.0f;
    private float dmg = 0f;
    private int Bullet_dir;
    
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<AudioSource>().Play();
    }

    void setOwner(bool ship)
    {
        if (ship)
            Bullet_dir = 1;
        else
            Bullet_dir = -1;
    }

    void setdmg(float d)
    {
        this.dmg = d;
    }


    // Update is called once per frame
    void Update()
    {
        Rigidbody rb = GetComponent<Rigidbody>();

        Vector3 pos = transform.position;           //ships position matrix
        pos.x -= Bullet_dir * (moveSpeed * Time.deltaTime); //update left/right position on z plane
        transform.position = pos;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Invader")
        {
            //Change Score
            GameObject.Find("Ship").SendMessage("getPoints", other.gameObject.GetComponent<InvaderScript>().score);
        }
        else if (other.gameObject.tag == "Player")
        {
            GameObject Ship = GameObject.Find("Ship");
            Ship.SendMessage("removeHealth", dmg);
        }
        //Destroy Bullet
        Destroy(this.gameObject);
    }
}
