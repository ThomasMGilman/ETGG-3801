using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingScript : GlobalScript
{
    private float offsetHeight;
    private bool setOffset = false;
    private bool falling = true;

    private Vector3 pos;

    private Text BuildingOption;
    // Start is called before the first frame update
    void Start()
    {
        pos = this.transform.position;
        BuildingOption = GameObject.Find("BuildingOption").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if(falling)
        {
            pos.y -= gravitationalConstant;
        }
        if(setOffset)
        {
            pos.y = offsetHeight;
            setOffset = false;
        }
        this.transform.position = pos;
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject obj = other.gameObject;
        
        if(obj.tag == "ground")
        {
            float diff = pos.y + obj.transform.position.y;
            offsetHeight = obj.transform.position.y + (transform.name == Base ? 1.1f : 1.8f);
            setOffset = true;
            falling = false;
        }
        if(obj.tag == "rocket" && this.name == Base)
        {
            removeHealth();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        falling = false;
    }

    private void OnTriggerExit(Collider other)
    {
        falling = true;
    }

    private void enterBuilding(bool state)
    {
        BuildingOption.enabled = state;
        string optionText = "Press: Fire2 to Enter ";
        BuildingOption.text = optionText += this.name == Base ? "Revive Mode!" : "Auto Fire Mode!";
        print("Entering: " + this.name + " state: " + state);
    }
}
