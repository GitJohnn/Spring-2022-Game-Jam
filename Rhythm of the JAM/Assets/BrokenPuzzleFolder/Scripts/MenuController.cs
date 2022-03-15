using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MenuController : MonoBehaviour
{
    public GameObject mainMenu, gameScoresPanel, PausePanel, gameOptionsPanel, mainMenuOptionsPanel, gameScorePanel, leaderboardPanel;

    public GameObject gameStartButton, pauseFirstButton, optionsGameFirstButton, optionsMainMenuFirstButton, gamescoreFirstButton, leaderboardFirstButton;
    
    // Start is called before the first frame update
    void Awake()
    {
        //clear selected gameobject
        // EventSystem.current.SetSelectedGameObject(null);
        //set selected gameobject
        // EventSystem.current.SetSelectedGameObject(gameStartButton);


        mainMenu.SetActive(false);
        gameScoresPanel.SetActive(true);
        PausePanel.SetActive(false);
        gameOptionsPanel.SetActive(false);
        mainMenuOptionsPanel.SetActive(false);
        gameScorePanel.SetActive(false);
        leaderboardPanel.SetActive(false);
        GameManager.instance.StartGame();
    }

    public void SinglePlayer()
    {
        mainMenu.SetActive(false);
        gameScoresPanel.SetActive(true);
        PausePanel.SetActive(false);
        gameOptionsPanel.SetActive(false);
        mainMenuOptionsPanel.SetActive(false);
        gameScorePanel.SetActive(false);
        leaderboardPanel.SetActive(false);
        GameManager.instance.StartGame();
    }

    public void Multiplayer()
    {

    }

    public void MainMenuOptions()
    {
        //clear selected gameobject
        EventSystem.current.SetSelectedGameObject(null);
        //set selected gameobject
        EventSystem.current.SetSelectedGameObject(optionsMainMenuFirstButton);

        mainMenu.SetActive(true);
        gameScoresPanel.SetActive(false);
        PausePanel.SetActive(false);
        gameOptionsPanel.SetActive(false);
        mainMenuOptionsPanel.SetActive(false);
        gameScorePanel.SetActive(false);
        leaderboardPanel.SetActive(false);
    }

    public void GameOptions()
    {
        //clear selected gameobject
        EventSystem.current.SetSelectedGameObject(null);
        //set selected gameobject
        EventSystem.current.SetSelectedGameObject(optionsGameFirstButton);

        mainMenu.SetActive(false);
        gameScoresPanel.SetActive(true);
        PausePanel.SetActive(true);
        gameOptionsPanel.SetActive(true);
        mainMenuOptionsPanel.SetActive(false);
        gameScorePanel.SetActive(false);
        leaderboardPanel.SetActive(false);
    }

    public void MainMenuReturnOptions()
    {
        //clear selected gameobject
        EventSystem.current.SetSelectedGameObject(null);
        //set selected gameobject
        EventSystem.current.SetSelectedGameObject(gameStartButton);

        mainMenu.SetActive(true);
        gameScoresPanel.SetActive(false);
        PausePanel.SetActive(false);
        gameOptionsPanel.SetActive(false);
        mainMenuOptionsPanel.SetActive(false);
        gameScorePanel.SetActive(false);
        leaderboardPanel.SetActive(false);
    }

    public void GameReturnOptions()
    {
        //clear selected gameobject
        EventSystem.current.SetSelectedGameObject(null);
        //set selected gameobject
        EventSystem.current.SetSelectedGameObject(pauseFirstButton);

        mainMenu.SetActive(false);
        gameScoresPanel.SetActive(true);
        PausePanel.SetActive(true);
        gameOptionsPanel.SetActive(false);
        mainMenuOptionsPanel.SetActive(false);
        gameScorePanel.SetActive(false);
        leaderboardPanel.SetActive(false);
    }

    public void PauseGame()
    {
        //clear selected gameobject
        EventSystem.current.SetSelectedGameObject(null);
        //set selected gameobject
        EventSystem.current.SetSelectedGameObject(pauseFirstButton);


        PausePanel.SetActive(true);
        gameScoresPanel.SetActive(true);
        mainMenu.SetActive(false);
        gameOptionsPanel.SetActive(false);
        mainMenuOptionsPanel.SetActive(false);
        gameScorePanel.SetActive(false);
        leaderboardPanel.SetActive(false);
        GameManager.instance.UpdatePauseMusic(true);
        Time.timeScale = 0;
    }

    public void UnPauseGame()
    {
        PausePanel.SetActive(false);
        gameScoresPanel.SetActive(true);
        mainMenu.SetActive(false);
        gameOptionsPanel.SetActive(false);
        mainMenuOptionsPanel.SetActive(false);
        gameScorePanel.SetActive(false);
        leaderboardPanel.SetActive(false);
        GameManager.instance.UpdatePauseMusic(false);
        Time.timeScale = 1;
    }

    public void GameEndScreen()
    {
        //clear selected gameobject
        EventSystem.current.SetSelectedGameObject(null);
        //set selected gameobject
        EventSystem.current.SetSelectedGameObject(gamescoreFirstButton);

        PausePanel.SetActive(false);
        gameScoresPanel.SetActive(true);
        mainMenu.SetActive(false);
        gameOptionsPanel.SetActive(false);
        mainMenuOptionsPanel.SetActive(false);
        gameScorePanel.SetActive(true);
        leaderboardPanel.SetActive(false);
    }

    public void LeaderboardScreen()
    {
        //clear selected gameobject
        EventSystem.current.SetSelectedGameObject(null);
        //set selected gameobject
        EventSystem.current.SetSelectedGameObject(leaderboardFirstButton);

        PausePanel.SetActive(false);
        gameScoresPanel.SetActive(true);
        mainMenu.SetActive(false);
        gameOptionsPanel.SetActive(false);
        mainMenuOptionsPanel.SetActive(false);
        gameScorePanel.SetActive(false);
        leaderboardPanel.SetActive(true);
    }

    public void ReturnToMusicSelection()
    {

    }

    public void QuitButton()
    {
        Application.Quit();
    }

}
