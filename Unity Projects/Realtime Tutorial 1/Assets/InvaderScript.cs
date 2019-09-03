using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InvaderScript : FleetScript  
{
    public int score;
    public float dmg;
    private float timeSinceReset;
    private float timeSinceLastFire;
    private float lastX;

    private bool movefwrd = false;
    private bool mvingFwrd = false;
    private bool InFront = false;
    
    private Vector3 pos;
    
    public GameObject bullet_prefab;
    // Start is called before the first frame update
    void Start()
    {
        score = 100;
        dmg = .1f;
        timeSinceLastFire = 0f;
        pos = transform.position;                       //position matrix
        checkInFront();
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        pos = transform.position;                       //position matrix
        //print("moving!! pos: "+pos);
        
        if(movefwrd)                                                    //start moving fwrd fixed distance
        {
            if(!mvingFwrd)                                                  //get position before moving fwrd and offset from wall a bit
            {
                lastX = pos.x;
                mvingFwrd = true;
                pos.z -= Zdirection * (moveSpeed * Time.deltaTime);
            }
            pos.x += 1 * (moveSpeed * Time.deltaTime);
            float newDis = pos.x - lastX;
            if (pos.x - lastX >= fwrdDistance)                              //reached distance to move fwrd, change Zdirection
                transform.parent.SendMessage("changeDir");
        }
        else
        {
            pos.z += Zdirection * (moveSpeed * Time.deltaTime);          //update left/right
            if (movefwrd)
            {
                pos.x += 1 * (moveSpeed * Time.deltaTime);
                movefwrd = false;
            }
        }
        transform.position = pos;

        if(InFront)
        {
            if(timeSinceLastFire - Time.time >= fireRate)
            {
                Transform spawn_transform = transform.GetChild(1);
                GameObject new_bul = Instantiate(bullet_prefab, spawn_transform.position, Quaternion.identity);
                timeSinceLastFire = Time.time;
                print("zapzap");
            }
        }
    }
    /*
     * Change Zdirection based off of collision or moving fixed distance forward
     * Makes sure not to update change of Zdirection right away based off of change in time as well
     */
    private void resetMovingFwrd()
    {
        if (!movefwrd)
        {
            movefwrd = true;
            timeSinceReset = Time.time;
        }
        else if(movefwrd && (Time.time - timeSinceReset > 1f))
        {
            Zdirection *= -1;
            movefwrd = false;
            mvingFwrd = false;
        }
    }

    private void resetFire()
    {
        timeSinceLastFire = 0f;
    }

    private void checkInFront()
    {
        //raycast for Invaders to know wether or not to fire
        RaycastHit hit;
        int layer_mask = 1 << 8;
        Vector3 rayDir = new Vector3(1f,0f,0f);
        print("Invader Fwrd: " + gameObject.transform.forward + " rayDir: " + rayDir);
        if (!Physics.Raycast(pos, rayDir, out hit, 10.0f, layer_mask))
        {
            print("Im on the front lines bois!!");
        }
        else
        {
            InFront = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
            Destroy(this.gameObject);
        if (other.gameObject.tag == "Bumper")
        {
            transform.parent.SendMessage("changeDir");
        }
    }
}
