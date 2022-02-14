using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{    
    public Image soundOn;
    public Image soundOff;
    public Image musicOn;
    public Image musicOff;

    public AudioSource shoot;
    public AudioSource bomb;
    public AudioSource music;

    private bool muted = false;
    private bool musmuted = false;

    private void Start()
    {
        if (!PlayerPrefs.HasKey("muted"))
        {
            PlayerPrefs.SetInt("muted", 0);
            Load();
        }
        else
        {
            Load();
        }
        
        if(!PlayerPrefs.HasKey("musmuted"))
        {
            PlayerPrefs.SetInt("musmuted", 0);
            Loadmu();
        }
        else
        {
            Loadmu();
        }
        UpdateButton();
        shoot.mute = muted;
        MusicButton();
        music.mute = musmuted;
        bomb.mute = musmuted;
    }

    public void OnButtonPress()
    {
        if (muted == false)
        {
            muted = true;
            shoot.mute = true;
        }
        else
        {
            muted = false;
            shoot.mute = false;
        }

        Save();
        UpdateButton();
    }

    public void OnButtonMusic()
    {
        if (musmuted == false)
        {
            musmuted = true;
            music.mute = musmuted;
            bomb.mute = musmuted;
        }
        else
        {
            musmuted = false;
            music.mute = musmuted;
            bomb.mute = musmuted;
        }

        Savemu();
        MusicButton();
    }

    private void UpdateButton()
    {
        if (muted == false)
        {
            soundOn.enabled = true;
            soundOff.enabled = false;

        }
        else
        {
            soundOn.enabled = false;
            soundOff.enabled = true;
        }
        Save();
    }

    private void MusicButton()
    {
        if (musmuted == false)
        {
            musicOn.enabled = true;
            musicOff.enabled = false;

        }
        else
        {
            musicOn.enabled = false;
            musicOff.enabled = true;
        }
        Savemu();
    }

    private void Loadmu()
    {
        musmuted = PlayerPrefs.GetInt("musmuted") == 1;
    }

    private void Savemu()
    {
        PlayerPrefs.SetInt("musmuted", musmuted ? 1 : 0);
    }

    private void Load()
    {
        muted = PlayerPrefs.GetInt("muted") == 1;
    }

    private void Save()
    {
        PlayerPrefs.SetInt("muted", muted ? 1 : 0);
    }
}
