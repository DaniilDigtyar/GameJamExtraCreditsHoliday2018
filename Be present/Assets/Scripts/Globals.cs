using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Globals : MonoBehaviour
{
    
    string[] missNamePhrasesRaw =
    {
        "I said ","Next time penalty, ", "I recomend you to answer next time, "
    };

    string[] namesEasy1Raw =
    {
        "Daniil", "Bryan", "Sara", "Elena", "Adria", "Albert", "Clara", "Marc","David","Xavier"
    };

    string[] namesEasy2Raw =
{
        "Alex", "Andy", "Angel", "Bernat", "Didac", "Diego", "Edgar", "Eric","Ivan","Joan"
    };

    string[] namesEasy3Raw =
{
        "Laia", "Joel", "Lluis", "Nuria", "Oriol", "Pablo", "Pau", "Pere","Paulo","Quim","Nuria"
    };

    string[] namesMedium1Raw =
    {
        "Eduard", "Ignasi", "Guillem", "William", "Samantha", "Thomas", "Roberts","Miquel","Miguel","Xavier"
    };

    string[] namesMedium2Raw =
{
        "Rubem", "Talia", "Toni", "Luciana", "Thodora", "Rafaella", "Victoria","Gerard","Daniel","Charles"
    };

    string[] namesHard1Raw =
    {
        "Harmandeep", "Belinda", "Bergljot", "Elizabeth", "Wilson", "Williams", "Alexander", "Anderson", "Augustus", "Esmeralda", "Isabella"
    };

    private string playerNameAssigned;
    private string saidNameAssigned;
    private List<string> namesEasy1;
    private List<string> namesEasy2;
    private List<string> namesEasy3;
    private List<string> namesMedium1;
    private List<string> namesMedium2;
    private List<string> namesHard1;
    private List<string> missNamePhrases;
    public static int score = 0;
    public static int actualLevel = 1;
    public static int lifesLeft = 3;

    public Globals()
    {
        this.playerNameAssigned = "";
        this.saidNameAssigned = "";
        this.namesEasy1 = new List<string>(namesEasy1Raw);
        this.namesEasy2 = new List<string>(namesEasy2Raw);
        this.namesEasy3 = new List<string>(namesEasy3Raw);
        this.namesMedium1 = new List<string>(namesMedium1Raw);
        this.namesMedium2 = new List<string>(namesMedium2Raw);
        this.namesHard1 = new List<string>(namesHard1Raw);
        this.missNamePhrases = new List<string>(missNamePhrasesRaw);
    }

    public List<string> ResetEasyNames()
    {
        int i=Random.Range(0, 3);
        switch (i)
        {
            case 1:
                return new List<string>(namesEasy1Raw);

                break;
            case 2:
                return new List<string>(namesEasy2Raw);

                break;
            case 3:
                return new List<string>(namesEasy3Raw);

                break;
        }
        return new List<string>(namesEasy1Raw);

    }


    public List<string> ResetMediumNames()
    {
        int i = Random.Range(0, 2);
        switch (i)
        {
            case 1:
                return new List<string>(namesMedium1Raw);

                break;
            case 2:
                return new List<string>(namesMedium2Raw);

                break;

        }

        return new List<string>(namesMedium1Raw);
    }


    public List<string> ResetHardNames()
    {
        return new List<string>(namesHard1Raw);
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

    public List<string> GetMissNamePhrases()
    {
        return this.missNamePhrases;
    }

}