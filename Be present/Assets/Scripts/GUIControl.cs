using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIControl: MonoBehaviour
{
    private Text playerNameText;
    private Text saidNameText;

    public GUIControl(Text playerNameText, Text saidNameText)
    {
        this.playerNameText = playerNameText;
        this.saidNameText = saidNameText;
    }

    public void ShowNewPlayerName(string newName)
    {
        playerNameText.text = newName;
    }

    public void ShowNewSaidName(string newName)
    {
        saidNameText.text = newName;
    }
}
