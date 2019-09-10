using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float moveSpeed = 1.0f;
    private float dmg = 0f;
    private int Bullet_dir;
    private bool collided = false;

    private Rigidbody rb;
    private AudioSource source;

    private string[] ASFoulder;

    // Start is called before the first frame update
    void Start()
    {
        this.rb = GetComponent<Rigidbody>();
    }

    /// <summary>
    /// Sets direction of the bullet and sound to be played when bullet is created
    /// </summary>
    /// <param name="ship"></param>
    void setOwner(bool ship)
    {
        this.source = GetComponent<AudioSource>();
        if (ship)
        {
            Bullet_dir = 1;
            this.source.clip = Resources.Load<AudioClip>("Sounds/iceball");
        }
        else
        {
            Bullet_dir = -1;
            this.source.clip = Resources.Load<AudioClip>("Sounds/flaunch");
        }
        print(this.source.clip.ToString());
        this.source.Play();
    }

    void setdmg(float d)
    {
        this.dmg = d;
    }

    // Update is called once per frame
    void Update()
    {
        if(!collided)
        {
            Vector3 pos = transform.position;           //ships position matrix
            pos.x -= Bullet_dir * (moveSpeed * Time.deltaTime); //update left/right position on z plane
            transform.position = pos;
        }
        else
        {
            if(!this.source.isPlaying)   //Destroy Bullet when audio is done
                Destroy(this.gameObject);
        }
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
        collided = true;                                //bullet collided and ready to destroy after audio finished
        GetComponent<MeshRenderer>().enabled = false;   //disable drawing of bullet
        GetComponent<BoxCollider>().enabled = false;    //disable bullet collider
    }
}
