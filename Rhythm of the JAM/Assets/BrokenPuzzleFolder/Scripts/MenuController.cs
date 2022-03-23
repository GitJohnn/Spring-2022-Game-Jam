using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MenuController : MonoBehaviour
{
    public FadeController fadePanel;

    public GameObject mouseWarningPanel;
    public GameObject mouseWarningEnterButton;

    public GameObject mainMenu, gameScoresPanel, PausePanel, gameOptionsPanel, mainMenuOptionsPanel, gameScorePanel, leaderboardPanel, musicLibraryPanel;

    public GameObject gameStartButton, pauseFirstButton, optionsGameFirstButton, optionsMainMenuFirstButton, gamescoreFirstButton, leaderboardFirstButton, musicLibraryFirstButton;

    private GameObject currentSelectedObj;

    // Start is called before the first frame update
    void Awake()
    {
        fadePanel.gameObject.SetActive(true);
        fadePanel.FadeOut();

        SwitchMenu(gameStartButton,new bool[] { false, false, true, false, false, false, false, false });

        mouseWarningPanel.SetActive(true);

        EventSystem.current.SetSelectedGameObject(null);
        //set selected gameobject
        EventSystem.current.SetSelectedGameObject(mouseWarningEnterButton);
    }

    public void MouseWarning()
    {
        EventSystem.current.SetSelectedGameObject(null);
        //set selected gameobject
        EventSystem.current.SetSelectedGameObject(gameStartButton);
    }

    public void SinglePlayer()
    {
        StartCoroutine(SwitchMenuCoroutine(musicLibraryFirstButton, new bool[] { false, true, false, false, false, false, false, true }));

        //SwitchMenu(musicLibraryFirstButton, new bool[] { false, true, false, false, false, false, false, true });

        ////clear selected gameobject
        //EventSystem.current.SetSelectedGameObject(null);
        ////set selected gameobject
        //EventSystem.current.SetSelectedGameObject(musicLibraryFirstButton);

        //PausePanel.SetActive(false);
        //gameScoresPanel.SetActive(true);
        //mainMenu.SetActive(false);
        //gameOptionsPanel.SetActive(false);
        //mainMenuOptionsPanel.SetActive(false);
        //gameScorePanel.SetActive(false);
        //leaderboardPanel.SetActive(false);
        //musicLibraryPanel.SetActive(true);
    }

    public void MainMenuOptions()
    {
        SwitchMenu(optionsMainMenuFirstButton, new bool[] { false, false, true, false, true, false, false, false });

        ////clear selected gameobject
        //EventSystem.current.SetSelectedGameObject(null);
        ////set selected gameobject
        //EventSystem.current.SetSelectedGameObject(optionsMainMenuFirstButton);

        //PausePanel.SetActive(false);
        //gameScoresPanel.SetActive(false);
        //mainMenu.SetActive(true);
        //gameOptionsPanel.SetActive(false);
        //mainMenuOptionsPanel.SetActive(true);
        //gameScorePanel.SetActive(false);
        //leaderboardPanel.SetActive(false);
        //musicLibraryPanel.SetActive(false);
    }

    public void GameOptions()
    {
        SwitchMenu(optionsGameFirstButton, new bool[] { true, true, false, true, false, false, false, false });

        ////clear selected gameobject
        //EventSystem.current.SetSelectedGameObject(null);
        ////set selected gameobject
        //EventSystem.current.SetSelectedGameObject(optionsGameFirstButton);

        //PausePanel.SetActive(true);
        //gameScoresPanel.SetActive(true);
        //mainMenu.SetActive(false);
        //gameOptionsPanel.SetActive(true);
        //mainMenuOptionsPanel.SetActive(false);
        //gameScorePanel.SetActive(false);
        //leaderboardPanel.SetActive(false);
        //musicLibraryPanel.SetActive(false);
    }

    public void MainMenuReturnOptions()
    {
        SwitchMenu(gameStartButton, new bool[] { false, false, true, false, false, false, false, false });

        ////clear selected gameobject
        //EventSystem.current.SetSelectedGameObject(null);
        ////set selected gameobject
        //EventSystem.current.SetSelectedGameObject(gameStartButton);

        //PausePanel.SetActive(false);
        //gameScoresPanel.SetActive(false);
        //mainMenu.SetActive(true);
        //gameOptionsPanel.SetActive(false);
        //mainMenuOptionsPanel.SetActive(false);
        //gameScorePanel.SetActive(false);
        //leaderboardPanel.SetActive(false);
        //musicLibraryPanel.SetActive(false);
    }

    public void GameReturnOptions()
    {
        SwitchMenu(pauseFirstButton, new bool[] { true, true, false, false, false, false, false, false });

        ////clear selected gameobject
        //EventSystem.current.SetSelectedGameObject(null);
        ////set selected gameobject
        //EventSystem.current.SetSelectedGameObject(pauseFirstButton);

        //PausePanel.SetActive(true);
        //gameScoresPanel.SetActive(true);
        //mainMenu.SetActive(false);             
        //gameOptionsPanel.SetActive(false);
        //mainMenuOptionsPanel.SetActive(false);
        //gameScorePanel.SetActive(false);
        //leaderboardPanel.SetActive(false);
        //musicLibraryPanel.SetActive(false);
    }

    public void PauseGame()
    {
        SwitchMenu(pauseFirstButton, new bool[] { true, true, false, false, false, false, false, false });

        ////clear selected gameobject
        //EventSystem.current.SetSelectedGameObject(null);
        ////set selected gameobject
        //EventSystem.current.SetSelectedGameObject(pauseFirstButton);

        //PausePanel.SetActive(true);
        //gameScoresPanel.SetActive(true);
        //mainMenu.SetActive(false);
        //gameOptionsPanel.SetActive(false);
        //mainMenuOptionsPanel.SetActive(false);
        //gameScorePanel.SetActive(false);
        //leaderboardPanel.SetActive(false);
        //musicLibraryPanel.SetActive(false);
        GameManager.instance.UpdatePauseMusic(true);
        Time.timeScale = 0;
    }

    public void UnPauseGame()
    {
        SwitchMenu(null, new bool[] { false, true, false, false, false, false, false, false });

        //PausePanel.SetActive(false);
        //gameScoresPanel.SetActive(true);
        //mainMenu.SetActive(false);
        //gameOptionsPanel.SetActive(false);
        //mainMenuOptionsPanel.SetActive(false);
        //gameScorePanel.SetActive(false);
        //leaderboardPanel.SetActive(false);
        //musicLibraryPanel.SetActive(false);
        GameManager.instance.UpdatePauseMusic(false);
        Time.timeScale = 1;
    }

    public void GameEndScreen()
    {
        SwitchMenu(gamescoreFirstButton, new bool[] { false, true, false, false, false, true, false, false });

        ////clear selected gameobject
        //EventSystem.current.SetSelectedGameObject(null);
        ////set selected gameobject
        //EventSystem.current.SetSelectedGameObject(gamescoreFirstButton);

        //PausePanel.SetActive(false);
        //gameScoresPanel.SetActive(true);
        //mainMenu.SetActive(false);
        //gameOptionsPanel.SetActive(false);
        //mainMenuOptionsPanel.SetActive(false);
        //gameScorePanel.SetActive(true);
        //leaderboardPanel.SetActive(false);
        //musicLibraryPanel.SetActive(false);
    }

    public void LeaderboardScreen()
    {
        SwitchMenu(leaderboardFirstButton, new bool[] { false, true, false, false, false, false, true, false });

        ////clear selected gameobject
        //EventSystem.current.SetSelectedGameObject(null);
        ////set selected gameobject
        //EventSystem.current.SetSelectedGameObject(leaderboardFirstButton);

        //PausePanel.SetActive(false);
        //gameScoresPanel.SetActive(true);
        //mainMenu.SetActive(false);
        //gameOptionsPanel.SetActive(false);
        //mainMenuOptionsPanel.SetActive(false);
        //gameScorePanel.SetActive(false);
        //leaderboardPanel.SetActive(true);
        //musicLibraryPanel.SetActive(false);
    }

    public void StartSongFromMusicLibrary()
    {
        //StartCoroutine(null, new bool[] { false, true, false, false, false, false, false, false });

        SwitchMenu(null, new bool[] { false, true, false, false, false, false, false, false });

        //PausePanel.SetActive(false);
        //gameScoresPanel.SetActive(true);
        //mainMenu.SetActive(false);
        //gameOptionsPanel.SetActive(false);
        //mainMenuOptionsPanel.SetActive(false);
        //gameScorePanel.SetActive(false);
        //leaderboardPanel.SetActive(false);
        //musicLibraryPanel.SetActive(false);
    }

    public void OpenMusicSelection()
    {
        SwitchMenu(musicLibraryFirstButton, new bool[] { false, false, false, false, false, false, false, true });

        ////clear selected gameobject
        //EventSystem.current.SetSelectedGameObject(null);
        ////set selected gameobject
        //EventSystem.current.SetSelectedGameObject(musicLibraryFirstButton);

        //PausePanel.SetActive(false);
        //gameScoresPanel.SetActive(false);
        //mainMenu.SetActive(false);
        //gameOptionsPanel.SetActive(false);
        //mainMenuOptionsPanel.SetActive(false);
        //gameScorePanel.SetActive(false);
        //leaderboardPanel.SetActive(false);
        //musicLibraryPanel.SetActive(true);
    }

    public void QuitButton()
    {
        Application.Quit();
    }

    private void SwitchMenu(GameObject selectedObj, bool[] menuSettings)
    {
        EventSystem.current.SetSelectedGameObject(null);
        //set selected gameobject
        if(selectedObj != null)
            EventSystem.current.SetSelectedGameObject(selectedObj);

        PausePanel.SetActive(menuSettings[0]);
        gameScoresPanel.SetActive(menuSettings[1]);
        mainMenu.SetActive(menuSettings[2]);
        gameOptionsPanel.SetActive(menuSettings[3]);
        mainMenuOptionsPanel.SetActive(menuSettings[4]);
        gameScorePanel.SetActive(menuSettings[5]);
        leaderboardPanel.SetActive(menuSettings[6]);
        musicLibraryPanel.SetActive(menuSettings[7]);
    }

    private IEnumerator SwitchMenuCoroutine(GameObject selectedObj, bool[] menuSettings)
    {
        fadePanel.gameObject.SetActive(true);
        fadePanel.FadeIn();
        yield return new WaitUntil(() => fadePanel.IsFadeIn);
        SwitchMenu(selectedObj, menuSettings);
        fadePanel.FadeOut();        
        yield return new WaitUntil(() => !fadePanel.IsFadeIn);
        //fadePanel.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.1f);
    }

    private IEnumerator SwitchMenuCoroutine(GameObject selectedObj, bool[] menuSettings, float fadeOutDelay)
    {
        fadePanel.gameObject.SetActive(true);
        fadePanel.FadeIn();
        yield return new WaitUntil(() => fadePanel.IsFadeIn);
        SwitchMenu(selectedObj, menuSettings);
        yield return new WaitForSeconds(fadeOutDelay);
        fadePanel.FadeOut();
        yield return new WaitUntil(() => !fadePanel.IsFadeIn);
        //fadePanel.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.1f);
    }

}
