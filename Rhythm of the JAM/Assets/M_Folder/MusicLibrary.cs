using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Song", menuName = "Song")]
public class MusicLibrary : ScriptableObject
{
    public string songName;
    public AudioClip audio;
    public string fileLocation;
    public int leaderboardID;

}
