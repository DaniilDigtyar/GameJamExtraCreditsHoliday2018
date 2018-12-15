using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Globals : MonoBehaviour
{
    string[] missNamePhrase =
    {
        "I said name"
    };

    private string playerNameAssigned;
    private string saidNameAssigned;
    private List<string> namesEasy;
    private List<string> namesMedium;
    private List<string> namesHard;
    private List<string> missNamePhrases;
    private int score;
    private int actualLevel;
    private int lifesLeft;

    public Globals()
    {
        this.playerNameAssigned = "";
        this.saidNameAssigned = "";
        this.namesEasy = new List<string>() { "Daniil", "Bryan", "Sara" };
        this.missNamePhrases = new List<string>(missNamePhrase);
        this.score = 0;
        this.actualLevel = 1;
        this.lifesLeft = 3;
    }

    public Globals(int score, int actualLevel, int lifesLeft)
    {
        this.playerNameAssigned = "";
        this.saidNameAssigned = "";
        this.namesEasy = new List<string>() { "Daniil", "Bryan", "Sara" };
        this.score = score;
        this.actualLevel = actualLevel;
        this.lifesLeft = lifesLeft;
    }

    public List<string> GetEasyNames()
    {
        return this.namesEasy;
    }

    public void SetPlayerNameAssigned(string name)
    {
        this.playerNameAssigned = name;
    }

    public string GetPlayerNameAssigned()
    {
        return this.playerNameAssigned;
    }

    public void SetSaidNameAssigned(string name)
    {
        this.saidNameAssigned = name;
    }

    public string GetSaidNameAssigned()
    {
        return this.saidNameAssigned;
    }

    public int GetScore()
    {
        return this.score;
    }

    public void SetScore(int score)
    {
        this.score = score;
    }

    public int GetActualLevel()
    {
        return this.actualLevel;
    }

    public void SetActualLevel(int actualLevel)
    {
        this.actualLevel = actualLevel;
    }

    public List<string> GetMissNamePhrases()
    {
        return this.missNamePhrases;
    }
}
