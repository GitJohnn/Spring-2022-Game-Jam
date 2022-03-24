using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSelectionPlayer : MonoBehaviour
{
    public AudioSource audioSource;
    public SetVolume volumeSet;
    //public AudioSource audioSource2;
    //Get a list of all music
    List<MusicLibrary> songSelection;
    //Get which music panel is currently selected
    //Play the song of the currently selected item
    private int songIndex = 0;
    private bool playingSong;
    private bool firstMusicSourceIsPlaying;

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.instance.PlayingGame)
        {
            if (!playingSong)
            {
                PlayMusicWithFade(songSelection[songIndex].audio, 1.5f);
                playingSong = true;
            }
        }
        else
        {
            audioSource.Stop();
        }
    }

    public void PlayMusic(AudioClip musicClip)
    {
        AudioSource activeSource = audioSource;//(firstMusicSourceIsPlaying) ? audioSource : audioSource2;

        activeSource.clip = musicClip;
        activeSource.time = activeSource.clip.length * 0.5f;
        activeSource.Play();
    }

    public void PlayMusicWithFade(AudioClip newClip, float transitionTime = 1.0f)
    {
        AudioSource activeSource = audioSource;//(firstMusicSourceIsPlaying) ? audioSource : audioSource2;

        StartCoroutine(UpdateMusicWithFade(activeSource, newClip, transitionTime));

    }

    private IEnumerator UpdateMusicWithFade(AudioSource activeSource, AudioClip newClip, float transitionTime)
    {
        // Make sure the source is active and playing
        if (!activeSource.isPlaying)
            activeSource.Play();

        float t = 0.0f;

        //Fade out
        for(t = 0; t < transitionTime; t+= Time.deltaTime)
        {
            activeSource.volume = (volumeSet.GetVolume() - (t / transitionTime));
            yield return null;
        }

        activeSource.Stop();        
        activeSource.clip = newClip;
        activeSource.time = activeSource.clip.length * 0.5f;
        activeSource.Play();

        //Fade IN
        for (t = 0; t < transitionTime; t += Time.deltaTime)
        {
            activeSource.volume = (t / transitionTime);
            yield return null;
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
    }
}
