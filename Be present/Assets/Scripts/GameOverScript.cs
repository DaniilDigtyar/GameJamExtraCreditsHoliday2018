using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScript : MonoBehaviour
{
    [SerializeField] private Text scoreText;

    void Start()
    {
        scoreText.text = "Final score " + Globals.score;
    }

}
