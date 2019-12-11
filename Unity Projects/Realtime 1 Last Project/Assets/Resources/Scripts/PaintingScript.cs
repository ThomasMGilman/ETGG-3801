using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintingScript : MonoBehaviour
{
    private int code;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void SetCode(int value)
    {
        code = value;
        //print(this.name+" code to display: " + code);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player")
            SendMessage("updateCodeDisplayed", this.code);
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.tag == "Player")
            SendMessage("hideCode");
    }
}
