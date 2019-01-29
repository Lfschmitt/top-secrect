using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

    public Text confirmText;
    public GameObject confirmPanel;
    public GameObject settingsPanel;

    private MusicController musicController;

    public Toggle toggleMusic;
    public Toggle toggleSound;

    private void Awake()
    {
        musicController = GetComponent<MusicController>();

        if (PlayerPrefs.GetInt("Sound") == 1)
            toggleSound.isOn = false;

        if (PlayerPrefs.GetInt("Music") == 1)
            toggleMusic.isOn = false;    

        StartCoroutine(Music());
    }

    public void StartGame() {
        if (PlayerPrefs.GetInt("SaveGame") == 1)
        {
            SetPanelConfirm(true);
            confirmText.text = PlayerPrefs.GetInt("Days").ToString() + " Days";
        }
        else
        {
            ChangeScene(true); ;
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
        }
        else
        {
            PlayerPrefs.SetInt("NewGame", 0);
        }
        SceneManager.LoadScene("World");
        SceneManager.UnloadSceneAsync("Menu");
    }

    IEnumerator Music()
    {
        yield return new WaitForSeconds(1f);
        musicController.SoundTheme("MenuTheme");        
    }
}
