using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsHandler : MonoBehaviour
{
    [SerializeField] private GameObject gameControlScript;

    public void ButtonCredits()
    {
        Invoke("Credits", 0.5f);
    }
    private void Credits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void ButtonMenu()
    {
        Invoke("Menu", 0.5f);
    }
    private void Menu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void ButtonPlay()
    {
        Invoke("Play", 0.5f);
    }
    private void Play()
    {
        SceneManager.LoadScene("Level1");
    }

    public void ButtonPlayLevel2()
    {
        Invoke("PlayLevel2", 0.5f);
    }
    private void PlayLevel2()
    {
        SceneManager.LoadScene("Level2");
    }

    public void ButtonPlayLevel3()
    {
        Invoke("PlayLevel3", 0.5f);
    }
    private void PlayLevel3()
    {
        SceneManager.LoadScene("Level3");
    }

    public void ButtonPlayLevel4()
    {
        Invoke("PlayLevel4", 0.5f);
    }
    private void PlayLevel4()
    {
        SceneManager.LoadScene("Level4");
    }

    public void ButtonPlayLevel5()
    {
        Invoke("PlayLevel5", 0.5f);
    }
    private void PlayLevel5()
    {
        SceneManager.LoadScene("Level5");
    }

    public void ButtonInstructions()
    {
        Invoke("Instructions", 0.5f);
    }
    private void Instructions()
    {
        SceneManager.LoadScene("Instructions");
    }

    public void ButtonExit()
    {
        Invoke("Exit", 0.5f);
    }
    private void Exit()
    {
        Application.Quit();
    }

    public void ButtonTryAgain()
    {
        Invoke("TryAgain", 0.5f);
    }
    private void TryAgain()
    {
        gameControlScript.BroadcastMessage("TryAgain");
    }

}
