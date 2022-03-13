using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public AudioSource theMusic;

    public BeatScroller theBS;
    public NoteHitsManager hitManager;    

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI multiplierText;
    public TextMeshProUGUI comboText;

    private bool canStart = false;
    private bool playingGame = false;

    private void Awake()
    {
        instance = this;

        scoreText.text = "Score: 0";
        multiplierText.text = "Multiplier x1";
        comboText.text = "Combo Hits: 0";
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canStart && !playingGame)
        {
            canStart = false;
            playingGame = true;
            theBS.hasStarted = true;

            theMusic.Play();
        }
    }

    public void StartGame()
    {
        canStart = true;
    }

    public void UpdatePauseMusic()
    {
        //This function will switch between the music being paused and played.
        if (theMusic.isPlaying)
        {
            theMusic.Pause();
        }
        else
        {
            theMusic.Play();
        }
    }

    public void UpdateUI()
    {
        scoreText.text = "Score: " + hitManager.CurrentScore;
        comboText.text = "Combo Hits: " + hitManager.ComboScore;
        multiplierText.text = "Multiplier x" + hitManager.CurrentMultiplier;
    }

}
