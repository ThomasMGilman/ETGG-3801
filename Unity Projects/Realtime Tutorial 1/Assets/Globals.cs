using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Globals : MonoBehaviour
{
    public bool paused;

    // Start is called before the first frame update
    void Start()
    {
        paused = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setPaused(bool state)
    {
        paused = state;
    }

    public void pauseGame()
    {
        paused = true;
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }

    public void restartGame()
    {
        paused = false;
    }
}
