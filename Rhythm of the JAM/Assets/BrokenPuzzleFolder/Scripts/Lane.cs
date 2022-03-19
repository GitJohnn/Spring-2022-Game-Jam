using Melanchall.DryWetMidi.Interaction;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lane : MonoBehaviour
{
    public Melanchall.DryWetMidi.MusicTheory.NoteName noteRestriction;
    public KeyCode input;
    public GameObject notePrefab;
    List<Note> notes = new List<Note>();
    public List<double> timeStamps = new List<double>();

    int spawnIndex = 0;
    int inputIndex = 0;

    public void SetTimeStamps(Melanchall.DryWetMidi.Interaction.Note[] array)
    {
        foreach (var note in array)
        {
            if (note.NoteName == noteRestriction)
            {
                var metricTimeSpan = TimeConverter.ConvertTo<MetricTimeSpan>(note.Time, SongManager.midiFile.GetTempoMap());
                timeStamps.Add((double)metricTimeSpan.Minutes * 60f + metricTimeSpan.Seconds + (double)metricTimeSpan.Milliseconds / 1000f);
            }
        }
    }

    public void ClearTimeStamps()
    {
        timeStamps.Clear();
        notes.Clear();
        spawnIndex = 0;
        inputIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnIndex < timeStamps.Count)
        {
            if (SongManager.GetAudioSourceTime() >= timeStamps[spawnIndex] - SongManager.Instance.noteTime)
            {
                var note = Instantiate(notePrefab, transform);
                notes.Add(note.GetComponent<Note>());
                note.GetComponent<Note>().assignedTime = (float)timeStamps[spawnIndex];
                spawnIndex++;
            }
        }

        //if (inputIndex < timeStamps.Count)
        //{
        //    double timeStamp = timeStamps[inputIndex];
        //    double marginOfError = SongManager.Instance.marginOfError;
        //    double audioTime = SongManager.GetAudioSourceTime() - (SongManager.Instance.inputDelayInMilliseconds / 1000.0);

        //    if (Input.GetKeyDown(input))
        //    {
        //        //if (Math.Abs(audioTime - timeStamp) < marginOfError)
        //        //{
        //        //    //print($"Hit on {inputIndex} note");
        //        //    notes[inputIndex].DisableNote();
        //        //    inputIndex++;
        //        //}
        //        //else
        //        //{
        //        //    //print($"Hit inaccurate on {inputIndex} note with {Math.Abs(audioTime - timeStamp)} delay");
        //        //}
        //    }
        //    if (timeStamp + marginOfError <= audioTime)
        //    {
        //        //print($"Missed {inputIndex} note");
        //        inputIndex++;
        //    }
        //}

    }
}
