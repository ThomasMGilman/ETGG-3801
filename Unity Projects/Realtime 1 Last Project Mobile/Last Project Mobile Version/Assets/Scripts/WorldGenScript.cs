using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WorldGenScript : MonoBehaviour
{
    /// <summary>
    /// Public variables to set in inspector
    /// </summary>
    public int maxCodeRange;

    public List<Texture> paintingList;
    /// <summary>
    /// Private variables used for world gen
    /// </summary>
    private Dictionary<int, Texture> paintings;
    private List<int> keys;

    private GameObject seedInputField;
    private Text seedText;
    private Text input;
    private MeshRenderer renderer;
    private int gameSeed, winKey;
    private bool gameStateSet = false;

    // Start is called before the first frame update
    void Start()
    {
        seedInputField = GameObject.FindGameObjectWithTag("Code");                      //Get Input feild for seed
        input = GameObject.FindGameObjectWithTag("CodeText").GetComponent<Text>();      //Get Text field for inputfield

        seedText = GameObject.FindGameObjectWithTag("GameSeed").GetComponent<Text>();   //Get Text for displaying seed
        seedText.enabled = false;                                                       //hide it

        renderer = this.gameObject.GetComponent<MeshRenderer>();                        //Get Renderer for this painting object
        renderer.enabled = false;                                                       //hide the painting object
    }

    private void checkInput()
    {
        if(Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetAxis("Fire1") != 0)
        {
            if(input.text.Length > 0)
            {
                gameStateSet = true;                        //Set in the gamestate, can no longer check for seed input
                seedInputField.SetActive(false);            //Hide the inputField
                initGame(Convert.ToInt32(input.text));      //setup game with provided seed
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(!gameStateSet)
            checkInput();
    }

    private void initGame(int seed)
    {
        gameSeed = seed;        //Generate Seed
        seedText.text = gameSeed.ToString();
        seedText.enabled = true;
        UnityEngine.Random.InitState(gameSeed);
        //Init variables and dictionary of paintings
        paintings = new Dictionary<int, Texture>();
        keys = new List<int>();

        setPaintings();
        int i = UnityEngine.Random.Range(0, keys.Count - 1);
        winKey = keys[i];

        this.gameObject.GetComponent<Renderer>().material.SetTexture("_MainTex", paintings[winKey]);
        renderer.enabled = true;
        this.enabled = true;
    }

    private void setPaintings()
    {
        int maxPaintings = paintingList.Count;
        for (int i = 0; i < maxPaintings; i++)
        {
            //Get random texture
            int texIndex = UnityEngine.Random.Range(0, paintingList.Count - 1);

            //Generate random code for painting
            int code = UnityEngine.Random.Range(0, maxCodeRange);
            int infCheck = 0;
            while (paintings.ContainsKey(code))
            {
                if (infCheck == 10)
                    break;
                code = UnityEngine.Random.Range(0, maxCodeRange);
                infCheck++;
            }
            if (infCheck >= 10)
                throw new System.Exception("Need to set maxCodeRange!!");

            paintings.Add(code, paintingList[texIndex]);
            paintingList.RemoveAt(texIndex);
            keys.Add(code);
        }
    }

    public void exitProgram()
    {
        Application.Quit();         //Quit the application
    }

    public void resetProgram()
    {
        SceneManager.LoadScene(0);  //Reload the current and only scene
    }
}
