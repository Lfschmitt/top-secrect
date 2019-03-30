using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour {

    public AudioManager audioManager;
    private bool oneTime = true;
    private bool music = true;
    private bool sound = true;

    private void Start()
    {
        if (PlayerPrefs.GetInt("Music") == 0)
            music = true;
        else
            music = false;

        if (PlayerPrefs.GetInt("Sound") == 0)
            sound = true;
        else
            sound = false;
    }

    public void SoundTheme(string name)
    {
        if(music)
            audioManager.PlaySound(name);
    }
    public void PauseSoundTheme(string name)
    {
        audioManager.PauseSound(name);
    }
    public void StopSoundTheme(string name)
    {
            audioManager.StopSound(name);
    }

	public void ClickSound()
    {
        if(sound)
            audioManager.PlaySound("Click");
    }
    public void CoinSound()
    {
        if(sound)
            audioManager.PlaySound("CoinDrop");
    }
    public void BeatSound()
    {
        if (sound)
            audioManager.PlaySound("DialogueBeat");
    }

    public void Win()
    {
        if (music)
        {
            if (oneTime)
            {
                audioManager.StopSound("TopSecretTheme");
                audioManager.PlaySound("WinTheme");
                oneTime = false;
            }
        }
    }
    public void Lose()
    {
        if (music)
        {
            if (oneTime)
            {
                audioManager.StopSound("TopSecretTheme");
                audioManager.PlaySound("LoseTheme");
                oneTime = false;
            }
        }
    }

    public void ReturnTheme()
    {
        if (music)
        {
            audioManager.StopSound("WinTheme");
            audioManager.StopSound("LoseTheme");
            audioManager.PlaySound("TopSecretTheme");
            oneTime = true;
        }
    }
    public void StopAllTheme()
    {
        audioManager.StopSound("MenuManager");
        audioManager.StopSound("TopSecretTheme");
    }

    public void ActiveMusic()
    {
        music = !music;
        if (music)
        {
            PlayerPrefs.SetInt("Music", 0);
            SoundTheme("MenuTheme");
        }
        else
        {
            PauseSoundTheme("MenuTheme");
            PlayerPrefs.SetInt("Music", 1);
        }
    }

    public void ActiveSound()
    {
        sound = !sound;
        if (sound)
            PlayerPrefs.SetInt("Sound", 0);
        else
            PlayerPrefs.SetInt("Sound", 1);
    }
}
