using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

    public Text confirmText;
    public GameObject confirmPanel;
    public GameObject settingsPanel;
    public GameObject difficultPanel;
    private MusicController musicController;

    public ColorActivity colorActivity;
    public Toggle toggleMusic;
    public Toggle toggleSound;

    private void Start()
    {
        musicController = GetComponent<MusicController>();
        //PlayerPrefs.DeleteAll();
        if (PlayerPrefs.GetInt("Sound") == 1)
            toggleSound.isOn = false;

        if (PlayerPrefs.GetInt("Music") == 1)
            toggleMusic.isOn = false;    

        StartCoroutine(Music());

        if (PlayerPrefs.GetInt("SaveGame") == 0)
            colorActivity.GrayButton();
    }

    public void StartGame() {
        if (PlayerPrefs.GetInt("SaveGame") == 1)
        {
            SetPanelConfirm(true);
            confirmText.text = PlayerPrefs.GetInt("Days").ToString() + " Days";
        }
        else
        {
            difficultPanel.SetActive(true);
        }
    }

    public void LoadGame()
    {
        if(PlayerPrefs.GetInt("SaveGame") == 1)
        {
            ChangeScene(false);
        }
    }

    public void NewGame()
    {
        PlayerPrefs.SetInt("SaveGame", 1);
        ChangeScene(true);
    }

    public void SetPanelConfirm(bool Bool)
    {
        confirmPanel.SetActive(Bool);
    }

    public void SettingsMenu(bool name)
    {
        settingsPanel.SetActive(name);
    }

    public void ChangeScene(bool newGame )
    {
        if(newGame == true)
        {
            PlayerPrefs.SetInt("NewGame", 1);
            SceneManager.LoadScene("Introduction");
        }
        else
        {
            PlayerPrefs.SetInt("NewGame", 0);
            SceneManager.LoadScene("World");
        }
    }

    public void DifficultPanel(bool name)
    {
        difficultPanel.SetActive(name);
    }

    public void DifficultSelect(float difficult)
    {
        Debug.Log(difficult);
        PlayerPrefs.SetFloat("Difficult", difficult);
        NewGame();
    }

    IEnumerator Music()
    {
        yield return new WaitForSeconds(1f);
        musicController.SoundTheme("MenuTheme");        
    }
}
