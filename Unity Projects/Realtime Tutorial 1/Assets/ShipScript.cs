using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipScript : MonoBehaviour
{
    public float moveSpeed = 10.0f;
    public GameObject bullet_prefab;

    [HideInInspector]
    public int score;
    [HideInInspector]
    public float health;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        health = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))             //ships firing code
        {
            //print("pewpew");
            Transform spawn_transform = transform.GetChild(1);
            GameObject new_bul = Instantiate(bullet_prefab, spawn_transform.position, Quaternion.identity);
            new_bul.transform.parent = this.transform;
        }
    }

    private void FixedUpdate()
    {
        float dz = Input.GetAxis("Horizontal");

        Rigidbody rb = GetComponent<Rigidbody>();

        Vector3 pos = transform.position;           //ships position matrix
        pos.z += dz * (moveSpeed * Time.deltaTime); //update left/right pos on z plane
        transform.position = pos;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bumper")
        {
            print("Ship Colliding");
        }
    }

    private void getPoints(int s)
    {
        score += s;
        Text scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
        scoreText.text = "Score: " + score;
    }

    private void removeHealth(float dmg)
    {
        float newHealth = health - dmg;
        if (newHealth <= 0.0)
            return;     //GameOver
        else
        {
            health = newHealth;
            RawImage HealthBar = GameObject.Find("Health").GetComponent<RawImage>();
            HealthBar.rectTransform.localScale = new Vector3(
               health, HealthBar.transform.localScale.y, HealthBar.transform.localScale.z);
            print("TAKING DMG, health now: " + health + " HealthbarScale: " + HealthBar.transform.localScale);
        }
        
    }
}
