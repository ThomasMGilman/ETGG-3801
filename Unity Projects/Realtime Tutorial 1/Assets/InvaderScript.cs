using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InvaderScript : FleetScript  
{
    public GameObject bullet_prefab;

    public int score;
    public float dmg;
    private float timeSinceReset;
    private float timeSinceLastFire;
    private float lastX;

    private bool movefwrd = false;
    private bool mvingFwrd = false;
    private bool InFront = false;
    private bool imHit = false;
    
    private Vector3 pos;
    private Vector3 rayDir;
    private Bounds BulletBounds;
    
    // Start is called before the first frame update
    void Start()
    {
        score = 100;
        dmg = .1f;
        timeSinceLastFire = Random.Range(0, fireRate);  //randomize invader fire timing
        pos = transform.position;                       //position matrix
        rayDir = new Vector3(1f, 0f, 0f);
        checkInFront();

        BulletBounds = bullet_prefab.GetComponent<MeshRenderer>().bounds;
    }

    // Update is called once per frame
    void Update()
    {
        if(imHit)
        {
            ParticleSystem ps = this.GetComponent<ParticleSystem>();
            if(!ps.isPlaying)
            {
                ps.Play();
                timeSinceLastFire = Time.time;
            }
            else if(ps.isPlaying && Time.time - timeSinceLastFire >= ps.duration)
            {
                ps.Stop();
                GameObject minMapIcon = this.transform.GetChild(0).gameObject;
                //print("child count: " + this.transform.GetChild(0));
                Destroy(minMapIcon);
                Destroy(this);
                transform.parent.SendMessage("recCheckInFront");
            }
        }
        else
        {
            Rigidbody rb = GetComponent<Rigidbody>();
            pos = transform.position;                       //position matrix

            if (movefwrd)                                                    //start moving fwrd fixed distance
            {
                if (!mvingFwrd)                                                  //get position before moving fwrd and offset from wall a bit
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
            float fireTimer = Time.time - timeSinceLastFire;
            if (InFront && fireTimer >= fireRate)
            {
                GameObject new_bul = Instantiate(bullet_prefab, BulletBounds.size + pos + rayDir, Quaternion.identity);
                new_bul.SendMessage("setOwner", false);
                new_bul.SendMessage("setdmg", this.dmg);
                timeSinceLastFire = Time.time;
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
        if (!Physics.Raycast(pos, rayDir, out hit, 10.0f, layer_mask))
            InFront = true;
        else
            InFront = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            imHit = true;                                       //Invader is now dead, play effect
            this.GetComponent<BoxCollider>().enabled = false;   //no more collisions with this object
            this.GetComponent<MeshRenderer>().enabled = false;  //no mmore rendering of object
        }
        if (other.gameObject.tag == "Bumper")
        {
            transform.parent.SendMessage("changeDir");
        }
    }
}
