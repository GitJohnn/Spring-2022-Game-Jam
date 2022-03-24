using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SongSelected : MonoBehaviour
{
    public MusicLibrary MusicObject;
    public TextMeshProUGUI textObj;
    private MusicSelectionPlayer musicPlayer;

    private Button button;
    private Navigation buttonNav;
    private void Awake()
    {
        musicPlayer = transform.parent.parent.GetComponent<MusicSelectionPlayer>();
        textObj.text = MusicObject.songName;
        button = GetComponent<Button>();
        button.onClick.AddListener(StartSong);
        button.onClick.AddListener(musicPlayer.StopMusicSelectionMusic);
        //buttonNav = button.navigation;
        //buttonNav.mode = Navigation.Mode.Vertical;
        //button.navigation = buttonNav;
    }

    public void StartSong()
    {
        GameManager.instance.StartGame(MusicObject);
    }

    private void OnDestroy()
    {
        button.onClick.RemoveListener(StartSong);
    }
}
