using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SongSelected : MonoBehaviour
{
    public MusicLibrary MusicObject;
    public TextMeshProUGUI textObj;

    private Button button;
    private Navigation buttonNav;
    private void Awake()
    {
        textObj.text = MusicObject.songName;
        button = GetComponent<Button>();
        button.onClick.AddListener(StartSong);
        buttonNav = button.navigation;
        buttonNav.mode = Navigation.Mode.Vertical;
        button.navigation = buttonNav;
    }

    public void StartSong()
    {
        GameManager.instance.StartGame(MusicObject);
    }
}
