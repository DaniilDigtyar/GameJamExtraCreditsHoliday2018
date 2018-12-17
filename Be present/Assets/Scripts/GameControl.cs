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
    [SerializeField] private Text studentAnswerText;
    [SerializeField] private float timeNameChangeBase = 2;
    [SerializeField] private int basePoints = 100;
    [SerializeField] private int level = 1;
    [SerializeField] private int correctAnswerNedded = 1;
    [SerializeField] private Image lifesImage;
    [SerializeField] private Image background;
    [SerializeField] private Sprite[] lifesSprites;
    [SerializeField] private GameObject tryAgainButton;

    //Private
    private float timerStart;
    private bool timerStartStoped;
    private float timerReaction;
    private bool timerReactionStoped;
    private bool stopInput;
    private bool stopEndTime;
    private string dificulty;
    private float multiplicationRate;

    private int addPoints = 100;
    private float reactionTime = 2;
    private int correctAnswers;
    private float h;
    private float w;
    private float x;
    private float y;
    private int fontSizeProfundity;
    private Vector2 position;
    private float answerTime;
    private List<string> namesList = new List<string>();

    //Objects
    private GUIControl GUIControlObject;
    private Globals GlobalsObject;

    private void Awake()
    {

        lifesImage.sprite = lifesSprites[3];
        w = (float)(Screen.width);
        h = (float)(Screen.height);
        
        background.rectTransform.sizeDelta = new Vector2(w, h);
        GUIControlObject = new GUIControl(playerNameText, saidNameText, scoreText, levelText, studentAnswerText, lifesImage, background);
        
        GlobalsObject = new Globals();



        LoadLevel(level);
    }

    void Update()
    {
        if (!timerStartStoped)
        {


            timerStart += Time.deltaTime;
            if (timerStart%60 >= 3)
            {
                timerStartStoped = true;
                timerReactionStoped = false;
                stopInput = false;
                SayNewName();
            }
        }

        if (!timerReactionStoped)
        {
            if (Input.GetKeyDown(KeyCode.Space) && !stopInput)
            {
                ControlNameSaid();
            }

            if (timerReaction % 60 >= reactionTime && !stopEndTime)
            {
                ControlEndTime();
            }
            else
            {
                if (timerReaction % 60 >= answerTime + 2)
                {
                    stopInput = false;
                    timerReaction = 0;
                    GUIControlObject.DisableStudentAnswerText();

                        SayNewName();

                }
            }
            timerReaction += Time.deltaTime;
        }

    }

    private void LoadLevel(int level)
    {

        stopInput = true;
        timerReactionStoped = true;
        timerStartStoped = false;
        timerStart = 0;
        timerReaction = 0;
        correctAnswers = 0;


        float addPointsF;
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


        addPointsF = basePoints * multiplicationRate;
        addPoints = (int)addPointsF;

        reactionTime = (timeNameChangeBase - 1) * multiplicationRate;

        switch (dificulty)
        {
            case "easy":
                namesList = GlobalsObject.ResetEasyNames();
                break;
            case "medium":
                namesList = GlobalsObject.ResetMediumNames();
                break;
            case "hard":
                namesList = GlobalsObject.ResetHardNames();
                break;
        }

        Globals.actualLevel = level;
        GUIControlObject.ShowNewLevel(level);
        GUIControlObject.ShowNewScore(Globals.score);
        GUIControlObject.ChangeLifes(lifesSprites[Globals.lifesLeft]);


        ChangePlayerName(dificulty);
        position = new Vector2(w / 4, h / 2);
        GUIControlObject.ShowNewSaidName("Okay we are going to start!", position, 25);

    }


    private void ControlNameSaid()
    {
        stopInput = true;
        stopEndTime = true;
        answerTime = reactionTime;
        if (GlobalsObject.GetSaidNameAssigned().Equals(GlobalsObject.GetPlayerNameAssigned()))
        {
            correctAnswers++;
            AddScore(addPoints);
            GUIControlObject.EnableStudentAnswerText();
            if (correctAnswers >= correctAnswerNedded)
            {
                SceneManager.LoadScene(string.Concat("Change to Level", Globals.actualLevel + 1));
            }
            ChangePlayerName(dificulty);
        }
        else
        {
            ControlLifes();
            timerReactionStoped = true;
            SayMissNamePhrase();
        }
        
    }

    private void ControlLifes()
    {
        int lifes = Globals.lifesLeft;
        if (lifes > 1)
        {
            lifes--;
            Globals.lifesLeft = lifes;
            GUIControlObject.ChangeLifes(lifesSprites[lifes]);

        }
        else if (lifes == 1)
        {
            lifes--;
            Globals.lifesLeft = lifes;
            GUIControlObject.ChangeLifes(lifesSprites[lifes]);
            Invoke("GameOver", 2f);
        }
    }

    private void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }

    private void ControlEndTime()
    {
        stopInput = true;
        
        if (!GlobalsObject.GetSaidNameAssigned().Equals(GlobalsObject.GetPlayerNameAssigned()))
        {
            GUIControlObject.EnableStudentAnswerText();
            if (timerReaction % 60 >= reactionTime + 2)
            {
                stopInput = false;
                timerReaction = 0;
                GUIControlObject.DisableStudentAnswerText();
                SayNewName();
            }
        }
        else
        {
            ControlLifes();
            timerReactionStoped = true;
            SayMissNamePhrase();
        }
    }

    private void ChangePlayerName(string dificulty)
    {
        int index;
        string randomNewName;
        index = Random.Range(0, namesList.Count-1);

        randomNewName = namesList[index];

        GlobalsObject.SetPlayerNameAssigned(randomNewName);
        GUIControlObject.ShowNewPlayerName(randomNewName);
    }

    private void SayNewName()
    {
        int index;
        string randomNewName;
        stopEndTime = false;

        index = Random.Range(0, namesList.Count-1);
        
        
        x = Random.Range( w / 5 , 2 * w / 5);
        y = Random.Range( h / 4, h * 3 / 4);
        position = new Vector2(x, y);
        fontSizeProfundity = (int)(w/6  + (x - w) * 10 / w);

        randomNewName = namesList[index];
        GlobalsObject.SetSaidNameAssigned(randomNewName);
        GUIControlObject.ShowNewSaidName(randomNewName, position, fontSizeProfundity);
        DeleteName(index);
    }

    private void DeleteName(int index)
    {
        print(namesList[index]);
        namesList.RemoveAt(index);
        if (namesList.Count <= 0)
        {
            print("reset");
            switch (dificulty)
            {
                case "easy":
                    namesList = GlobalsObject.ResetEasyNames();
                    break;
                case "medium":
                    namesList = GlobalsObject.ResetMediumNames();
                    break;
                case "hard":
                    namesList = GlobalsObject.ResetHardNames();
                    break;
            }
        }
    }


    private void AddScore(int score)
    {
        int newScore;
        newScore = Globals.score + score;
        Globals.score = newScore;
        GUIControlObject.ShowNewScore(newScore);
    }

    private void SayMissNamePhrase()
    {
        if (Globals.lifesLeft > 0)
        {
            tryAgainButton.SetActive(true);
        }
        int index;
        List<string> phraseList = new List<string>();
        phraseList = GlobalsObject.GetMissNamePhrases();
        index = Random.Range(0, phraseList.Count);
        
        GUIControlObject.ShowMissNamePhrase(string.Concat(phraseList[index], GlobalsObject.GetPlayerNameAssigned()));
    }

    private void TryAgain()
    {
        tryAgainButton.SetActive(false);
        LoadLevel(Globals.actualLevel);
    }
}
