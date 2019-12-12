using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinLoseScript : MonoBehaviour
{
    private float counter, timeForSceneSwap = 30;
    // Start is called before the first frame update
    void Start()
    {
        counter = 0;   
    }

    // Update is called once per frame
    void Update()
    {
        counter += Time.deltaTime;
        if (counter >= timeForSceneSwap || Input.GetAxis("Fire1") != 0)
            SceneManager.LoadScene(0);
    }
}
