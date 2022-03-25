using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Song", menuName = "Song")]
public class MusicLibrary : ScriptableObject
{
    public string songName;//Name of the song used for the text in buttons
    public AudioClip audio;//The music clip
    public string fileLocation;//Location of the song's MIDI file. This should only include the name of the file inside StreamingAssets. Don't include streaming assets path.
    public int leaderboardID;//This number comes from Loot Locker leaderboard ID system. log int to get the respective song's leaderboard ID.
    public int endTimeInSeconds;//This variable is used by the song manager to know when it should enable the final score panel.

}
