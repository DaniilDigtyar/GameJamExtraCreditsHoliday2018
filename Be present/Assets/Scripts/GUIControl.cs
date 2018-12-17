using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIControl: MonoBehaviour
{
    private Text playerNameText;
    private Text saidNameText;
    private Text scoreText;
    private Text levelText;
    private Text studentAnswerText;
    private Image lifesImage;
    private Image background;

    public GUIControl(Text playerNameText, Text saidNameText, Text scoreText, Text levelText, Text studentAnswerText, Image lifesImage, Image background)
    {
        this.playerNameText = playerNameText;
        this.saidNameText = saidNameText;
        this.scoreText = scoreText;
        this.levelText = levelText;
        this.studentAnswerText = studentAnswerText;
        this.lifesImage = lifesImage;
        this.background = background;
    }

    public void ShowNewPlayerName(string newName)
    {
        playerNameText.text = string.Concat("Your name is ",newName);
    }

    public void ShowNewSaidName(string newName,Vector2 position, int size)
    {
        saidNameText.text = newName;
        saidNameText.rectTransform.anchoredPosition = position;
        saidNameText.fontSize = size;
    }

    public void ChangeLifes(Sprite lives)
    {
        lifesImage.sprite = lives;
    }

    public void ShowMissNamePhrase(string phrase)
    {
        saidNameText.fontSize = 50;
        saidNameText.rectTransform.position = new Vector2(Screen.width/4,Screen.height/1.5f);
        saidNameText.rectTransform.sizeDelta = new Vector2(300,60);
        saidNameText.text = phrase;
    }

    public void ShowNewScore(int score)
    {
        scoreText.text = string.Concat("Score ", score);
    }

    public void ShowNewLevel(int level)
    {
        levelText.text = string.Concat("Level ", level);
    }

    public void EnableStudentAnswerText()
    {
        saidNameText.enabled = false;
        studentAnswerText.enabled = true;
    }

    public void DisableStudentAnswerText()
    {
        saidNameText.enabled = true;
        studentAnswerText.enabled = false;
    }
}
