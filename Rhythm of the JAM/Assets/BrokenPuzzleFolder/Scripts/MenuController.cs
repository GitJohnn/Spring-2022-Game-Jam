using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public GameObject mainMenu, gameScoresPanel, PausePanel, OptionsPanel;


    // Start is called before the first frame update
    void Start()
    {
        mainMenu.SetActive(false);
        gameScoresPanel.SetActive(true);
        PausePanel.SetActive(false);
        GameManager.instance.StartGame();
    }

    public void SinglePlayer()
    {
        mainMenu.SetActive(false);
        gameScoresPanel.SetActive(true);
        PausePanel.SetActive(false);
        GameManager.instance.StartGame();
    }

    public void Multiplayer()
    {

    }

    public void Options()
    {

    }

    public void PauseGame()
    {
        PausePanel.SetActive(true);
        gameScoresPanel.SetActive(true);
        mainMenu.SetActive(false);
        GameManager.instance.UpdatePauseMusic();
        Time.timeScale = 0;
    }

    public void UnPauseGame()
    {
        PausePanel.SetActive(false);
        gameScoresPanel.SetActive(true);
        mainMenu.SetActive(false);
        GameManager.instance.UpdatePauseMusic();
        Time.timeScale = 1;
    }

    public void QuitButton()
    {
        Application.Quit();
    }

}
