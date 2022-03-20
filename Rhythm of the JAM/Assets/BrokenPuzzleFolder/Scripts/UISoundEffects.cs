using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISoundEffects : MonoBehaviour
{
    public AudioClip selectClip;
    public AudioClip changeSelectClip;

    private AudioSource sfxSource;

    // Start is called before the first frame update
    void Start()
    {
        sfxSource = GetComponent<AudioSource>();
        sfxSource.loop = false;
    }

    public void PlaySelectClip()
    {
        sfxSource.clip = selectClip;
        sfxSource.Play();
    }

    public void PlayChangeSelectClip()
    {
        sfxSource.clip = changeSelectClip;
        sfxSource.Play();
    }

}
