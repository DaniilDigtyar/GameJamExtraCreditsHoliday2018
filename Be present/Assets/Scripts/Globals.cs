using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Globals : MonoBehaviour
{
    private string playerNameAssigned;
    private string saidNameAssigned;
    private List<string> namesEasy;

    public Globals()
    {
        this.playerNameAssigned = "";
        this.saidNameAssigned = "";
        this.namesEasy = new List<string>() { "Daniil", "Bryan", "Sara" };
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
}
