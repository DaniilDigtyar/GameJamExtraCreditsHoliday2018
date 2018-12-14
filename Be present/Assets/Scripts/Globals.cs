using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Globals : MonoBehaviour
{
    private string playerNameAssigned;
    private List<string> namesEasy;

    public Globals()
    {
        this.playerNameAssigned = "";
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
}
