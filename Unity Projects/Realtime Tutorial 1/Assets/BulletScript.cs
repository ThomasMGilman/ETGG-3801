using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float moveSpeed = 25.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody rb = GetComponent<Rigidbody>();

        Vector3 pos = transform.position;           //ships position matrix
        pos.x -= 1 * (moveSpeed * Time.deltaTime); //update left/right position on z plane
        transform.position = pos;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bumper" || other.gameObject.tag == "Invader")
            Destroy(this.gameObject);
    }
}
