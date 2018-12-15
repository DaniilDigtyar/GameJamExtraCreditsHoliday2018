using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsHandler : MonoBehaviour
{
    public void ButtonCredits()
    {
        Invoke("Credits", 0.5f);
    }
    private void Credits()
    {
        Application.LoadLevel("Credits");
    }

    public void ButtonMenu()
    {
        Invoke("Menu", 0.5f);
    }
    private void Menu()
    {
        Application.LoadLevel("MenuPrincipal");
    }

    public void ButtonPlay()
    {
        Invoke("Play", 0.5f);
    }
    private void Play()
    {
        Application.LoadLevel("Main");
    }

    public void ButtonInstructions()
    {
        Invoke("Instructions", 0.5f);
    }
    private void Instructions()
    {
        Application.LoadLevel("Instructions");
    }

    public void ButtonExit()
    {
        Invoke("Exit", 0.5f);
    }
    private void Exit()
    {
        Application.Quit();
    }
}
