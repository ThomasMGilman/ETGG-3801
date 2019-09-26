using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : GlobalScript
{
    Vector3 pos;
    ParticleSystem dyingAnimation;
    bool isDead = false;
    float rocketFallRate = 10;
    // Start is called before the first frame update
    void Start()
    {
        pos = this.transform.position;
        dyingAnimation = this.gameObject.GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDead)
        {
            pos.y -= rocketFallRate * Time.deltaTime;
            this.transform.position = pos;
        }
        if ((isDead && !dyingAnimation.isPlaying) || pos.y > 1000 || pos.y < -8)
            detonation();
    }

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
            if (other.tag == "rocket") Instantiate(Money_prefab, pos, Money_prefab.transform.localRotation);
            this.GetComponent<MeshRenderer>().enabled = false;
            dyingAnimation.Play();
            isDead = true;
        }
    }
}
