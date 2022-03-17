using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public SongManager songManager;
    public ScoreManager scoreManager;
    public MenuController menuController;
    public LeaderboardController leaderboardController;
    [Space()]
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI multiplierText;
    public TextMeshProUGUI comboText;
    [Space()]
    public KeyCode pauseKey;

    private MusicLibrary currentMusic;

    private bool canStart = false;
    private bool playingGame = false;

    public bool IsPaused { get; set; } = false;

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
        //Game start conditions
        if (canStart && !playingGame)
        {
            canStart = false;
            playingGame = true;
            songManager.CanStart = true;
        }

        if (playingGame)
        {
            //Listen for pause button
            if (Input.GetKeyDown(pauseKey))
            {
                if (IsPaused)
                {
                    menuController.UnPauseGame();
                }
                else
                {
                    menuController.PauseGame();
                }                
            }
            //Check if the track has ended
            if (songManager.SongEnded)
            {
                Debug.Log("Song has ended");
                playingGame = false;
                songManager.SongEnded = false;
                menuController.GameEndScreen();
            }
        }
    }

    public void StartGame(MusicLibrary music)
    {
        currentMusic = music;
        songManager.SetAudioClip(currentMusic.audio);
        songManager.SetFileLocation(currentMusic.fileLocation);
        leaderboardController.SetLeaderboardID(currentMusic.leaderboardID);
        canStart = true;
        menuController.StartSongFromMusicLibrary();
    }

    public void ReturnMusicLibrary()
    {

    }

    public void UpdatePauseMusic(bool isPaused)
    {
        IsPaused = isPaused;
        //This function will switch between the music being paused and played.
        if (songManager.audioSource.isPlaying)
        {
            songManager.audioSource.Pause();
        }
        else
        {
            songManager.audioSource.Play();
        }
    }

}
