using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : GlobalScript
{
    public float radiusToPoint = 1f;

    Vector3 pos, prevForwardDir, distPoint;
    ParticleSystem dyingAnimation;
    bool isDead = false;
    float rocketFallRate = 10;
    // Start is called before the first frame update
    void Start()
    {
        pos = this.transform.position;
        dyingAnimation = this.gameObject.GetComponent<ParticleSystem>();
        distPoint = new Vector3(0, 0, 0); //default distPoint
        prevForwardDir = this.transform.forward;
        if(this.name == "rocket(Clone)")
        {
            Vector3 tmpRotation = this.transform.rotation.eulerAngles;
            tmpRotation.x += 90;
            this.transform.rotation = Quaternion.Euler(tmpRotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDead)
        {
            pos += (this.transform.forward ) * Time.deltaTime;
            this.transform.position = pos;
        }
        if ((isDead && !dyingAnimation.isPlaying) || pos.y > 1000 || pos.y < -8 || checkPointReached())
            detonation();
    }

    /// <summary>
    /// check if projectile  has reached the point where it should detonate
    /// check each point within a radius around the point to reach
    /// </summary>
    /// <returns></returns>
    private bool checkPointReached()
    {
        if(pos.x >= distPoint.x - radiusToPoint 
        && pos.x <= distPoint.x + radiusToPoint)
        {
            if(pos.y >= distPoint.y - radiusToPoint
            && pos.y <= distPoint.y + radiusToPoint)
            {
                if (pos.z >= distPoint.z - radiusToPoint
                && pos.z <= distPoint.z + radiusToPoint)
                    return true;
            }
        }
        return false;
    }

    /// <summary>
    /// Destroy the object and perform any extra task required
    /// </summary>
    private void detonation()
    {   
        if(this.name == "rocket(Clone)") this.transform.parent.SendMessage("deadRocket");
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
        if(other.tag == "ground" || other.tag == "structure" || other.tag == "rocket")
        {
            if (other.name == "rocket(Clone)") Instantiate(Money_prefab, pos, Money_prefab.transform.localRotation);
            this.GetComponent<MeshRenderer>().enabled = false;
            dyingAnimation.Play();
            isDead = true;
        }
    }

    private void setDistance(Vector3 distPos)
    {
        distPoint = distPos;
    }
}
