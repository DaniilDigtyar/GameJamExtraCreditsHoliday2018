﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIControl: MonoBehaviour
{
    private Text playerNameText;
    private Text saidNameText;
    private Text scoreText;
    private Text levelText;

    public GUIControl(Text playerNameText, Text saidNameText, Text scoreText, Text levelText)
    {
        this.playerNameText = playerNameText;
        this.saidNameText = saidNameText;
        this.scoreText = scoreText;
        this.levelText = levelText;
    }

    public void ShowNewPlayerName(string newName)
    {
        playerNameText.text = string.Concat("Your name ",newName);
    }

    public void ShowNewSaidName(string newName)
    {
        saidNameText.text = newName;
    }

    public void ShowNewScore(int score)
    {
        scoreText.text = string.Concat("Score: ", score);
    }
}
