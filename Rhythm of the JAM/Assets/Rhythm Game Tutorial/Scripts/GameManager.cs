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
    public KeyCode pauseKey;

    private MusicLibrary currentMusic;

    public bool PlayingGame { get; set; } = false;
    public bool IsPaused { get; set; } = false;

    private void Awake()
    {
        instance = this;       
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayingGame)
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
                PlayingGame = false;
                songManager.SongEnded = false;
                menuController.GameEndScreen();                
            }
        }
    }

    public void StartGame(MusicLibrary music)
    {
        menuController.StartSongFromMusicLibrary();
        currentMusic = music;
        songManager.SetAudioClip(currentMusic.audio);
        songManager.SetFileLocation(currentMusic.fileLocation);
        leaderboardController.SetLeaderboardID(currentMusic.leaderboardID);                
        PlayingGame = true;
        songManager.GetFileData();
        Debug.Log("Start Game");
    }

    public void ReturnMusicLibrary()
    {
        PlayingGame = false;
        songManager.audioSource.Stop();
        Debug.Log("Stoping music");
        //menuController.UnPauseGame();
        //menuController.OpenMusicSelection();
        menuController.ReturnMusicSelect();
        songManager.ExitSong();
        scoreManager.ResetScores();
        UpdatePauseMusic(false, false);
    }

    public void UpdatePauseMusic(bool isPaused, bool playSong)
    {
        IsPaused = isPaused;
        //This function will switch between the music being paused and played.
        if (songManager.audioSource.isPlaying)
        {
            Time.timeScale = 0;
            songManager.audioSource.Pause();
        }
        else
        {
            Time.timeScale = 1;
            if(playSong)
                songManager.audioSource.Play();
        }
    }

}
