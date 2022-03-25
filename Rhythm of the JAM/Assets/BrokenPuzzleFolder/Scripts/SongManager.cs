using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Melanchall.DryWetMidi.Core;
using Melanchall.DryWetMidi.Interaction;
using System.IO;
using UnityEngine.Networking;
using System;

public class SongManager : MonoBehaviour
{
    public static SongManager Instance;
    public AudioSource audioSource;
    public Lane[] lanes;
    public float songDelayInSeconds;
    public double marginOfError; // in seconds

    public int inputDelayInMilliseconds;

    //public bool startingSong { get; set; }
    public bool inProgress { get; set; }
    public bool SongEnded { get; set; }
    private bool songStarted = false;
    public string fileLocation { get; set; }
    public float noteTime;
    public float noteSpawnY;
    public float noteTapY;
    public float noteDespawnY
    {
        get
        {
            return noteTapY - (noteSpawnY - noteTapY);
        }
    }

    public static MidiFile midiFile;
    private AudioClip currentAudioClip;
    private float endSongTime;
    private float currentSongTime = 0;
    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        //Once game is in progress lets wait for the music to stop playing
        if (inProgress && !GameManager.instance.IsPaused)
        {
            //(songStarted && IsDone()) || 
            if (currentSongTime >= endSongTime)
            {
                SongEnded = true;
                songStarted = false;
                inProgress = false;
                currentSongTime = 0;
            }
            currentSongTime += Time.deltaTime;
        }

        //Wait for Game manager to tell us to start the game
        //if (!audioSource.isPlaying && inProgress && !GameManager.instance.IsPaused)
        //{
        //    audioSource.time = 0;
        //    audioSource.clip = currentAudioClip;
        //    audioSource.Play();
        //}
    }

    public void GetFileData()
    {
        if (Application.streamingAssetsPath.StartsWith("http://") || Application.streamingAssetsPath.StartsWith("https://"))
        {
            StartCoroutine(ReadFromWebsite());
        }
        else
        {
            ReadFromFile();
        }
    }

    private IEnumerator ReadFromWebsite()
    {
        using (UnityWebRequest www = UnityWebRequest.Get(Application.streamingAssetsPath + "/" + fileLocation))
        {
            yield return www.SendWebRequest();

            if (www.result.Equals(UnityWebRequest.Result.ConnectionError) || www.result.Equals(UnityWebRequest.Result.ProtocolError))
            {
                Debug.LogError(www.error);
            }
            else
            {
                byte[] results = www.downloadHandler.data;
                using (var stream = new MemoryStream(results))
                {
                    midiFile = MidiFile.Read(stream);
                    GetDataFromMidi();
                }
            }
        }
    }

    private void ReadFromFile()
    {
        midiFile = MidiFile.Read(Application.streamingAssetsPath + "/" + fileLocation);
        GetDataFromMidi();
    }

    public void GetDataFromMidi()
    {
        var notes = midiFile.GetNotes();
        var array = new Melanchall.DryWetMidi.Interaction.Note[notes.Count];
        notes.CopyTo(array, 0);

        foreach (var lane in lanes) lane.SetTimeStamps(array);
        Invoke(nameof(StartSong), songDelayInSeconds);
    }

    public void StartSong()
    {                        
        inProgress = true;
        songStarted = true;
        audioSource.clip = currentAudioClip;
        audioSource.time = 0;
        audioSource.Play();
    }

    public void ExitSong()
    {
        foreach (var lane in lanes) lane.ClearTimeStamps();
        SongEnded = false;
        inProgress = false;
    }

    public void SetAudioClip(AudioClip clip)
    {
        currentAudioClip = clip;
    }

    public void SetFileLocation(string location)
    {
        fileLocation = location;
    }

    public void SetSongTime(float endTime)
    {
        endSongTime = endTime;
    }

    public double GetAudioSourceTime()
    {
        return (double)audioSource.time;//Instance.audioSource.timeSamples / Instance.audioSource.clip.frequency;
    }

    private bool IsDone()
    {
        return !audioSource.loop && (audioSource.time >= currentAudioClip.length);
    }
}