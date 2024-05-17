using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeJeu : MonoBehaviour
{

    public Slider Music;
    

    void Start()
    {
        if (!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 1);
            Load();
        }
        else { Load(); }
    }

    public void ChangeVolume()
    {
        AudioListener.volume = Music.value;
        Save();
    }

    private void Load()
    {
        Music.value = PlayerPrefs.GetFloat("musicVolume");
    }

    private void Save()
    {
        PlayerPrefs.SetFloat("musicVolume", Music.value);
    }
}
