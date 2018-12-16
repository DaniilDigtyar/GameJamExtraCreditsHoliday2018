using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Globals : MonoBehaviour
{
    
    string[] missNamePhrasesRaw =
    {
        "I said ","Next time punishment, ", "I recomend you to respond next time, "
    };

    string[] namesEasyRaw =
    {
        "Daniil", "Bryan", "Sara"
    };

    string[] namesMediumRaw =
    {
        "Eduard", "Ignasi", "Guillem"
    };

    string[] namesHardRaw =
    {
        "Harmandeep", "Belinda", "Bergljot"
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
        this.namesEasy = new List<string>(namesEasyRaw);
        this.namesMedium = new List<string>(namesMediumRaw);
        this.namesHard = new List<string>(namesHardRaw);
        this.missNamePhrases = new List<string>(missNamePhrasesRaw);
        this.score = 0;
        this.actualLevel = 1;
        this.lifesLeft = 3;
    }

    public List<string> GetEasyNames()
    {
        return this.namesEasy;
    }

    public List<string> GetMediumNames()
    {
        return this.namesMedium;
    }

    public List<string> GetHardNames()
    {
        return this.namesHard;
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

    public void SetLifesLeft(int lifes)
    {
        this.lifesLeft = lifes;
    }
    public int GetLifesLeft()
    {
        return this.lifesLeft;
    }
}