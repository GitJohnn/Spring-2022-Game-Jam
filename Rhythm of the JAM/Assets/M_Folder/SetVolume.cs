using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SetVolume : MonoBehaviour
{
    public AudioMixer mixer;

    public Slider[] sliders;

    private void Start()
    {
        SetLevel(1f);
    }

    public void SetLevel(float sliderValue)
    {
        mixer.SetFloat("MusicVol", Mathf.Log10(sliderValue) * 20);
        foreach(Slider slider in sliders)
        {
            slider.value = sliderValue;
        }
    }

    public float GetVolume()
    {
        float volume;
        mixer.GetFloat("MusicVol", out volume);
        return volume;
    }
}