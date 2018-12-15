using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine;

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

    //Private
    private float timerStart;
    private bool timerStartStoped;
    private float timerReaction;
    private bool timerReactionStoped;
    private string dificulty;
    private float multiplicationRate;
    private int lastIndexSaidName = -1;
    private int lastIndexPlayerName = -1;
    private int addPoints = 100;
    private float reactionTime = 2;


    //Objects
    private GUIControl GUIControlObject;
    private Globals GlobalsObject;

    private void Awake()
    {
        timerReactionStoped = true;
        timerStartStoped = true;
        GUIControlObject = new GUIControl(playerNameText, saidNameText, scoreText, levelText, studentAnswerText);
        GlobalsObject = new Globals();
        LoadLevel(1);
    }

    void Update()
    {
        if (!timerStartStoped)
        {
            GUIControlObject.ShowNewSaidName("Okay we are going to start!");
            timerStart += Time.deltaTime;
            if (timerStart%60 >= 3)
            {
                timerStartStoped = true;
                timerReactionStoped = false;
                SayNewName();
            }
        }

        if (!timerReactionStoped)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                ControlNameSaid();
            }

            if (timerReaction % 60 >= reactionTime)
            {
                ControlEndTime();
            }
            timerReaction += Time.deltaTime;
        }

    }

    private void LoadLevel(int level)
    {
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

        GlobalsObject.SetActualLevel(level);
        GUIControlObject.ShowNewLevel(level);
        ChangePlayerName(dificulty);
        timerStartStoped = false;
    }


    private void ControlNameSaid()
    {
        float answerTime = reactionTime;
        if (GlobalsObject.GetSaidNameAssigned().Equals(GlobalsObject.GetPlayerNameAssigned()))
        {
            AddScore(addPoints);
            GUIControlObject.EnableStudentAnswerText();

            if (timerReaction % 60 >= answerTime + 2)
            {
                timerReaction = 0;
                GUIControlObject.DisableStudentAnswerText();
                SayNewName();
            }
        }
        else
        {
            print("incorrecto");
        }
        ChangePlayerName(dificulty);
    }

    private void ControlEndTime()
    {
        if (!GlobalsObject.GetSaidNameAssigned().Equals(GlobalsObject.GetPlayerNameAssigned()))
        {
            GUIControlObject.EnableStudentAnswerText();
            if (timerReaction % 60 >= reactionTime + 2)
            {
                timerReaction = 0;
                GUIControlObject.DisableStudentAnswerText();
                SayNewName();
            }
        }
        else
        {
            timerReactionStoped = true;
            SayMissNamePhrase();
        }
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

        lastIndexSaidName = index;

        randomNewName = namesList[index];
        GlobalsObject.SetSaidNameAssigned(randomNewName);
        GUIControlObject.ShowNewSaidName(randomNewName);
    }

    private void AddScore(int score)
    {
        int newScore;
        newScore = GlobalsObject.GetScore() + score;
        GlobalsObject.SetScore(newScore);
        GUIControlObject.ShowNewScore(newScore);
    }

    //FALTA HACER EL RANDOM PARA ESCOJER FRASE DE ERROR
    private void SayMissNamePhrase()
    {
        int index;
        List<string> phraseList = new List<string>();
        phraseList = GlobalsObject.GetMissNamePhrases();
        index = Random.Range(0, phraseList.Count);
        GUIControlObject.ShowMissNamePhrase(phraseList[index]);
    }
}
