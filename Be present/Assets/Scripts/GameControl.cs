using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    //to edit
    public Text playerNameText;
    public Text saidNameText;
    public float timeNameChange;

    //Private
    float timer;
    int lastIndexSaidName = -1;
    int lastIndexPlayerName = -1;

    //Objects
    GUIControl GUIControlObject;
    Globals GlobalsObject;
  

    private void Awake()
    {
        GUIControlObject = new GUIControl(playerNameText, saidNameText);
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
            print("correcto");
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
}
