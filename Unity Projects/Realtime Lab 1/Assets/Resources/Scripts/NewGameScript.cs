using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NewGameScript : GlobalScript
{
    // Start is called before the first frame update
    public RawImage Title;
    public Button NewGameOption;
    public Button ResumeGameOption;
    public Button QuiteGameOption;

    public float ButtonGap = 50f;       //Gap between buttons
    public float AnimationSpeed = 1f;   //speed at which menu scrolls upwards
    public bool AnimateMenu = true;     //animate Menu upwards by default when game starts

    private RectTransform pRTransform;
    private RectTransform TitleRT;
    private RectTransform NewGameRT;
    private RectTransform ResumeGameRT;
    private RectTransform QuiteRT;

    private float maxHeight;
    private float maxWidth;
    private float alphaFadeStart;

    void Start()
    {
        //Get RectTransforms
        pRTransform     = this.GetComponent<RectTransform>();
        TitleRT         = Title.GetComponent<RectTransform>();
        NewGameRT       = NewGameOption.GetComponent<RectTransform>();
        ResumeGameRT    = ResumeGameOption.GetComponent<RectTransform>();
        QuiteRT         = QuiteGameOption.GetComponent<RectTransform>();

        //set buttons to disabled if animated menu
        if(AnimateMenu)
        {
            NewGameOption.interactable      = false;
            QuiteGameOption.interactable    = false;
        }
        else
        {
            Title.enabled                   = false; //dont show title
            NewGameOption.interactable      = true;
            QuiteGameOption.interactable    = true;
        }
        ResumeGameOption.interactable       = false; //Resume game is disabled by default

        //get half the height of the components
        float TitlesHalfHeight      = TitleRT.rect.height / 2;
        float NewGameHalfHeight     = NewGameRT.rect.height / 2;
        float ResumeGameHalfHeight  = ResumeGameRT.rect.height / 2;
        float QuiteGameHalfHeight   = QuiteRT.rect.height / 2;

        maxHeight = pRTransform.rect.height;
        maxWidth = pRTransform.rect.width / 2;

        alphaFadeStart = maxHeight - TitlesHalfHeight - 255;

        float TitleStartPosHeight;
        float NewGameStartPosHeight;
        float ResumeGameStartPosHeight;
        float QuiteStartPosHeight;
        if (AnimateMenu) TitleStartPosHeight    = -TitleRT.rect.height;                 //set start pos for Title Image              
        else TitleStartPosHeight                = maxHeight;
        NewGameStartPosHeight                   = TitleStartPosHeight - TitlesHalfHeight - ButtonGap - NewGameHalfHeight;     //set start pos for newGame Button
        ResumeGameStartPosHeight                = NewGameStartPosHeight - NewGameHalfHeight - ButtonGap - ResumeGameHalfHeight;  //set start pos for ResumeGame Button
        QuiteStartPosHeight                     = ResumeGameStartPosHeight - NewGameHalfHeight - ButtonGap - QuiteGameHalfHeight;  //set start pos for QuiteGame Button

        TitleRT.position        = new Vector3(maxWidth, TitleStartPosHeight, 0);
        NewGameRT.position      = new Vector3(maxWidth, NewGameStartPosHeight, 0);
        ResumeGameRT.position   = new Vector3(maxWidth, ResumeGameStartPosHeight, 0);
        QuiteRT.position        = new Vector3(maxWidth, QuiteStartPosHeight, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(AnimateMenu)
        {
            if(TitleRT.position.y < maxHeight)
            {
                float transformVal = 1;//AnimationSpeed * Time.deltaTime; 
                Vector3 newTitleRTpos       = TitleRT.position;
                Vector3 newNewGameRTpos     = NewGameRT.position;
                Vector3 newResumeGameRTpos  = ResumeGameRT.position;
                Vector3 newQuiteRTpos       = QuiteRT.position;

                newTitleRTpos.y         += transformVal;
                newNewGameRTpos.y       += transformVal;
                newResumeGameRTpos.y    += transformVal;
                newQuiteRTpos.y         += transformVal;

                TitleRT.position        = newTitleRTpos;
                NewGameRT.position      = newNewGameRTpos;
                ResumeGameRT.position   = newResumeGameRTpos;
                QuiteRT.position        = newQuiteRTpos;

                if (TitleRT.position.y >= alphaFadeStart) //start fading Title Image
                {
                    Color newColor  = Title.color;
                    newColor.a      -= (float)0.003921;
                    Title.color     = newColor;
                }
            }
            else
            {
                Title.enabled                   = false; //dont show title
                AnimateMenu                     = false; //finished animation
                NewGameOption.interactable      = true;  //set buttons interactable
                QuiteGameOption.interactable    = true;
            }
        }
    }

    public void startGame()
    {
        //print("starting game!");
        ResumeGameOption.interactable = true;
        //restartGame();                          //set pause state to false
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }

    public void quitGame()
    {
        Application.Quit();
    }

    public void resumeGame()
    {
        //setPaused(false);
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }
}
