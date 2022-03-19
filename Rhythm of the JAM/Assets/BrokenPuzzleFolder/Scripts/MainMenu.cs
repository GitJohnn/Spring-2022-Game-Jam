using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MainMenu : MonoBehaviour
{   

    public GameObject gameStartButton, multiplayerStartButton, optionsButton, quitButton;

    void Awake(){
        //clear selected gameobject
        EventSystem.current.SetSelectedGameObject(null);
        //set selected gameobject
        EventSystem.current.SetSelectedGameObject(gameStartButton);
    }
    public void StartGameButton(){
        //clear selected gameobject
        EventSystem.current.SetSelectedGameObject(null);
        //set selected gameobject
        EventSystem.current.SetSelectedGameObject(multiplayerStartButton);

        SceneManager.LoadScene("GameScene");

        // GameManager.instance.StartGame();
    }

    public void MultiPlayerStartGame(){
        //clear selected gameobject
        EventSystem.current.SetSelectedGameObject(null);
        //set selected gameobject
        EventSystem.current.SetSelectedGameObject(optionsButton);

    }

    public void OptionsButton(){
        //clear selected gameobject
        EventSystem.current.SetSelectedGameObject(null);
        //set selected gameobject
        EventSystem.current.SetSelectedGameObject(quitButton);


    }


    public void QuitButton(){
        //clear selected gameobject
        EventSystem.current.SetSelectedGameObject(null);
        //set selected gameobject
        EventSystem.current.SetSelectedGameObject(gameStartButton);

    }
}
