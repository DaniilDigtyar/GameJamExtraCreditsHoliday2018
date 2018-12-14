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
    [SerializeField] private float timeNameChange;
    [SerializeField] private int points = 100;

    //Private
    private float timer;
    private int lastIndexSaidName = -1;
    private int lastIndexPlayerName = -1;

    //Objects
    private GUIControl GUIControlObject;
    private Globals GlobalsObject;
  
    private void Awake()
    {
        GUIControlObject = new GUIControl(playerNameText, saidNameText, scoreText, levelText);
        GlobalsObject = new Globals();
        ChangePlayerName();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ControlNameSaid();
        }

        if (timer % 60 >= timeNameChange -1)
        {
            timer = 0;
            SayNewName();
        }

        timer += Time.deltaTime;
    }

    private void ControlNameSaid()
    {
        if (GlobalsObject.GetSaidNameAssigned().Equals(GlobalsObject.GetPlayerNameAssigned()))
        {
            AddScore(points);
        }
        else
        {
            print("incorrecto");
        }
        ChangePlayerName();
    }

    private void ChangePlayerName()
    {
        int index;
        string randomNewName;
        do
        {
            index = Random.Range(0, GlobalsObject.GetEasyNames().Count);
        } while (index == lastIndexPlayerName);

        lastIndexPlayerName = index;

        randomNewName = GlobalsObject.GetEasyNames()[index];
        GlobalsObject.SetPlayerNameAssigned(randomNewName);
        GUIControlObject.ShowNewPlayerName(randomNewName);
    }

    private void SayNewName()
    {
        int index;
        string randomNewName;
        do
        {
            index = Random.Range(0, GlobalsObject.GetEasyNames().Count);
        } while (index == lastIndexSaidName);

        lastIndexSaidName = index;

        randomNewName = GlobalsObject.GetEasyNames()[index];
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
}
