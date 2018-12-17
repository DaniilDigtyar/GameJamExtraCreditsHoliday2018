using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsHandler : MonoBehaviour
{
    [SerializeField] private GameObject gameControlScript;
    [SerializeField] private AudioSource click;

    public void ButtonCredits()
    {
        click.Play();
        Invoke("Credits", 0.5f);
    }
    private void Credits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void ButtonMenu()
    {
        click.Play();
        Invoke("Menu", 0.5f);
    }
    private void Menu()
    {
        Globals.lifesLeft = 3;
        Globals.score = 0;
        SceneManager.LoadScene("Menu");
    }

    public void ButtonPlay()
    {
        click.Play();
        Invoke("Play", 0.5f);
    }
    private void Play()
    {
        SceneManager.LoadScene("Level1");
    }

    public void ButtonPlayLevel2()
    {
        click.Play();
        Invoke("PlayLevel2", 0.5f);
    }
    private void PlayLevel2()
    {
        SceneManager.LoadScene("Level2");
    }

    public void ButtonPlayLevel3()
    {
        click.Play();
        Invoke("PlayLevel3", 0.5f);
    }
    private void PlayLevel3()
    {
        SceneManager.LoadScene("Level3");
    }

    public void ButtonPlayLevel4()
    {
        click.Play();
        Invoke("PlayLevel4", 0.5f);
    }
    private void PlayLevel4()
    {
        SceneManager.LoadScene("Level4");
    }

    public void ButtonPlayLevel5()
    {
        click.Play();
        Invoke("PlayLevel5", 0.5f);
    }
    private void PlayLevel5()
    {
        SceneManager.LoadScene("Level5");
    }

    public void ButtonInstructions()
    {
        click.Play();
        Invoke("Instructions", 0.5f);
    }
    private void Instructions()
    {
        SceneManager.LoadScene("Instructions");
    }

    public void ButtonExit()
    {
        click.Play();
        Invoke("Exit", 0.5f);
    }
    private void Exit()
    {
        Application.Quit();
    }

    public void ButtonTryAgain()
    {
        click.Play();
        Invoke("TryAgain", 0.5f);
    }
    private void TryAgain()
    {
        gameControlScript.BroadcastMessage("TryAgain");
    }

}
