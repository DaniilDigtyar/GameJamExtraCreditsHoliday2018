using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    //
    public Text playerNameText;
    public Text saidNameText;

    //Objects
    GUIControl GUIControlObject;
    Globals GlobalsObject;
  

    private void Awake()
    {
        GUIControlObject = new GUIControl(playerNameText, saidNameText);
        GlobalsObject = new Globals();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ChangePlayerName();
        }
    }

    private void ChangePlayerName()
    {
        string randomNewName = GlobalsObject.GetEasyNames()[Random.Range(0,GlobalsObject.GetEasyNames().Count)];

        GlobalsObject.SetPlayerNameAssigned(randomNewName);
        GUIControlObject.ShowNewPlayerName(randomNewName);
    }
}
