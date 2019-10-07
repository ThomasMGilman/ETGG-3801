using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : GlobalScript
{
    Vector3 pos, prevForwardDir, distPoint;
    ParticleSystem dyingAnimation;
    MeshRenderer meshRenderer;
    AudioSource aSource;
    GameObject destination;
    bool isDead = false;
    private float radiusToPoint = 2f, rocketFallRate = 1;
    Dictionary<string, groundGroup> worldMap;
    // Start is called before the first frame update
    void Start()
    {
        aSource = this.GetComponent<AudioSource>();
        pos = this.transform.position;
        dyingAnimation = this.gameObject.GetComponent<ParticleSystem>();
        distPoint = new Vector3(0, 0, 0); //default distPoint
        prevForwardDir = this.transform.forward;
        if (this.name == "rocket(Clone)")
        {
            Vector3 tmpRotation = this.transform.rotation.eulerAngles;
            tmpRotation.x += 90;
            this.transform.rotation = Quaternion.Euler(tmpRotation);
            meshRenderer = this.GetComponent<MeshRenderer>();
        }
        else
        {
            rocketFallRate = 20;
            meshRenderer = this.transform.GetChild(0).GetComponent<MeshRenderer>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDead)
        {
            pos += rocketFallRate * (this.transform.forward ) * Time.deltaTime;
            this.transform.position = pos;
        }
        if ((isDead && !dyingAnimation.isPlaying && !aSource.isPlaying) || pos.y > 300 || pos.y < -8)
            detonation();
    }

    /// <summary>
    /// Destroy the object and perform any extra task required
    /// </summary>
    private void detonation()
    {   
        if (this.name == "rocket(Clone)") this.transform.parent.SendMessage("deadRocket");
        if (this.name == "arrow(Clone)") Destroy(destination);
        Destroy(gameObject);
    }

    private void disableObject()
    {
        this.GetComponent<MeshRenderer>().enabled = false;
        dyingAnimation.Play();
        isDead = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "ground" || other.tag == "structure" || other.tag == "rocket" || other.tag == "arrowDestination")
        {
            if (other.name == "rocket(Clone)") Instantiate(Money_prefab, pos, Money_prefab.transform.localRotation);

            //print("This: " + this.transform.name + " is hit by: " + other.transform.name+ " "+ other.tag);
            aSource.Stop();
            aSource.volume = 100;
            aSource.clip = Resources.Load<AudioClip>("Sounds/Grenade");
            aSource.loop = false;
            aSource.Play();

            meshRenderer.enabled = false;
            dyingAnimation.Play();
            isDead = true;

            if (this.name == "rocket(Clone)") //Hit in radius of rocket collision
            {

                float posX = worldMap[other.name].x;
                float posZ = worldMap[other.name].z;

                print(worldMap[other.name].ground.name);
                
                for (int x = (int)(posX - radiusToPoint); x < (int)(posX + radiusToPoint); x++)
                {
                    for (int z = (int)(posZ - radiusToPoint); z < (int)(posZ + radiusToPoint); z++)
                    {
                        string key = groundName + "_X:" + x.ToString()
                            + "_Z:" + z.ToString();
                        //print(other.name + " keyToTry: "+key);
                        groundGroup r;
                        if (worldMap.TryGetValue(key, out r))
                            r.ground.SendMessage("hit");
                        else
                        {
                            bool result = key == other.name;
                            print(key + " = " + other.name + " " + result.ToString());
                            print("could not find key!!!: " + key);
                        }
                            
                    }
                }
            }
        }
    }

    private void ToCheck(Dictionary<string, groundGroup> map)
    {
        worldMap = map;
    }

    private void setDestination(GameObject d)
    {
        destination = d;
    }
}
