using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalScript : MonoBehaviour
{
    static public int Score = 100;
    public int addativeScore = 50;
    public int deductiveScore = -10;

    public string scoreString = "Score: ";
    static public Text ScoreText;

    public GameObject Sphere_Prefab;

    private float width = 35;
    private float height = 20;

    // Start is called before the first frame update
    void Start()
    {
        ScoreText = GameObject.Find("Score").GetComponent<Text>();
        Random.InitState(Time.time.GetHashCode());
    }

    // Update is called once per frame
    void Update()
    {
        randomGenSphere();
    }

    private void randomGenSphere()
    {
        float val = Random.Range(0, 1);
        if ( val >= .5 && val <= 1)
        {
            Vector3 orbPos = new Vector3(Random.Range(-width, width), height, 0);
            Vector3 angle = new Vector3(0, 0, Random.Range(0, 360));
            GameObject newSphere = Instantiate(Sphere_Prefab, orbPos, Sphere_Prefab.transform.rotation);
            newSphere.transform.rotation = Quaternion.Euler(angle);
        }
    }
}
