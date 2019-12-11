using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PaintingScript : MonoBehaviour
{
    private int code;
    private Text codeText;
    // Start is called before the first frame update
    void Start()
    {
        //Get UI Elements
        codeText = GameObject.FindGameObjectWithTag("Code").GetComponent<Text>();
        codeText.enabled = false;
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

    void updateCodeDisplayed(int val)
    {
        codeText.text = val.ToString();
        codeText.enabled = true;
    }

    void hideCode()
    {
        codeText.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
            updateCodeDisplayed(this.code);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Player")
            hideCode();
    }
}
