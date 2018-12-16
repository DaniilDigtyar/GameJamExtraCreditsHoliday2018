using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{
    //to edit
    [SerializeField] private Text playerNameText;
    [SerializeField] private Text saidNameText;
    [SerializeField] private Text scoreText;
    [SerializeField] private Text levelText;
    [SerializeField] private float timeNameChange;
    [SerializeField] private int points = 100;
    [SerializeField] private Image lifesImage;
    [SerializeField] private Image background;
    [SerializeField] private Sprite[] lifesSprites;

    //Private
    private float timer;
    private string dificulty;
    private float multiplicationRate;
    private int lastIndexSaidName = -1;
    private int lastIndexPlayerName = -1;
    private float h;
    private float w;
    private float x;
    private float y;
    private int fontSizeProfundity;


    private Vector2 position;

    //Objects
    private GUIControl GUIControlObject;
    private Globals GlobalsObject;

    private void Awake()
    {
        lifesImage.sprite = lifesSprites[3];
        GlobalsObject = new Globals();
        
        w = (float)(Screen.width);
        h = (float)(Screen.height);
        background.rectTransform.sizeDelta = new Vector2(w, h);
        GUIControlObject = new GUIControl(playerNameText, saidNameText, scoreText, levelText, lifesImage,background);

        w = w / 5;


        LoadLevel(1);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ControlNameSaid();
        }

        if (timer % 60 >= timeNameChange - 1)
        {
            timer = 0;
            SayNewName();
        }

        timer += Time.deltaTime;
    }

    private void LoadLevel(int level)
    {
        switch (level)
        {
            case 1:
                dificulty = "easy";
                multiplicationRate = 1;
                break;
            case 2:
                dificulty = "easy";
                multiplicationRate = 1.1f;
                break;
            case 3:
                dificulty = "medium";
                multiplicationRate = 1.2f;
                break;
            case 4:
                dificulty = "medium";
                multiplicationRate = 1.3f;
                break;
            case 5:
                dificulty = "hard";
                multiplicationRate = 1.4f;
                break;
        }

        GlobalsObject.SetActualLevel(level);
        GUIControlObject.ShowNewLevel(level);
        ChangePlayerName(dificulty);
    }


    private void ControlNameSaid()
    {
        if (GlobalsObject.GetSaidNameAssigned().Equals(GlobalsObject.GetPlayerNameAssigned()))
        {
            AddScore(points);
        }
        else
        {
            int lifes = GlobalsObject.GetLifesLeft();
            if (lifes>0)
            {
                lifes--;
                GlobalsObject.SetLifesLeft(lifes);
                GUIControlObject.ChangeLifes(lifesSprites[lifes]);

            }
            else if(lifes == 0)
            {
                SceneManager.LoadScene("GameOver");
            }
            
            
           
        }
        ChangePlayerName(dificulty);
    }

    private void ChangePlayerName(string dificulty)
    {
        int index;
        string randomNewName;
        List<string> namesList = new List<string>();

        switch(dificulty)
        {
            case "easy":
                namesList = GlobalsObject.GetEasyNames();
                break;
            case "medium":
                //namesList = GlobalsObject.GetMediumNames();
                break;
            case "hard":
                //namesList = GlobalsObject.GetHardNames();
                break;
        }

        do
        {
            index = Random.Range(0, namesList.Count);
        } while (index == lastIndexPlayerName);

        lastIndexPlayerName = index;

        randomNewName = namesList[index];
        GlobalsObject.SetPlayerNameAssigned(randomNewName);
        GUIControlObject.ShowNewPlayerName(randomNewName);
    }

    private void SayNewName()
    {
        int index;
        string randomNewName;
        List<string> namesList = new List<string>();

        switch (dificulty)
        {
            case "easy":
                namesList = GlobalsObject.GetEasyNames();
                break;
            case "medium":
                //namesList = GlobalsObject.GetMediumNames();
                break;
            case "hard":
                //namesList = GlobalsObject.GetHardNames();
                break;
        }

        do
        {
            index = Random.Range(0, namesList.Count);
        } while (index == lastIndexSaidName);
        x = Random.Range(w,2*w);
        y = Random.Range(h/5, h*4/5);
        position = new Vector2 (x,y);
        fontSizeProfundity = (int)(w/10 + (x-w) * 10/w );




        lastIndexSaidName = index;

        randomNewName = namesList[index];
        GlobalsObject.SetSaidNameAssigned(randomNewName);
        GUIControlObject.ShowNewSaidName(randomNewName,position,fontSizeProfundity);
    }

    private void AddScore(int score)
    {
        int newScore;
        newScore = GlobalsObject.GetScore() + score;
        GlobalsObject.SetScore(newScore);
        GUIControlObject.ShowNewScore(newScore);
    }
}
