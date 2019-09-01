using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipScript : MonoBehaviour
{
    public float moveSpeed = 10.0f;
    public GameObject bullet_prefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))             //ships firing code
        {
            //print("pewpew");
            Transform spawn_transform = transform.GetChild(1);
            GameObject new_bul = Instantiate(bullet_prefab, spawn_transform.position, Quaternion.identity);
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
}
