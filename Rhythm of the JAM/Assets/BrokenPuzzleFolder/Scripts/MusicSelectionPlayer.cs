using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSelectionPlayer : MonoBehaviour
{
    public AudioSource audioSource;
    //Get a list of all music
    List<MusicLibrary> songSelection;
    //Get which music panel is currently selected
    //Play the song of the currently selected item
    private int songIndex = 0;
    private bool playingSong;

    // Update is called once per frame
    void Update()
    {
        if(!playingSong)
        {
            audioSource.clip = songSelection[songIndex].audio;
            audioSource.time = audioSource.clip.length * 0.5f;
            audioSource.Play();
            playingSong = true;
        }
    }

    public void SetSongIndex(int index)
    {
        if (index == songIndex)
            return;
        songIndex = index;
        playingSong = false;
    }

    public void SetSongSelection(List<MusicLibrary> songArray)
    {
        songSelection = songArray;
        foreach(MusicLibrary song in songSelection)
        {
            Debug.Log(song.name);
        }        
    }
}
