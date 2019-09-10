using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject HealthBar;
    public GameObject MiniMap;
    public GameObject Score;

    void Start()
    {
        //float MiniMapX = -(this.transform.GetComponent<RectTransform>().rect.width/2) + (MiniMap.GetComponent<RectTransform>().rect.width/2);
        float MiniMapY = (this.transform.GetComponent<RectTransform>().rect.height / 2);
        //MiniMap.transform.position = new Vector3(0, MiniMapY, 0);
        //Score.transform.position = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
